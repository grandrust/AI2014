using System;
using System.Collections.Generic;

using GranDrust.AI.Helpers;

using GranDrust.AI.Implementation.Actions.Base;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using GranDrust.AI.Core;
using GranDrust.AI.Core.States;


namespace GranDrust.AI.Implementation.Actions
{
    public class CoverNet  : ActionBase
    {
        protected double XCover;
        protected double YCover;

        protected INode Node;
       
        protected override void Do()
        {
            //TODO: I don,t like this
            if (Current.Stratagy.State != TeamStateType.SafeNet)
            {
                Current.Stratagy.State = TeamStateType.SafeNet;
                Current.SaferCount++;
            }

            var myPlayer = Current.World.GetMyPlayer();

            if (Node == null)
            {
                var myGoalie = PlayerHelper.GetMyGoalie();

                if (myGoalie != null)
                    XCover = myGoalie.X + Math.Sign(myPlayer.NetFront - myPlayer.NetBack) * 1.7D * myGoalie.Radius; 
                else
                    XCover = myPlayer.NetFront + (myPlayer.NetFront - myPlayer.NetBack) * 2.0D * Self.Radius;

                YCover = PlayerHelper.GetPlayerYCenterNetCoordinate(myPlayer);

                Node = new GoToXY(XCover, YCover);
            }


            if (Self.GetDistanceTo(Current.World.Puck) < Self.Radius * 3.5D)
            {
                Move.Turn = Self.GetAngleTo(Current.World.Puck);
                Move.SpeedUp = 1.0D;
                if (Self.CanStrike(Current.World.Puck))
                {

                    if (Current.World.Puck.IsOpponentPlayerOwner())
                    {
                        Move.Action = ActionType.Strike;
                        return;
                    }

                    if (!Current.World.Puck.IsMyPlayerOwner())
                    {
                        var temp = Current.World.Puck.GetSpeedModule();
                        if (Current.World.Puck.GetSpeedModule() < 13.0D)
                            Move.Action = ActionType.TakePuck;
                        else if (Current.World.Puck.GoesIntoNet() && Math.Abs(
                                                                        Self.GetAngleTo(myPlayer.NetFront, PlayerHelper.GetMyYCenterNetCoordinate())) > Math.PI / 2.0D)
                            Move.Action = ActionType.Strike;
                        else Move.Action = ActionType.TakePuck;
                    }
                }
            }
            else
            {
                if (Self.GetDistanceTo(XCover, YCover) < Self.Radius * 1.1D)
                    Move.Turn = Self.GetAngleTo(Current.World.Puck);
                else
                    Node.Decide();
            }
        }
    }
}
