using System;
using GranDrust.AI.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GranDrust.AI.Implementation.Actions.Base;
using GranDrust.AI.Helpers;

namespace GranDrust.AI.Implementation.Actions
{
    public class Strike: ActionBase
    {
        private double topDistanse;
        private double bottomDistance;
        private double yCoordinate;

        protected override void Do()  //TODO: refactoring
        {
            var opponent = Current.World.GetOpponentPlayer();
            Hockeyist enemyGoalie = PlayerHelper.GetEnemyGoalie();

            if (enemyGoalie != null) { 

                bottomDistance = opponent.NetBottom - enemyGoalie.Y;
                topDistanse = enemyGoalie.Y - opponent.NetTop;

                yCoordinate = (topDistanse - bottomDistance) > 0
                                        ? opponent.NetTop + Current.World.Puck.Radius
                                        : opponent.NetBottom - Current.World.Puck.Radius;
            }
            else yCoordinate = PlayerHelper.GetPlayerYCenterNetCoordinate(opponent);

            Move.SpeedUp = 1.0D;
            Move.Turn = Self.GetAngleTo(opponent.NetFront, yCoordinate);

            if (Math.Abs(Move.Turn) <= 2.0D / 180 * Math.PI)
            {
                if (enemyGoalie != null)
                    HasGoalieStrikeLogic(enemyGoalie);
                else
                    Move.Action = ActionType.Strike;

            }
            else if (Self.State == HockeyistState.Swinging)
                Move.Action = ActionType.Strike;
        }

        private void HasGoalieStrikeLogic(Hockeyist enemyGoalie)
        {
            Move.Action = Self.SwingTicks < Current.Stratagy.RandomSwingCount
                            ? ActionType.Swing
                            : ActionType.Strike;

            if (Move.Action == ActionType.Swing)
            {
                var xPossibleConnection = Math.Abs((Self.Y + Self.SpeedY * Current.Game.SwingActionCooldownTicks - enemyGoalie.Y) / Math.Tan(Self.Angle));
                double offset = 1.0D;

                if (Self.X - enemyGoalie.X > 0.0)
                    offset = -1.0D;


                var dis = UnitHelper.GetDistance(Self.X + Self.SpeedX * Current.Game.SwingActionCooldownTicks + xPossibleConnection * offset,
                                            enemyGoalie.Y,
                                            enemyGoalie.X + offset * enemyGoalie.Radius * -1.0D,
                                            enemyGoalie.Y);

                if (dis < 2.0D * enemyGoalie.Radius)
                    Move.Action = ActionType.Strike;
            }
        }
    }
}
