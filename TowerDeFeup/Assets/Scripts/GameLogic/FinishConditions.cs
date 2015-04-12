using UnityEngine;
using System.Collections;

public class FinishConditions : MonoBehaviour {
	
	public Texture background;
	
	void OnGUI(){
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);

		float bWidth=200*Screen.width/1366, bHeight=50*Screen.height/597;
		if(GUI.Button(new Rect(Screen.width/2-bWidth/2,350*Screen.height/597,bWidth,bHeight),"Play again"))
			Application.LoadLevel(2);
		if(GUI.Button(new Rect(Screen.width/2-bWidth/2,420*Screen.height/597,bWidth,bHeight),"Go to menu"))
			Application.LoadLevel(0);
	}
}
