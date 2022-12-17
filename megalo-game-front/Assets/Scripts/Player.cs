using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerBullet bullet;
    [SerializeField] GameObject targetObj;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            photonView.RPC("Shot", RpcTarget.All);
        }


    }

    void Move()
    {
        float speed = 1*Time.deltaTime;

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
            Debug.Log("damage");
            targetObj.GetComponent<PlayerHpBar>().RecvDamege();
        }
    }
}

