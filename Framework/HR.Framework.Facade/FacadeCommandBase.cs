using HR.Framework.Core.ApplicationService;
using HR.Framework.Core.Facade;

namespace HR.Framework.Facade
{
    public abstract class FacadeCommandBase : ICommandFacade
    {
        protected readonly ICommandBus commandBus;

        protected FacadeCommandBase(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
    }
}
