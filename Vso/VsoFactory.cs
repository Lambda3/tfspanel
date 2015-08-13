using Microsoft.Framework.OptionsModel;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

        public VisualStudioOnline CreateBuildServer()
        {
            var serverData = server.Options.Server ?? server.Options.Builds;
            var requests = new Requests(serverData.Api, serverData.Username, serverData.Password);

            return new VisualStudioOnline(requests) { TeamProject = serverData.TeamProject };
        }

        public VisualStudioOnline CreatePullRequestsServer()
        {
            var serverData = server.Options.Server ?? server.Options.PullRequests;
            var requests = new Requests(serverData.Api, serverData.Username, serverData.Password);

            return new VisualStudioOnline(requests) { TeamProject = serverData.TeamProject };
        }
    }
}
