using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarletBulletSmall : MonoBehaviour
{
    
    float Speed=4;
    SpriteRenderer sr;
    void Start(){
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine("Move");
    }
    IEnumerator Move(){
        transform.position += Speed * transform.up * Time.deltaTime;
        yield return null;

        float x = transform.position.x;
        float y = transform.position.y;
        if(!(-10<x && x<10 && -6<y && y<6)){
            Destroy(gameObject);
        }
        
        StartCoroutine( Move());
    }
}
