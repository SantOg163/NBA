using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Models
{
    public class AnonimTeam
    {
        Team _team;
        public int TeamScore1;
        public int TeamScore2;
        public int TeamScore3;
        public int TeamScore4;
        public int TeamTotal;
        public AnonimTeam(Team team)
        {
            _team = team;
            TeamScore1 = Convert.ToInt32(NBAEntities.GetContext().MatchupDetail.Where(m => m.Quarter == 1).Select(m => m.Team_Away_Score));
            TeamScore2 = Convert.ToInt32(NBAEntities.GetContext().MatchupDetail.Where(m => m.Quarter == 2).Select(m => m.Team_Away_Score));
            TeamScore3 = Convert.ToInt32(NBAEntities.GetContext().MatchupDetail.Where(m => m.Quarter == 3).Select(m => m.Team_Away_Score));
            TeamScore4 = Convert.ToInt32(NBAEntities.GetContext().MatchupDetail.Where(m => m.Quarter == 4).Select(m => m.Team_Away_Score));
            TeamTotal = TeamScore1 + TeamScore2 + TeamScore3 + TeamScore4;
        }
    }
}
