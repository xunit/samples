using System.Threading.Tasks;
using Xunit;

namespace NamespaceParallelization.Sample.ConfigA;

#pragma warning disable xUnit1041  // This is an unconventional "fixture" arrangement

// You have access to the setup object (though we're not using it)
public sealed class ATest3(Setup setup) : IAsyncLifetime
{
    public ValueTask DisposeAsync()
    {
        TestContext.Current.SendDiagnosticMessage("ATest3 Dispose for {0}", TestContext.Current.Test?.TestDisplayName ?? "(null)");
        return default;
    }

    public ValueTask InitializeAsync()
    {
        TestContext.Current.SendDiagnosticMessage("ATest3 Initialize for {0}", TestContext.Current.Test?.TestDisplayName ?? "(null)");
        return default;
    }

    [Fact]
    public async Task ATest3_Test1()
    {
        TestContext.Current.SendDiagnosticMessage("ATest3_Test1");
        await DemoDelay.WaitRandomTimeAsync();
        Assert.NotNull(setup);
        //Assert.Fail();
    }

    [Fact]
    public async Task ATest3_Test2()
    {
        TestContext.Current.SendDiagnosticMessage("ATest3_Test2");
        await DemoDelay.WaitRandomTimeAsync();
        //Assert.Fail();
    }

    [Fact]
    public async Task ATest3_Test3()
    {
        TestContext.Current.SendDiagnosticMessage("ATest3_Test3");
        await DemoDelay.WaitRandomTimeAsync();
    }
}
