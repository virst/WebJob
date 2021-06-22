using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJob.Job
{
    public class JobInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastRun { get; set; } = DateTime.MinValue;
        public string Parameters { get; set; }

        public bool Active { get; set; } = true;
        public bool Blocking { get; set; } = false;
    }
}
