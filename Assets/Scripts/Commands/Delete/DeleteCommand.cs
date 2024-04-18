namespace Scorewarrior.Test.Commands.Delete
{
	internal class DeleteCommand : ICommand
	{
        public uint Id { get; }

        public DeleteCommand(uint id)
		{
			Id = id;
		}
	}
}