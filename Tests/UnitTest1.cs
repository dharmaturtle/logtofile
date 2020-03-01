using Sandbox;
using Serilog;
using System;
using System.IO;
using Xunit;

namespace Tests {
  public abstract class TestBase: IDisposable {
    protected TestBase() {
      File.Delete("c:\\Logs\\myapp.log");
      Log.Logger = new LoggerConfiguration().WriteTo.File("c:\\Logs\\myapp.log").CreateLogger();
    }

    public void Dispose() {
      Log.CloseAndFlush();
    }
  }
  
  public class UnitTest1 : TestBase {
    [Fact]
    public void Test1() {
      "hello world how bout now ".L(); // .L() logs the associated object at an INF level
      Environment.GetFolderPath(Environment.SpecialFolder.Desktop).L();
      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "UnitTestLog3").L();
    }
    [Fact]
    public void Test2() {
      "TWO".L(); // .L() logs the associated object at an INF level
      "TWO".L();
      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "UnitTestLog22222222").L();
    }
  }
}
