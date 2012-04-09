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
                    var left = things[i];
                    var right = things[j];
                    
                    var r = CreateFindResultFromTwoThings(right, left);

                    tr.Add(r);
                }
            }
            return tr;
        }

        private static FindResult CreateFindResultFromTwoThings(Thing right, Thing left)
        {
            var r = new FindResult();

            if (left.BirthDate < right.BirthDate)
            {
                r.Oldest = left;
                r.Youngest = right;
            }
            else
            {
                r.Oldest = right;
                r.Youngest = left;
            }
            r.Difference = r.Youngest.BirthDate - r.Oldest.BirthDate;
            return r;
        }
    }
}