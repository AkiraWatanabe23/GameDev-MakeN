/// <summary> 「モノ」を扱うクラスが継承するinterface </summary>
namespace ECSCommons
{
    public interface IComponent
    {
        public Entity Entity { get; set; }

        public IComponent GenericNew<T>() where T : IComponent, new() => new T();
    }
}