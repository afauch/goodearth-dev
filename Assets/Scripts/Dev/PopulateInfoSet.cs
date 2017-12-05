using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateInfoSet : MonoBehaviour {

    public GameObject _label;
    public GameObject _content;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetNewData(string label, string content)
    {
        _label.GetComponent<TextMesh>().text = label;
        _content.GetComponent<TextMesh>().text = content;

    }
}
