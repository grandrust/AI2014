using System;
using System.Collections.Generic;

using GranDrust.AI.Core;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Decisions;
using GranDrust.AI.Implementation.Actions;

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
            Start = new SmartDecision()
            {
                Condition = () => { 
                    var opponent = Current.World.GetOpponentPlayer();
                    return Current.Hockeyist.GetDistanceTo(opponent.NetFront, (opponent.NetBottom + opponent.NetTop) / 2) <= Current.World.Width / 2.8D;
                },
                YesNode = new Strike(),
                NoNode = new MoveToNet()

            };
        }
    }
}