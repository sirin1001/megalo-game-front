using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class ConnectServer : MonoBehaviourPunCallbacks
{
    Text ConnectLog;
    void Start()
    {
        ConnectLog = GameObject.Find("ConnectLog").GetComponent<Text>();
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("ConnectedToMaster");
        ConnectLog.text = "ConnectedToMaster";
        var roomOpt = new RoomOptions();
<<<<<<< Updated upstream
        roomOpt.MaxPlayers = 2;
=======
        roomOpt.MaxPlayers = 1; // あとで２にして！！！！！！！！！！！！！
>>>>>>> Stashed changes
        PhotonNetwork.JoinOrCreateRoom("Room",roomOpt, TypedLobby.Default);
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
        ConnectLog.text = "JoinedRoom";
        
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            photonView.RPC(nameof(CloneBattleManager), RpcTarget.All);
        }

        Vector3 pos, rot;
        pos = new Vector3(-8f, UnityEngine.Random.Range(-4.0f, 4.1f),0f);
        rot = new Vector3(0f, 0f, 0f);

        PhotonNetwork.Instantiate("Player", pos, Quaternion.Euler(rot));

        Invoke("LastMsg", 2f);
    }

    [PunRPC]
    void CloneBattleManager()
    {
        Debug.Log("[Debug] CloneBAttleManager");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject("BattleManager", Vector3.zero, Quaternion.Euler(Vector3.zero));
        }
    }



    public override void OnCreatedRoom()
    {
        Debug.Log("CreatedRoom");
        
        
        ConnectLog.text = "CreatedRoom";
    }

    void LastMsg()
    {
        ConnectLog.text = "Enjoy, GoodLuck";
        Invoke("DelMsg", 1f);
    }
    void DelMsg()
    {
        ConnectLog.text = "";
    }
}
