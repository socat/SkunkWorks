using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using LipsumGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;

namespace TopNTests
{
	[TestClass]
	public class TopNCollectionUnitTests
	{
		[TestMethod]
		public void TopNConstructorValuesDefaultArraySize()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);

			Assert.IsTrue(size == topN.m_values.Length, string.Format("Array is the correct size.", size));
		}

		[TestMethod]
		public void TopNConstructorWeightsDefaultArraySize()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);

			Assert.IsTrue(size == topN.m_weights.Length, string.Format("Array is the correct size.", size));
		}

		[TestMethod]
		public void TopNConstructorLowestWeightDefaultValue()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);
			Assert.IsTrue(default(int) == topN.m_lowestWeightInCollection, "Lowest value should be the default value of the weight type.");
		}

		[TestMethod]
		public void TopNConstructorCountDefaultValue()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);
			Assert.IsTrue(default(int) == topN.m_count, "Lowest value should be the default value of the weight type.");
		}
		
		[TestMethod]
		public void AddStoresWeights()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);
			topN.Add("lorem", 1);
			topN.Add("ipsum", 100);

			Assert.AreEqual(1, topN.m_weights[0]);
			Assert.AreEqual(100, topN.m_weights[1]);
		}

		[TestMethod]
		public void AddIncrementsMaxCount()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);
			topN.Add("One", 1);
			Assert.IsTrue(1 == topN.m_count, "First item added should increment the count to one.");
		}

		[TestMethod]
		public void AddIncrementDoesNotExceedTopSize()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);
			topN.Add("One", 1);
			topN.Add("Two", 2);
			topN.Add("Three", 3);
			topN.Add("Four", 4);
			topN.Add("Five", 5);

			Assert.AreEqual(size, topN.m_count, string.Format("Added five members, count should be {0}.", size));
			Assert.AreEqual(size, topN.m_values.Count());
		}

		[TestMethod]
		public void AddFirstMemberCorrectlySetsLowestWeight()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);
			topN.Add("fifty", 50);

			Assert.AreEqual(50, topN.m_lowestWeightInCollection);
		}

		[TestMethod]
		public void AddLowerWeightCorrectlySetsLowerWeightWhenNotFull()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);
			topN.Add("fifty", 50);
			topN.Add("forty", 40);

			Assert.AreEqual(40, topN.m_lowestWeightInCollection);
		}

		[TestMethod]
		public void AddWillNotAddLighterValuesWhenFull()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);

			topN.Add("Two", 2);
			topN.Add("Two", 2);
			topN.Add("Two", 2); // Max size

			topN.Add("One", 1); // should not appear in collection

			Assert.AreEqual(0, topN.m_weights.Where(p => p == 1).Count());
			Assert.AreEqual(size, topN.m_count, string.Format("Added five members, count should be {0}.", size));
			Assert.AreEqual(size, topN.m_values.Count());
		}

		[TestMethod]
		[Description("Tests the section that tracks the lowest weight.  When the capacity reaches 100%, add a new value to replace the current lowest value.  2,000 -> 200 -> 2, then 20.  Should result in a collection with 2000, 200, and 20 where 20 is the lowest weight.")]
		public void AddLowerWeightCorrectlySetsLowerWeightWhenFull()
		{
			var size = 3;
			var topN = new TopNCollection<string, int>(size);

			topN.Add("TwoThousand", 2000);
			Assert.AreEqual(2000, topN.m_lowestWeightInCollection);

			topN.Add("TwoHundred", 200);
			Assert.AreEqual(200, topN.m_lowestWeightInCollection);

			topN.Add("Two", 2); // Max size
			Assert.AreEqual(2, topN.m_lowestWeightInCollection);

			topN.Add("Twenty", 20); // Should replace #2

			Assert.AreEqual(0, topN.m_weights.Where(p => p == 2).Count());
			Assert.AreEqual(1, topN.m_weights.Where(p => p == 20).Count());
			Assert.AreEqual(1, topN.m_weights.Where(p => p == 200).Count());
			Assert.AreEqual(1, topN.m_weights.Where(p => p == 2000).Count());

			Assert.AreEqual( 20, topN.m_lowestWeightInCollection );

		}

		[TestMethod]
		public void GetEnumeratorReturnsKvps()
		{
			var topN = new TopNCollection<string, int>(1);
			topN.Add("One", 1);
			topN.Add("Two", 2);

			KeyValuePair<string, int> previousValue = new KeyValuePair<string, int>();

			foreach (KeyValuePair<string, int> value in (IEnumerable)topN)
			{
				Assert.IsNull(previousValue.Key, "Expect to see not more than one value");
				previousValue = value;
			}

			Assert.AreEqual("Two", previousValue.Key, "Expect to see at least one value");
		}
	}

	[TestClass]
	public class TopNCollectionFunctionalTests
	{
		[TestMethod]
		[TestCategory("Unit Test")]
		public void Empty()
		{
			var topN = new TopNCollection<string, int>(2);
			Assert.AreEqual("", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void One()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("One", 1);
			Assert.AreEqual("One", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void OneTwo()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("One", 1);
			topN.Add("Two", 2);
			Assert.AreEqual("Two, One", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void TwoOne()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("Two", 2);
			topN.Add("One", 1);
			Assert.AreEqual("Two, One", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void OneTwoThree()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("One", 1);
			topN.Add("Two", 2);
			topN.Add("Three", 3);
			Assert.AreEqual("Three, Two", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void ThreeTwoOne()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("Three", 3);
			topN.Add("Two", 2);
			topN.Add("One", 1);
			Assert.AreEqual("Three, Two", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void OneThreeTwo()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("One", 1);
			topN.Add("Three", 3);
			topN.Add("Two", 2);
			Assert.AreEqual("Three, Two", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void ThreeOneTwo()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("Three", 3);
			topN.Add("One", 1);
			topN.Add("Two", 2);
			Assert.AreEqual("Three, Two", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void OneTwoThreeTwee()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("One", 1);
			topN.Add("Two", 2);
			topN.Add("Three", 3);
			topN.Add("Twee", 2);
			Assert.AreEqual("Three, Two", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void OneTweeThreeTwo()
		{
			var topN = new TopNCollection<string, int>(2);
			topN.Add("One", 1);
			topN.Add("Twee", 2);
			topN.Add("Three", 3);
			topN.Add("Two", 2);
			Assert.AreEqual("Three, Twee", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void NewLowestValueInCollectionIsNotTheOneBeingAdded()
		{
			var topN = new TopNCollection<string, int>(3);
			topN.Add("Six", 6);
			topN.Add("Three", 3);
			topN.Add("Five", 5);

			topN.Add("Seven", 7);
			Assert.AreEqual("Seven, Six, Five", PrintContents(topN));
		}

		[TestMethod]
		[TestCategory("Unit Test")]
		public void NonGenericEnumerator()
		{
			var topN = new TopNCollection<string, int>(1);
			topN.Add("One", 1);
			topN.Add("Two", 2);

			string previousValue = null;

			foreach (string value in (IEnumerable)topN)
			{
				Assert.IsNull(previousValue, "Expect to see not more than one value");
				previousValue = value;
			}

			Assert.AreEqual("Two", previousValue, "Expect to see at least one value");

		}

		[TestMethod]
		public void TopNDoesntCareAboutStringWeights()
		{
			var topN = new TopNCollection<string, string>(3);
			topN.Add("Six", "useis");
			topN.Add("Three", "tres");
			topN.Add("Five", "cinco");
			topN.Add("Seven", "spanish for \"seven\"");
			Assert.AreEqual("Seven, Six, Five", PrintContents(topN));
		}

		/// <summary>
		/// Helper to print all values to a string.
		/// </summary>
		private string PrintContents(TopNCollection<string, int> topNCollection)
		{
			return string.Join(", ", topNCollection.GetOrderedValues());
		}


		/// <summary>
		/// Helper to print all values to a string.
		/// </summary>
		private string PrintContents(TopNCollection<string, string> topNCollection)
		{
			return string.Join(", ", topNCollection.GetOrderedValues());
		}

	}
}
