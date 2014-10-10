using System;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

namespace GranDrust.AI.Implementation
{
    public static class Current
    {
        public static Move Move { get; set; }

        public static Game Game { get; set; }

        public static World World { get; set; }

        public static Hockeyist Hockeyist { get; set; }

        public static MyStrategy Stratagy { get; set; }

        public static int SaferCount { get; set; }
    }
}
