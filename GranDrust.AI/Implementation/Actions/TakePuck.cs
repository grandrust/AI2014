using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GranDrust.AI.Implementation.Actions.Base;

namespace GranDrust.AI.Implementation.Actions
{
    public class TakePuck : ActionBase
    {
        protected override void Do()
        {
            Move.Turn = Self.GetAngleTo(Current.World.Puck);
            Move.SpeedUp = 1.0D;
            Move.Action = ActionType.TakePuck;
        }
    }
}
