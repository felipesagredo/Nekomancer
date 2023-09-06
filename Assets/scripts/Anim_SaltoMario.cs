using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_SaltoMario : MonoBehaviour
{
    public float fuerzaSalto = 10f; // Fuerza del salto
    public float alturaMaxima = 2f; // Altura máxima del salto
    public bool enSuelo = true; // Indicador de si el personaje está en el suelo

    private Animator anim;
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D
    private float alturaInicial; // Altura inicial del salto
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D
        alturaInicial = transform.position.y; // Obtener la altura inicial del personaje
    }

    void Update()
    {
        // Detectar el salto cuando se presiona la tecla de espacio o se toca la pantalla
        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && enSuelo)
        {
            // Aplicar la fuerza del salto al Rigidbody2D
            enSuelo = false; // Indicar que el personaje ya no está en el suelo
            anim.SetBool("Salta", true);
            anim.SetBool("Pisa", false);
            alturaInicial = transform.position.y; // Actualizar la altura inicial del salto
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        // Detectar la altura máxima alcanzada y detener el salto
        if (transform.position.y - alturaInicial >= alturaMaxima)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // Detener el movimiento vertical
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar la colisión con el suelo y permitir un nuevo salto
        if (collision.gameObject.tag == "Suelo")
        {
            anim.SetBool("Salta", false);
            anim.SetBool("Pisa", true);

            enSuelo = true; // Indicar que el personaje está en el suelo
        }
        else
        {   // En el aire
            anim.SetBool("Sujeta", false);
            anim.SetBool("Pisa", false);
        }

        if (collision.contacts[0].normal == Vector2.up)
        {
            Debug.Log("Suelo");
            anim.SetBool("Sujeta", false);
        }
        else if (collision.contacts[0].normal == Vector2.down)
        {
            Debug.Log("Techo");
        }
        else if (collision.contacts[0].normal == Vector2.left)
        {
            Debug.Log("Lado izquierdo");
            anim.SetBool("Sujeta", true);
        }
        else if (collision.contacts[0].normal == Vector2.right)
        {
            Debug.Log("Lado derecho");
            anim.SetBool("Sujeta", true);
        }

    }
}
