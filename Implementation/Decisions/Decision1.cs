using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation.Actions;
using System;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation.Decisions
{
    public class Decision1 : Decision
    {
        public bool flag;
        protected override HokeyNode Branch
        {
            get
            {
                HokeyNode node;
                if (flag) node = new TestAction();
                else node = new TestAction1();

                node.Game = Game;
                node.World = World;
                node.Hockeyist = Hockeyist;
                node.Move = Move;

                return node;

            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
