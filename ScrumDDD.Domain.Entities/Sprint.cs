using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities
{
    public class Sprint
    {
        public Sprint() : this(Duration.FromDays(1))
        {
            
        }
        public int Id { get; set; }
        public ICollection<UserStory> Stories { get; }
        public DateTime StartDate { get; set; }
        public Duration Duration { get; }
        public DateTime EndDate {

            get { return StartDate.AddDays(Duration.Days); }
        }

        public Sprint(Duration duration)
        {
            this.Duration = duration;
            this.Stories = new List<UserStory>();
        }

        public bool Overlaps(Sprint otherSprint)
        {
            var myStart = this.StartDate;
            var OtherStart = otherSprint.StartDate;
            var myEnd = this.EndDate;
            var OtherEnd = otherSprint.EndDate;

            return (myStart <= OtherEnd && myEnd >= OtherStart);

        }
    }
}
