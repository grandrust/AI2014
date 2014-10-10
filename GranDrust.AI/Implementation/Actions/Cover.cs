using System;
using System.Collections.Generic;

using GranDrust.AI.Helpers;

using GranDrust.AI.Implementation.Actions.Base;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;


namespace GranDrust.AI.Implementation.Actions
{
    public class Cover : ActionBase
    {

        protected override void Do()
        {
            var myPuckOwner = PlayerHelper.GetPuckOwner();

            var me = Current.World.GetMyPlayer();
            var netYCenter = (me.NetBottom + me.NetTop) / 2.0D;

            var angle = Math.Atan2(myPuckOwner.Y - netYCenter, myPuckOwner.X - me.NetFront);

            var distance = Self.Radius * 5;

            var xDest = myPuckOwner.X - distance * Math.Cos(angle);
            var yDest = myPuckOwner.Y - distance * Math.Sin(angle);

            var a = Self.GetDistanceTo(xDest, yDest);
            var b = Math.Sqrt(Self.SpeedX * Self.SpeedX + Self.SpeedY * Self.SpeedY);


            Move.SpeedUp = a - b;
            Move.Turn = Self.GetAngleTo(xDest, yDest);
        }
    }
}
