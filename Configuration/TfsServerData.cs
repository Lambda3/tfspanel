namespace TfsPanel.Configuration
{
    public class TfsServer
    {
        public TfsServerData Builds { get; set; }
        public TfsServerData PullRequests { get; set; }
        public TfsServerData Server { get; set; }
    }

    public class TfsServerData
    {
        public string TeamProject { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Api { get; set; }
    }
}
