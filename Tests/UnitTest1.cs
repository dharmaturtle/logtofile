using Sandbox;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Tests {

  public class Solution {
    public static void DoThing(string inputData) {
      string line;
      //while ((line = Console.ReadLine()) != null) {
      //  inputData += line + "\n";
      //}
      // Do not edit: Output solution to console
      Console.WriteLine(codeHere(inputData));
    }

    static String codeHere(String inputData) {
      var lines = inputData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

      var nums = lines[1].Split(' ').Select(int.Parse).ToList();
      var countByX = new Dictionary<int, int>();
      foreach (var x in nums) {
        if (countByX.ContainsKey(x)) {
          countByX[x]++;
        } else {
          countByX.Add(x, 1);
        }
      }
      var max = countByX.Max(x => x.Value);
      var maxOptions = countByX.Where(kvp => kvp.Value == max);
      var min = maxOptions.Select(maxOption => {
        var key = maxOption.Key;
        var first = nums.IndexOf(key);
        var last = nums.LastIndexOf(key);
        return last - first + 1;
      }).Min();

      // Use this function to return your solution.
      return min.ToString();
    }
  }

  public class UnitTest1 {
    [Fact]
    public void T1() {
      //"Hello world".D();
      Solution.DoThing(@"5
1 2 2 3 1");
    }

    [Theory]
    [InlineData("a", "b")]
    public void T2(params string[] inputs) {
      foreach (var input in inputs) {
        input.D();
      }
    }

    [Theory]
    [InlineData(new object[] { new int[] { 1, 2 }, "" })]
    public void T3(int[] inputs, string i) {
      foreach (var input in inputs) {
        input.D();
      }
      i.D();
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-4, -6, -10)]
    [InlineData(-2, 2, 0)]
    [InlineData(int.MinValue, -1, int.MaxValue)]
    public void T4(int i1, int i2, int i3) {
      i1.D();
      i2.D();
      i3.D();
    }

    public class T5Data: IEnumerable<object[]> {
      public IEnumerator<object[]> GetEnumerator() {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { -4, -6, -10 };
        yield return new object[] { -2, 2, 0 };
        yield return new object[] { int.MinValue, -1, int.MaxValue };
      }
      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    [Theory]
    [ClassData(typeof(T5Data))]
    public void T5(int value1, int value2, int expected) {
      value1.D();
      value2.D();
      expected.D();
    }

  }
}
