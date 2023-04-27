using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MuslceWizard
{
    public class Biodata
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Gender { get; set; }
        public string Exercise { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public double Bmr { get; set; }
        public double Calorie { get; set; }
        public double Protein { get; set; }


    }
}
