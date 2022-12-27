using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    [SerializeField] PlayerBullet bullet;
    [SerializeField] GameObject PlayerHpBar;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHpBar = GameObject.Find("PlayerHpBar");
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && photonView.IsMine)
        {
            photonView.RPC("Shot", RpcTarget.All);
        }


    }

    void Move()
    {
        float speed = 6f*Time.deltaTime;
        if (photonView.IsMine) { 
            //�E
            if(Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(speed, 0, 0);
            }
            //��
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(-speed, 0, 0);
            }
            //��
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(0,speed, 0);
            }
            //��
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(0, -speed, 0);
            }
        }


    }


    [PunRPC]void Shot()
    {
        for (int k=-40; k <=40; k+=20)
        {
  
            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, k)));
        }         
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            PlayerHpBar.GetComponent<PlayerHpBar>().RecvDamege();
        }
    }
}

