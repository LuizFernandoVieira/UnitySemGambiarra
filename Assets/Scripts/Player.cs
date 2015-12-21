using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public float velocity;
	private Rigidbody2D rb;

	public void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Start ()
	{

	}
	
	public void UpdateMove ()
	{
		if (Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = Vector2.right * velocity;
		} else if (!Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = -Vector2.right * velocity;
		} else {
			rb.velocity = Vector2.zero;
		}
	}

	public void Update () 
	{

	}

	public void OnCollisionStay2D (Collision2D other)
	{
		if (other.collider.tag == "Ground") {
			UpdateMove ();
		}
	}

}
