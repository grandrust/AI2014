using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GameAction = GranDrust.AI.Core.Action;

namespace GranDrust.AI.Implementation.Actions
{
    public class MoveToNet : GameAction
    {
        protected Move Move { get { return Current.Move; } }

        public override void Do()
        {
            var opponent = Current.World.GetOpponentPlayer();
            
            Move.SpeedUp = 1.0D;
            Move.Turn = Current.Hockeyist.GetAngleTo(opponent.NetFront, opponent.NetBottom);
        }
    }
}
