using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace duolingo_tracker.Models
{
    public class DuolingoLanguage
    {
        public bool current_learning { get; set; }
        public string language { get; set; }
        public string language_string { get; set; }
        public bool learning { get; set; }
        public long level { get; set; }
        public long points { get; set; }
        public long sentences_translated { get; set; }
        public long streak { get; set; }
        public long to_next_level { get; set; }
    }
}