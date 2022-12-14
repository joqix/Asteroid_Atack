using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] private GameObject panelPrincipal;
    [SerializeField] private GameObject panelMultiplayer;
    // Start is called before the first frame update
    void Start()
    {
        ActivarPanel(panelPrincipal);
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

    public void OnBotonVolver()
    {
        ActivarPanel(panelPrincipal);
    }

    public void OnBotonMultiplayer()
    {
        ActivarPanel(panelMultiplayer);
    }

    private void ActivarPanel(GameObject panel)
    {
        panelPrincipal.SetActive(false);
        panelMultiplayer.SetActive(false);
       
        panel.SetActive(true);
    }


}
