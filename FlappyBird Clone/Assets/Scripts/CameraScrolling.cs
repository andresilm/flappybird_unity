using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour {
	float scrollStep = 0.015f;
	float deltaTimeCount=0;
	float deltaTimeUpdateRate = 1;
	float deltaTimePerSecond;
	Vector3 initial;
	bool gameFinished=false;



	// Use this for initialization
	void Awake () {
		deltaTimePerSecond = 1/Time.deltaTime;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		initial = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameFinished =  Time.timeScale==0;

		if (Time.timeScale!=0 && gameFinished) {
			this.transform.position = initial;
			gameFinished = false;
		}

	}

	void FixedUpdate () {
		deltaTimeCount += 1;
		if (deltaTimeCount >= deltaTimeUpdateRate) {
			float x = this.transform.position.x;
			float y = this.transform.position.y;
			float z = this.transform.position.z;

			this.transform.position = new Vector3(x-scrollStep,y,z);
			deltaTimeCount = 0;
		}


	}
}
