using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{   void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene("TitleScene");
        }
    }
}
