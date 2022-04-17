using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NBA.Models
{
    public class AnonimMatchup
    {
        public Matchup Matchup { get; set; }
        public string Status { get; set; }
        public SolidColorBrush color { get; set; }
        public Team awayTeam { get; set; }
        public Team homeTeam { get; set; }


        public AnonimMatchup(Matchup matchup)
        {
            Matchup = matchup;
            if (matchup.Status == 1)
            {
                Status = "Finished";
                color = new SolidColorBrush(Color.FromRgb(170, 170, 170));
            }
            if (matchup.Status == -1)
            {
                Status = "Not Start";
                color= new SolidColorBrush(Color.FromRgb(105, 149, 194));
            }
        }
    }
}
