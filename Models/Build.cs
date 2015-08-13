using System;

namespace TfsPanel.Models
{
    public class Build
    {
        public DateTime FinishTime { get; set; }
        public BuildStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public string Definition { get; set; }
        public string Number { get; set; }
        public string Author { get; set; }

        public string Duration
        {
            get
            {
                var timeStamp = FinishTime.Subtract(StartTime);
                return string.Format("{0:D2}:{1:D2}:{2:D2}", timeStamp.Hours, timeStamp.Minutes, timeStamp.Seconds);
            }
        }
    }
}
