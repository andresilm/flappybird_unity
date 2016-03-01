using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour
{
		Animator animator;
		float flapForce = 2.35f;//gravity scale = 0.5
		bool collided = false;
		AudioSource[] sfx;
		GameObject camera;

		void Awake ()
		{
				sfx = GetComponents<AudioSource> ();
				animator = GetComponent<Animator> ();
				camera = GameObject.Find ("MainCamera");
		}

		// Use this for initialization
		void Start ()
		{
				

		}

		void FixedUpdate ()
		{
				animator.SetFloat ("vertical_velocity", this.GetComponent<Rigidbody2D> ().velocity.y);
			if (isOutOfScreen()) {
				collisionScript ();
			}	

		}

		bool isOutOfScreen ()
		{
		return this.transform.position.y >= this.camera.transform.position.y *2;
		}
	

		// Update is called once per frame
		void Update ()
		{
				
				if (Input.GetKeyDown (KeyCode.Space)) {
						GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, flapForce);
						sfx [0].Play ();
				}

				if (Input.GetKeyDown (KeyCode.Q)) {
						Application.Quit ();
				}
				//probar en android
				//Vector2 touch = Input.GetTouch(0).deltaPosition;
				//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, flapForce*touch.y);
	
		}

		void OnCollisionEnter2D (Collision2D col)
		{

				collisionScript ();

		}

		void collisionScript ()
		{
				sfx [1].Play ();
				Debug.Log ("GAME OVER");
				collided = true;
		}

		public bool Collided {
				get {
						return collided;
				}
		}
}