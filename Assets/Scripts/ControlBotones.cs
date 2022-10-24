using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBotonJugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void OnBotonSalir()
    {
        Application.Quit(); 
    }
}
