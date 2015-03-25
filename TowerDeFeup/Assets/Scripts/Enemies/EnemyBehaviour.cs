using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MonoBehaviour {
	
	private List<GameObject> waypoints= new List<GameObject>();
	public float speed;
	Animator animator;
	public int health;
	public int maxHealth;
	private int index=0;
	
	// Use this for initialization
	void Start () {
		
		
		animator = GetComponent<Animator>();
		foreach(GameObject way in GameObject.FindGameObjectsWithTag("Waypoint"))
		{
			waypoints.Add(way);
		}
		
		
		if(waypoints.Count>0)
			transform.position = waypoints [index].transform.position;
		
		index = index + 1;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if (index < waypoints.Count) {
			GameObject way=waypoints [index];
			
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, waypoints [index].transform.position, step);
			
			
			if (transform.position == way.transform.position)
			{
				index = index + 1;
				if(index<waypoints.Count)
					SetAnimation (waypoints [index]);
			}
		}
	}
	
	void SetAnimation(GameObject way) {
		
		if(transform.position.x<way.transform.position.x)
			animator.SetInteger("direction",2);
		else if(transform.position.x>way.transform.position.x)
			animator.SetInteger("direction",3);
		else if(transform.position.y<way.transform.position.y)
			animator.SetInteger("direction",0);
		else if(transform.position.y>=way.transform.position.y)
			animator.SetInteger("direction",1);
	}
	
}

