using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebJob.Data;

namespace WebJob.Job
{
    public static class Job
    {

        public static TimeSpan Period = new(0, 0, 30); // 30 sec.
        public static int CoolDown = 5 * 1000; // 5 sec.

        static Job()
        {
            WebJobContext.JobInfo.Add(new JobInfo() { Id = 1, Name = "JOB - 1", Parameters = "INFO 1" });
            var j2 = new JobInfo() { Id = 2, Name = "JOB - 2", Parameters = "INFO 2" };
            j2.UpdateLastRunFunc += J2_UpdateLastRunFunc;
            WebJobContext.JobInfo.Add(j2);
            WebJobContext.JobInfo.Add(new JobInfo() { Id = 3, Name = "JOB - 3", Parameters = "INFO 3" });
        }

        private static DateTime J2_UpdateLastRunFunc(DateTime d, TimeSpan t)
        {
            d = DateTime.Now.Add(t);
            var tmp = new DateTime(d.Year, d.Month, d.Day, 9, 0,0);
            while (tmp < d) tmp = tmp.AddDays(1);
            return tmp;
        }

        static void Run(JobInfo j)
        {
            try
            {
                Console.WriteLine($"RUN - {j.Name}({j.Id})");
                File.WriteAllText(j.Name.Replace(' ', '_') + ".log", DateTime.Now.ToLongTimeString());
                Console.WriteLine($"END - {j.Name}({j.Id})");
            }
            catch (Exception)
            {
                j.Blocking = true;
            }
        }

        public static void Loop()
        {
            while (true)
            {
                try
                {
                    foreach (var job in WebJobContext.JobInfo)
                    {
                        if (job.NextRun > DateTime.Now || job.Blocking || !job.Active) continue;
                        Run(job);
                        job.UpdateLastRun(Period);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("LOP ERR:" + ex);
                }

                Thread.Sleep(CoolDown);
            }
        }
    }
}
