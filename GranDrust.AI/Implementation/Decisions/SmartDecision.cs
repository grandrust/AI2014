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
        }

        public INode YesNode { get; set; }

        public INode NoNode { get; set; }

        public SmartDecision Yes(INode node) // TODO: make generic
        {
            YesNode = node;
            return this;
        }

        public SmartDecision No(INode node)
        {
            NoNode = node;
            return this;
        }
    }
}
