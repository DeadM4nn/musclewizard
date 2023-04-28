using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuslceWizard
{
    public class Exercise
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }

    }
}
