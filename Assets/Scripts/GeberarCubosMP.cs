using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeberarCubosMP : MonoBehaviourPunCallbacks
{
    public GameObject cubo;
    public GameObject vida;
    public GameObject arma;
    public float tiempo;
    public float repeticion;

    private Text textoVidas;
    private Text textoPuntos;

    private int puntuacion;

    private int siguienteNivel = 50;
    // Start is called before the first frame update
    void Start()
    {
        textoVidas = GameObject.Find("TxtVidas").GetComponent<Text>();
        textoPuntos = GameObject.Find("TxtPuntos").GetComponent<Text>();
        if (PhotonNetwork.IsMasterClient)
        {
            InvokeRepeating("GenerarCubo", tiempo, repeticion);
          
            puntuacion = 0;
            ControlVidas();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
            ControlVidas();
    }

    public void GenerarCubo()
    {
        int aleatorio = Random.Range(1, 7);
        Vector3 position = new Vector3(Random.Range(-10, 11), 10, 0);
        GameObject objeto = null;

        switch (aleatorio)
        {
            case 1:
                objeto = vida;
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                objeto = cubo;
                objeto.GetComponent<ControlCubo>().puntosPorEsqivar = Random.Range(1, 6);
                break;
            case 6:
                objeto = arma;
                break;
        }

        
        PhotonNetwork.Instantiate(objeto.name, position, new Quaternion(0, 0, 0, 0));
    }



    public void ControlVidas()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            textoVidas.text = "Vidas : " + GameObject.Find("Nave(Clone)").GetComponent<ControlNave>().getVidas();
        }
        else
        {
            textoVidas.text = "Vidas : " + GameObject.Find("Nave_J2(Clone)").GetComponent<ControlNave>().getVidas();
        }
        ControlPuntuacion();
    }

   
    private void ControlPuntuacion()
    {
        textoPuntos.text = "Puntuación: " + puntuacion;


        if (puntuacion >= siguienteNivel)
        {
            siguienteNivel += 25;
            repeticion -= 0.01f;
            if (repeticion <= 0)
            {
                repeticion = 0.02f;
            }
            CancelInvoke("GenerarCubo");
            InvokeRepeating("GenerarCubo", tiempo, repeticion);
        }

    }

    

    public void SumaPuntos(int puntosASumar)
    {
        puntuacion += puntosASumar;
    }

    public void OnButtonVolver()
    {
        SceneManager.LoadScene("Menu");
    }

}
