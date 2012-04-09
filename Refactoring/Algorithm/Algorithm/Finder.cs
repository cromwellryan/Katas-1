using System;
using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Thing> _p;

        public Finder(List<Thing> p)
        {
            _p = p;
        }

        public FindResult FindClosest()
        {
            return Find(FindType.Closest);
        }

        public FindResult FindFurthest()
        {
            return Find(FindType.Furthest);
        }

        private FindResult Find(FindType ft)
        {
            var tr = new List<FindResult>();

            for(var i = 0; i < _p.Count - 1; i++)
            {
                for(var j = i + 1; j < _p.Count; j++)
                {
                    var r = new FindResult();
                    if(_p[i].BirthDate < _p[j].BirthDate)
                    {
                        r.P1 = _p[i];
                        r.P2 = _p[j];
                    }
                    else
                    {
                        r.P1 = _p[j];
                        r.P2 = _p[i];
                    }
                    r.D = r.P2.BirthDate - r.P1.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new FindResult();
            }

            FindResult answer = tr[0];
            foreach(var result in tr)
            {
                switch(ft)
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
    }
}