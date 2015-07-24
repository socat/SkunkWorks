namespace HelperLibrary.Console.Shell
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #region Enumerations

    public enum LineFeed
    {
        Top = 0,
        Bottom = 1
    }

    #endregion Enumerations

    /// <summary>
    /// Manages a simple progress dialog for console applications
    /// </summary>
    public class ConsoleProgress
    {
        #region Fields

        public static readonly object locker = new object();

        /// <summary>
        /// Start position of the cursor from the left-hand side of the screen.
        /// </summary>
        public static int XStart = 1;

        /// <summary>
        /// Line position of the progress bar from the top of the console window.
        /// </summary>
        internal static int ProgressbarLineNumber = 1;

        private static int currentTick = 0;
        private static int progressTotal = 0;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ConsoleProgress class and clears the console.
        /// </summary>
        public ConsoleProgress()
        {
            // Console.Clear();
        }

        #endregion Constructors

        #region Properties

        public static int CurrentTick
        {
            get
            {
                return currentTick;
            }
            set
            {
                currentTick = value;
            }
        }

        public static int ProgressTotal
        {
            get
            {
                return progressTotal;
            }
            set
            {
                progressTotal = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the cursor position below the dialog
        /// </summary>
        public static void Completed()
        {
            lock (locker)
            {
                System.Console.SetCursorPosition(XStart, System.Console.CursorTop + 1);
                string clearLine = string.Empty;
                clearLine = clearLine.PadRight(System.Console.BufferWidth, ' ');
                System.Console.Write(clearLine);
            }
        }

        public static void ProgressStep()
        {
            CurrentTick = CurrentTick + 1;
            SetProgressBar(CurrentTick, ProgressTotal);
        }

        public static void SetMessage(int line, string formatString, params object[] args)
        {
            lock (locker)
            {
                System.Console.SetCursorPosition(XStart, line);
                string message = (args.Count() > 0)
                    ? string.Format(formatString, args)
                    : formatString;

                message = message.PadRight(200, ' ');
                System.Console.Write(message);
            }
            Completed();
        }

        /// <summary>
        /// Draw a progress bar at the current cursor position.
        /// </summary>
        /// <param name="progress">The position of the bar</param>
        /// <param name="total">The amount it counts</param>
        /// <remarks>Be careful not to Console.WriteLine or anything whilst using this to show progress!
        /// from: www.nullify.net/Article/269.aspx
        /// </remarks>
        public static void SetProgressBar(int progress, int total)
        {
            CurrentTick = progress;
            ProgressTotal = total;

            var normalback = System.Console.BackgroundColor;
            var normalfore = System.Console.ForegroundColor;

            Action<ConsoleColor, ConsoleColor> setcolor = (ConsoleColor fore, ConsoleColor back) =>
            {
                System.Console.BackgroundColor = back;
                System.Console.ForegroundColor = fore;
            };
            Action highlight = () => { setcolor(ConsoleColor.Black,  ConsoleColor.Gray); };

            Action normalcolor = () => { setcolor(normalfore, normalback);};

            lock (locker)
            {
                //draw empty progress bar
                System.Console.SetCursorPosition(XStart, ProgressbarLineNumber);

                System.Console.Write("["); //start
                System.Console.CursorLeft = XStart + 31;
                System.Console.Write("]"); //end
                System.Console.CursorLeft = XStart + 1;
                float onechunk = 30.0f / ProgressTotal;

                //draw filled part
                int position = XStart + 1;
                int fillcount = Convert.ToInt32(onechunk * currentTick);

                string fill = string.Empty.PadRight(fillcount, '>');
                string empty = string.Empty.PadRight((XStart + 29) - fillcount, '.');

                highlight();
                System.Console.Write(fill);

                normalcolor();
                System.Console.Write(empty);

                System.Console.CursorLeft = XStart + 35;
                string progressMessage = string.Format("{0} of {1}", CurrentTick, ProgressTotal);

                System.Console.BackgroundColor = ConsoleColor.Black;
                System.Console.Write(progressMessage);
            }
            Completed();
        }

        #endregion Methods
    }

    public class ConsoleSettings
    {
        #region Fields

        public int BufferHeight;
        public int BufferWidth;
        public int Height;
        public string Title;
        public int Width;

        #endregion Fields

        #region Methods

        public static ConsoleSettings Create(int height, int width, int bufferheight, int bufferwidth, string title)
        {
            return new ConsoleSettings()
            {
                Height = height,
                Width = width,
                BufferHeight = bufferheight,
                BufferWidth = bufferwidth,
                Title = title
            };
        }

        public static ConsoleSettings SnapShot()
        {
            return ConsoleSettings.Create(System.Console.WindowHeight, System.Console.WindowWidth, System.Console.BufferHeight, System.Console.BufferWidth, System.Console.Title);
        }

        public void Apply()
        {
            // returns max if out of bounds, otherwise value
            Func<int, int, int, int> safemax = (int value, int min, int max) =>
            {
                return (value >= min && value <= max) ? value : max;
            };

            // returns min if out of bounds, otherwise value
            Func<int, int, int, int> safemin = (int value, int min, int max) =>
            {
                return (value >= min && value <= max) ? value : min;
            };

            System.Console.WindowHeight = safemax(this.Height, 0, System.Console.LargestWindowHeight);
            System.Console.WindowWidth = safemax(this.Width, 0, System.Console.LargestWindowWidth);
            System.Console.BufferHeight = safemin(this.BufferHeight, (System.Console.WindowHeight + System.Console.WindowTop), System.Console.LargestWindowHeight * 10);
            System.Console.BufferWidth = safemin(this.BufferWidth, (System.Console.WindowWidth + System.Console.WindowWidth), System.Console.LargestWindowHeight * 10);
            System.Console.Title = this.Title;
        }

        public override string ToString()
        {
            return string.Format("Height:{0}; Width:{1}; BufferHeight:{2}; BufferWidth:{3}; Title:{4};",
                this.Height, this.Width, this.BufferHeight, this.BufferWidth, this.Title);
        }

        #endregion Methods
    }

    public class ConsoleWindowProperties : ConsoleSettings
    {
        #region Fields

        // private int currentXPos = 0; // left
        private int currentYPos = 0; // top

        #endregion Fields

        #region Constructors

        public ConsoleWindowProperties()
        {
        }

        #endregion Constructors

        #region Methods

        public static ConsoleWindowProperties Snapshot()
        {
            return new ConsoleWindowProperties()
            {
                Height = System.Console.WindowHeight,
                Width = System.Console.WindowWidth,
                BufferHeight = System.Console.BufferHeight,
                BufferWidth = System.Console.BufferWidth,
                Title = System.Console.Title
            };
        }

        public void AddLine(string line, params object[] args)
        {
            System.Console.SetCursorPosition(0, currentYPos);

            string message = string.Format(line, args);

            if (message.Length > Width + BufferWidth)
            {
                message = message.Substring(0, Width + BufferWidth);
            }

            System.Console.Write(message);

            if (currentYPos >= Height - 1)
            {
                System.Console.MoveBufferArea(0, 1, Width, Height - 1, 0, 0);
            }

            if (currentYPos+1 < Height)
            {
                currentYPos++;
            }
        }

        public void Clear()
        {
            System.Console.Clear();
            // currentXPos = 0;
            currentYPos = 0;
        }

        public void NoBuffer()
        {
            System.Console.BufferHeight = Height;
            System.Console.BufferWidth = Width;
        }

        #endregion Methods
    }

    public class ScrollGui
    {
        #region Fields

        public LineFeed feed = LineFeed.Bottom;
        public ConsoleSettings Settings;

        private int currentXPos = 0; // left
        private int currentYPos = 0; // top

        #endregion Fields

        #region Constructors

        public ScrollGui()
        {
            Settings = ConsoleSettings.SnapShot();
        }

        #endregion Constructors

        #region Methods

        public static ScrollGui Snapshot()
        {
            return new ScrollGui()
            {
                Settings = ConsoleSettings.SnapShot()
            };
        }

        public void AddLine(string line, params object[] args)
        {
            Action<int, int> SetPos = (int x, int y) =>
            {
                System.Console.SetCursorPosition(x, y);
            };

            Action LineFeedBottom = () =>
            {
                System.Console.MoveBufferArea(0, 1, this.Settings.Width, this.Settings.Height - 1, 0, 0);
            };

            Action LineFeedTop = () =>
            {
                System.Console.MoveBufferArea(0, 0, this.Settings.Width, this.Settings.Height - 1, 0, 1);
            };

            // linefeedtop
            if (feed == LineFeed.Top)
            {
                LineFeedTop();
                currentYPos = 0;
            }

            SetPos(0, currentYPos);

            string message = string.Format(line, args);

            if (message.Length > this.Settings.Width + this.Settings.BufferWidth)
            {
                message = message.Substring(0, this.Settings.Width + this.Settings.BufferWidth);
            }

            System.Console.Write(message);
            // linefeedbottom
            if (feed == LineFeed.Bottom)
            {
                if (currentYPos >= this.Settings.Height - 1)
                {
                    LineFeedBottom();
                }

                if (currentYPos + 1 < this.Settings.Height)
                {
                    currentYPos++;
                }
            }
        }

        public void NoBuffer()
        {
            System.Console.BufferHeight = this.Settings.Height;
            System.Console.BufferWidth = this.Settings.Width;
        }

        public void Reset()
        {
            System.Console.Clear();
            currentXPos = 0;
            currentYPos = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ConsoleWindowProperties");
            sb.AppendLine("{ ");
            sb.AppendFormat(" ", Settings.ToString());
            sb.AppendFormat(" currentXPos: {0}; currentYPos: {1}", this.currentXPos, this.currentYPos);
            sb.AppendLine("}");
            sb.AppendLine(" Console: ");
            sb.Append(" { ");
            sb.AppendFormat(" Height:{0}; Width:{1}; BufferHeight:{2}; BufferWidth:{3}; Title:{4}; {5}",
                System.Console.WindowHeight, System.Console.WindowWidth, System.Console.BufferHeight, System.Console.BufferWidth, System.Console.Title, Environment.NewLine);
            sb.AppendLine(" }");
            sb.AppendLine("}");
            return sb.ToString();
        }

        #endregion Methods
    }
}