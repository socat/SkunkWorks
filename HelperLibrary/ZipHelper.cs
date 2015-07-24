//----------------------------------------------------------------
// <copyright file="ZipHelper.cs" company="Nick Carlson">
//     Copyright (c) Nick Carlson.  All rights reserved.
// </copyright>
//----------------------------------------------------------------
namespace HelperLibrary
{
    using System;
    using System.IO;

    using Ionic.Zip;

    /// <summary>
    /// ZipHelper Class
    /// </summary>
    public class ZipHelper
    {
        #region Methods

        /// <summary>
        /// Create a Zip File
        /// </summary>
        /// <param name="location">
        /// Full File Folder Name
        /// </param>
        /// <param name="name">
        /// Archive File Name
        /// </param>
        /// <param name="password">
        /// Archive Password
        /// </param>
        /// <param name="size">
        /// Size of Data Buffer to Compress
        /// </param>
        /// <param name="compressionRatio">
        /// Desired (Approximate) Compression Ratio
        /// </param>
        public static void CreateZip(string location, string name, string password, int size, decimal compressionRatio)
        {
            using (ZipFile zip = new ZipFile(location + name))
            {
                zip.Password = password;
                zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                string tempFileName = (new Guid()).ToString();
                GenerateFile(tempFileName, (long) (size*(1 - compressionRatio)), (long) size);
                zip.AddFile(tempFileName);
                zip.Save();
            }
        }

        /// <summary>
        /// Create Compressed File From Uncompressed Buffer
        /// </summary>
        /// <param name="fileName">
        /// Destination Filename
        /// </param>
        /// <param name="compressedSize">
        /// Size After Compression
        /// </param>
        /// <param name="uncompressedSize">
        /// Size Before Compression
        /// </param>
        private static void GenerateFile(string fileName, long compressedSize, long uncompressedSize)
        {
            // create blank buffer
            byte[] blankBuffer = new byte[1024 * 1024];
            for (int i = 0; i < blankBuffer.Length; i++)
            {
                blankBuffer[i] = 0;
            }

            Random numrnd = new Random();
            long bytesRemaining = compressedSize;
            long compressedBytes = uncompressedSize - compressedSize;
            byte[] buffer = new byte[1024 * 1024];
            using (Stream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                // write compressed portion
                while (bytesRemaining > 0)
                {
                    int sizeOfChunkToWrite;
                    if (bytesRemaining > buffer.Length)
                    {
                        sizeOfChunkToWrite = buffer.Length;
                    }
                    else
                    {
                        sizeOfChunkToWrite = (int)bytesRemaining;
                    }

                    numrnd.NextBytes(buffer);
                    fileStream.Write(buffer, 0, sizeOfChunkToWrite);
                    bytesRemaining -= sizeOfChunkToWrite;
                }

                // write uncompressed portion
                while (compressedBytes > 0)
                {
                    int sizeOfChunkToWrite;
                    if (compressedBytes > buffer.Length)
                    {
                        sizeOfChunkToWrite = buffer.Length;
                    }
                    else
                    {
                        sizeOfChunkToWrite = (int)compressedBytes;
                    }

                    fileStream.Write(blankBuffer, 0, sizeOfChunkToWrite);
                    compressedBytes -= sizeOfChunkToWrite;
                }
            }
        }

        #endregion Methods
    }
}