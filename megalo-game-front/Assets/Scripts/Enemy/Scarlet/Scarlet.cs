using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Scarlet : MonoBehaviour
{
    [SerializeField] ScarletBullet sb;
    [SerializeField] ScarletBulletSmall sbs;
    float speed;
    int ActionPtn=0;
    int MaxPtn=2;
    public int HP = 100;
    void Start(){
        ShotSbs();
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
            case 3:
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
                for(int i=-5; i<=5; i++){
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
            case 3:
                pos = transform.position;
                rot = transform.rotation.eulerAngles;
                for(int i=0; i<=5; i++)
                {
                    pos.y = i;
                    rot.z =112f;
                    Shot(pos,rot);
                    pos.y = -i;
                    rot.z = 68f;
                    Shot(pos,rot);
                }
                break;
                
        }

        UnityEngine.Random.InitState((int)Time.time);
        // ActionPtn = 3;
        ActionPtn = UnityEngine.Random.Range(1, 4);
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
    void ShotSbs(){
        Debug.Log("[Debug] ShotSbs");
        Vector3 rot = transform.rotation.eulerAngles;
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        rot.z = UnityEngine.Random.Range(0f,361f);
        StartCoroutine( SbsMove(rot));
    }
    IEnumerator SbsMove(Vector3 rot){
        Instantiate(sbs,transform.position,Quaternion.Euler(rot));
        yield return new WaitForSeconds(0.01f);
        ShotSbs();
    }
}
