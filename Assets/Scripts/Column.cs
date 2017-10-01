using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Hero>() != null)
		{
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			GameControl.instance.HeroScored();
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.name == "shot(Clone)") {

			gameObject.transform.position = new Vector2 (gameObject.transform.position.x, -100);

			GameControl.instance.HeroScored ();
		}
	}
}
