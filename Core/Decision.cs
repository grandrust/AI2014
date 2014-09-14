using System;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core
{
    public abstract class Decision: HokeyNode
    {
        protected abstract HokeyNode Branch { get; set; }

        public override void Decide()
        {
            Branch.Decide();
        }
    }
}
