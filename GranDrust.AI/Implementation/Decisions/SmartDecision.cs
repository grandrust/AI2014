using System;

using GranDrust.AI.Core;
using GranDrust.AI.Implementation.Actions;

namespace GranDrust.AI.Implementation.Decisions
{
    public class SmartDecision : Decision
    {
        public Func<bool> Condition { get; set; }
        protected override INode Branch
        {
            get
            {
                if (Condition())
                    return YesNode;
                return NoNode;


            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public INode YesNode { get; set; }

        public INode NoNode { get; set; }
    }
}
