using Controller.Cam;
using Signals.Receivers.Unary;
using UnityEngine;

namespace World.CameraEffects
{
    public class CameraSignaledEffect : UnaryReceiver
    {
        [SerializeField] private CameraController controller;
        [SerializeField] [HideInInspector] private bool hasTriggered;
        [SerializeField] private bool triggerOnce = true;
       
        protected CameraController Controller => controller;
        public bool TriggerOnce => triggerOnce;
        public bool HasTriggered
        {
            get => hasTriggered;
            set => hasTriggered = value;
        }

        protected override void OnSignalAcquired()
        {
            if (!TriggerOnce)
            {
                TriggerEffect();
            }
            else
            {
                if (!HasTriggered)
                {
                    HasTriggered = true;
                    TriggerEffect();
                }
            }
        }

        protected virtual void TriggerEffect()
        {
        }
    }
}