using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject player;
	public GameObject ground;

	public void SetupScene ()
	{
		//Instantiate (player, new Vector3 (0f, 0.323f, 0f), Quaternion.identity);
		Instantiate (ground, new Vector3 (0f, -1.75003f, 0f), Quaternion.identity);
	}
}
