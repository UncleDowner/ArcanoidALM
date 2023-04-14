using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    //Velocidad de la raqueta
    public float racketSpeed = 25;
    //El eje que quiero usar para esta pala
    public string axis = "Vertical";

    public AudioSource audioB;
    public AudioClip audioS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Ponemos FixedUpdate para que la longitud de cada frame en segundos mida lo mismo, y así el movimiento sea suavizado
    void FixedUpdate()
    {
        //Obtenemos el valor del eje asignado
        float v = Input.GetAxis(axis);
        //Debug.Log(v);
        //Accedemos al componente del Rigidbody del objeto donde está metido el script y le aplicamos una velocidad en Y
        /*if(this.gameObject.name == "RacketLeft" || this.gameObject.name == "RacketRight")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * racketSpeed;//Multiplicamos por la velocidad de movimiento => 1*25 ó -1*25
        }*/

        GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * racketSpeed;//Multiplicamos por la velocidad de movimiento => 1*25 ó -1*25
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            audioB.PlayOneShot(audioS);
        }
    }
}
