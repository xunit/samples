using System.Threading.Tasks;
using Xunit;

namespace NamespaceParallelization.Sample.ConfigB;

#pragma warning disable xUnit1041  // This is an unconventional "fixture" arrangement

// You have access to the setup object (though we're not using it)
public sealed class BTest1(Setup setup) : IAsyncLifetime
{
    public ValueTask DisposeAsync()
    {
        TestContext.Current.SendDiagnosticMessage("BTest1 Dispose for {0}", TestContext.Current.Test?.TestDisplayName ?? "(null)");
        return default;
    }

    public ValueTask InitializeAsync()
    {
        TestContext.Current.SendDiagnosticMessage("BTest1 Initialize for {0}", TestContext.Current.Test?.TestDisplayName ?? "(null)");
        return default;
    }

    [Fact]
    public async Task BTest1_Test1()
    {
        TestContext.Current.SendDiagnosticMessage("BTest1_Test1");
        await DemoDelay.WaitRandomTimeAsync();
        Assert.NotNull(setup);
        //Assert.Fail();
    }

    [Fact]
    public async Task BTest1_Test2()
    {
        TestContext.Current.SendDiagnosticMessage("BTest1_Test2");
        await DemoDelay.WaitRandomTimeAsync();
        //Assert.Fail();
    }

    [Fact]
    public async Task BTest1_Test3()
    {
        TestContext.Current.SendDiagnosticMessage("BTest1_Test3");
        await DemoDelay.WaitRandomTimeAsync();
    }
}
