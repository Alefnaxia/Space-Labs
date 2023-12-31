using System.Linq;
using Content.Server.Administration.UI;
using Content.Server.EUI;
using Robust.Server.Player;

namespace Content.IntegrationTests.Tests.Cleanup;

public sealed class EuiManagerTest
{
    [Test]
    public async Task EuiManagerRecycleWithOpenWindowTest()
    {
        // Even though we are using the server EUI here, we actually want to see if the client EUIManager crashes
        for (var i = 0; i < 2; i++)
        {
            await using var pairTracker = await PoolManager.GetServerClient(new PoolSettings
            {
                Connected = true,
                Dirty = true
            });
            var server = pairTracker.Pair.Server;

            var sPlayerManager = server.ResolveDependency<IPlayerManager>();
            var eui = server.ResolveDependency<EuiManager>();

            await server.WaitAssertion(() =>
            {
                var clientSession = sPlayerManager.ServerSessions.Single();
                var ui = new AdminAnnounceEui();
                eui.OpenEui(ui, clientSession);
            });
            await pairTracker.CleanReturnAsync();
        }
    }
}
