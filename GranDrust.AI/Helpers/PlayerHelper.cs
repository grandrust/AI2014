using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Implementation;
using System;

namespace GranDrust.AI.Helpers
{
    public class PlayerHelper
    {
        public static Hockeyist GetEnemyGoalie()
        {
            Hockeyist enemyGoalie = Current.World.Hockeyists[0];

            foreach (var hockeyist in Current.World.Hockeyists)
            {
                if (!hockeyist.IsTeammate && hockeyist.Type == HockeyistType.Goalie)
                {
                    enemyGoalie = hockeyist;
                    break;
                }
            }
            return enemyGoalie;
        }

        public static Hockeyist GetPuckOwner()
        {
            var hockeyists = Current.World.Hockeyists;
            Hockeyist puckOwner = null;

            var ownerId = Current.World.Puck.OwnerHockeyistId;
            if (ownerId == -1) return puckOwner;

            foreach (var hockeist in hockeyists)
            {
                if (hockeist.Id == ownerId)
                {
                    puckOwner = hockeist;
                    break;
                }
            }

            return puckOwner;
 
        }
    }
}
