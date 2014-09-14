using System;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Implementation.Decisions;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk {
    public sealed class MyStrategy : IStrategy {

        int count = 0;
        public MyStrategy()
        {
 
        }

        public void Move(Hockeyist self, World world, Game game, Move move) {
            var decision = new Decision1();

            decision.Move = move;
            decision.World = world;
            decision.Hockeyist = self;
            decision.Game = game;

            decision.flag = count > 2000;

            decision.Decide();

            count++;
        }
    }
}