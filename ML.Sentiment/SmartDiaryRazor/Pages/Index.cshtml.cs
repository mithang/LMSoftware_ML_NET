using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SmartDiaryRazor.Models;
using SmartDiaryRazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDiaryRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDiaryEntryRepository _diaryEntryRepository;
        public IndexModel(ILogger<IndexModel> logger, IDiaryEntryRepository diaryEntryRepository)
        {
            _logger = logger;
            _diaryEntryRepository = diaryEntryRepository;
        }
        public DiaryEntry Entry { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost(DiaryEntry entry)
        {
            if (ModelState.IsValid)
            {
                entry.EntryDate = DateTime.Now.ToString("dd MMM, yyyy");
                entry.Sentiment = _diaryEntryRepository.Prediction(entry.EntryText);
                _diaryEntryRepository.AddEntry(entry);
                return RedirectToPage("Index");
            }
            return Page();
        }
        public IActionResult OnPostDelete(int entryID)
        {
            _diaryEntryRepository.DeleteEntry(entryID);
            return RedirectToPage("Index");
        }
    }
}
