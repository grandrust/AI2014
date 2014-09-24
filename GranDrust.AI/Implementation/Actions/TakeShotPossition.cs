using System;
using System.Collections.Generic;

using GranDrust.AI.Helpers;

using GameAction = GranDrust.AI.Core.Action;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;


namespace GranDrust.AI.Implementation.Actions
{
    public class TakeShotPossition : GameAction
    {
        protected Hockeyist Self { get { return Current.Hockeyist; } }

        protected Move Move { get { return Current.Move; } }

        public override void Do()
        {
            var opponent = Current.World.GetOpponentPlayer();
            var yCoordinate = Self.SpeedY > 0.0D ? opponent.NetBottom + Self.Radius * 2.0D : opponent.NetTop - Self.Radius * 2.0D;
            var xOffset = (opponent.NetFront - opponent.NetBack) * 2.0D;

            Move.SpeedUp = 1.0D;
            Move.Turn = Self.GetAngleTo(opponent.NetFront + xOffset, yCoordinate);
        }
    }
}
