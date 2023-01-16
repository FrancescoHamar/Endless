using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class CameraSwitch : MonoBehaviour {

	public Slider VideoM;



	private Transform cameraTransform;

	public Animator VideoMenuAnim;
	public Animator OptionMenuAnim;

	public Camera FirstPerson;
	public Camera ThirdPerson;

	// Use this for initialization
	void Start () 
	{

		cameraTransform = Camera.main.transform;


		
	}
	
	// Update is called once per frame
	void Update () {

		float VideoM = PlayerPrefs.GetFloat ("CameraSwitch");
		
		if (VideoM  < 1)
		{

			ThirdPerson.gameObject.SetActive(true);
			FirstPerson.gameObject.SetActive(false);

		}

		if (VideoM > 0) 
		{
			
			FirstPerson.gameObject.SetActive(true);
			ThirdPerson.gameObject.SetActive(false);


		}



	}
	public void LookAtMenu(Transform menuTransform)
	{
		cameraTransform = menuTransform;
	}



	public void VideoMenuOn ()
	{
		VideoMenuAnim.SetTrigger ("VideoMenu1");
	}

	public void VideoMenuOff ()
	{
		VideoMenuAnim.SetTrigger("FinishVideoMenu");
	}





	public void OptionMenuOn ()
	{
		OptionMenuAnim.SetTrigger ("OptionMenu");
	}

	public void OptionMenuOff ()
	{
		OptionMenuAnim.SetTrigger("FinishOptionMenu");
	}



	public void LoadMenu ()
	{
		Application.LoadLevel("MENU");
		if (Advertisement.IsReady ()) 
		{
			Advertisement.Show ();
		}
	}



	public void SliderValueSave()
	{
		PlayerPrefs.GetFloat ("CameraS");
		Debug.Log ("$");
	}

}
