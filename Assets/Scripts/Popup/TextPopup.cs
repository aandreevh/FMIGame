using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Popup
{
    public class TextPopup : MonoBehaviour
    {
        [SerializeField] private string text;

        public string Text
        {
            get => text;
            set {
            text = value;
            TextComponent.text = text;
            }
}

        [SerializeField] private float hideTimeout;
        public float HideTimeout {
            get => hideTimeout;
            set => hideTimeout = value;
        }
        
        [SerializeField] private float timeout;
        public float Timeout
        {
            get => timeout;
            private set => timeout = value;
        }
        

        public event Action OnPopup;
        public event Action OnHide;

        private Text TextComponent { get; set; }

        private void Awake()
        {
            TextComponent = GetComponent<Text>();
        }

        private void Start()
        {
            OnPopup?.Invoke();
            SetupTimeout();
        }

        private void SetupTimeout()
        {
            if(Timeout <=0)  Timeout = HideTimeout;
            StartCoroutine(nameof(TimeoutCoroutine));
        }

        private IEnumerator TimeoutCoroutine()
        {
          
            while (true)
            {
                Timeout -= Time.deltaTime;
                if (Timeout <= 0)
                {
                    OnHide?.Invoke();
                    Destroy(this.gameObject);
                    yield break;
                }

                yield return null;
            }
        }

        private void OnValidate()
        {
            TextComponent = GetComponent<Text>();
            Text = text;
        }
    }
}