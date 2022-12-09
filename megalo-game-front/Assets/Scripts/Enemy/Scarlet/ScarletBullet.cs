using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarletBullet : MonoBehaviour
{
    void Start()
    {
        var scl = transform.localScale;
        scl = new Vector3(0.25f,1f,1f);
        transform.localScale = scl;
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += 1f * transform.up * Time.deltaTime;
    }
}
