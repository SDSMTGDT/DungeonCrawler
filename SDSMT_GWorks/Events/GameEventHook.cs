﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDSMTGDT.GWorks.Events
{
    /// <summary>
    /// Used to allow subscribers and publishers to register for an event.
    /// Normally a publisher would be used for this, however there are times
    /// when we wish to allow other pieces of code to listen to an event
    /// without exposing the publisher.
    /// </summary>
    public class GameEventHook<T> : IDisposable where T : GameEventInfo
    {
        /// <summary>
        /// The event id which identifies the sink for this publisher
        /// </summary>
        public EventID<T> EVENT_ID { get; private set; }

        /// <summary>
        /// The manager to connect the publisher with the subscribers
        /// </summary>
        protected EventManager manager;

        public GameEventHook(EventManager manager, EventID<T> eventID)
        {
            this.manager = manager;
            this.EVENT_ID = eventID;
        }

        /// <summary>
        /// Registers an event listener with this publisher through the manager
        /// </summary>
        /// <param name="eventListener">A function to call when the event fires</param>
        public void registerEventListener(GameEvent<T> eventListener)
        {
            manager.registerEventListener(EVENT_ID, eventListener);
        }

        /// <summary>
        /// Registers a threaded event listener with this publisher through the manager
        /// </summary>
        /// <param name="eventListener">A function to call when the event fires</param>
        public void registerAsyncEventListener(GameEvent<T> eventListener)
        {
            manager.registerAsyncEventListener(EVENT_ID, eventListener);
        }

        /// <summary>
        /// Removes an event listener from the manager corresponding to this publisher
        /// </summary>
        /// <param name="eventListener">A function currently being called when the event fires</param>
        public void unregisterEventListener(GameEvent<T> eventListener)
        {
            manager.unregisterEventListener(EVENT_ID, eventListener);
        }

        /// <summary>
        /// Removes a threaded event listener from the manager corresponding to this publisher
        /// </summary>
        /// <param name="eventListener">A function currently being called when the event fires</param>
        public void unregisterAsyncEventListener(GameEvent<T> eventListener)
        {
            manager.unregisterAsyncEventListener(EVENT_ID, eventListener);
        }

        /// <summary>
        /// Registers an object oriented event listener with this publisher through the manager
        /// </summary>
        /// <param name="eventSubscriber">An object containing a method to call when the event fires</param>
        public void registerEventSubscriber(GameEventSubscriber<T> eventSubscriber)
        {
            manager.registerEventListener(EVENT_ID, eventSubscriber.gameEventRecieved);
        }

        /// <summary>
        /// Registers an object oriented threaded event listener with this publisher through the manager
        /// </summary>
        /// <param name="eventSubscriber">An object containing a method to call when the event fires</param>
        public void registerAsyncEventSubscriber(GameEventSubscriber<T> eventSubscriber)
        {
            manager.registerAsyncEventListener(EVENT_ID, eventSubscriber.gameEventRecieved);
        }

        /// <summary>
        /// Removes an object oriented event listener from the manager corresponding to this publisher
        /// </summary>
        /// <param name="eventSubscriber">An object containing a method which is being called when the event fires</param>
        public void unregisterEventSubscriber(GameEventSubscriber<T> eventSubscriber)
        {
            manager.registerEventListener(EVENT_ID, eventSubscriber.gameEventRecieved);
        }

        /// <summary>
        /// Removes an object oriented threaded event listener from the manager corresponding to this publisher
        /// </summary>
        /// <param name="eventSubscriber">An object containing a method which is being called when the event fires</param>
        public void unregisterAsyncEventSubscriber(GameEventSubscriber<T> eventSubscriber)
        {
            manager.unregisterAsyncEventListener(EVENT_ID, eventSubscriber.gameEventRecieved);
        }

        public virtual void Dispose()
        {
            manager.removeEvent(EVENT_ID);
            //this.EVENT_ID = null;
            //We do not set the event ID to null
            //if fire is called once this is disposed
            //the event manager will simply not do anything
            //due to the checks that are done when the eventid
            //is used to access the dictionary
        }
    }
}
