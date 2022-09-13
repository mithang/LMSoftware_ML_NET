using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDiaryRazor.Models
{
    public class DiaryEntry
    {
        [Key]
        public int EntryID { get; set; }
        [Required]
        [Display(Name ="On This Day")]
        public string EntryText { get; set; }
        public string EntryDate { get; set; }
        public float Sentiment { get; set; }
    }
}
