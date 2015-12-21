using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	
	public GameObject bullet;
	public float bulletInitialVelocity;
	public float maxTimeShooting;

	private Vector2 direction;
	private float timeShooting;
	private bool shooting = false;
	private Vector2 mousePosScreen;
	private Vector2 mousePosWorld;
	private Vector2 playerToMouse;
	
	public void Awake ()
	{
	}

	public void Update ()
	{
		UpdateDirection ();
		CheckIfShooting ();

		if (shooting) {
			CalculateTimeShooting ();
		}
	}

	public void UpdateDirection ()
	{
		mousePosScreen = Input.mousePosition;
		mousePosWorld = Camera.main.ScreenToWorldPoint (mousePosScreen);
		playerToMouse = new Vector2 (mousePosWorld.x - transform.position.x,
		                                     mousePosWorld.y - transform.position.y);
		playerToMouse.Normalize ();
		
		float angle = Mathf.Asin (playerToMouse.y) * Mathf.Rad2Deg;
		if (playerToMouse.x < 0f) {
			angle = 180 - angle;
		}
		
		if (playerToMouse.x > 0f && transform.localScale.x > 0f) {
			transform.localScale = new Vector3 (-transform.localScale.x, 
			                                   transform.localScale.y, 0f);
		} else if (playerToMouse.x < 0f && transform.localScale.x < 0f) {
			transform.localScale = new Vector3 (-transform.localScale.x, 
			                                   transform.localScale.y, 0f);
		}
		
		transform.localEulerAngles = new Vector3 (0f, 0f, angle);
	}

	public void CheckIfShooting ()
	{
		if (Input.GetMouseButtonDown (0)) {
			shooting = true;
			timeShooting = 0f;
		}
	}

	public void CalculateTimeShooting ()
	{
		timeShooting += Time.deltaTime;
		if (Input.GetMouseButtonUp (0) || Input.GetKeyUp (KeyCode.Space)) {
			shooting = false;
			Shoot ();
		}
		if (timeShooting > maxTimeShooting) {
			shooting = false;
			Shoot ();
		}
	}
	
	public void Shoot ()
	{
		direction = playerToMouse;
		GameObject b = Instantiate (bullet);
		b.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
		b.GetComponent<Rigidbody2D> ().velocity = direction * bulletInitialVelocity * 
			(timeShooting / maxTimeShooting);
	}

}
