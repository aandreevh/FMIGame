using UnityEngine;

namespace World.CameraEffects
{
    public class ShakeCameraSignaledEffect : CameraSignaledEffect
    {
        [SerializeField] private float shakeAmount;
        [Header("Shake params")] [SerializeField] private float shakeTime;

        protected override void TriggerEffect()
        {
            Controller.AddAsyncAfter(Controller.ShakeScreenTransition(shakeAmount, shakeTime));
        }
    }
}