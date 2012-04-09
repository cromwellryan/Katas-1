using System;

namespace Algorithm
{
    public class FindResult
    {
        public Thing Oldest { get; set; }
        public Thing Youngest { get; set; }
        public TimeSpan Difference { get; set; }
    }
}