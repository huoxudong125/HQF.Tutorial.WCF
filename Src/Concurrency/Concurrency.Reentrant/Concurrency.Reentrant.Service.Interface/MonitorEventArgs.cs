﻿using System;

namespace Concurrency.Reentrant.Service.Interface
{
    public enum EventType
    {
        StartCall,
        EndCall,
        StartExecute,
        EndExecute,
        StartCallback,
        EndCallback,
        StartExecuteCallback,
        EndExecuteCallback
    }

    public class MonitorEventArgs : EventArgs
    {
        public int ClientId { get; private set; }
        public EventType EventType { get; private set; }
        public DateTime EventTime { get; private set; }

        public MonitorEventArgs(int clientId, EventType eventType, DateTime eventTime)
        {
            this.ClientId = clientId;
            this.EventType = eventType;
            this.EventTime = eventTime;
        }
    }
}