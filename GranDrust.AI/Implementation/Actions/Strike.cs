using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GameAction = GranDrust.AI.Core.Action;

namespace GranDrust.AI.Implementation.Actions
{
    public class Strike: GameAction
    {
        protected Move Move { get { return Current.Move; } }
        public override void Do()
        {
            var opponent = Current.World.GetOpponentPlayer();

            //foreach (var hockeyist in Current.World.Hockeyists)
            //{
            //    if (!hockeyist.IsTeammate && hockeyist.Type == HockeyistType.Goalie)
            //    {
 
            //    }
            //}

            Move.SpeedUp = 1.0D;
            Move.Turn = Current.Hockeyist.GetAngleTo(opponent.NetFront, opponent.NetBottom - Current.World.Puck.Radius);
            Move.Action = ActionType.Strike;
                     
        } 
    }
}
