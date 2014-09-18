using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core
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
