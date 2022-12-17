 using Photon.Pun;
 using UnityEngine;

 public class RpcSample : MonoBehaviourPunCallbacks
 {
     private void Update() {
         // マウスクリック毎に、ルーム内のプレイヤー全員にメッセージを送信する
         if (Input.GetMouseButtonDown(0)) {
            RpcSendMessage("こんにちは");
            photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, "こんにちは");
         }
     }

    [PunRPC]
     private void RpcSendMessage(string message) {
         Debug.Log(message);
     }
 }