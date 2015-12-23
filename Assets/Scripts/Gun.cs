using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
	
	public GameObject bullet;
	public float bulletMaximumVelocity;
	//public float maxTimeCharging;
	public float angularVelocity;
	public float chargeRatio = 0.3f;

	public Image fireGauge;

	private float power = 0f;
	private bool charging = false;
	private bool angleChanging = false;
	private bool angleDirection = false;
	//private Vector2 direction;
	//private float timeCharging;
	private Vector2 mousePosScreen;
	private Vector2 mousePosWorld;
	private Vector2 playerToMouse;

	public void Awake ()
	{
	}

	public void Update ()
	{
		//UpdateDirection ();
		//CheckIfShooting ();
		ChangeAngle ();
		Charge ();
		Shoot ();
	}

	public void SetCharging(bool value){
		charging = value;
	}
	public void SetAngleUp (bool value){
		angleChanging = value;
		angleDirection = true;
	}
	public void SetAngleDown (bool value){
		angleChanging = value;
		angleDirection = false;
	}

	/*public void UpdateDirection ()
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
	}*/

	/*public void CheckIfShooting ()
	{
		if (Input.GetMouseButtonDown (0)) {
			shooting = true;
			timeShooting = 0f;
		}
	}*/

	void Charge (){
		if (charging == false)
			return;
		power = power + (Time.deltaTime * chargeRatio);
		fireGauge.fillAmount = power;
		if (power >= 1f) {
			power = 1f;
			charging = false;
		}
	}
	
	public void Shoot ()
	{
		if ((charging == true) || (power == 0f))
			return;

		//direction = playerToMouse;
		GameObject b = Instantiate (bullet);
		b.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
		b.transform.rotation = this.transform.rotation;
		b.GetComponent<Rigidbody2D> ().velocity = b.transform.right * bulletMaximumVelocity * power;

		fireGauge.fillAmount = 0.01f;
		power = 0f;
	}

	public void ChangeAngle ()
	{
		if (angleChanging == false)
			return;

		if (angleDirection == true) { //  sentido anti-horario
			transform.Rotate (new Vector3 (0f,0f,Time.deltaTime * angularVelocity));
		}
		if (angleDirection == false) { //  sentido anti-horario
			transform.Rotate (new Vector3 (0f,0f,-Time.deltaTime * angularVelocity));
		}
	}

}
