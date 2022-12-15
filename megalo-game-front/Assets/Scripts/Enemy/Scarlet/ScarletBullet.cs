using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarletBullet : MonoBehaviour
{
    float Speed = 0f;
    float Acceleration = 1.01f; // 加速度
    float MaxSpeed = 40f; // 最高速度
    SpriteRenderer sr;
    void Start()
    {
        var scl = transform.localScale;
        scl = new Vector3(0.25f,1f,1f);
        transform.localScale = scl;

        sr = GetComponent<SpriteRenderer>();

        StartCoroutine("Tojo");
    }
    IEnumerator Tojo(){
        Material material = GetComponent<Renderer>().material;
        Color32 IncreaseAlpha = new Color32(0,0,0,1);

        for(int i=0;material.color.a*255 < 255; i++)
        {
            material.color += IncreaseAlpha;
            if(i % 20 == 0){
                IncreaseAlpha.a += (byte)1;
            }
            yield return new WaitForSeconds(0.01f);
        }

        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        transform.position += Speed * transform.up * Time.deltaTime;
        if(Speed < MaxSpeed){
            Speed += Acceleration * Time.deltaTime;
        }
        if(Speed > MaxSpeed){
            Speed = MaxSpeed;
        }
        
        Acceleration += Acceleration * Acceleration * Time.deltaTime;

        if(!sr.isVisible && Speed == MaxSpeed){
            Destroy(gameObject);
        }
        yield return null; // 1フレーム待つ
        StartCoroutine("Move");
    }
}