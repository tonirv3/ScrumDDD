using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ScrumDDD.Domain
{
    public interface IMessageBus
    {
        TReturn Publish<T, TReturn>(T command)
            where T : IMessage<TReturn>;
    }
}
