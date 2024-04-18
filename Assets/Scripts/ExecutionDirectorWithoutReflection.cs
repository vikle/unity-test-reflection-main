using System;
using System.Collections.Generic;
using Scorewarrior.Test.Commands;

namespace Scorewarrior.Test
{
    public sealed class ExecutionDirectorWithoutReflection : IExecutionDirector
    {
        private readonly Dictionary<Type, Delegate> _executorByExecutableType = new();

        public void RegisterExecutor<TCommand, TExecutor>(TExecutor executor)
            where TCommand : class, ICommand
            where TExecutor : class, IExecutor<TCommand>
        {
            var executableType = typeof(TCommand);

            if (_executorByExecutableType.ContainsKey(executableType))
            {
                throw new ArgumentException("Executor already registered");
            }

            var executionDelegate = new Action<TCommand>(executor.Execute);
            _executorByExecutableType.Add(executableType, executionDelegate);
        }

        public void Execute(ICommand command)
        {
            if (_executorByExecutableType.TryGetValue(command.GetType(), out var executor))
            {
                executor.DynamicInvoke(command);
            }
            else
            {
                throw new Exception("Executor not found");
            }
        }
    }
}
