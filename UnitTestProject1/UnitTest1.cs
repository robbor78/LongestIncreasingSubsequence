using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LongestIncreasingSubsequence;
using System.Linq;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestContinuous()
    {
      int[][] allSequences = new int[][]
      {
        new int[] { 5,3,4,8,6,7},
        new int[] { 1,2,3,4,5,6},
        new int[] { 6,5,4,3,2,1},
        new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 }
      };
      int[] allLength = new int[] { 3, 6, -1, 2 };
      int[][] allSubsequences = new int[][]
      {
        new int[] { 3,4,8},
        new int[] { 1,2,3,4,5,6},
        null,
        new int[] {0,8 }
      };

      Program p = new Program();
      int length = allSequences.Length;
      for (int i = 0; i < length; i++)
      {
        int[] sequence = allSequences[i];
        int[] subsequence = null;
        int actual = p.getContinuous(sequence, out subsequence);
        int expected = allLength[i];
        Assert.AreEqual(expected, actual);
        TestEqual(allSubsequences[i], subsequence);
      }

    }

    [TestMethod]
    public void TestNonContinuous()
    {
      int[][] allSequences = new int[][]
      {
        new int[] { 5,3,4,8,6,7},
        new int[] { 1,2,3,4,5,6},
        new int[] { 6,5,4,3,2,1},
        new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 }
      };
      int[] allLength = new int[] { 4, 6, -1, 6 };
      int[][] allSubsequences = new int[][]
      {
        new int[] { 3,4,6,7},
        new int[] { 1,2,3,4,5,6},
        null,
        new int[] {0, 2, 6, 9, 11, 15}
      };

      Program p = new Program();
      int length = allSequences.Length;
      for (int i = 0; i < length; i++)
      {
        int[] sequence = allSequences[i];
        int[] subsequence = null;
        int actual = p.getNonContinuous(sequence, out subsequence);
        int expected = allLength[i];
        Assert.AreEqual(expected, actual);
        TestEqual(allSubsequences[i], subsequence);
      }
    }

    private void TestEqual(int[] expected, int[] actual)
    {
      if (expected == null)
      {
        Assert.IsNull(actual);
      }
      else {
        Assert.AreEqual(expected.Length, actual.Length);
        Assert.IsTrue(expected.SequenceEqual(actual));
      }
    }
  }
}
