using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GranDrust.AI.Implementation.Actions.Base;

namespace GranDrust.AI.Implementation.Actions
{
    public class GoToSide : ActionBase
    {
        protected override void Do()
        {
            var opponent = Current.World.GetOpponentPlayer();

            var summY = 0.0D;
            var yHalf = (Current.Game.RinkTop + Current.Game.RinkBottom) / 2.0D;

            foreach (var opp in Current.World.Hockeyists)
            {
                if (!opp.IsTeammate && opp.Type != HockeyistType.Goalie)
                    summY += opp.Y - yHalf - Current.Game.RinkTop;
            }

            var y = summY > 0.0D
                            ? 0.0D
                            : Current.World.Height;

            var turnAngle = Self.GetAngleTo(Self.X, y);

            
            Move.SpeedUp = 1.0D;
            Move.Turn = turnAngle;
        }
    }
}
