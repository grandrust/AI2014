using System;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation.Decisions;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk {
    public sealed class MyStrategy : IStrategy {

        int count = 0;
        public MyStrategy()
        {
 
        }

        public void Move(Hockeyist self, World world, Game game, Move move) 
        {
            Current.Move = move;
            Current.World = world;
            Current.Hockeyist = self;
            Current.Game = game;

            var decision = new Decision1();
            decision.flag = count > 2000;

            decision.Decide();

            count++;
        }
    }
}