using System;
using System.Collections.Generic;
using System.Text;

namespace GameServer
{
    class ServerHandle
    {

        public static void WelcomeReceived(int fromClient, Packet packet)
        {
            int clientIDCheck = packet.ReadInt();
            string username = packet.ReadString();

            Console.WriteLine($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint}" +
                $"connected successfully and is now player {fromClient}.");

            if (fromClient != clientIDCheck)
            {
                Console.WriteLine($"Player \"{username}\"" +
                    $" (ID: {fromClient} was assumed the wrong client id {clientIDCheck})! ");
            }
            //TODO: Send player into game
        }
    }
}
