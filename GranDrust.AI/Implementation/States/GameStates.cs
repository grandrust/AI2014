using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GranDrust.AI.Core.States;

namespace GranDrust.AI.Implementation.States
{
    public static class GameStates
    {
        private static Dictionary<TeamStateType, TeamState> states = null;
        public static TeamStateType CurrentState { get; private set; }

        public static void Init()
        {
            states = new Dictionary<TeamStateType, TeamState>();
            states.Add(TeamStateType.Occupy, new Occupy());
            states.Add(TeamStateType.Attack, new Attack());
            
            CurrentState = TeamStateType.Occupy;
        }

        public static void Play()
        {
            if (Current.World.Puck.OwnerPlayerId == Current.World.GetMyPlayer().Id)
                CurrentState = TeamStateType.Attack;
            else 
                CurrentState = TeamStateType.Occupy;

            states[CurrentState].Start.Decide();
        }
    }
}
