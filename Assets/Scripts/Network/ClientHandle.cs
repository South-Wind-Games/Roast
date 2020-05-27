using UnityEngine;

namespace Network
{
    public class ClientHandle : MonoBehaviour
    {
        public static void Welcome(Packet packet)
        {
            var message = packet.ReadString();
            var id = packet.ReadInt();

            Debug.Log($"Message from server {message}");

            Client.Instance.ID = id;

            ClientSend.WelcomeReceived();
        }
    }
}