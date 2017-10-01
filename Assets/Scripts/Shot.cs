using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.name == "Column(Clone)") {

			this.gameObject.SetActive (false);
		}
	}
}
