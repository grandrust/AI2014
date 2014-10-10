using System;
using GranDrust.AI.Helpers;

using GranDrust.AI.Implementation.Actions.Base;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

namespace GranDrust.AI.Implementation.Actions
{
    public class GoToXY : ActionBase
    {
        const double AbsoluteBack = 0.069;
        const double AbsoluteFront = 0.116;
        const double e = 0.021;


        protected double X { get; set; }
        protected double Y { get; set; }
        public GoToXY(double x, double y)
        {
            X = x;
            Y = y;
        }

        protected override void Do()
        {
            var v0 = Self.GetSpeedModule();

            var me = Current.World.GetMyPlayer();

            var stopDistance = Self.GetDistanceTo(X, Y);
            var tStop = (v0 - e) / AbsoluteBack;

            var actualstopDistance = CalcDistance(v0, e, AbsoluteBack, tStop);
            var angleToPoint = Self.GetAngleTo(X, Y);

            if ((stopDistance - actualstopDistance > Self.Radius))
            {
                Move.SpeedUp = 1.0D;

                if (stopDistance < Current.World.Width / 3.1D )
                {
                    if (Math.Abs(angleToPoint) > Math.PI / 1.4D)
                    {
                        var sign = Math.Sign(angleToPoint);

                        angleToPoint -= sign * Math.PI;

                        Move.SpeedUp = -1.0D;

                    }
                }

                Move.Turn = angleToPoint;
            }
            else
            {
                Move.SpeedUp = -1.0D;
                if (stopDistance > Self.Radius)
                {
                    if (Math.Abs(angleToPoint) > Math.PI / 1.4D)
                    {
                        var sign = Math.Sign(angleToPoint);

                        angleToPoint -= sign * Math.PI;                        
                    }
                }
                else if (v0 < 0.15)
                    Move.SpeedUp = 0.0D;
            }
        }

        private double CalcDistance(double v, double e, double a, double t)
        {
            double s = 0.0D;
            var i = 0;
            var v0 = v;
            while (i < Math.Ceiling(t))
            {
                v0 = Dist(v0, a, e);
                s += v0;
                i++;
            }

            return s; //t * (v - a*0.5D*(t + 1));

        }

        private double Dist(double v, double a, double e)
        {
            return v - e * v - a;
        }
    }
}
