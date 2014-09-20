using System;

using GranDrust.AI.Core;
using GranDrust.AI.Implementation.Actions;

namespace GranDrust.AI.Implementation.Decisions
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
