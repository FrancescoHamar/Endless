using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

	private float fallDeally = 1.5f;

	public BoxCollider Collider1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}


	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") 
		{
			TileManager.Instance.SpawnTile ();
			StartCoroutine (fallDown ());
		}
	}
	IEnumerator fallDown ()
	{
		yield return new WaitForSeconds (fallDeally);
		GetComponent<Rigidbody>().isKinematic = false;
		yield return new WaitForSeconds (2);
		switch (gameObject.name) {
		case "LeftTile":
			TileManager.Instance.LeftTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);

			break;

		case "TopTile":

			TileManager.Instance.TopTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);

			break;


		case "RightTile":

			TileManager.Instance.RightTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;
			gameObject.SetActive (false);

			break;

		}


	}
}

