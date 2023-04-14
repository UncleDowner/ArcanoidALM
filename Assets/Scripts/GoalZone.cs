using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Librería para poder acceder a los TextMeshPro

public class GoalZone : MonoBehaviour
{
    //Referencia para acceder al marcador de puntos
    public TextMeshProUGUI scoreText;
    //Variable para guardar los puntos marcados
    //int scoreLeft, scoreRight, scoreUp, scoreLow;
    
    //Creamos una referencia al GameManager
    public GameManager referenceGM;
    public Ball referenceB;

    public AudioSource audioB;
    public AudioClip audioS;

    // Start is called before the first frame update
    void Start()
    {
        
    }  

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método para detectar cuando algo ha entrado en el trigger(zona de gol)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Solo aquellos gameObjects etiquetados como pelota, que hayan entrado en el trigger
        if(collision.CompareTag("Ball"))
        {            
            //Sumo 1 a la puntuación
            //score++; //score++ <-> score = score + 1 <-> score += 1            

            //Cambiamos el texto de las puntuaciones al valor que tenga en ese momento el score
            //scoreText.text = scoreRight.ToString();
            
            //Ejecuto el método de que se ha marcado un gol, que está programado en el GameManager
            referenceGM.GoalScored();
        }
    }
}
