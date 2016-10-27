﻿using UnityEngine;

public abstract class SubscriberComponent<T> : MonoBehaviour, IEventSubscriber<T> where T : IEvent {

    void Start() {
        EventManager.Subscribe<T>(this);
    }

    public abstract void Handle(T eventReceived);

    void Update() {
        EventManager.UnSubscribe<T>(this);
    }
}
