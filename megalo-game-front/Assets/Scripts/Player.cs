using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    

    }

    void Move()
    {
        float speed = 1*Time.deltaTime;

        //âE
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed, 0, 0);
        }
        //ç∂
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed, 0, 0);
        }
        //è„
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0,speed, 0);
        }
        //â∫
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed, 0);
        }
        
        
    }


    void Shot()
    {
        
        

    }

}

