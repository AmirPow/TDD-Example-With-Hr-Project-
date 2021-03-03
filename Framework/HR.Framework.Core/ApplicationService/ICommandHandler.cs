using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Framework.Core.ApplicationService
{
    public interface ICommandHandler<TCommand> : IHandler where TCommand : Command
    {
        void Execute(TCommand command);
    }
}
