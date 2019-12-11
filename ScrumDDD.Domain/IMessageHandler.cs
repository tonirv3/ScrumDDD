namespace ScrumDDD.Domain
{
    public  interface IMessageHandler<T, TReturn>
        where T:IMessage<TReturn>
    {
        TReturn Handle(T message);
    }
}