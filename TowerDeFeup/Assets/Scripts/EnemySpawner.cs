using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var tex = new Texture2D(20, 20);

		var y = 10;
		var d = 1/4 - 10;
		var end = Mathf.Ceil(10/Mathf.Sqrt(2));
		Color col = Color (Random.Range (0.25, 1.0), Random.Range (0.25, 1.0), Random.Range (0.25, 1.0));
		int cy = 2, cx = 2;
		for (int x = 0; x <= end; x++) {
			tex.SetPixel(cx+x, cy+y, col);
			tex.SetPixel(cx+x, cy-y, col);
			tex.SetPixel(cx-x, cy+y, col);
			tex.SetPixel(cx-x, cy-y, col);
			tex.SetPixel(cx+y, cy+x, col);
			tex.SetPixel(cx-y, cy+x, col);
			tex.SetPixel(cx+y, cy-x, col);
			tex.SetPixel(cx-y, cy-x, col);
			
			d += 2*x+1;
			if (d > 0) {
				d += 2 - 2*y--;
			}
		}

		tex.Apply();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
