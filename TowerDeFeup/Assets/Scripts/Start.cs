using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {

	public GameObject LoadingImage;
	public GameObject LoadingText;

	public void LoadScene(int level){
		LoadingImage.SetActive (true);
		LoadingText.SetActive (true);
		Application.LoadLevel(level);
	}
}