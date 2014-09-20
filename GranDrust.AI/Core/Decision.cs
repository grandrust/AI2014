using System;

namespace GranDrust.AI.Core
{
    public abstract class Decision: INode
    {
        protected abstract INode Branch { get; set; }

        public void Decide()
        {
            Branch.Decide();
        }
    }
}
