using System;

public class TypeSpecifier<TBase, TDerived> : IEventSubscriber<TBase> where TDerived : TBase {
    private IEventSubscriber<TDerived> inner;

    public TypeSpecifier(IEventSubscriber<TDerived> inner) {
        if (inner == null) {
            throw new ArgumentNullException("inner");
        }

        this.inner = inner;
    }

    public void Handle(TBase data) {
        inner.Handle((TDerived) data);
    }
}