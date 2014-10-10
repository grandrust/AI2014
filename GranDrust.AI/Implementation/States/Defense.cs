using System;
using System.Linq;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation.Actions;
using GranDrust.AI.Implementation.Decisions;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Helpers;

namespace GranDrust.AI.Implementation.States
{
    public class Defense : TeamState
    {
        public Defense()
        {
            StateType = TeamStateType.Defense;

            Init();
        }

        private void Init()
        {
            Start = GameStates.InSwingingState
                .Yes(GameStates.CancelStrikeAction)
                .NoNode =  new SmartDecision 
                            {
                                Condition = HasLongestDistanceToOpponent,
                                NoNode = new SmartDecision {
                                    Condition = () => !PlayerHelper.IsFreezeTime(),
                                    YesNode = new CoverNet(),
                                    NoNode = new TakePuck()                                
                                },
                                YesNode = new SmartDecision
                                        {
                                            Condition = () =>
                                            {
                                                var myGoalie = PlayerHelper.GetMyGoalie();
                                                var puckOwner = PlayerHelper.GetPuckOwner();

                                                if (myGoalie != null)
                                                    return myGoalie.GetDistanceTo(puckOwner) <= Current.World.Width / 2.3D;
                                                else
                                                    return puckOwner.GetDistanceTo(Current.World.GetMyPlayer().NetFront, puckOwner.Y) <= Current.World.Width / 1.8D;
                                            },
                                            YesNode = new StrikePuckOwner(),
                                            NoNode = new TakePuck()
                                        }
                            };
        }

        private static bool HasLongestDistanceToOpponent()
        {
            var zasranech = PlayerHelper.GetPuckOwner();
            var myDistance = Current.Hockeyist.GetDistanceTo(zasranech);

            //if (Current.SaferCount < PlayerHelper.GetTeammatesCount() - 1)
            if (Current.SaferCount < 1)
            {
                return Current.World.Hockeyists.Any( // there is no hock with less distance
                    (hock) =>
                    {
                        if (hock.IsTeammate && hock.Type != HockeyistType.Goalie && hock.TeammateIndex != Current.Hockeyist.TeammateIndex)
                        {
                            return hock.GetDistanceTo(zasranech) > myDistance;
                        }
                        return false;
                    });
            }
            return true;
        }
    }
}