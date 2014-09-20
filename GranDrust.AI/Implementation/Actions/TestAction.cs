using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GameAction = GranDrust.AI.Core.Action;

namespace GranDrust.AI.Implementation.Actions
{
    public class TestAction : GameAction
    {
        protected Move Move { get { return Current.Move; } }

        public override void Do()
        {
            Move.SpeedUp = -1.0D;
            Move.Turn = Math.PI;
            Move.Action = ActionType.Strike;
        }
    }
}
