using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Thing> things;

        public Finder(List<Thing> things)
        {
            this.things = things;
        }

        public FindResult FindClosest()
        {
            return Find(FindType.Closest);
        }

        public FindResult FindFurthest()
        {
            return Find(FindType.Furthest);
        }

        private FindResult Find(FindType findType)
        {
            var allAgeDifferences = CalculateAllAgeDifferences();

            var answer = new FindResult();

            if (allAgeDifferences.Any())
            {
                var ordered = from result in allAgeDifferences
                              orderby result.Difference ascending
                              select result;

                switch (findType)
                {
                    case FindType.Closest:
                        answer = ordered.First();
                        break;
                    case FindType.Furthest:
                        answer = ordered.Last();
                        break;
                }
            }

            return answer;
        }

        private List<FindResult> CalculateAllAgeDifferences()
        {
            var tr = new List<FindResult>();

            for (var i = 0; i < things.Count - 1; i++)
            {
                for (var j = i + 1; j < things.Count; j++)
                {
                    var r = new FindResult();
                    if (things[i].BirthDate < things[j].BirthDate)
                    {
                        r.Oldest = things[i];
                        r.Youngest = things[j];
                    }
                    else
                    {
                        r.Oldest = things[j];
                        r.Youngest = things[i];
                    }
                    r.Difference = r.Youngest.BirthDate - r.Oldest.BirthDate;
                    tr.Add(r);
                }
            }
            return tr;
        }
    }
}