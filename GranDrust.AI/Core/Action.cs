using System;

namespace GranDrust.AI.Core
{
    public abstract class Action : INode
    {
        public void Decide()
        {
            Do();
        }

        protected abstract void Do();
    }
}
