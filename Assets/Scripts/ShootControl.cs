using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class ShootControl : MonoBehaviour {


	private bool charging = false;
	private float power = 0f;
	public float chargeRatio = 0.3f;

	public Image fireGauge;

	void FixedUpdate () {
		
		InputControl ();
		Charge ();

	}




	void InputControl (){

		if (Input.touchCount > 0) { // screen has been touched
			Touch touch = Input.GetTouch (0);
			
			if (touch.phase == TouchPhase.Began) {
				PointerEventData pointer = new PointerEventData(EventSystem.current); // creates event data
				pointer.position = touch.position; // sets it's position
				
				List<RaycastResult> raycastResults = new List<RaycastResult>(); // list results of raycast
				EventSystem.current.RaycastAll(pointer, raycastResults); // raycasts
				
				if(raycastResults.Count > 0) // something was hit
				{
					if(raycastResults[0].gameObject.tag == "FireButton"){ // tagged as GUI
						Debug.Log("charging..");
						charging = true;
					}
				}
			}
		}
	}


	void Charge (){
		if (charging == false)
			return;
		power = power + (Time.fixedDeltaTime * chargeRatio);
		fireGauge.fillAmount = power;
		if (Input.GetTouch (0).phase == TouchPhase.Ended || power >= 1f) {
			Fire ();
			fireGauge.fillAmount = 0.01f;
			charging = false;
			power = 0f;
		}
	}

	void Fire(){
		Debug.Log ("fire!!");
		// set bulletIniticalVelocity
	}
	
}
