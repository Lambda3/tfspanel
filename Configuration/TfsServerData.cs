namespace TfsPanel.Configuration
{
    public class TfsServer
    {
        public TfsBuildServerData Builds { get; set; }
        public TfsPullRequestsServerData PullRequests { get; set; }
    }

    public abstract class TfsServerData
    {
        public string TeamProject { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Api { get; set; }
    }

    public class TfsBuildServerData : TfsServerData
    {
        public TfsBuildServerData()
        {
            ItemsPerDefinitionPerRequest = 3;
        }

        public int ItemsPerDefinitionPerRequest { get; set; }
    }

    public class TfsPullRequestsServerData : TfsServerData
    {
        public TfsPullRequestsServerData()
        {
            ItemsPerRequest = 6;
        }

        public int ItemsPerRequest { get; set; }
    }
}