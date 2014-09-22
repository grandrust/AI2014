using System;
using System.Collections.Generic;

using GameAction = GranDrust.AI.Core.Action;

namespace GranDrust.AI.Implementation.Actions
{
    public class ScriptAction : GameAction
    {
        public Action Action { get; set; } 

        public override void Do()
        {
            Action();
        }
    }
}
