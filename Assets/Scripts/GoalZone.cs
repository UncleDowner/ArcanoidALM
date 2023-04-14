using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Librer�a para poder acceder a los TextMeshPro

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

    //M�todo para detectar cuando algo ha entrado en el trigger(zona de gol)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Solo aquellos gameObjects etiquetados como pelota, que hayan entrado en el trigger
        if(collision.CompareTag("Ball"))
        {            
            //Sumo 1 a la puntuaci�n
            //score++; //score++ <-> score = score + 1 <-> score += 1            

            //Cambiamos el texto de las puntuaciones al valor que tenga en ese momento el score
            //scoreText.text = scoreRight.ToString();
            
            //Ejecuto el m�todo de que se ha marcado un gol, que est� programado en el GameManager
            referenceGM.GoalScored();
        }
    }
}
