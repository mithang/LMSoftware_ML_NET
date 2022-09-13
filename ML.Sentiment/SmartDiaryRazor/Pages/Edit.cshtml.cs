using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartDiaryRazor.Models;
using SmartDiaryRazor.Services.Interfaces;

namespace SmartDiaryRazor.Pages
{
    public class EditModel : PageModel
    {
        private readonly IDiaryEntryRepository _diaryEntryRepository;
        public EditModel(IDiaryEntryRepository diaryEntryRepository)
        {
            _diaryEntryRepository = diaryEntryRepository;
        }
        [BindProperty]
        public DiaryEntry Entry { get; set; }
        public void OnGet(int entryID)
        {
            Entry = _diaryEntryRepository.GetDiaryEntryById(entryID);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Entry.EntryDate = DateTime.Now.ToString("dd MMM, yyyy");
            Entry.Sentiment = _diaryEntryRepository.Prediction(Entry.EntryText);
            _diaryEntryRepository.UpdateEntry(Entry);
            return RedirectToPage("Index");
        }
    }
}
