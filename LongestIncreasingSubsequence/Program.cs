using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence
{
  public class Program
  {
    static void Main(string[] args)
    {
    }

    public int getContinuous(int[] sequence, out int[] subsequence)
    {
      int length = sequence.Length;
      int[] solutions = Enumerable.Repeat(1, length).ToArray();
      int max = 0;
      int bestSolution = -1;

      for (int i = 0; i < length; i++)
      {
        int j = i - 1;
        if (j >= 0 && sequence[j] <= sequence[i])
        {
          solutions[i] = solutions[j] + 1;
          if (solutions[i] > max)
          {
            max = solutions[i];
            bestSolution = i;
          }
        }
      }

      if (bestSolution == -1)
      {
        subsequence = null;
      }
      else
      {
        int subsequenceLength = solutions[bestSolution];
        int start = bestSolution - subsequenceLength + 1;
        subsequence = sequence.Skip(start).Take(subsequenceLength).ToArray();
      }

      return bestSolution == -1 ? -1 : max;
    }

    public int getNonContinuous(int[] sequence, out int[] subsequence)
    {
      int length = sequence.Length;
      int[] solutions = Enumerable.Repeat(1, length).ToArray();
      int max = 0;
      int bestSolution = -1;

      for (int i = 0; i < length; i++)
      {
        int currMax = 0;
        for (int j = i - 1; j >= 0; j--)
        {

          if (sequence[j] <= sequence[i])
          {
            if (solutions[j] > currMax)
            {
              currMax = solutions[j];
            }
          }
        }

        solutions[i] += currMax;
        if (solutions[i] > max)
        {
          bestSolution = i;
          max = solutions[i];
        }
      }

      if (bestSolution == -1 || solutions[bestSolution] == 1)
      {
        subsequence = null;
      }
      else
      {
        //subsequence = null;
        int prev = sequence[bestSolution];
        int count = solutions[bestSolution];
        Queue<int> queue = new Queue<int>();
        for (int i = bestSolution; i >= 0; i--)
        {
          if (sequence[i] <= prev && solutions[i] == count)
          {
            queue.Enqueue(sequence[i]);
            prev = sequence[i];
            count = solutions[i] - 1;
          }
        }
        subsequence = queue.Reverse().ToArray();
      }

      return bestSolution == -1 || solutions[bestSolution] == 1 ? -1 : max;
    }
  }
}
