using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Implementation;
using System;

namespace GranDrust.AI.Helpers
{
    public class PlayerHelper
    {
        public static Hockeyist GetEnemyGoalie()
        {
            return GetGoalie(false);
        }

        public static Hockeyist GetMyGoalie()
        {
            return GetGoalie(true);
        }

        private static Hockeyist GetGoalie(bool isTeammate)
        {
            Hockeyist goalie = null;

            foreach (var hockeyist in Current.World.Hockeyists)
            {
                if (hockeyist.IsTeammate == isTeammate && hockeyist.Type == HockeyistType.Goalie)
                {
                    goalie = hockeyist;
                    break;
                }
            }
            return goalie;
        }

        public static bool IsFreezeTime()
        {
            var me = Current.World.GetMyPlayer();
            var opponent = Current.World.GetOpponentPlayer();

            return (me.IsJustMissedGoal && opponent.IsJustScoredGoal) || (me.IsJustScoredGoal && opponent.IsJustMissedGoal);
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

        public static int GetTeammatesCount()
        {
            var goaliesCount = GetMyGoalie() != null ? 2 : 0;
            return (Current.World.Hockeyists.Length - goaliesCount) / 2;
        }

        public static double GetMyYCenterNetCoordinate()
        {
            var me = Current.World.GetMyPlayer();
            return GetPlayerYCenterNetCoordinate(me);
        }

        public static double GetOpponentYCenterNetCoordinate()
        {
            var opponent = Current.World.GetOpponentPlayer();
            return GetPlayerYCenterNetCoordinate(opponent);
        }

        public static double GetPlayerYCenterNetCoordinate(Player player)
        {
            return (player.NetBottom + player.NetTop) / 2.0D;
        }
    }
}
