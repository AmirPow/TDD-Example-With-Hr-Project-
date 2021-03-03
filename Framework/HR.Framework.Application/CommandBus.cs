using HR.Framework.Core.ApplicationService;
using HR.Framework.Core.DependencyInjection;

namespace HR.Framework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly IDiContainer diContainer;

        public CommandBus(IDiContainer diContainer)
        {
            this.diContainer = diContainer;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand :Command
        {
            var commandHandler = diContainer.Resolve<ICommandHandler<TCommand>>();
            var transactionalCommandHandler = new TransactionalCommandHandler<TCommand>(commandHandler , diContainer);
            transactionalCommandHandler.Execute(command);
        }
    }
}
