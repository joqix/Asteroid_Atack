using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCubo : MonoBehaviour
{
    public GameObject esfera;
    public int puntosPorEsqivar;
    private GameObject controlJuego;

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
            controlJuego.GetComponent<GenerarCubos>().SumaPuntos(puntosPorEsqivar);
            Destroy(gameObject);
        }
    }





}
