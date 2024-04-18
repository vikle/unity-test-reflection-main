namespace Scorewarrior.Test.Commands.Push
{
	internal class PushCommand : ICommand
	{
        public string Name { get; }

        public PushCommand(string name)
		{
			Name = name;
		}
	}
}