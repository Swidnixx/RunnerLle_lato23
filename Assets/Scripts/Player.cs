using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float movementSpeed = 1;
	public float jumpForce = 5000;
	public float doubleJumpVel = 10;
	public float antiFallingForce = 100;

	public Rigidbody2D rb;
	public Animator animator;
	SpriteRenderer sr;

	//UI
	public Text punktyUI;

	//Jumping logic
	Vector2 force;
	bool inContact;
	bool doubleJumped;
	bool jumpHeldDown;

	//Points
	int punkty = 0;

	//Game Over
	bool dead;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		animator.SetBool("appearing", true);
		Invoke(nameof(Appeared), 0.583f);
		rb.bodyType = RigidbodyType2D.Static;
	}
	public void Appeared()
    {
		rb.bodyType = RigidbodyType2D.Dynamic;
		animator.SetBool("appearing", false);
    }
	void Update()
	{
		if (dead) return;

		// Collecting Input
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		bool inputJump = Input.GetMouseButtonDown(0);
		jumpHeldDown = Input.GetMouseButton(0);

		// Setting Global Parameters
		force = new Vector2(inputX, inputY);

		//Kucanie
		if (inputY < 0)
		{
			transform.localScale = new Vector3(1, 0.5f, 1);
		}
		else
		{
			transform.localScale = Vector3.one;
		}


		if (inputJump)
		{
			if (inContact)
			{
				animator.SetTrigger("jump");
				// regular jump
				rb.AddForce(Vector2.up * jumpForce);
				doubleJumped = false;
			}
			else if (!doubleJumped)
			{
				animator.SetTrigger("jump");
				// second jump
				rb.velocity = new Vector2(0, doubleJumpVel);
				doubleJumped = true;
			}
		}


		if (Input.GetKeyDown(KeyCode.X))
		{
			if (rb.gravityScale == 0)
			{
				rb.gravityScale = 20;
			}
			else
			{
				rb.gravityScale = 0;
			}
		}

		//Animator parameters
		animator.SetFloat("velocityY", rb.velocity.y);

		// Display Debug Info
		//Debug.Log(force);
	}

	private void FixedUpdate()
	{
		rb.AddForce(force * movementSpeed);

		if (jumpHeldDown && rb.velocity.y <= 0)
		{
			rb.AddForce(new Vector2(0, antiFallingForce) - new Vector2(0, rb.velocity.y * rb.mass) / Time.fixedDeltaTime);
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.GetContact(0).normal.y > 0.75)
		{
			if (!inContact)
			{
				sr.color = Color.red;
				inContact = true;
				animator.SetBool("grounded", true);
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{

		//Debug.Log("Collision exit: " + collision.GetContact(0).normal);
		sr.color = Color.green;
		inContact = false;
		animator.SetBool("grounded", false);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Pickup")
		{
			//Destroy(collision.gameObject); // Moved to Pickup script
			punkty++;

			punktyUI.text = punkty.ToString();

			var pickup = collision.GetComponent<Pickup>();
			pickup.Collect();
		}

		if (collision.CompareTag("Obstacle"))
		{
			animator.SetTrigger("hit");
			Invoke(nameof(PlayerDead), 2);
			dead = true;
			rb.bodyType = RigidbodyType2D.Static;
			GameManager.Instance.worldSpeed = 0;
		}
	}
	void PlayerDead()
    {
		GameManager.Instance.GameOver();
	}
}
