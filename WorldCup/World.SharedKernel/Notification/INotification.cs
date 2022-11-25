namespace Alunos.SharedKernel.Notification
{
    public interface INotification
    {
        void Add(string message);
        string GetNotifications();
        T AddWithReturn<T>(string message);
        bool Any();
        bool Notify(bool condition, string value);
    }
}
