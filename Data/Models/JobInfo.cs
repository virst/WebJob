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
        public DateTime NextRun { get; set; } = DateTime.MinValue;
        public string Parameters { get; set; }
        public bool Active { get; set; } = true;
        public bool Blocking { get; set; } = false;

        public event Func<DateTime, TimeSpan, DateTime> UpdateLastRunFunc = null;

        public void UpdateLastRun(TimeSpan period)
        {
            NextRun = UpdateLastRunFunc?.Invoke(NextRun, period) ?? DateTime.Now.Add(period);
        }
    }
}
