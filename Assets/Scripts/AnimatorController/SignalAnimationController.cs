using Signals;
using UnityEngine;

namespace AnimatorController
{
    public class SignalAnimationController : StateMachineBehaviour
    {
        [SerializeField] private string signalParam = "triggered";

        private Signal Signal { get; set; }
        private int SignalKey => Animator.StringToHash(signalParam);

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Signal = animator.GetComponent<Signal>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Signal) animator.SetBool(SignalKey, Signal.Signaled);
        }
    }
}