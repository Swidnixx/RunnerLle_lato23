using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float movementSpeed = 1;
	public float jumpForce = 5000;
	public Rigidbody2D rb;
	SpriteRenderer sr;

	Vector2 force;
	bool inContact;

	int punkty = 0;
	public Text punktyUI;

	private void Start()
    {
		sr = GetComponent<SpriteRenderer>();
    }
    // Wywowy³wany w ka¿dej klatce gry
    void Update()
	{
		// Collecting Input
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		bool inputJump = Input.GetButtonDown("Jump");

		// Setting Global Parameters
		force = new Vector2(inputX, inputY);


        if (inputJump && inContact)
        {
			rb.AddForce(Vector2.up * jumpForce);
		}


		if(Input.GetKeyDown(KeyCode.X))
        {
			if(rb.gravityScale == 0)
            {
				rb.gravityScale = 20;
            }
			else
            {
				rb.gravityScale = 0;
            }
        }

		// Display Debug Info
		//Debug.Log(force);
	}

    private void FixedUpdate()
    {
		rb.AddForce(force * movementSpeed);

	}

    private void OnCollisionStay2D(Collision2D collision)
    {
		if(collision.GetContact(0).normal.y > 0.75)
        {
			sr.color = Color.red;
			inContact = true;
		}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

			//Debug.Log("Collision exit: " + collision.GetContact(0).normal);
			sr.color = Color.green;
			inContact = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.tag == "Pickup")
        {
			Destroy(collision.gameObject);
			punkty++;

			punktyUI.text = "Punkty: " + punkty;
        }
    }
}
