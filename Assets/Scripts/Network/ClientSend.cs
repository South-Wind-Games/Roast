using UnityEngine;

namespace Network
{
    public class ClientSend : MonoBehaviour
    {
        private static void SendTCPData(Packet packet)
        {
            packet.WriteLength();
            Client.Instance.SendData(packet);
        }

        #region Packets

        public static void WelcomeReceived()
        {
            using (Packet packet = new Packet((int) ClientPackets.welcomeReceived))
            {
                packet.Write(Client.Instance.ID);
                packet.Write(UIManager.Instance.GetUsername());

                SendTCPData(packet);
            }
        }

        #endregion
    }
}