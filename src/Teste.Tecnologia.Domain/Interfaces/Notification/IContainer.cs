namespace Teste.Tecnologia.Domain.Interfaces.Notification
{
    public interface IContainer
    {
        T GetService<T>(Type type);
    }
}
