using Microsoft.ML;
using SmartDiaryRazor.Data;
using SmartDiaryRazor.Machine_Learning;
using SmartDiaryRazor.Models;
using SmartDiaryRazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDiaryRazor.Services.Repositories
{
    public class DiaryEntryRepository : IDiaryEntryRepository
    {
        private readonly AppDbContext _context;
        public DiaryEntryRepository(AppDbContext context)
        {
            _context = context;
        }
        public DiaryEntry AddEntry(DiaryEntry diaryEntry)
        {
            _context.DiaryEntries.Add(diaryEntry);
            _context.SaveChanges();
            return diaryEntry;
        }

        public DiaryEntry DeleteEntry(int id)
        {
            DiaryEntry diaryEntry = _context.DiaryEntries.Find(id);
            if (diaryEntry != null)
            {
                _context.DiaryEntries.Remove(diaryEntry);
                _context.SaveChanges();
            }
            return diaryEntry;
        }

        public IEnumerable<DiaryEntry> GetDiaryEntries()
        {
            var entries = _context.DiaryEntries.OrderByDescending(x=>x.EntryID);
            return entries;
        }

        public DiaryEntry GetDiaryEntryById(int id)
        {
            var entry = _context.DiaryEntries.Find(id);
            return entry;
        }

        public float Prediction(string diaryEntry)
        {
            MLContext mlContext = new MLContext();
            DataViewSchema modelSchema;
            string modelPath = "MachineLearning/MLModel.zip";
            ITransformer trainedModel = mlContext.Model.Load(modelPath,out modelSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(trainedModel);
            SentimentData input = new SentimentData
            {
                SentimentText = diaryEntry
            };
            SentimentPrediction analysis = predEngine.Predict(input);
            return analysis.Probability;
        }

        public DiaryEntry UpdateEntry(DiaryEntry diaryEntry)
        {
            if (diaryEntry != null)
            {
                _context.DiaryEntries.Update(diaryEntry);
                _context.SaveChanges();
            }
            return diaryEntry;
        }
    }
}
