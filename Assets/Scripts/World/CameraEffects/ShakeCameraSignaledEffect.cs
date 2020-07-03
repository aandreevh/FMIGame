using UnityEngine;

namespace World.CameraEffects
{
    public class ShakeCameraSignaledEffect : CameraSignaledEffect
    {
        [Header("Shake params")]
        [SerializeField] private float shakeTime;
        [SerializeField] private float shakeAmount;

        protected override void TriggerEffect()
        {
            Controller.AddAsyncAfter(Controller.ShakeScreenTransition(shakeAmount, shakeTime));
        }
    }
}