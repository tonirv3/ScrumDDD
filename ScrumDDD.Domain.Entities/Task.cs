using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public bool IsBlocked { get; set; }
        public int PlannedEffort { get; set; }
        public int RemainingEffort { get; set; }
        public User AssignedTo { get; set; }
    }
}
