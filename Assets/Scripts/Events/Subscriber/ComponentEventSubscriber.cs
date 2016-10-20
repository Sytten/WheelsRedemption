using UnityEngine;
using System.Collections;

public abstract class ComponentEventSubscriber<T> : MonoBehaviour, IEventSubscriber<T> {

    public virtual void Handle(T data) {
    }
}