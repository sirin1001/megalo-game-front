using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarlet : MonoBehaviour
{
    [SerializeField] ScarletBullet sb;

    void Start()
    {  
        Instantiate(sb, transform.position, Quaternion.Euler(0,0,90));
    }
}
