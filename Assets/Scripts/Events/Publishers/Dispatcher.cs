using System;
using System.Collections.Generic;

public class Dispatcher<TBase> : IEventPublisher<TBase> where TBase : IEvent {

    private readonly Dictionary<Type, Multiplexor<TBase>> subscriptions = new Dictionary<Type, Multiplexor<TBase>>();

    public void Publish(TBase data) {
        Multiplexor<TBase> multiplexor;

        if (subscriptions.TryGetValue(data.GetType(), out multiplexor)) {
            multiplexor.Handle(data);
        }
    }

    public void Subscribe<TDerived>(IEventSubscriber<TDerived> handler) where TDerived : TBase {
        Multiplexor<TBase> multiplexor;

        if (!subscriptions.TryGetValue(typeof(TDerived), out multiplexor)) {
            multiplexor = new Multiplexor<TBase>();
            subscriptions.Add(typeof(TDerived), multiplexor);
        }

        multiplexor.AttachSubscriber(new TypeSpecifier<TBase, TDerived>(handler));
    }

    public void UnSubscribe<TDerived>(IEventSubscriber<TDerived> handler) where TDerived : TBase {
        Multiplexor<TBase> multiplexor;

        if (subscriptions.TryGetValue(typeof(TDerived), out multiplexor)) {
            multiplexor.RemoveSubscriber((IEventSubscriber<TBase>) handler);
        }
    }
}