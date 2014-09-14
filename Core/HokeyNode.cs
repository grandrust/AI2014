using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Core
{
    public abstract class HokeyNode : INode
    {
        public abstract void Decide();

        public Hockeyist Hockeyist { get; set; }
        public World World { get; set; }
        public Game Game { get; set; }
        public Move Move { get; set; }
    }
}
