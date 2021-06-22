using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebJob.Pages
{
    public class EditConfigModel : PageModel
    {
        public int PeriodSec { get; set; }
        public int CoolDownSec { get; set; }

        public void OnGet()
        {
            PeriodSec = (int)Job.Job.Period.TotalSeconds;
            CoolDownSec = Job.Job.CoolDown / 1000;
        }


        public IActionResult OnPost(int PeriodSec,int CoolDownSec)
        {
            Job.Job.Period = new TimeSpan(0, 0, PeriodSec);
            Job.Job.CoolDown = CoolDownSec * 1000;

            return RedirectToPage("./Index");
        }
    }
}
