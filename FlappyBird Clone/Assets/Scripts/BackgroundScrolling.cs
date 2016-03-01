using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour {
	float scrollStep = 0.001f;
	float deltaTimeCount=0;
	float deltaTimeUpdateRate = 1;
	float deltaTimePerSecond;
	Vector3 initial;
	bool gameFinished=false;
	GameObject[] backgroundParts;
	float fieldsSize;
	GameObject camera;
	
	void Awake() {
		backgroundParts = GameObject.FindGameObjectsWithTag("Background");
		fieldsSize = backgroundParts[0].GetComponent<BoxCollider2D>().size.x;
		camera = GameObject.Find("MainCamera");
		GameObject ground = GameObject.Find("ground_part1");

		foreach (GameObject backgroundPart in backgroundParts) {
			float x = backgroundPart.transform.position.x;
			float newY = ground.transform.position.y*2.0f + backgroundPart.GetComponent<BoxCollider2D>().bounds.size.y / 2.0f;
			backgroundPart.transform.position = new Vector2(x,newY);
		}

	}
	
	// Use this for initialization
	void Start () {
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

		foreach (GameObject ground in backgroundParts) {
			if (FieldIsAtExitPoint(ground)) {

				ArrangeField(ground);
				break;
			}
			
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

	bool FieldIsAtExitPoint(GameObject aField) {
		Vector2 fieldPos = aField.transform.TransformPoint(Vector2.right);
		Vector2 cameraPos = camera.transform.TransformPoint(Vector2.right);
		
		return fieldPos.x   <= cameraPos.x - fieldsSize * 2.0f;
	}
	
	
	
	void ArrangeField(GameObject aField) {
		float x = aField.transform.position.x;
		float y = aField.transform.position.y;
		
		
		aField.transform.position = new Vector2(x+fieldsSize*backgroundParts.Length,y);
	}
}
