using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public CircleCollider2D destructionCircle;
	public static Ground ground;

	public void Start ()
	{
	}

	void Update () 
	{
	}

	void OnCollisionEnter2D( Collision2D coll ){
		if( coll.collider.tag == "Ground" ){
			ground.DestroyGround( destructionCircle );
			Destroy(gameObject);
		}
	}
}
