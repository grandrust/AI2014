using System;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core
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
