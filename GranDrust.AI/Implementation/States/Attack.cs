using System;
using System.Collections.Generic;

using GranDrust.AI.Core;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Decisions;

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
            Start = new Decision1();
        }
    }
}
