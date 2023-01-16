using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {


	public GameObject[] tilePrefabs;

	public GameObject currentTile;

	private static TileManager instance;

	private Stack<GameObject> leftTiles = new Stack<GameObject>();

	public Stack<GameObject> LeftTiles
	{
		get { return leftTiles; }
		set { leftTiles = value; }
	}

	private Stack<GameObject> topTiles = new Stack<GameObject>();

	public Stack<GameObject> TopTiles
	{
		get { return leftTiles; }
		set { topTiles = value; }
	}


	private Stack<GameObject> rightTiles = new Stack<GameObject>();

	public Stack<GameObject> RightTiles
	{
		get { return rightTiles; }
		set { rightTiles = value; }
	}



	public static TileManager Instance
	{
		get 
		{
			if (instance == null) {
				instance = GameObject.FindObjectOfType<TileManager> ();
			}	
			return instance; 
			}
	}

	// Use this for initialization
	void Start () 
	{
		
		creatTiles (120);

		for (int i = 0; i < 40; i++)
		{
			SpawnTile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void creatTiles(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			leftTiles.Push (Instantiate (tilePrefabs [0]));
			topTiles.Push (Instantiate (tilePrefabs [1]));
			rightTiles.Push (Instantiate (tilePrefabs [2]));
			leftTiles.Peek ().name = "LeftTile";
			leftTiles.Peek ().SetActive (false);
			topTiles.Peek ().name = "TopTile";
			topTiles.Peek ().SetActive (false);
			rightTiles.Peek ().name = "RightTile";
			rightTiles.Peek ().SetActive (false);


		}


	}


	public void SpawnTile()
	{
		if (leftTiles.Count == 0 || topTiles.Count == 0 || rightTiles.Count == 0)
			creatTiles (10);



		//Generating a random number between 0 and 2
		int randomIndex = Random.Range (0, 3);

		if (randomIndex == 0) {
			GameObject tmp = leftTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (1).position;
			currentTile = tmp;
		}
		else if(randomIndex == 1) {
			GameObject tmp = topTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (1).position;
			currentTile = tmp;
		}
		else if(randomIndex == 2) {
			GameObject tmp = rightTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (1).position;
			currentTile = tmp;
		}

		int spawnCoin = Random.Range (0, 10);

		if (spawnCoin == 0) 
		{
			currentTile.transform.GetChild (1).gameObject.SetActive (true);

		}

		//currentTile = (GameObject)Instantiate (tilePrefabs[randomIndex], currentTile.transform.GetChild (0).transform.GetChild (1).position, Quaternion.identity);

	
	}

	public void ResetGame ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
