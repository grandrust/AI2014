using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GranDrust.AI.Implementation.Actions.Base;

namespace GranDrust.AI.Implementation.Actions
{
    public class MoveToNet : ActionBase
    {
        protected override void Do()
        {
            var opponent = Current.World.GetOpponentPlayer();

            var topYOffset = Math.Abs(opponent.NetTop - Self.Y);
            var bottomYOffset = Math.Abs(Self.Y- opponent.NetBottom);

            var y = topYOffset < bottomYOffset ? opponent.NetTop : opponent.NetBottom;

            
            Move.SpeedUp = 1.0D;
            Move.Turn = Current.Hockeyist.GetAngleTo(opponent.NetFront - 5*Current.World.Puck.Radius, y);
        }
    }
}
