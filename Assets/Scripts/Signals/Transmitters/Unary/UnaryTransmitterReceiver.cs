using System;
using Signals.Receivers.Unary;
using UnityEngine;

namespace Signals.Transmitters.Unary
{
    public class UnaryTransmitterReceiver : UnaryReceiver
    {
        
        private UnaryTransmitter Transmitter { get; set; }
        protected void Awake()
        {
            Transmitter = GetComponent<UnaryTransmitter>();
        }

        protected override void OnSignalAcquired()
        {
            Transmitter.UpdateTransmitter(Signal);
        }

        protected override void OnSignalLost()
        {
            Transmitter.UpdateTransmitter(Signal);
        }
    }
}