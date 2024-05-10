﻿using System.Threading.Tasks;
using Xunit;

namespace NamespaceParallelization.Example.ConfigA;

#pragma warning disable xUnit1041  // This is an unconventional "fixture" arrangement

public class ATest3(Setup setup) : IAsyncLifetime
{
    public Task DisposeAsync()
    {
        setup.SendDiagnosticMessage("ATest3 Dispose");
        return Task.CompletedTask;
    }

    public Task InitializeAsync()
    {
        setup.SendDiagnosticMessage("ATest3 Initialize");
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ATest3_Test1()
    {
        setup.SendDiagnosticMessage("ATest3_Test1");
        await DemoDelay.WaitRandomTimeAsync();
        //Assert.Fail();
    }

    [Fact]
    public async Task ATest3_Test2()
    {
        setup.SendDiagnosticMessage("ATest3_Test2");
        await DemoDelay.WaitRandomTimeAsync();
        //Assert.Fail();
    }

    [Fact]
    public async Task ATest3_Test3()
    {
        setup.SendDiagnosticMessage("ATest3_Test3");
        await DemoDelay.WaitRandomTimeAsync();
    }
}
