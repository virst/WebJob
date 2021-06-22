using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebJob.Job
{
    public static class Job
    {
        public static readonly Dictionary<string, DateTime> LastRuns = new Dictionary<string, DateTime>();
        public static readonly TimeSpan Period = new TimeSpan(0, 0, 30);
        public const int CoolDown = 5 * 1000; // 5 sec.

        static Job()
        {
            LastRuns["JOB - 1"] = DateTime.MinValue;
            LastRuns["JOB - 2"] = DateTime.MinValue;
            LastRuns["JOB - 3"] = DateTime.MinValue;
        }

        static void Run(string s)
        {
            Console.WriteLine($"RUN - {s}");
            File.WriteAllText(s.Replace(' ', '_') + ".log", DateTime.Now.ToLongTimeString());
            Console.WriteLine($"END - {s}");
        }

        public static void Loop()
        {
            while (true)
            {
                try
                {
                    foreach (var run in LastRuns)
                    {
                        if(run.Value.Add(Period) > DateTime.Now) continue;
                        Run(run.Key);
                        LastRuns[run.Key] = DateTime.Now;
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
