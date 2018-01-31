namespace Server.Abstractions
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
