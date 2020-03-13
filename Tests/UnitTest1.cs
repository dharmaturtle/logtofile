using Sandbox;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Tests {
  public abstract class TestBase : IDisposable {
    protected TestBase() {
      var logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyAppLog.txt");
      File.Delete(logPath);
      Log.Logger = new LoggerConfiguration().WriteTo.File(logPath).CreateLogger();
    }

    public void Dispose() {
      Log.CloseAndFlush();
    }
  }

  class MyClass {
    public string MyProperty { get; set; }
    public Guid GuidProp { get; set; }
    public List<MyClass> Children { get; set; }
  }
  public class UnitTest1 : TestBase {
    [Fact]
    public void Test1() {
      "hello logger".L();
      new MyClass() {
        MyProperty = "hello world",
        GuidProp = Guid.NewGuid(),
        Children = new List<MyClass> { new MyClass() }
      }.L("this is an id");
    }
  }

}
