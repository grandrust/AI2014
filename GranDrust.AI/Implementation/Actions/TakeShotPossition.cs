using System;
using System.Collections.Generic;

using GranDrust.AI.Helpers;

using GranDrust.AI.Implementation.Actions.Base;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;


namespace GranDrust.AI.Implementation.Actions
{
    public class TakeShotPossition : ActionBase
    {
        protected override void Do()
        {
            var opponent = Current.World.GetOpponentPlayer();
            var yCoordinate = Self.SpeedY > 0.0D ? opponent.NetBottom + Self.Radius * 2.0D : opponent.NetTop - Self.Radius * 2.0D;
            var xOffset = (opponent.NetFront - opponent.NetBack) * 5.0D;

            Move.SpeedUp = 1.0D;
            Move.Turn = Self.GetAngleTo(opponent.NetFront + xOffset, yCoordinate);
        }
    }
}
