using Microsoft.Extensions.DependencyInjection;
using ScrumDDD.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Infrastructure
{
    public class MessageBus : IMessageBus
    {
        private readonly IServiceProvider _sp;
        public MessageBus(IServiceProvider sp)
        {
            _sp = sp;
        }
        public TReturn Publish<T, TReturn>(T command) where T : IMessage<TReturn>
        {
            
            var type = typeof(IMessageHandler<,>);
            var typeFinal = type.MakeGenericType(typeof(T));
            var handler = _sp.GetService(typeFinal) as IMessageHandler<T,TReturn>;
            return handler.Handle(command);
            
        }
    }
}
