using System;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace Network
{
    public class Client : Singleton<Client>
    {
        public static int DataBufferSize = 4096;

        private static Dictionary<int, PacketHandler> packetHandlers;

        [SerializeField]
        private string ip = "127.0.0.1";

        [SerializeField]
        private int port = 26950, myId;

        private TCP tcp;

        public int ID { get; set; }


        private void Start()
        {
            tcp = new TCP();
        }

        public void ConnectToServer()
        {
            InitializeClientData();
            tcp.Connect();
        }

        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, PacketHandler>
            {
                {(int) ServerPackets.welcome, ClientHandle.Welcome}
            };
            Debug.Log("Client data initialized");
        }

        private delegate void PacketHandler(Packet packet);

        public class TCP
        {
            private byte[] receiveBuffer;
            private Packet receivedData;
            public TcpClient socket;

            private NetworkStream stream;

            public void Connect()
            {
                socket = new TcpClient
                {
                    ReceiveBufferSize = DataBufferSize,
                    SendBufferSize = DataBufferSize
                };

                receiveBuffer = new byte[DataBufferSize];
                socket.BeginConnect(Instance.ip, Instance.port, ConnectCallback, socket);
            }

            private void ConnectCallback(IAsyncResult result)
            {
                socket.EndConnect(result);

                if (!socket.Connected) return;

                stream = socket.GetStream();

                receivedData = new Packet();

                stream.BeginRead(receiveBuffer, 0, DataBufferSize, ReceiveCallback, null);
            }

            public void SendData(Packet packet)
            {
                try
                {
                    if (socket != null)
                    {
                        stream.BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log($"Error sending data to server via TCP: {e}");
                }
            }

            private void ReceiveCallback(IAsyncResult result)
            {
                try
                {
                    var byteLength = stream.EndRead(result);
                    if (byteLength <= 0)
                        // TODO: disconnect
                        return;

                    var data = new byte[byteLength];
                    Array.Copy(receiveBuffer, data, byteLength);

                    receivedData.Reset(HandleData(data));
                    stream.BeginRead(receiveBuffer, 0, DataBufferSize, ReceiveCallback, null);
                }
                catch
                {
                    // TODO: disconnect
                }
            }

            private bool HandleData(byte[] data)
            {
                var packetLength = 0;

                receivedData.SetBytes(data);

                if (receivedData.UnreadLength() >= 4)
                {
                    packetLength = receivedData.ReadInt();
                    if (packetLength <= 0) return true;
                }

                while (packetLength > 0 && packetLength <= receivedData.UnreadLength())
                {
                    var packetBytes = receivedData.ReadBytes(packetLength);
                    ThreadManager.ExecuteOnMainThread(() =>
                    {
                        using (var packet = new Packet(packetBytes))
                        {
                            var packetId = packet.ReadInt();
                            packetHandlers[packetId](packet);
                        }
                    });
                    packetLength = 0;

                    if (receivedData.UnreadLength() >= 4)
                    {
                        packetLength = receivedData.ReadInt();
                        if (packetLength <= 0) return true;
                    }
                }

                return packetLength <= 1;
            }
        }
    }
}