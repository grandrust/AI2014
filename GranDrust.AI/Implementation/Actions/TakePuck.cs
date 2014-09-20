using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GameAction = GranDrust.AI.Core.Action;

namespace GranDrust.AI.Implementation.Actions
{
    public class TakePuck : GameAction
    {
        protected Move Move { get { return Current.Move; } }
        public override void Do()
        {
            var self = Current.Hockeyist;

            Move.Turn = self.GetAngleTo(Current.World.Puck);
            Move.SpeedUp = 1.0D;
            Move.Action = ActionType.TakePuck;            
        } 
    }
}
