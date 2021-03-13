using System.Collections.Generic;

namespace Continental.Producao.Domain.Core
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public IList<Event> Events { get; private set; }

        public Entity()
        {
            Events = new List<Event>();
        }

        public void AddEvent(Event e)
        {
            Events.Add(e);
        }
    }
}
