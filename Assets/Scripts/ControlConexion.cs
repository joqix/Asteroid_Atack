using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlConexion : MonoBehaviourPunCallbacks
{
    [Header("inputField")]
    [SerializeField] private Text txtNombreJugador;
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI txtBarraDeEstado;
    [Header("Buttons")]
    [SerializeField] private Button btnConectar;
    [SerializeField] private Button btnJugar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pulsar_BtnConectar()
    {
        if (!string.IsNullOrEmpty(txtNombreJugador.text) || !string.IsNullOrWhiteSpace(txtNombreJugador.text))
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = txtNombreJugador.text;
            RoomOptions opcionesSala = new RoomOptions();
            opcionesSala.MaxPlayers = 2;
            PhotonNetwork.JoinOrCreateRoom("Sala", opcionesSala, TypedLobby.Default);
        }
        else
        {
            txtBarraDeEstado.text = "Indica un nombre de usuario para conectar";
        }

    }

    public override void OnConnected()
    {
        //base.OnConnected();

        txtBarraDeEstado.text = "Conectado a Photon";
    }

    public override void OnCreatedRoom()
    {
        txtBarraDeEstado.text = "Sala creada";
    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        txtBarraDeEstado.text = "Sala no creada ERROR " + returnCode + ": " + message;
    }

    public override void OnJoinedRoom()
    {
        txtBarraDeEstado.text = "Te has unido a la sala";
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        txtBarraDeEstado.text = "Error al unirse a la sala, Error: " + returnCode + ": " + message;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        txtBarraDeEstado.text = newPlayer.NickName + " se ha unido a la sala";
        txtBarraDeEstado.text = PhotonNetwork.CurrentRoom.PlayerCount+"/2";
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        txtBarraDeEstado.text = player.NickName + " ha abandonado la sala";
        txtBarraDeEstado.text = PhotonNetwork.CurrentRoom.PlayerCount + "/2";
    }

    public void PulsarBTNJugar()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("Multiplayer");
        }
    }

}