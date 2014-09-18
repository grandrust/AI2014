using System;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GameAction = Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core.Action;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation.Actions
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
