using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using Crayon;

public class TagObject : MonoBehaviour, IFocusable, IInputHandler, ISourceStateHandler
{

    public Tag myTag;
    public int userId;
    public bool bSelected { get; private set; }
    private GetLocalUser localUser;
    // public Color toggleOn = new Color(.42f, .71f, .97f);
    // public Color toggleOff = Color.white;

    //private Color myColor;

	// Use this for initialization
	void Start () {
        localUser = GetComponentInParent<GetLocalUser>();
        //myColor = this.GetComponent<TextMesh>().color;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void OnFocusEnter()
    {
        // Debug.Log("Enter " + gameObject.name);
        if (bSelected)
        {
            this.gameObject.SetState(CrayonStateType.Custom, "selectedhover");
        }
        else
        {
            this.gameObject.SetState(CrayonStateType.Hover);
        }

    }

    public void OnFocusExit()
    {
        // Debug.Log("Exit " + gameObject.name);
        if(bSelected)
        {
            this.gameObject.SetState(CrayonStateType.Selected);
        } else
        {
            this.gameObject.SetState(CrayonStateType.Default);
        }



    }

    public void OnInputDown(InputEventData eventData)
    {
        Debug.Log("Input Down " + gameObject.name);
        // this.gameObject.SetState(CrayonStateType.Selected);
        ToggleTag();
    }

    public void OnInputUp(InputEventData eventData)
    {
        // this.gameObject.SetState(CrayonStateType.Hover);
    }

    public void OnSourceDetected(SourceStateEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnSourceLost(SourceStateEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    //toggle this tag's bselected state
    public void ToggleTag()
    {
        if (bSelected)
        {
            this.gameObject.SetState(CrayonStateType.Default);
            SelectTag(false);
        }
        else
        {
            this.gameObject.SetState(CrayonStateType.Selected);
            SelectTag(true);
        }
        localUser.SendFilterRequest();
    }

    //add this tag to selected tag list
    public void SelectTag(bool _bselect)
    {
        bSelected = _bselect;
        if (_bselect)
        {
            if (!localUser.selectedTagObjects.Contains(this))
            {
                localUser.selectedTagObjects.Add(this);
                localUser.SendFilterRequest();
            }
        }
        else
        {
            localUser.selectedTagObjects.Remove(this);
            localUser.SendFilterRequest();
        }

    }
}
