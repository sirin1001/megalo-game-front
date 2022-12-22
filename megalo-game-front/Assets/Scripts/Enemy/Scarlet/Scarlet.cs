using System.Collections;
using System.Collections.Generic;
using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scarlet : MonoBehaviourPunCallbacks
{
    [SerializeField] ScarletBullet sb;
    [SerializeField] ScarletBulletSmall sbs;
    EnemyHpBar ehb;
    float speed;
    int ActionPtn=0;
    int MaxPtn=3; // �p�^�[����+1
    public int Hp = 100;
    void Start(){
        transform.name = "Scarlet";
        ehb = GameObject.Find("EnemyHpBar").GetComponent<EnemyHpBar>();
        ehb.GetObject();
        transform.position = new Vector3(11f,0f,0f);
        Action();
        //Invoke("ShotSbs", 2f);
        
    }

    public void ShotPtnTest(){
        /* ------------------------------------------------ */
        /* Debug.Log($"ShotPtnTest: {photonView is null}"); */
        /* ------------------------------------------------ */

        ShotTest();
        photonView.RPC(nameof(ShotTest),RpcTarget.All);
        
        Invoke("ShotPtnTest",1f);
    }
    [PunRPC] private void ShotTest(){
        Instantiate(sb,new Vector3(0,0,0),Quaternion.Euler(new Vector3(0,0,0)));
    }

    void Action()
    {
        Debug.Log("[Debug] ActionPtn = " + ActionPtn);
        Debug.Log("[Debug] Action");
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
                for(int i=-3; i<=3; i+=2){
                    pos.y = i;
                    photonView.RPC("Shot",RpcTarget.All,pos,rot);
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

                    photonView.RPC(nameof(Shot),RpcTarget.All,pos,rot);
                }
                break;

            case 3:
                pos = transform.position;
                rot = transform.rotation.eulerAngles;
                for(int i=0; i<=5; i++)
                {
                    pos.y = i;
                    rot.z =112f;
                    photonView.RPC("Shot",RpcTarget.All,pos,rot);
                    pos.y = -i;
                    rot.z = 68f;
                    photonView.RPC("Shot",RpcTarget.All,pos,rot);
                }
                break;
            default:
                
                break;
                
        }

        UnityEngine.Random.InitState((int)Time.time);
        ActionPtn = UnityEngine.Random.Range(1, MaxPtn+1);
        // ActionPtn = 3;
        
        Action();
    }

    [PunRPC] void Shot(Vector3 Pos,Vector3 Rot){
        Instantiate(sb,Pos,Quaternion.Euler(Rot));

        // Vector3[] Pos = new Vector3[5];
        // Array.Fill(Pos,transform.position);
        // Vector3[] Rot = new Vector3[5];
        // Array.Fill(Rot,transform.rotation.eulerAngles);
    }
    void ShotSbs(){
        Vector3 rot = transform.rotation.eulerAngles;
        UnityEngine.Random.InitState(DateTime.Now.Millisecond);
        rot.z = UnityEngine.Random.Range(0f,361f);
        StartCoroutine( SbsMove(rot));
    }
    IEnumerator SbsMove(Vector3 rot){
        Instantiate(sbs,transform.position,Quaternion.Euler(rot));
        yield return new WaitForSeconds(0.5f);
        ShotSbs();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player"){
            ehb.Damage();
        }
    }
    public void Dead()
    {
        BattleManager.isWin = true;
        Destroy(gameObject);
        ChangeResultScene();
    }
    void ChangeResultScene()
    {
        Debug.Log("ChangeScene");
        SceneManager.LoadScene("ResultScene");
    }
}
