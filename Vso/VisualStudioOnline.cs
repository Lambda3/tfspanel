using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TfsPanel.Models;
using TfsPanel.Configuration;

namespace TfsPanel.Vso
{
    public class VisualStudioOnline
    {
        private readonly TfsServerData data;
        private readonly Requests requests;
        
        public VisualStudioOnline(Requests requests, TfsServerData data)
        {
            this.requests = requests;
            this.data = data;
        }


        public async Task<IEnumerable<Repository>> Repositories()
        {
            var response = await requests.Get("git/repositories?api-version=1.0");
            return (response.value as JArray)
                .Where((dynamic repo) => repo.project.name == data.TeamProject)
                .Select((dynamic repo) => new Repository { Name = repo.name, Id = repo.id });
        }

        public async Task<string[]> BuildDefinitions()
        {
            var response = await requests.Get("build/definitions?api-version=2.0");
            return (response.value as JArray)
                .Select((dynamic definition) => definition.id)
                .Select(id => id.ToString())
                .Cast<string>()
                .ToArray();
        }


        public async Task<IEnumerable<PullRequest>> ActivePullRequests(IEnumerable<Repository> repositories)
        {
            var prs = await Task
                .WhenAll(repositories.Select(repo => ActivePullRequests(repo)));

            return prs.SelectMany(repos => repos);
        }

        public async Task<IEnumerable<PullRequest>> ActivePullRequests(Repository repository)
        {
            var maxCount = (data as TfsPullRequestsServerData).ItemsPerRequest;
            var response = await requests.Get($"git/repositories/{repository.Id}/pullRequests?status=completed&$top={maxCount}&api-version=1.0");
            return (response.value as JArray)
                .Select((dynamic pr) => new PullRequest
                {
                    Repo = repository,
                    Title = pr.title,
                    FromBranch = pr.sourceRefName,
                    ToBranch = pr.targetRefName,
                    Author = pr.createdBy.displayName,
                    CreationDate = pr.creationDate
                });
        }

        public async Task<IEnumerable<Build>> Builds(IEnumerable<string> definitions)
        {
            var maxCount = (data as TfsBuildServerData).ItemsPerDefinitionPerRequest;
            var url = $"build/builds?definitions={string.Join(",", definitions)}&maxBuildsPerDefinition={maxCount}&api-version=2.0";
            var response = await requests.Get(url);

            return (response.value as JArray)
                .Select((dynamic build) => new Build
                {
                    Status = BuildExtensions.ToBuildStatus(build.result.ToString()),
                    Number = build.buildNumber,
                    Author = build.requestedFor.displayName,
                    StartTime = build.startTime,
                    FinishTime = build.finishTime,
                    Definition = build.definition.name
                });
        }
    }
}
