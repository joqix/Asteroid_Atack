using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    [Header("NAVES")]
    [SerializeField] private GameObject[] prefabJugadores;
    private GameObject jugador;
    int id;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                id = 0;
            }
            else
            {
                id = 1;
            }
            jugador = PhotonNetwork.Instantiate(prefabJugadores[id].name, new Vector3(0, 0, 0), Quaternion.identity, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
