using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para saber cuando la pelota se ha metido en la zona de muerte
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vemos si la pelota se ha metido en el trigger
        if (collision.gameObject.CompareTag("Ball"))
        {
            //Le quitamos una vida al jugador
            GameManager.sharedInstance.lives--;
            //Desactivamos la pelomta
            //collision.gameObject.SetActive(false);
            //Llamamos al m�todo que resetea la pelota
            collision.gameObject.GetComponent<Ball>().ResetBall();
            //Reproducimos el sonido de perder una vida
            GetComponent<AudioSource>().Play();
        }
    }
}
