using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public BoardManager boardScript;

	void Awake() 
	{
		if (instance = null) 
		{
			instance = this;
		}
		else if (instance != null)
		{
			Destroy(gameObject);
		}

		boardScript = GetComponent<BoardManager> ();
		Init ();
	}

	void Init()
	{
		boardScript.SetupScene ();
	}

}
