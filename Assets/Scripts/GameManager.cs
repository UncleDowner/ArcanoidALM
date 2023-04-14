using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Librería para poder acceder a los TextMeshPro
using UnityEngine.UI; //Librería para acceder a los componentes de la UI
using UnityEngine.SceneManagement;//Para cambiar entre escenas

public class GameManager : MonoBehaviour
{
    //Referencias a los objetos que queremos que se activen o desactiven
    public GameObject ball, racket;

    //Referencia para las imágenes de las vidas
    public Image live1, live2, live3;

    //Texto de GameOver
    public TextMeshProUGUI gameOverText, puntuation;
    int score;

    /*
    public AudioSource audioB;
    public AudioClip audioS;
    */

    //iniciamos el contador de vida
    public int lives = 3;

    //Hacemos un Singleton del script GM, para poder usar sus propiedades desde cualquier script
    public static GameManager sharedInstance;

    private void Awake()
    {
        //Primero comprobamos si la instancia del Singleton está vacía
        if(sharedInstance == null)
            //La relleno con todo el contenido de este código
            sharedInstance = this;
    }

    //Referencia para guardar la dirección de la pelota
    Vector2 direction;

    private bool check;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //Descativamos la imagen GameOver
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Controlamos las imágenes de las vidas, dependiendo de cuantas nos quedan
        //Si nos quedan menos de 3 vidas
        /* if(lives < 3)
         {
             //Desactivamos la imagen de la vida 3
             live3.enabled = false;//enabled desactiva un componente de un GO
         }
         //Si nos quedan menos de 2 vidas
         if (lives < 2)
         {
             //Desactivamos la imagen de la vida 2
             live2.enabled = false;//enabled desactiva un componente de un GO
         }
         //Si nos quedan menos de 1 vidas
         if (lives < 1)
         {
             //Desactivamos la imagen de la vida 1
             live1.enabled = false;//enabled desactiva un componente de un GO
         }*/
        //Nos damos cuenta de que al ver el valor de una sola variable, podemos sustituir lo de arriba por un swtich
        puntuation.text = "Puntuation: " + score.ToString();
        switch (lives)
        {
            //En el caso que las vidas sean 3
            case 3:
                //Activamos la imagen de la vida 3
                live3.enabled = true;
                //Activamos la imagen de la vida 2
                live2.enabled = true;
                //Activamos la imagen de la vida 1
                live1.enabled = true;
                break;
            //En el caso que las vidas sean 2
            case 2:
                //Activamos la imagen de la vida 3
                live3.enabled = false;
                //Activamos la imagen de la vida 2
                live2.enabled = true;
                //Activamos la imagen de la vida 1
                live1.enabled = true;
                break;
            //En el caso que las vidas sean 1
            case 1:
                //Activamos la imagen de la vida 3
                live3.enabled = false;
                //Activamos la imagen de la vida 2
                live2.enabled = false;
                //Activamos la imagen de la vida 1
                live1.enabled = true;
                break;
            //En el caso que las vidas sean 0
            case 0:
                //Activamos la imagen de la vida 3
                live3.enabled = false;
                //Activamos la imagen de la vida 2
                live2.enabled = false;
                //Activamos la imagen de la vida 1
                live1.enabled = false;
                Invoke("LostScene", 2.0f);
                //Activamos la imagen GameOver
                gameOverText.enabled = true;
                break;
            //En cualquier otro caso
            default:
                //Activamos la imagen de la vida 3
                live3.enabled = false;
                //Activamos la imagen de la vida 2
                live2.enabled = false;
                //Activamos la imagen de la vida 1
                live1.enabled = false;
                break;
        }

        //Vamos a contar cuantos bloques hay en esta partida
        //Creamos un array donde meter todos los bloques que tenemos en esta partida
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("NormalBlock");
        //FindGameObjectsWithTag = busca objectos por etiqueta
        //Si el tamaño del array es 0 (osea se ha quedado vacío, no quedan bloques)
        if (blocks.Length == 0)
        {
            //Invocamos al método para hacer el cambio de escena tras 2 segundos
            Invoke("GoToNextScene", 2.0f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exit game");
            //Esto apaga el juego
            Application.Quit();
        }

        int numberOfBlocks = GameObject.FindGameObjectsWithTag("NormalBlock").Length;

        if (numberOfBlocks <= 0)
        {
            Debug.Log("Juego completado");
        }


        if (check)
        {
            ball.transform.position = new Vector2(racket.transform.position.x, racket.transform.position.y + 0.5f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
                check = false;
            }
            
        }
    }

    public void ScoreUp()
    {
        score += 5;
    }
    //Método para cambiar entre escenas
    private void GoToNextScene()
    {
        //Cambiamos de escena yendo a la siguiente que tengamos preparada en la Build
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //BuildIndex es el número de la escena actual en los Build Settings
    }
   
    private void LostScene()
    {
        SceneManager.LoadScene("Menu");
    }

    //Método para hacer lo que ocurre al marcar un punto
    public void GoalScored()
    {
        //Ponemos la pelota al marcar un gol en la posición de origen
        //ball.transform.position = Vector2.zero; //Vector2.zero <-> new Vector2(0,0)
        //ball.transform.position = new Vector2(0, -20);
        //ball.transform.position = new Vector2(racket.transform.position.x, racket.transform.position.y + 2);
        //Aquí guardamos la velocidad en X que llevaba la pelota e invertimos su signo

        //direction = new Vector2(-ball.GetComponent<Rigidbody2D>().velocity.x, 0);

        direction = new Vector2(0, -ball.GetComponent<Rigidbody2D>().velocity.y);

        //Paramos la pelota
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //Usando Invoke esperamos X segundos antes de llamar a un Método
        //Invoke("LaunchBall", 2.0f);

        check = true;
        
    }

    //Método para hacer que la bola se lance
    void LaunchBall()
    {
        //Aplicamos esa nueva dirección a la bola
        ball.GetComponent<Rigidbody2D>().velocity = direction;
    }
}
