using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Scarlet : MonoBehaviour
{
    [SerializeField] ScarletBullet sb;
    float speed;
    int ActionPtn=0;
    int MaxPtn=2;
    void Start(){
        transform.position = new Vector3(11f,0f,0f);
        Action();
    }
    void Action(){
        MovePtn();
    }

    void MovePtn(){
        switch(ActionPtn)
        {
            case 0:
                StartCoroutine( Move( new Vector3(7f,0f,0f)));
                break;
            case 1:
                StartCoroutine( Move( new Vector3(7f,0f,0f)));
                break;
            case 2:
                StartCoroutine( Move( new Vector3(7f,0f,0f)));
                break;
        }
    }
 
    IEnumerator Move(Vector3 targetPos){
        while(transform.position != targetPos){
            transform.position = Vector3.MoveTowards(transform.position,targetPos,5f*Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        ShotPtn();
        
    }
    void ShotPtn(){
        Vector3 pos;
        Vector3 rot;
        switch(ActionPtn)
        {
            case 0:
                break;

            case 1:
                pos = transform.position;
                rot = new Vector3(0f,0f,90f);
                pos.x = transform.position.x - 2;
                for(int i=-4; i<=4; i++){
                    pos.y = i;
                    Shot(pos,rot);
                }
                break;

            case 2:
                pos = transform.position;
                for(int i=90;i<=270; i+=15){
                    pos.x = transform.position.x + Mathf.Cos(i * Mathf.Deg2Rad);
                    pos.x += (pos.x - transform.position.x) * 0.5f;
                    pos.y = transform.position.y + Mathf.Sin(i * Mathf.Deg2Rad);
                    pos.y += (pos.y - transform.position.y) * 0.5f;
                    pos.z = 0f;

                    rot.x = 0f;
                    rot.y = 0f;
                    rot.z = i-90;

                    Shot(pos,rot);
                }
                break;
                
        }

        UnityEngine.Random.InitState((int)Time.time);
        ActionPtn = UnityEngine.Random.Range(1, 3);
        Debug.Log("[Debug] ActionPtn " + ActionPtn);
        Action();
    }

    void Shot(Vector3 Pos,Vector3 Rot){
        Instantiate(sb,Pos,Quaternion.Euler(Rot));

        

        // Vector3[] Pos = new Vector3[5];
        // Array.Fill(Pos,transform.position);
        // Vector3[] Rot = new Vector3[5];
        // Array.Fill(Rot,transform.rotation.eulerAngles);
    }
}
