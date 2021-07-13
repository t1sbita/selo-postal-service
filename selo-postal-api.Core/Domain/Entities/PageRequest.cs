using System;
using System.Collections.Generic;


namespace selo_postal_api.Core.Domain.Entities
{
    public class PageRequest
    {

        protected internal static readonly List<int> PageLimits = new List<int> { 10, 20, 30, 50, 100 };
        protected internal static readonly int DefaultPageLimit = 10;
        private int number;
        private int limit;
        public int Number { get { return number; } }
        public int Limit { get { return limit; } }

        public PageRequest() { }

        public static PageRequest Of(Nullable<int> number, Nullable<int> limit)
        {
            int n = number.HasValue ? number.Value : 1;
            int l = limit.HasValue ? limit.Value : DefaultPageLimit;
            return Of(n, l);
        }

        public static PageRequest Of(int number, int limit)
        {

            PageRequest pr = new PageRequest();

            pr.number = number < 1 ? 1 : number;

            if (limit <= 100)
            {
                for (int i = 0; i < PageLimits.Count; i++)
                {
                    if (limit <= PageLimits[i])
                    {
                        pr.limit = PageLimits[i];
                        break;
                    }

                }
            }
            else
            {
                pr.limit = 100;
            }

            return pr;

        }

        public static PageRequest First() => Of(1, DefaultPageLimit);
    }
}