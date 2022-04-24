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
    /// Логика взаимодействия для ManageTeams.xaml
    /// </summary>
    public partial class ManageTeams : Page
    {
        public ManageTeams()
        {
            InitializeComponent();
            var teams=new[] { new{team = NBAEntities.GetContext().Team.ToList().First(),
                totalSalary=NBAEntities.GetContext().PlayerInTeam.ToList().
                Where(p => p.TeamId == NBAEntities.GetContext().Team.ToList().First().TeamId &&
                p.SeasonId == NBAEntities.GetContext().Season.ToList().Last().SeasonId).Select(p => p.Salary).Sum() } }.ToList();
            if(teams.Count==1)
            for (int i = 0; i < NBAEntities.GetContext().Team.ToList().Count; i++)
            {
                teams.Add(new
                {
                    team = NBAEntities.GetContext().Team.ToList()[i],
                    totalSalary = NBAEntities.GetContext().PlayerInTeam.ToList().
                 Where(p => p.TeamId == NBAEntities.GetContext().Team.ToList()[i].TeamId &&
                 p.SeasonId == NBAEntities.GetContext().Season.ToList().Last().SeasonId).Select(p => p.Salary).Sum()
                });
                if (!teams[i].team.Logo.Contains("\\Images\\Logo\\"))
                    teams[i].team.Logo = teams[i].team.Logo.Insert(0, "\\Images\\Logo\\");
            }
            teams.Remove(teams[0]);
                DGridTeams.ItemsSource = teams;
            List<string> conference = new List<string>() { "All", "Eastern", "Western" };
            List<string> division = new List<string>() { "All"};
                division.AddRange(NBAEntities.GetContext().Division.ToList().Select(d=>d.Name));
            Total.Content=Total.Content.ToString().Replace("XX",$"{teams.Count}");
            comboConference.ItemsSource = conference;
            comboDividsion.ItemsSource = division;
            comboConference.SelectedIndex = 0;
            comboDividsion.SelectedIndex = 0;
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var teams = new[] { new{team = NBAEntities.GetContext().Team.ToList().First(),
                totalSalary=NBAEntities.GetContext().PlayerInTeam.ToList().
                Where(p => p.TeamId == NBAEntities.GetContext().Team.ToList().First().TeamId &&
                p.SeasonId == NBAEntities.GetContext().Season.ToList().Last().SeasonId).Select(p => p.Salary).Sum() } }.ToList();
            for (int i = 0; i < NBAEntities.GetContext().Team.ToList().Count; i++)
            {
                teams.Add(new
                {
                    team = NBAEntities.GetContext().Team.ToList()[i],
                    totalSalary = NBAEntities.GetContext().PlayerInTeam.ToList().
                 Where(p => p.TeamId == NBAEntities.GetContext().Team.ToList()[i].TeamId &&
                 p.SeasonId == NBAEntities.GetContext().Season.ToList().Last().SeasonId).Select(p => p.Salary).Sum()
                });
                if (!teams[i].team.Logo.Contains("\\Images\\Logo\\"))
                    teams[i].team.Logo = teams[i].team.Logo.Insert(0, "\\Images\\Logo\\");
            }
            if (comboConference.Text == "All" && comboDividsion.Text=="All")
            {
                DGridTeams.ItemsSource = teams.Where(t => t.team.TeamName.ToLower().Contains(Name.Text.ToLower()));
                return;
            }
            if (comboConference.Text == "All")
            {
                DGridTeams.ItemsSource = teams.Where(t =>  t.team.Division.Name == comboDividsion.Text && t.team.TeamName.ToLower().Contains(Name.Text.ToLower()));
                return;
            }
            if (comboDividsion.Text == "All")
            {
                DGridTeams.ItemsSource = teams.Where(t => t.team.Division.Conference.Name == comboConference.Text && t.team.TeamName.ToLower().Contains(Name.Text.ToLower()));
                return;
            }
            DGridTeams.ItemsSource = teams.Where(t => t.team.Division.Conference.Name == comboConference.Text && t.team.Division.Name == comboDividsion.Text && t.team.TeamName.ToLower().Contains(Name.Text.ToLower()));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The  feature would be a future add-on to the current system.", "Add a new team – Future Add-on");
        }
    }
}
