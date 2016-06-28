using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace duolingo_tracker.Models
{
    public class DuolingoUser
    {
        public string bio{ get; set; }
        public string username{ get; set; }
        public long contribution_points { get; set; }
        public long daily_goal { get; set; }
        public long rupees { get; set; }
        public long site_streak { get; set; }
        public List<DuolingoLanguage> languages { get; set; }
        public List<DuolingoImprovement> calendar { get; set; }

        public DuolingoInventoryItem inventory { get; set; }
        //interesting:
        //certificates
        public long totalPoints
        {
            get
            {
                return this.languages.Sum(lang => lang.points);
            }
        }
    }
}