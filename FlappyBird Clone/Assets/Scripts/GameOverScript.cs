using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	bool gameOver=false;
	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().enabled=false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameObject.Find("Bird").GetComponent<BirdScript>().Collided) {
			this.GetComponent<Renderer>().enabled=true;
			gameOver=true;
			Time.timeScale=0;
		}



	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.R) && gameOver) {
			gameOver=false;
			Time.timeScale=1;
			this.GetComponent<Renderer>().enabled = false;
		}
	}
}
