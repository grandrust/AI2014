using System;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Actions;
using GranDrust.AI.Implementation.Decisions;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

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
            Start = new SmartDecision
            {
                Condition = () => Current.Hockeyist.State == HockeyistState.Swinging
            }
            .Yes(new ScriptAction
                      {
                          Action = () => Current.Move.Action = ActionType.CancelStrike
                      }
            )
            .No(new TakePuck());
        }
    }
}
