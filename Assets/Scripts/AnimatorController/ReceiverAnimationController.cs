using Signals.Receivers.Unary;
using UnityEngine;

namespace AnimatorController
{
    public class ReceiverAnimationController : StateMachineBehaviour
    {
        [SerializeField] private string signalParam = "triggered";

        private UnaryReceiver Receiver { get; set; }
        private int SignaledKey => Animator.StringToHash(signalParam);

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Receiver = animator.GetComponent<UnaryReceiver>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Receiver && Receiver.Signal) animator.SetBool(SignaledKey, Receiver.Signal.Signaled);
        }
    }
}