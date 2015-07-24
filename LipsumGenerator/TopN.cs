using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Test
{
	
    /// <summary>
    /// Collection that maintains the top n values
    /// </summary>
    /// <typeparam name="TValue">Type of values to store.</typeparam>
    /// <typeparam name="TWeight">Weight of the values.</typeparam>
    public class TopNCollection<TValue, TWeight> : IEnumerable<KeyValuePair<TValue, TWeight>>
        where TWeight: IComparable<TWeight>
    {
        internal TValue[] m_values;
        internal TWeight[] m_weights;

        internal int m_count;

        internal TWeight m_lowestWeightInCollection;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="topCount"></param>
        public TopNCollection(int topCount)
        {
            Contract.Requires(topCount > 0, "Argument topCount must be greater than zero");

            m_values = new TValue[topCount];
            m_weights = new TWeight[topCount];
            m_lowestWeightInCollection = default(TWeight);
        }

        /// <summary>
        /// Adds a value to the top n values. If there are more than n values, it will replace the lowest one.
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="weight">Weight of value</param>
        public void Add(TValue value, TWeight weight)
        {


	        if (m_count < m_values.Length)
            {
                // Default cause, we don't have n values yet.
                m_values[m_count] = value;
                m_weights[m_count] = weight;
                
                // Update lowest weight. If none set, use the first, else compare.
                if (m_count == 0)
                {
                    m_lowestWeightInCollection = weight;
                }
                else if (weight.CompareTo(m_lowestWeightInCollection) < 0)
                {
                    m_lowestWeightInCollection = weight;
                }

                m_count++;
            }
            else if (weight.CompareTo(m_lowestWeightInCollection) > 0)
            {
                // We already have n top values. Check if this one is larger than the lowest.

                // Now we need to replace the lowest one. Presumption is that n is not that large, so we will do linear search.
                // we can optimize later to sorted list.
                bool replacedItem = false;
				// not needed
                //var newLowestValue = weight;
                for (int i = 0; i < m_values.Length; i++)
                {
                    var itemWeight = m_weights[i];

					/* BUG: We're at capacity, if a new lower weight is detected this would incorrectly set the lowest weight to the previous value.
					if (itemWeight.CompareTo(newLowestValue) < 0)
					{
						// set the lowest value
						newLowestValue = itemWeight;
					}
					*/

					if (!replacedItem && itemWeight.CompareTo(m_lowestWeightInCollection) == 0)
                    {
                        // Replace the previous lowest one with the new one.
                        m_weights[i] = weight;
                        m_values[i] = value;

                        // we have to keep track of only replacing one item, it could be that there are now multiple values with the lowest weight.
                        replacedItem = true;
                    }
                }
				/* Using weight instead of newLowestValue */
                m_lowestWeightInCollection = weight;
            }
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        public IEnumerator<KeyValuePair<TValue, TWeight>> GetEnumerator()
        {
            for (int i = 0; i < m_count; i++)
            {
                yield return new KeyValuePair<TValue, TWeight>(m_values[i], m_weights[i]);
            }
        }

        /// <summary>
        /// Gets the values in an ordered list
        /// </summary>
        public IEnumerable<TValue> GetOrderedValues()
        {
            return ((IEnumerable<KeyValuePair<TValue, TWeight>>)this).OrderByDescending(kv => kv.Value).Select(kv => kv.Key);
        }
            
        /// <summary>
        /// Gets the enumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
