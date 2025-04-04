namespace Teste.Tecnologia.Domain.Entities;

public class EntityBase
{
    public EntityBase() { Id = Guid.NewGuid(); }

    public Guid Id { get; protected set; }
}
