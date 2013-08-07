using System.Collections.Generic;
using NUnit.Framework;
using Microsoft.FSharp.Collections;
using BowllingGameKata.FSharp;

namespace BowlingGameScore.FSharp.Tests
{

	public static class Extensions
	{
		public static FSharpList<T> ToFSharpList<T>(this IEnumerable<T> source)
		{
			return ListModule.OfSeq(source);
		}
	}

	[TestFixture]
	public class CalculatorTest
	{
        [TestCase(0, new int[] {})]
		[TestCase(300, new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 })]
		[TestCase(60, new[] { 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
		[TestCase(190, new[] { 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9 })]
		[TestCase(110, new[] { 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1 })]
		[TestCase(73, new[] { 5, 2, 3, 4, 4, 2, 6, 1, 8, 0, 0, 9, 2, 7, 2, 3, 8, 1, 3, 3 })]
		public void ShouldBeCorrectSum(int actual, int[] expected)
		{
			Assert.AreEqual(actual, Calculator.CalculateScore(expected.ToFSharpList()));
		}

        [TestCase(0, new int[] { })]
        [TestCase(300, new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 })]
        [TestCase(60, new[] { 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        [TestCase(190, new[] { 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9 })]
        [TestCase(110, new[] { 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1 })]
        [TestCase(73, new[] { 5, 2, 3, 4, 4, 2, 6, 1, 8, 0, 0, 9, 2, 7, 2, 3, 8, 1, 3, 3 })]
        public void SumWithUnfoldShouldBeCorrect(int actual, int[] expected)
        {
            Assert.AreEqual(actual, Calculator.CalculateScoreUnfold(expected.ToFSharpList()));
        }

	}
}
