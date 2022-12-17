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
        Debug.Log("OnConnectedToMaster");
        ConnectLog.text = "OnConnectedToMaster";
        var roomOpt = new RoomOptions();
        roomOpt.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("Room",new RoomOptions(), TypedLobby.Default);
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        ConnectLog.text = "OnJoinedRoom";
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        Vector3 pos, rot;
        pos = new Vector3(-8f, UnityEngine.Random.Range(-4.0f, 4.1f),0f);
        rot = new Vector3(0f, 0f, 0f);
        PhotonNetwork.Instantiate("Player", pos, Quaternion.Euler(rot));
        Invoke("LastMsg", 2f);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
        
        
        ConnectLog.text = "OnCreatedRoom";
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
