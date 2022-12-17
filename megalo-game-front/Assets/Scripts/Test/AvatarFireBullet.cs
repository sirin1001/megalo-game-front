using Photon.Pun;
using UnityEngine;

public class AvatarFireBullet : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerBullet bulletPrefab = default;

    private void Update() {
        if (photonView.IsMine) {
            // 左クリックでカーソルの方向に弾を発射する
            if (Input.GetMouseButtonDown(0)) {
                var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x);
                
                Vector3 Kakudo = new Vector3(0f,0f,angle);
                photonView.RPC("FireBullet",RpcTarget.All,Kakudo);
            }
        }
    }

    [PunRPC]
    // 弾を発射するメソッド
    private void FireBullet(Vector3 angle) {
        var Fbullet = Instantiate(bulletPrefab,transform.position, Quaternion.Euler(angle));
    }
}