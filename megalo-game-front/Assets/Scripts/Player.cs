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
        //âE
        if(Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(10, 0, 0);
        }
        //ç∂
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(-10, 0, 0);
        }
        //è„
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.transform.Translate(0, 10, 0);
        }
        //â∫
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.Translate(0, -10, 0);
        }
        
        
    }


    void Shot()
    {
        
        

    }

}

