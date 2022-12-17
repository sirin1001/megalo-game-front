using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BattleManager : MonoBehaviour
{
    bool isWin = false;
    public void SpawnEnemy()
    {
        Vector3 pos, rot;
        pos = new Vector3(10f, 0f, 0f);
        rot = new Vector3(0f, 0f, 0f);
        PhotonNetwork.Instantiate("Scarlet", pos, Quaternion.Euler(rot));
    }
    public void SetWin(bool result)
    {
        isWin = result;
    }
    
    public bool GetWin()
    {
        return isWin;
    }
}
