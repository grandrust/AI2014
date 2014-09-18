using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation.Actions;
using System;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation.Decisions
{
    public class Decision1 : Decision
    {
        public bool flag;
        protected override INode Branch
        {
            get
            {
                INode node;
                if (flag) node = new TestAction();
                else node = new TestAction1();

                return node;

            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
