using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities
{
    public static class DomainEvents
    {

        private static  readonly List<IDomainEvent> _list;
        static DomainEvents()
        {
            _list = new List<IDomainEvent>();
        }

        public static void AddDomainEvent<TEvent>(TEvent evt)
            where TEvent : IDomainEvent
        {
            _list.Add(evt);
        }

        public static void Clear()
        {
            _list.Clear();
        }
    }
}
