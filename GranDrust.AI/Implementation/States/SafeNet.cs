using System;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Actions;
using GranDrust.AI.Implementation.Decisions;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Helpers;

namespace GranDrust.AI.Implementation.States
{
    public class SafeNet : TeamState
    {
        public SafeNet()
        {
            StateType = TeamStateType.SafeNet;

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
            .No(
                new SmartDecision
                {
                    Condition = () => !PlayerHelper.IsFreezeTime(),
                    NoNode = new TakePuck(),
                    YesNode = new SmartDecision 
                    { 
                        Condition = () => {

                            var minDistance = Current.World.Width;

                            foreach (var hock in Current.World.Hockeyists)
                            {
                                if (!hock.IsTeammate && hock.Type != HockeyistType.Goalie)
                                {
                                    var nd = Current.World.Puck.GetDistanceTo(hock);

                                    if (minDistance > nd)
                                        minDistance = nd;
                                }
                            }

                            return (!Current.World.Puck.IsMyPlayerOwner() &&   (Current.World.Puck.GetSpeedModule() < 9.0D ) &&  minDistance > Current.Hockeyist.GetDistanceTo(Current.World.Puck) / 2.0D) 
                                            && (Current.Hockeyist.GetDistanceTo(Current.World.GetMyPlayer().NetFront, PlayerHelper.GetMyYCenterNetCoordinate()) < Current.World.Width / 3.5D);
                        },

                        NoNode = new CoverNet(),
                        YesNode = new TakePuck()
                    }

                });
        }
    }
}
