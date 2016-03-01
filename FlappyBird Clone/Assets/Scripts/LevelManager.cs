using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	AudioSource[] sfx;
	GameObject nextPipe;
	bool passedPipe = false;
	GameObject bird;
	int score = 0;

	void Awake () {

	}

	void Start () {
		bird = GameObject.Find("Bird");
		nextPipe = GameObject.Find("pipedown");
		sfx = this.GetComponents<AudioSource>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (!passedPipe && bird.transform.position.x > nextPipe.transform.position.x ) {
			passedPipe = true;
			++score;
			sfx[0].Play ();
		}
	}
}
