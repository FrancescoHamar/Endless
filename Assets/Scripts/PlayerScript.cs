using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour {

	public float maxtime;
	public float minSwipeDist;

	public float speed;
	public float maxSpeed;
	public float acceleration;

	public BoxCollider Collider1;
	public BoxCollider Collider2;
	public BoxCollider Collider3;

	private int score = 0;
	public Text scoreText;
	public Text Score;
	public Text BestScore;
	public Text NewHighScore;
	public Text[] ScoreTexts;
	public Text actualScore;

	public Image background;
	public Image retry;

	public static bool isDead;
	public static bool adOk;

	float startTime;
	float endTime;

	Vector3 startPos;
	Vector3 endPos;

	public Vector3 dir;
	public Vector3 pos;
	public GameObject ps;
	public GameObject pauseMenu;

	public GameObject ResetBtn;
	public Animator gameOverAnim;



	float swipeDistance;
	float swipeTime;
	// Use this for initialization
	void Start () 
	{
		adOk = false;
		isDead = false;
		dir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > (0)){
			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				startTime = Time.time;
				startPos = touch.position;
			} else if (touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;

				swipeDistance = (endPos - startPos).magnitude;
				swipeTime = (endTime - startTime);

				if (swipeTime < maxtime && swipeDistance < minSwipeDist) {

					swipe ();
				}
			}
		}

		float amountToMove = speed * Time.deltaTime;

		transform.Translate(dir * amountToMove);
		speed += acceleration * Time.deltaTime;

		if (speed > maxSpeed)
			speed = maxSpeed;

			

		if (gameObject.transform.position.y < 3) 
		{
			//kill player!
			isDead = true;
			adOk = true;
			GameOver ();

			transform.GetChild (0).transform.parent = null;




		}
		
	}

	         void swipe ()
	{



		Vector3 distance = endPos - startPos;


		if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y)) {

			if (distance.x > 0 && !isDead) { 
				score++;
				scoreText.text = score.ToString ();
				dir = Vector3.forward + Vector3.right;
			}

			if (distance.x < 0 && !isDead) { 
				score++;
				scoreText.text = score.ToString ();
				dir = Vector3.forward + Vector3.left;
			}
			


		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Coin") {
			other.gameObject.SetActive (false);
			Instantiate (ps, transform.position, Quaternion.identity);
			score += 3;
			scoreText.text = score.ToString ();
			}

	}

	private void GameOver ()
	{
		gameOverAnim.SetTrigger ("GameOver");
		actualScore.gameObject.SetActive(false);

		Score.text = score.ToString ();

		int bestScore = PlayerPrefs.GetInt ("BestScore", 0);
		if (score > bestScore) 
		{
			PlayerPrefs.SetInt ("BestScore", score);
			NewHighScore.gameObject.SetActive(true);
			foreach (Text txt in ScoreTexts) 
			{
				txt.color = Color.blue;
			}
		}

		BestScore.text = PlayerPrefs.GetInt ("BestScore", 0).ToString ();
	}

	private void Pause()
	{
		if (pauseMenu.transform.position.y < 785) 
		{
			Time.timeScale = 0;
		}
	}

}



