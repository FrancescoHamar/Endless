using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour 
{


	private string adID = "1768375";

	private string interstitialAd = "video";

	public PlayerScript script;

	public bool isTestAd;


	private void Start()
	{
		InitializeAdvertisement ();
	}

	private void InitializeAdvertisement ()
	{
		Advertisement.Initialize (adID, isTestAd);
		return;
	}

	public void PlayInterstitialAd ()
	{
		if (Advertisement.IsReady(interstitialAd))
		{
			return;
		}

		Advertisement.Show (interstitialAd);
	}

}
