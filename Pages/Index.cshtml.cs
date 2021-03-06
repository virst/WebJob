using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebJob.Data;
using WebJob.Job;

namespace WebJob.Pages
{
    public class IndexModel : PageModel
    {
        public IList<JobInfo> JobInfo { get;set; }
        public int PeriodSec { get; set; }
        public int CoolDownSec { get; set; }

        public void OnGet()
        {
            JobInfo = WebJobContext.JobInfo;

            PeriodSec = (int)Job.Job.Period.TotalSeconds;
            CoolDownSec = Job.Job.CoolDown / 1000;
        }
    }
}
