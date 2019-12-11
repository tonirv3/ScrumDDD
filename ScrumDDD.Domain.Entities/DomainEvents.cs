using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities
{
    public  class DomainEvents
    {

        private   readonly List<IDomainEvent> _list;
        public  IEnumerable<IDomainEvent> Events => _list;
        public DomainEvents()
        {
            _list = new List<IDomainEvent>();
        }

        public  void AddDomainEvent<TEvent>(TEvent evt)
            where TEvent : IDomainEvent
        {
            _list.Add(evt);
        }

        public  void Clear()
        {
            _list.Clear();
        }
    }
}
