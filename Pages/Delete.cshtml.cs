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
    public class DeleteModel : PageModel
    {
        

        [BindProperty]
        public JobInfo JobInfo { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobInfo = WebJobContext.JobInfo.FirstOrDefault(m => m.Id == id);

            if (JobInfo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobInfo = WebJobContext.JobInfo.FirstOrDefault(m => m.Id == id);

            if (JobInfo != null)
            {
                WebJobContext.JobInfo.Remove(JobInfo);
               
            }

            return RedirectToPage("./Index");
        }
    }
}
