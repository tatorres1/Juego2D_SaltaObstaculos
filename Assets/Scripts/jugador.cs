using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    public GameManager gameManager;
    public float fuerzaSalto;
    private bool estaSuelo;

    // Start is called before the first frame update
    void Start()
    {
        //listo para ser manipulado
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        estaSuelo = true;
    } 
    

    // Update is called once per frame
    void Update()
    {
        //detecta una tecla para saltar (mov)
        if(Input.GetKeyDown(KeyCode.Space) && estaSuelo)
        {
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            estaSuelo = false;
            animator.SetBool("estarSuelo", false);
        }
    }
    //para detectar la colision 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //la colisio evalua con la etiqueta suelo 
        //para que tope suelo y se dispara la anumacion
        if (collision.gameObject.tag == "Suelo") {
            estaSuelo = true;
            animator.SetBool("estarSuelo", false);
            //estaSuelo = true;
        }

        //aqui controla cuando choca o colisiona
        if(collision.gameObject.tag == "obstaculo")
        {
            gameManager.gameOver = true;
        }



    }
}
