using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int endurance = 1;

    public Sprite hit;
    bool damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hit;
        }
    }

    /*Método para saber cuando algo choca contra el bloque, en nuestro caso
     * el único objeto que se mueve por la pantalla es la bola, luego solamente
     * puede ser ella la que choque contra los bloques*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detectamos que sea la pelota el objeto contra el que hemos colisionado
        if (collision.gameObject.CompareTag("Ball"))
        {
            endurance--;
            damaged = true;
            //Destruimos el objetos bloque concreto contra el que ha chocado la pelota
            if(endurance <= 0)
            {
                GameManager.sharedInstance.ScoreUp();
                Destroy(this.gameObject);
            }
                
        }
    }
}
