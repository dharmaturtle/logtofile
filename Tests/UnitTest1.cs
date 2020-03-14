using Sandbox;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Tests {
  public class UnitTest1 {
    [Fact]
    public void T1() {
      "Hello world".D();
    }

    [Theory]
    [InlineData("a", "b")]
    public void T2(params string[] inputs) {
      foreach (var input in inputs) {
        input.D();
      }
    }

    [Theory]
    [InlineData(new object[] { new string[] { "a", "b" }, 1337 })]
    public void T3(string[] inputs, int i) {
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
