using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlarEsfera : MonoBehaviour
{
    public float velocidad;
    public int vidas;
    
    public Text texto;
    public Text textoPuntos;
    // Start is called before the first frame update
    void Start()
    {
        vidas = 3;
    }

    // Update is called once per frame
    void Update()
    {
        MoverHorizontal();
        MoverVertical();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cubo"))
        {
            vidas--;
        }

        if (collision.gameObject.CompareTag("Vida"))
        {
            vidas++;
        }

        ControlVidas();
        Destroy(collision.gameObject);
    }

    public void MoverHorizontal()
    {
        //registramos la pulsación
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
        //registramos la pulsación
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

    private void ControlVidas()
    {
        if (vidas < 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
