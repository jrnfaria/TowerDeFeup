using UnityEngine;
using System.Collections;

public class teste : MonoBehaviour {

	public Color c1,c2;

	void Start () {
		float PI = Mathf.PI;
		float r = 3;
		float x, y;
		float theta_scale = 0.1f;             //Set lower to add more points
		int size = (int)((2.0 * PI) / theta_scale); //Total number of points in circle.
		
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.2F, 0.2F);
		lineRenderer.SetVertexCount(size);
		
		int i = 0;
		for (float theta = 0; theta < 2 * PI; theta += 0.1f) {
			x = r * Mathf.Cos (theta);
			y = r * Mathf.Sin(theta);
			
			Vector3 pos = new Vector3 (x, y, 0);
			lineRenderer.SetPosition (i, pos);
			i += 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
