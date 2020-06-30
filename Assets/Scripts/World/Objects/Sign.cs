using System;
using Popup;
using Signals.Emitters;
using UnityEngine;

namespace World.Objects
{
    public class Sign : ShowedPopup
    {
        [SerializeField]
        private string text;
        public string Text => text;

        [SerializeField] private Vector3 offset;
        public Vector3 Offset => offset;
        
        private bool FirstTimeFlag { get; set; }

        private InteractSignal InteractSignal { get; set; }
        private void Awake()
        {
            InteractSignal = gameObject.AddComponent<InteractSignal>();
            InteractSignal.OnSignalChangedEvent += SignalChanged;
        }

        private void SignalChanged()
        {
            if (FirstTimeFlag)
                ShowPopup(transform.position + Offset, Text);
            else FirstTimeFlag = true;
        }
    }
}