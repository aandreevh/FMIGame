using Controller.Cam;
using Signals.Receivers.Unary;
using UnityEngine;
namespace World.CameraEffects
{
    public class CameraSignaledEffect : UnaryReceiver
    {
        [SerializeField] private CameraController controller;
        protected CameraController Controller => controller;

        [SerializeField] private bool triggerOnce = true;
        public bool TriggerOnce => triggerOnce;

        [SerializeField, HideInInspector] private bool hasTriggered;
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
        
        protected virtual void TriggerEffect(){}

        protected override void OnSignalLost()
        {
            base.OnSignalLost();
        }
    }
}