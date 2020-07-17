using Signals.Receivers.Unary;
using UnityEngine;

namespace World.Objects
{
    public class Door : UnaryReceiver
    {
        [SerializeField] private GameObject doorObject;

        public GameObject DoorObject => doorObject;

        protected override void OnSignalAcquired()
        {
            DoorObject.SetActive(false);
        }

        protected override void OnSignalLost()
        {
            DoorObject.SetActive(true);
        }
    }
}