using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crayon;

public class TestStates : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {

			gameObject.SetState (CrayonStateType.Default);

		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {

			gameObject.SetState (CrayonStateType.Hover);

		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {

			gameObject.SetState (CrayonStateType.Selected);

		}




	}
}
