using System;
using Com.CodeGame.CodeHockey2014.DevKit.CSharpCgdk.Model;

namespace GranDrust.AI.Implementation.Actions.Base
{
    public abstract class ActionBase : GranDrust.AI.Core.Action
    {
        protected Hockeyist Self { get { return Current.Hockeyist; } }

        protected Move Move { get { return Current.Move; } }
    }
}
