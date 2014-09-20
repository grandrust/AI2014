using System;
using System.Collections.Generic;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

using GranDrust.AI.Core;
using GranDrust.AI.Core.States;
using GranDrust.AI.Implementation;

using GranDrust.AI.Implementation.Actions;
using GranDrust.AI.Implementation.Decisions;
using GranDrust.AI.Implementation.States;

namespace Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk {
    public sealed class MyStrategy : IStrategy
    {
        public MyStrategy()
        {
            InitStates();
        }

        private void InitStates()
        {
            GameStates.Init();
        }

        public void Move(Hockeyist self, World world, Game game, Move move) 
        {
            Current.Move = move;
            Current.World = world;
            Current.Hockeyist = self;
            Current.Game = game;

            GameStates.Play();
        }
    }
}