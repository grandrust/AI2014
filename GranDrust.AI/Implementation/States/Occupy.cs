using System;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Actions;

namespace GranDrust.AI.Implementation.States
{
    public class Occupy : TeamState
    {
        public Occupy()
        {
            StateType = TeamStateType.Occupy;

            Init();
        }

        private void Init()
        {
            Start = new TakePuck();
        }
    }
}
