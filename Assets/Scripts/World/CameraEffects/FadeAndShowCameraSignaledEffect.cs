using System.Collections;
using UnityEngine;
using static Controller.Cam.CameraController;

namespace World.CameraEffects
{
    public class FadeAndShowCameraSignaledEffect : CameraSignaledEffect
    {
        [SerializeField] private Transform back;
        [SerializeField] private Transform target;
        [SerializeField] private float timeoutFade = 1f;
        [SerializeField] private float timeoutShow = 1f;

        protected override void TriggerEffect()
        {
            Controller.AddSyncBefore(CreateEffect());
        }

        private IEnumerator CreateEffect()
        {
            return CombineSync(FadeAndShow(target),
                CombineSync(Controller.WaitTransition(timeoutShow), FadeAndShow(back)));
        }

        private IEnumerator FadeAndShow(Transform s)
        {
            return CombineAsync(Controller.FadeScreenTransition(timeoutFade),
                CombineSync(Controller.WaitTransition(timeoutFade),
                    Controller.SmoothGoToTransition(s.position, 10000f)));
        }
    }
}