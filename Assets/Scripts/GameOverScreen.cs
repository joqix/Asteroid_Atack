using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Disconnect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBotonVolver()
    {
        SceneManager.LoadScene("Menu");
    }
}
