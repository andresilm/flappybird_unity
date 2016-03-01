using UnityEngine;
using System.Collections;


public class GroundManager : MonoBehaviour {
	GameObject[] fields;
	float fieldsSize;
	GameObject camera;
	
	void Awake () {
		fields = GameObject.FindGameObjectsWithTag("Ground");
		fieldsSize = fields[0].GetComponent<BoxCollider2D>().size.x;
		camera = GameObject.Find("MainCamera");

		Debug.Assert(camera != null);
	}
	
	// Use this for initialization
	void Start () {


	}
	
	void Update() {
		foreach (GameObject ground in fields) {
			if (FieldIsAtExitPoint(ground)) {

				ArrangeField(ground);
				break;
			}

		}
	
		
	}
	
	bool FieldIsAtExitPoint(GameObject aField) {
		Vector2 fieldPos = aField.transform.TransformPoint(Vector2.right);
		Vector2 cameraPos = camera.transform.TransformPoint(Vector2.right);
		
		return fieldPos.x   <= cameraPos.x - fieldsSize * 2.2f;
	}
	
	
	
	void ArrangeField(GameObject aField) {
		float x = aField.transform.position.x;
		float y = aField.transform.position.y;

		
		aField.transform.position = new Vector2(x+fieldsSize*fields.Length,y);
	}
	
	
}