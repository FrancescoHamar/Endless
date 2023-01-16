using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private Transform cameraTransform;
	private Transform cameraDesiredLookAt;

	public Button play;
	public Animator AudioMenuAnim;
	public Animator VideoMenuAnim;
	public Animator GiftMenuAnim;
	public Animator CoinStoreAnim;
	public Slider CameraSwitch;


	int sliderAmount;


                          // linking the self-reference
		 // set to dont destroy

	// Use this for initialization
	void Start ()
	{
		cameraTransform = Camera.main.transform;
		DontDestroyOnLoad (transform.gameObject);
	}


	
	// Update is called once per frame
	void Update () 
	{
			if (cameraDesiredLookAt != null)
			{
				cameraTransform.rotation = Quaternion.Slerp (cameraTransform.rotation, cameraDesiredLookAt.rotation, 3 * Time.deltaTime);
			}
		}


	public void LookAtMenu(Transform menuTransform)
	{
		cameraDesiredLookAt = menuTransform;
	}

	public void LoadLevel ()
	{
		Application.LoadLevel ("GAME");

	}



     public void AudioMenu ()
				{

				}


	public void VideoMenuOn ()
	{
		VideoMenuAnim.SetTrigger ("VideoMenu1");
	}

	public void VideoMenuOff ()
	{
		VideoMenuAnim.SetTrigger("FinishVideoMenu");
	}
		
	public void saveSliderValue()
	{
		PlayerPrefs.SetFloat("CameraS", CameraSwitch.value);
		PlayerPrefs.Save();
	}


}
