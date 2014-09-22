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
        private static Random Rndm = new Random();

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
            Current.Stratagy = this;

            GameStates.Play();
        }

        private int randomSwingCount = 0;
        private int randomSwingCountCall = 0;
        public int RandomSwingCount { //TODO: Just for fun
            get 
            {
                if (randomSwingCountCall == randomSwingCount)
                    randomSwingCount = Rndm.Next(2, 13);

                randomSwingCountCall++;

                return randomSwingCount;
            }
        }
    }
}