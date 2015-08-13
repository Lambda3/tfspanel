using System;

namespace TfsPanel.Models
{
    public class PullRequest
    {
        private string from;
        private string to;

        public DateTime CreationDate { get; set; }
        public Repository Repo { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string FromBranch
        {
            get { return RemoveGitPath(from); }
            set { from = value; }
        }

        public string ToBranch
        {
            get { return RemoveGitPath(to); }
            set { to = value; }
        }

        private string RemoveGitPath(string head) =>
            head.Replace("refs/heads/", "");
    }
}
