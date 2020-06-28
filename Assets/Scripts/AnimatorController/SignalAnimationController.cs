using Signals;
using UnityEngine;

namespace AnimatorController
{
    public class SignalAnimationController : StateMachineBehaviour
    {

        public const string TriggeredParam = "triggered";
        
        private Signal Signal { get; set; }
        private static readonly int Triggered = Animator.StringToHash(TriggeredParam);

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Signal = animator.GetComponent<Signal>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Signal)
            {
                animator.SetBool(Triggered, Signal.Signaled);
            }
        }
    }
}
