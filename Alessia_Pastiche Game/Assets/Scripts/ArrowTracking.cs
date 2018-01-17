//// class that rotates arrow and tracks nearby bubbles
//// reference: Brackeys Youtube Tutorial (Tower Defense Game)
//
//
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class Arrow : MonoBehaviour {
//
//	private Transform target;
//	public float range = 15f;
//	public string bubbleTag = "Bubble";
//	public Transform partToRotate;
//	public float turnSpeed = 10f;
//
//	// Use this for initialization
//	void Start () {
//
//		//Invoke.Repeating ("UpdateTarget", 0f, 0.5f);
//
//	}
//
//	/* Finding all of the bubbles, and for each bubble that we have found, get distance to that bubble, see if 
//	that distance is shorter than previous, if it is, the nearest bubble found so far will be the chosen bubble */
//	void UpdateTarget() {
//	
//		GameObject[] bubbles = GameObject.FindGameObjectsWithTag(bubbleTag);
//		float shortestDistance = Mathf.Infinity;
//		GameObject nearestBubble = null;
//	
//		foreach (GameObject bubble in bubbles) {
//
//			float distanceToBubble = Vector3.Distance (transform.position, bubble.transform.position);
//			if (distanceToBubble < shortestDistance) {
//
//				shortestDistance = distanceToBubble;
//				nearestBubble = bubble;
//			
//			}				
//		}
//
//		//If we did find a bubble AND if distance is within that range, we have the closest target
//		if (nearestBubble != null && shortestDistance <= range) {
//		
//			target = nearestBubble.transform;
//
//		} else {
//		
//			target = null;
//		
//		}
//
//	}
//
//	// Update is called once per frame
//	void Update () {
//
//		if (target == null) {
//			return;
//		}
//
////		//Target Lock on
////		//Converting quaternion into xyz (eulerAngles)
////		Vector3 dir = target.position - transform.position;
////		//Quaternion lookDirection = Quaternion.lookRotation(dir);
////		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, LookRotation, Time.deltaTime * turnSpeed).eulerAngles;
////		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
//
//	}
//
//	void OnDrawGizmosSelected () {
//	
//		Gizmos.color = Color.red;
//		Gizmos.DrawWireSphere (transform.position, range);
//	
//	}
//
//}
