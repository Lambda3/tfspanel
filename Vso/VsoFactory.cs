using Microsoft.Framework.OptionsModel;
using TfsPanel.Configuration;

namespace TfsPanel.Vso
{
    public class VsoFactory
    {
        private readonly IOptions<TfsServer> server;

        public VsoFactory(IOptions<TfsServer> server)
        {
            this.server = server;
        }

        public VisualStudioOnline CreateBuildServer() =>
            CreateServer(server.Options.Builds);

        public VisualStudioOnline CreatePullRequestsServer() =>
            CreateServer(server.Options.PullRequests);

        private VisualStudioOnline CreateServer(TfsServerData data)
        {
            var requests = new Requests(data.Api, data.Username, data.Password);
            return new VisualStudioOnline(requests, data);
        }
    }
}
