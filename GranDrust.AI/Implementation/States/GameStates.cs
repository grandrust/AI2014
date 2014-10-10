using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Actions;
using GranDrust.AI.Helpers;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Implementation.Decisions;

namespace GranDrust.AI.Implementation.States
{
    public static class GameStates
    {
        private static Dictionary<TeamStateType, TeamState> states = null;
        public static TeamStateType CurrentState { get; private set; }

        public static void Init()
        {
            states = new Dictionary<TeamStateType, TeamState>();
            states.Add(TeamStateType.Occupy, new Occupy()); // TODO: used only at start. interchangable with Defense
            states.Add(TeamStateType.Attack, new Attack());
            states.Add(TeamStateType.Defense, new Defense());
            states.Add(TeamStateType.SafeNet, new SafeNet());
            
            CurrentState = TeamStateType.Occupy;
        }

        public static void Play()
        {
            var me = Current.World.GetMyPlayer();
            var opponent = Current.World.GetOpponentPlayer();

            if (PlayerHelper.IsFreezeTime())
            {
                Current.Stratagy.State = TeamStateType.Occupy;
                Current.SaferCount = 0;
            }

            if (Current.Stratagy.State == TeamStateType.SafeNet)
            {
                CurrentState = TeamStateType.SafeNet;

                if (Current.World.Puck.OwnerHockeyistId == Current.Hockeyist.Id)
                {
                    Current.Stratagy.State = CurrentState = TeamStateType.Attack;
                    Current.SaferCount--;
                }
            }
            else
            {
                if (Current.World.Puck.OwnerPlayerId == me.Id)
                    CurrentState = TeamStateType.Attack;
                else
                    CurrentState = TeamStateType.Occupy;

                if (Current.World.Puck.OwnerPlayerId == opponent.Id)
                    CurrentState = TeamStateType.Defense;
            }
            
            states[CurrentState].Start.Decide();
        }

        private static Actions.Base.ActionBase _cancelStrikeAction;
        public static Actions.Base.ActionBase CancelStrikeAction
        {
            get
            {
                if (_cancelStrikeAction == null)
                    _cancelStrikeAction = new ScriptAction { Action = () => Current.Move.Action = ActionType.CancelStrike };
                return _cancelStrikeAction;
            }
        }

        public static SmartDecision InSwingingState
        {
            get
            {
                return new SmartDecision { Condition = () => Current.Hockeyist.State == HockeyistState.Swinging };
            }
        }


    }
}
