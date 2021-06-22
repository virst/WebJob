using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebJob.Job;

namespace WebJob.Data
{
    public static class WebJobContext
    {

        public static List<JobInfo> JobInfo { get; }

        static WebJobContext()
        {
            JobInfo = new List<JobInfo>();
        }
    }
}
