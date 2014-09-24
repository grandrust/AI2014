using System;
using System.Collections.Generic;

using GranDrust.AI.Core;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Decisions;
using GranDrust.AI.Implementation.Actions;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

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
                            Condition = () => { 
                                var opponent = Current.World.GetOpponentPlayer();
                                return Current.Hockeyist.GetDistanceTo(opponent.NetFront, (opponent.NetBottom + opponent.NetTop) / 2) <= Current.World.Width / 2.8D;
                            },
                            YesNode = new SmartDecision
                                    {
                                        Condition = () => {
                                            var opponent = Current.World.GetOpponentPlayer();
                                            return (Current.Hockeyist.State != HockeyistState.Swinging)
                                                    && Math.Abs(Current.Hockeyist.X - opponent.NetFront) < Math.Abs((opponent.NetFront - opponent.NetBack) * 2.0D);  //TODO: write out to specific const
                                        },
                                        YesNode = new TakeShotPossition(),
                                        NoNode = new Strike()

                                    },                            
                            NoNode = new SmartDecision
                                    {
                                        Condition = () => {
                                            var opponent = Current.World.GetOpponentPlayer();
                                            return (opponent.NetBottom > Current.Hockeyist.Y && Current.Hockeyist.Y > opponent.NetTop);
                                        },
                                        YesNode = new GoToSide(),
                                        NoNode =  new MoveToNet()
                                    }

                        },
                NoNode = new Cover()
            };
        }
    }
}