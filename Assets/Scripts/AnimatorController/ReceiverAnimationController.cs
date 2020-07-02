using Signals.Receivers.Unary;
using UnityEngine;

namespace AnimatorController
{
    public class ReceiverAnimationController : StateMachineBehaviour
    {
        public const string TriggeredParam = "triggered";
        
        private UnaryReceiver Receiver { get; set; }
        private static readonly int Triggered = Animator.StringToHash(TriggeredParam);

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Receiver = animator.GetComponent<UnaryReceiver>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {  
            if (Receiver && Receiver.Signal)
            {
             
                animator.SetBool(Triggered, Receiver.Signal.Signaled);
            }
        }
    }
}