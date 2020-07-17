using Signals.Receivers.Unary;
using UnityEngine;
using World.Navigation;

namespace World.Objects
{
    [RequireComponent(typeof(Agent))]
    public class Mover : UnaryReceiver
    {
        private Agent Agent { get; set; }

        private void Awake()
        {
            Agent = GetComponent<Agent>();
        }

        private void FixedUpdate()
        {
            if (Signal && Signal.Signaled) Agent.UpdateAgent();
        }
    }
}