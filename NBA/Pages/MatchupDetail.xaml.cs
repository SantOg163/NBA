using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NBA.Models;


namespace NBA.Pages
{
    /// <summary>
    /// Логика взаимодействия для MatchupDetail.xaml
    /// </summary>
    public partial class MatchupDetail : Page
    {
        public static List<AnonimMatchUp> _currentMatch;
        public MatchupDetail(AnonimMatchUp selectedMatch)
        {
            InitializeComponent();
            if(selectedMatch != null)
                _currentMatch = new List<AnonimMatchUp> { selectedMatch };
            LViewMatchup.ItemsSource = _currentMatch;
            var list = new { Match = selectedMatch, score1 = _currentMatch.Select(m => m.Matchup.MatchupDetail.Where(s => s.Quarter == 1).Select(s => s.Team_Away_Score)) };
            var a = _currentMatch.Select(m => m.Matchup.MatchupDetail.Where(s => s.Quarter == 1));
        }
    }
}
