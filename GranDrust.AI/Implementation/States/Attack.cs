using System;
using System.Collections.Generic;

using GranDrust.AI.Core;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Decisions;
using GranDrust.AI.Implementation.Actions;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Helpers;

namespace GranDrust.AI.Implementation.States
{
    public class Attack : TeamState
    {
        public Attack()
        {
            StateType = TeamStateType.Attack;

            Init();
        }

        private void Init()
        {
            Start = new SmartDecision
            {
                Condition = () => Current.World.Puck.OwnerHockeyistId == Current.Hockeyist.Id,
                YesNode = new SmartDecision
                        {
                            Condition = () =>
                            {
                                var opponent = Current.World.GetOpponentPlayer();
                                return Current.Hockeyist.GetDistanceTo(opponent.NetFront, PlayerHelper.GetPlayerYCenterNetCoordinate(opponent)) <= Current.World.Width / 2.8D;
                            },
                            YesNode = new SmartDecision
                                    {
                                        Condition = () =>
                                        {
                                            var opponent = Current.World.GetOpponentPlayer();
                                            return (Current.Hockeyist.State != HockeyistState.Swinging)
                                                    && Math.Abs(Current.Hockeyist.X - opponent.NetFront) < Math.Abs((opponent.NetFront - opponent.NetBack) * 4.3D);  //TODO: write out to specific const
                                        },
                                        YesNode = new TakeShotPossition(),
                                        //new SmartDecision {
                                        //    Condition = () => {
                                        //        var minDistance = 200.0D;

                                        //        foreach (var hock in Current.World.Hockeyists)
                                        //        {
                                        //            if (!hock.IsTeammate && hock.Type != HockeyistType.Goalie)
                                        //            {
                                        //                var nd = Current.World.Puck.GetDistanceTo(hock);

                                        //                if (minDistance > nd)
                                        //                    minDistance = nd;
                                        //            }
                                        //        }

                                        //        return minDistance < Current.Hockeyist.Radius + 0.5D + Current.Game.StickLength;

                                        //    },
                                            
                                        //    YesNode = new TakePass(),
                                        //    NoNode = new TakeShotPossition()
                                        //},
                                        NoNode = new Strike()

                                    },
                            NoNode = new SmartDecision
                            {
                                Condition = () => Current.Hockeyist.State == HockeyistState.Swinging,
                                YesNode = GameStates.CancelStrikeAction,
                                NoNode =  new SmartDecision
                                            {
                                                Condition = () =>
                                                {
                                                    var opponent = Current.World.GetOpponentPlayer();
                                                    var futureY = Current.Hockeyist.Y + 4.0D * Current.Hockeyist.SpeedY;
                                                    return (opponent.NetBottom > futureY && futureY > opponent.NetTop);
                                                },
                                                YesNode = new GoToSide(),
                                                NoNode = new MoveToNet()
                                            }

                            }

                        },
                NoNode =
                  new Cover()
            };
        }
    }
}