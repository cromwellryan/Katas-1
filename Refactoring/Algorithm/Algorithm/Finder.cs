using System;
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

            if(allAgeDifferences.Count < 1)
            {
                return new FindResult();
            }

            FindResult answer = allAgeDifferences[0];
            foreach(var result in allAgeDifferences)
            {
                switch(findType)
                {
                    case FindType.Closest:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case FindType.Furthest:
                        if(result.D > answer.D)
                        {
                            answer = result;
                        }
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
                        r.P1 = things[i];
                        r.P2 = things[j];
                    }
                    else
                    {
                        r.P1 = things[j];
                        r.P2 = things[i];
                    }
                    r.D = r.P2.BirthDate - r.P1.BirthDate;
                    tr.Add(r);
                }
            }
            return tr;
        }
    }
}