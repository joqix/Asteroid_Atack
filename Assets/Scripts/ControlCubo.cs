using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCubo : MonoBehaviour
{
    public GameObject esfera;
    public int puntosPorEsqivar;
    private GameObject controlJuego;

    public bool multiplayer;

    // Start is called before the first frame update
    void Start()
    {
        esfera = GameObject.Find("Esfera");
        controlJuego = GameObject.Find("GeneradorCubos");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Transform>().position.y < -10)
        {
            if (!multiplayer)
            {
                controlJuego.GetComponent<GenerarCubos>().SumaPuntos(puntosPorEsqivar);
            }
            else
            {
                controlJuego.GetComponent<GeberarCubosMP>().SumaPuntos(puntosPorEsqivar);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }





}
