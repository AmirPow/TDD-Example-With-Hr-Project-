using System;
using HR.Framework.Core.ApplicationService;
using HR.Framework.Core.DependencyInjection;

namespace HR.Framework.Application
{
    public class TransactionalCommandHandler<TCommand>:ICommandHandler<TCommand> where TCommand:Command
    {
        private readonly ICommandHandler<TCommand> commandHandler;
        private readonly IDiContainer  diContainer;

        public TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler , IDiContainer diContainer)
        {
            this.commandHandler = commandHandler;
            this.diContainer = diContainer;
        }

        public void Execute(TCommand command)
        {
            var unitOfWork = diContainer.Resolve<IUnitOfWork>();
            try
            {
                commandHandler.Execute(command);
                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                unitOfWork.RollBack();
                throw;
            }
        }
    }
}
