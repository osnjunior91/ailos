namespace Questao5.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public string Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        protected void SetId (string id) => Id = id;

        public bool Equals(Entity? other)
        {
            return Id.Equals(other?.Id);
        }
    }
}
