using System;

namespace TfsPanel.Models
{
    public static class BuildExtensions
    {
        public static BuildStatus ToBuildStatus(this string text)
        {
            if (string.Equals(text, "failed", StringComparison.CurrentCultureIgnoreCase))
                return BuildStatus.Failed;

            if (string.Equals(text, "succeeded", StringComparison.CurrentCultureIgnoreCase))
                return BuildStatus.Succeeded;

            return BuildStatus.PartiallySucceeded;
        }

        public static string ToJson(this BuildStatus status)
        {
            switch (status)
            {
                case BuildStatus.Succeeded:
                    return "succeeded";
                case BuildStatus.Failed:
                    return "failed";
                default:
                    return "partially succeeded";
            }
        }
    }
}
