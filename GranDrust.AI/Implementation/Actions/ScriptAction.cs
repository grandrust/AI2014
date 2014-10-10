using System;
using System.Collections.Generic;

using GranDrust.AI.Implementation.Actions.Base;

namespace GranDrust.AI.Implementation.Actions
{
    public class ScriptAction : ActionBase
    {
        public Action Action { get; set; }

        protected override void Do()
        {
            Action();
        }
    }
}
