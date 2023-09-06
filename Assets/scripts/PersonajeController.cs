using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour{

	private Rigidbody2D rb;
	private SpriteRenderer spi;
	private Animator anim;

	public float moveSpeed = 15f;
	public float jumpForce = 8f;
	public float siCamina = 0.2f;

	private float mHorizontal;
	// se actualiza solo al iniciar
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		spi = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator>();
	}
	
	// se actualiza en cada frame
	void Update () {

		mHorizontal = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.D))
		{
			//mover animacion a la derecha
			spi.flipX = false;
			anim.SetBool("Camina", true);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			//mover animacion a la izquierda
			spi.flipX = true;
			anim.SetBool("Camina", true);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//activar animacion de salto
			anim.SetBool("Camina", false);
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		rb.velocity = new Vector2(mHorizontal * moveSpeed, rb.velocity.y);
	}
} 
