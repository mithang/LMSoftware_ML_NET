using SmartDiaryRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDiaryRazor.Services.Interfaces
{
    public interface IDiaryEntryRepository
    {
        DiaryEntry AddEntry(DiaryEntry diaryEntry);
        IEnumerable<DiaryEntry> GetDiaryEntries();
        DiaryEntry DeleteEntry(int id);
        DiaryEntry UpdateEntry(DiaryEntry diaryEntry);
        DiaryEntry GetDiaryEntryById(int id);
        float Prediction(string diaryEntry);
    }
}
