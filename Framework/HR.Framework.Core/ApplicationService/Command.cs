using System;

namespace HR.Framework.Core.ApplicationService
{
    public abstract class Command
    {
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
        public  DateTime TimeStamp { get; }
    }
}
