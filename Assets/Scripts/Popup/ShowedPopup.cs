using UnityEngine;

namespace Popup
{
    public class ShowedPopup : MonoBehaviour
    {
        [SerializeField] private GameObject popupObject;
        private GameObject PopupObject => popupObject;

        
        
        [SerializeField,HideInInspector] private bool popupVisible = false;
        private bool PopupVisible
        {
            get => popupVisible;
            set => popupVisible = value;
        }

        [SerializeField] private float popupTimeout;
        public float PopupTimeout => popupTimeout;

        protected bool ShowPopup(Vector3 position,string text)
        {
            if(PopupVisible) return false;
            if (!PopupObject ) return false;

            GameObject newPopup = Instantiate(PopupObject);
            TextPopup popup = newPopup.GetComponent<TextPopup>();
            popup.HideTimeout = PopupTimeout;
            popup.transform.position = position;
            popup.Text = text;
            popup.OnPopup += SwitchPopup;
            popup.OnHide += SwitchPopup;

            return true;
        }

        private void SwitchPopup()
        {
            PopupVisible = !PopupVisible;
        }
    }
}