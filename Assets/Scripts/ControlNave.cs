using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlNave : MonoBehaviourPunCallbacks
{
    public float velocidad;
    public int vidas;
    public int balas;

    public Text texto;
    public Text textoPuntos;
    public Text textoBalas;
    public GameObject bala;
    private GenerarCubos datosJuego;


    // Start is called before the first frame update
    void Start()
    {

        texto = GameObject.Find("TxtVidas").GetComponent<Text>();
        textoPuntos = GameObject.Find("TxtPuntos").GetComponent<Text>();
        textoBalas = GameObject.Find("TxtBalas").GetComponent<Text>();
         
        vidas = 3;
        balas = 0;
        

        datosJuego = GameObject.Find("GeneradorCubos").GetComponent<GenerarCubos>();
        textoBalas.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            MoverHorizontal();
            MoverVertical();
            Disparar();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (photonView.IsMine)
        {
            if (collision.gameObject.CompareTag("Cubo"))
            {
                vidas--;
            }

            if (collision.gameObject.CompareTag("coazon"))
            {
                Debug.Log("sube");
                vidas++;

                datosJuego.ControlVidas();
            }

            if (collision.gameObject.CompareTag("arma"))
            {
                collision.gameObject.GetComponent<AudioSource>().Play();
                balas += 3;
                textoBalas.text = "Balas: " + balas;

            }

            ControlVidas();
            Destroy(collision.gameObject);
        }
    }

    public void MoverHorizontal()
    {
        //registramos la pulsaci�n
        float horizontalX = Input.GetAxis("Horizontal");

        //movimiento Horizontal
        gameObject.GetComponent<Transform>().position += new Vector3(horizontalX * velocidad * Time.deltaTime, 0, 0);
        //controlamos si nos hemos pasado
        if (gameObject.GetComponent<Transform>().position.x > 10)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(10, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
        }
        if (gameObject.GetComponent<Transform>().position.x < -10)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(-10, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
        }

    }

    public void MoverVertical()
    {
        //registramos la pulsaci�n
        float verticalY = Input.GetAxis("Vertical");

        //movimiento Horizontal
        gameObject.GetComponent<Transform>().position += new Vector3(0, verticalY * velocidad * Time.deltaTime, 0);
        //controlamos si nos hemos pasado
        if (gameObject.GetComponent<Transform>().position.y > 6.21)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, 6.21f, gameObject.GetComponent<Transform>().position.z);
        }
        if (gameObject.GetComponent<Transform>().position.y < -4.26)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, -4.26f, gameObject.GetComponent<Transform>().position.z);
        }

    }

    public void Disparar()
    {
        if (Input.GetButtonDown("Jump") && balas > 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            PhotonNetwork.Instantiate(bala.name, new Vector3(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y + 1.5f, gameObject.GetComponent<Transform>().position.z), new Quaternion(0, 0, 0, 0));
            balas--;
            textoBalas.text = "Balas: " + balas;
        }
        if (balas == 0)
        {
            textoBalas.text = "";
        }
    }

    private void ControlVidas()
    {
        if(vidas<0)
        {
            
            photonView.RPC("GameOver", RpcTarget.All);
        }
        
    }

    public int getVidas()
    {
        return vidas;
    }

    public void setVidas(int num)
    {
        vidas = num;
    }

    public void sumaVidas(int num)
    {
        vidas += num;
    }

    public string getName()
    {
        return name;
    }
    [PunRPC]
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        //PhotonNetwork.LoadLevel("GameOver");

    }
}
