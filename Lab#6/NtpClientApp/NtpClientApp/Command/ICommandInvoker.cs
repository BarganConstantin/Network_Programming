
namespace NtpClientApp.Command
{
    public interface ICommandInvoker
    {
        ICommand Invoke(string option);
        void printCommandMenu();
    }
}
