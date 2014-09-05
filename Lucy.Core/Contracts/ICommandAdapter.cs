using Lucy.Core.Model;

namespace Lucy.Core.Contracts
{
    public interface ICommandAdapter
    {
        Command Translate(string message);
    }
}
