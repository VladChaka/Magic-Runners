using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroControl : MonoBehaviour {

	public static HeroControl instance;
	public GameObject _Hero;
	public GameObject shot;
	public static bool isJump = true;
	public static bool isShot = true;

	void FixedUpdate() {

		if (Input.GetMouseButtonDown (0)) {

			float PosCenter = (float)Screen.width / 2;
			float PosClick = (float)Input.mousePosition.x;

			if (PosClick < PosCenter) {

				Jump ();
			} else {

				Shot ();
			}
		}
	}

	void Jump() {

		if (!isJump)
			return;

		isJump = false;
		Rigidbody2D rb2d = _Hero.GetComponent<Rigidbody2D> ();
		rb2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
	}

	void Shot() {

		if (!isJump || !isShot)
			return;

		var bullet = (GameObject)Instantiate (
			shot
		);

		isShot = false;

		bullet.SetActive (true);

		bullet.GetComponent<Rigidbody2D> ().velocity = _Hero.GetComponent<Rigidbody2D> ().velocity;

		bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);

		Destroy(bullet, 0.05f);

		isShot = true;
	}
}
