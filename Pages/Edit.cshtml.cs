using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebJob.Data;
using WebJob.Job;

namespace WebJob.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public JobInfo JobInfo { get; set; }

        public ActionResult OnGetAsync(int? id)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            
            return RedirectToPage("./Index");
        }

        private bool JobInfoExists(int id)
        {
            return WebJobContext.JobInfo.Any(e => e.Id == id);
        }
    }
}
