using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {

	public GameObject LoadingImage;

	public void LoadScene(int scene){
		if(LoadingImage != null)
			LoadingImage.SetActive (true);
		Application.LoadLevel(scene);
	}
}