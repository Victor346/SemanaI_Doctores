using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkCustom : NetworkManager
{
    public int chosenCharacter = 0;
    public GameObject[] characters;
    public GameObject[] jugadores;

    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        Debug.Log("server add with message " + selectedClass);

        GameObject player;
        Transform startPos = GetStartPosition();

        if (startPos != null)
        {
            player = jugadores[chosenCharacter];
           //player = Instantiate(characters[chosenCharacter], new Vector3(0.43405f, 0.351f, 3.021807f), startPos.rotation);
            chosenCharacter++;
        }
        else
        {
            
            player = Instantiate(characters[chosenCharacter], Vector3.zero, Quaternion.identity) as GameObject;
            chosenCharacter++;
        }

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);

    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        NetworkMessage test = new NetworkMessage();
        test.chosenClass = chosenCharacter;

        ClientScene.AddPlayer(conn, 0, test);
    }


    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        //base.OnClientSceneChanged(conn);
    }

    public void btn1()
    {
        chosenCharacter = 0;
    }

    public void btn2()
    {
        chosenCharacter = 1;
    }
}