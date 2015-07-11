using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private float speed = 2f;
	[SerializeField] private float jumpForce = 100f;
	[SerializeField] private float groundedTreshhold = .5f;

	private float move = 0f;
	private bool grounded = false;
	private GameObject groundedOn = null;
	private Rigidbody2D body;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D collidee)
	{
		//if(collidee.gameObject.GetComponent<Rigidbody2D>().isKinematic)
		//{
			foreach(ContactPoint2D contact in collidee.contacts)
			{
				if (contact.normal.y > groundedTreshhold)
				{
					grounded = true;
					groundedOn = collidee.gameObject;
					break;
				}
			}
		//}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject == groundedOn)
		{
			groundedOn = null;
			grounded = false;
		}
	}

	void FixedUpdate()
	{
		move = Input.GetAxis("Horizontal");
		body.velocity = new Vector2(move * speed, body.velocity.y);

		if (Input.GetKey(KeyCode.Space) && grounded)
		{
			body.AddForce(new Vector2(body.velocity.x, jumpForce));
		}
	}
}