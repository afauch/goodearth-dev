using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Vuforia;
using Crayon;

public class FollowTarget : MonoBehaviour {

 //   public ImageTargetBehaviour _targetToFollow;
 //   private GameObject _targetGameObject;
 //   public bool _isTracking = false;

	//// Use this for initialization
	//void Start () {

 //       _targetGameObject = _targetToFollow.gameObject;
 //       SubscribeToTarget();
	//}
	
	//// Update is called once per frame
	//void FixedUpdate () {

 //       if (_isTracking)
 //           FollowTargetTransform();

	//}

 //   void SubscribeToTarget()
 //   {
 //       ModifiedTrackableEventHandler h = _targetGameObject.GetComponent<ModifiedTrackableEventHandler>();
 //       h.TrackableStateChanged += TrackableStateChange;

 //   }

 //   private void TrackableStateChange(bool isTracking)
 //   {
 //       Debug.Log("TrackableStateChange called from " + gameObject.name);

 //       if(isTracking)
 //       {
 //           OnTrackingFound();
 //       } else
 //       {
 //           OnTrackingLost();
 //       }
 //   }

 //   private void OnTrackingFound()
 //   {
 //       Debug.Log("OnTrackingFound called from " + gameObject.name);
 //       _isTracking = true;
 //   }

 //   private void OnTrackingLost()
 //   {
 //       Debug.Log("OnTrackingLost called from " + gameObject.name);
 //       _isTracking = false;
 //   }

 //   private void FollowTargetTransform()
 //   {
 //       // Here's where the logic to position the object goes
 //       this.gameObject.transform.position = _targetGameObject.transform.position;
 //   }

}
