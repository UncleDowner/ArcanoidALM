using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBlock : MonoBehaviour
{
    public int endurance = 2;

    public Sprite hitB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(endurance == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = hitB;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Detectamos que sea la pelota el objeto contra el que hemos colisionado
        if (collision.gameObject.CompareTag("Ball"))
        {
            endurance--;
            if(endurance <= 0)
            {
                //Destruimos el objetos bloque concreto contra el que ha chocado la pelota
                Destroy(this.gameObject);
            }            
        }
    }
}
