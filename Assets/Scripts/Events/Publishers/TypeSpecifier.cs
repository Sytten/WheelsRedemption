﻿using System;

public class TypeSpecifier<TBase, TDerived> : IEventSubscriber<TBase> where TDerived : TBase where TBase : IEvent {

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

    public override bool Equals(object obj) {
        if (obj == null) {
            return false;
        }

        return inner.Equals(obj);
    }

    public override int GetHashCode() {
        return inner.GetHashCode();
    }
}