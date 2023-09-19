namespace PETeca.Domain.Entities
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
