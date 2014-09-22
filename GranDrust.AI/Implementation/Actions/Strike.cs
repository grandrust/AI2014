using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GameAction = GranDrust.AI.Core.Action;

namespace GranDrust.AI.Implementation.Actions
{
    public class Strike: GameAction
    {
        protected Move Move { get { return Current.Move; } }
        protected Hockeyist Self { get { return Current.Hockeyist; } }

        private double topDistanse;
        private double bottomDistance;
        private double yCoordinate;

        public override void Do()  //TODO: move in different INodes
        {
            var opponent = Current.World.GetOpponentPlayer();
            Hockeyist enemyGoalie = GetEnemyGoalie();

            bottomDistance = opponent.NetBottom - enemyGoalie.Y;
            topDistanse = enemyGoalie.Y - opponent.NetTop;

            yCoordinate = (topDistanse - bottomDistance) > 0
                                    ? opponent.NetTop + Current.World.Puck.Radius
                                    : opponent.NetBottom - Current.World.Puck.Radius;

            Move.SpeedUp = 1.0D;
            Move.Turn = Self.GetAngleTo(opponent.NetFront, yCoordinate);

            if (Math.Abs(Move.Turn) <= 2.0D / 180 * Math.PI)
            {
                if (Self.SwingTicks < Current.Stratagy.RandomSwingCount)
                    Move.Action = ActionType.Swing;
                else 
                    Move.Action = ActionType.Strike;
            }
            else if (Self.State == HockeyistState.Swinging) 
                Move.Action = ActionType.Strike;
                     
        }

        private static Hockeyist GetEnemyGoalie()
        {
            Hockeyist enemyGoalie = Current.World.Hockeyists[0];

            foreach (var hockeyist in Current.World.Hockeyists)
            {
                if (!hockeyist.IsTeammate && hockeyist.Type == HockeyistType.Goalie)
                {
                    enemyGoalie = hockeyist;
                    break;
                }
            }
            return enemyGoalie;
        } 
    }
}
