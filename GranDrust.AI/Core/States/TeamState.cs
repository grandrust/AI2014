using System;
using GranDrust.AI.Core;

namespace GranDrust.AI.Core.States
{
    public enum TeamStateType
    {
        Attack,
        Defense,
        TakePuck
    }

    public class TeamState
    {
        public INode Start { get; set; }

        public TeamStateType StateType { get; protected set; } 
    }
}
