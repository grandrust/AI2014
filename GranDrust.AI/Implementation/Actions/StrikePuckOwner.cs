using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GranDrust.AI.Implementation.Actions.Base;
using GranDrust.AI.Helpers;

namespace GranDrust.AI.Implementation.Actions
{
    public class StrikePuckOwner : ActionBase
    {
        protected override void Do()
        {
            var puckOwner = PlayerHelper.GetPuckOwner();

            Move.Turn = Self.GetAngleTo(puckOwner);
            Move.SpeedUp = 1.0D;

            if (Self.CanStrike(puckOwner))
                Move.Action = ActionType.Strike;
            else
                Move.Action = ActionType.TakePuck;
        } 
    }
}
