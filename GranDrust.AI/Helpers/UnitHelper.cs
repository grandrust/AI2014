using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Implementation;
using System;

namespace GranDrust.AI.Helpers
{
    public static class UnitHelper
    {
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            var x = x1 - x2;
            var y = y1 - y2;

            return Math.Sqrt(x*x + y*y);
        }

        public static bool CanStrike(this Hockeyist self, Unit unit)
        {
            var angle = self.GetAngleTo(unit);

            return ((Math.Abs(angle) <= 0.5 * Current.Game.StickSector)
                       && (self.GetDistanceTo(unit) <= Current.Game.StickLength));
        }

        public static double GetSpeedModule(this Unit self)
        {
            return Math.Sqrt(self.SpeedX * self.SpeedX + self.SpeedY * self.SpeedY);
        }

        public static bool IsOpponentPlayerOwner(this Puck puck)
        {
            return puck.OwnerPlayerId == Current.World.GetOpponentPlayer().Id;
        }

        public static bool IsMyPlayerOwner(this Puck puck)
        {
            return puck.OwnerPlayerId == Current.World.GetMyPlayer().Id;
        }

        public static bool GoesIntoNet(this Puck puck)
        {
            var me = Current.World.GetMyPlayer();
            var a = puck.GetDistanceTo(me.NetFront, puck.Y) / puck.X;

            var futurePuckY = Math.Abs(a)*puck.SpeedY + puck.Y;

            return (futurePuckY < me.NetBottom && futurePuckY > me.NetTop);  
        }

    }
}
