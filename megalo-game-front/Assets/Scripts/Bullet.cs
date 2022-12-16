using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        bullet();


       
    }

    void bullet()
    {
        float speed = 10;
        Vector3 velocity = gameObject.transform.rotation * new Vector3(speed, 0, 0);
        gameObject.transform.position += velocity * Time.deltaTime;

        

    }

    void OnBecameInvisible()
    {
            Destroy(gameObject);
    }






}










