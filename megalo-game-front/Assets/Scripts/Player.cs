using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bullet;
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
            Shot();
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


    void Shot()
    {

        Instantiate(bullet, transform.position, transform.rotation);
    }

}
