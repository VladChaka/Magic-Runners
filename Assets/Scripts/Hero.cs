using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour 
{
	public bool isDead = false;			//Has the player collided with a wall?

	public static Hero instance;
	private Animator anim;					//Reference to the Animator component.
	public Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.

	private float startPosition = 0.0f;

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

		startPosition = rb2d.position.x;
	}

	void FixedUpdate() {

		if (isDead == false && GameControl.instance.isRun) {

			rb2d.position = new Vector2 (startPosition, rb2d.position.y);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		HeroControl.isJump = true;

		if (other.gameObject.name == "DeadTrigger" || other.gameObject.name == "Column(Clone)") {
			isDead = true;
			GameControl.instance.HeroDied ();
		}
	}
}