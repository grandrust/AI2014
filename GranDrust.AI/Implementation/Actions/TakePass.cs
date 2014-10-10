using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Implementation.Actions.Base;
using System;

namespace GranDrust.AI.Implementation.Actions
{
    public class TakePass : ActionBase
    {
        private ActionBase TakePossition = null;
        protected override void Do()
        {
            if (Current.SaferCount > 0)
            {
                var distance = 0.0;
                Hockeyist passer = null;

                foreach (var friend in Current.World.Hockeyists)
                {
                    if (friend.IsTeammate && friend.Type != HockeyistType.Goalie)
                    {
                        var dis = friend.GetDistanceTo(Self);
                        if (dis > distance)
                        {
                            distance = dis;
                            passer = friend;
                        }
                    }

                }

                if (passer != null)
                {
                    var angle = Self.GetAngleTo(passer);
                    if (angle <= Current.Game.PassSector / 2.0D)
                    {
                        Move.PassPower = 1.0D;
                        Move.PassAngle = angle;
                    }
                    else
                    {
                        Move.Turn = angle;
                    }
                }
            }
            else
            {
                if (TakePossition == null)
                    TakePossition = new TakeShotPossition();

                TakePossition.Decide();
            }

        }
    }
}
