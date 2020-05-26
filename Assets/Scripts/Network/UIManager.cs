using UnityEngine;
using UnityEngine.UI;

namespace Network
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField]
        private GameObject startMenu;

        [SerializeField]
        private InputField usernameField;

        public void ConnectToServer()
        {
            startMenu.SetActive(false);
            usernameField.interactable = false;
            Client.Instance.ConnectToServer();
        }

        public string GetUsername()
        {
            return usernameField.text;
        }
    }
}