using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities
{
    public struct Duration
    {
        public int Days { get; private set; }

        public static Duration FromDays(int days)
        {
            if (days < 1 || days > 30)
            {
                throw new ArgumentException("days must be greather than 0 and lower than 30");
            }

            return new Duration()
            {
                Days = days
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Duration) 
            { 
                return ((Duration)obj).Days == this.Days;
            }

            return base.Equals(obj);
        }


        public override int GetHashCode()
        {
            return this.Days.GetHashCode();
        }

        public static bool operator==(Duration first, Duration second)
        {
            return first.Days == second.Days;
        }

        public static bool operator !=(Duration first, Duration second)
        {
            return !(first == second);
            //return first.Days != second.Days;
        }
    }
}
