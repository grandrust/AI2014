using System;

namespace GranDrust.AI.Core
{
    public abstract class Action : INode
    {
        public void Decide()
        {
            Do();
        }

        public abstract void Do();
    }
}
