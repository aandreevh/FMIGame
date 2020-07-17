using UnityEngine;

namespace Popup
{
    public class ShowedPopup : MonoBehaviour
    {
        [SerializeField] private GameObject popupObject;
        [SerializeField] private float popupTimeout;
        [SerializeField] [HideInInspector] private bool popupVisible;
        private GameObject PopupObject => popupObject;

        private bool PopupVisible
        {
            get => popupVisible;
            set => popupVisible = value;
        }

        public float PopupTimeout => popupTimeout;

        protected bool ShowPopup(Vector3 position, string text)
        {
            if (PopupVisible) return false;
            if (!PopupObject) return false;
            
            CreatePopup(position,text);
            
            return true;
        }

        private void CreatePopup(Vector3 position, string text)
        {
            var newPopup = Instantiate(PopupObject);
            var popup = newPopup.GetComponent<TextPopup>();
            
            popup.HideTimeout = PopupTimeout;
            popup.transform.position = position;
            popup.Text = text;
            popup.OnPopup += SwitchPopup;
            popup.OnHide += SwitchPopup;
        }

        private void SwitchPopup()
        {
            PopupVisible = !PopupVisible;
        }
    }
}