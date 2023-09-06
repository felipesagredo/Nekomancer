using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnElAire : MonoBehaviour
{
	private bool isGrounded;
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		// Salto
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			//rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			isGrounded = false;
			//anim.SetBool("Pisando", false);
		}


	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Verificar si el personaje está en el suelo
		if (collision.contacts[0].normal == Vector2.up)
		{
			isGrounded = true;
			anim.SetBool("Salto", false);
			anim.SetBool("Pisando", true);
        }
        else
        {
			anim.SetBool("Pisando", false);
			anim.SetBool("Camina", false);
		}

	}

}