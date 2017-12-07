using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

[RequireComponent(typeof(SpriteRenderer))]
public class ExpandInfo : MonoBehaviour, IFocusable, IInputHandler {

    public Sprite _defaultCollapsed;
    public Sprite _hoverCollapsed;
    public Sprite _defaultExpanded;
    public Sprite _hoverExpanded;

    bool _isExpanded;
    SpriteRenderer _sr;

    // Use this for initialization
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = _defaultCollapsed;
        _isExpanded = false;
    }

    public void OnFocusEnter()
    {

        if (!_isExpanded)
        {
            _sr.sprite = _hoverCollapsed;
        }
        else
        {
            _sr.sprite = _hoverExpanded;
        }
    }

    public void OnFocusExit()
    {
        if (!_isExpanded)
        {
            _sr.sprite = _defaultCollapsed;
        }
        else
        {
            _sr.sprite = _defaultExpanded;
        }
    }

    public void OnInputDown(InputEventData eventData)
    {
        if(!_isExpanded)
        {
            _sr.sprite = _defaultExpanded;
            AdjustCollider();
            _isExpanded = true;
        }
        else
        {
            _sr.sprite = _defaultCollapsed;
            AdjustCollider();
            _isExpanded = false;
        }
    }

    private void AdjustCollider()
    {
        BoxCollider c = GetComponent<BoxCollider>();
        Destroy(c);
        BoxCollider n = gameObject.AddComponent<BoxCollider>();
        n.size = new Vector3(n.size.x, n.size.y, 0.01f);
    }


    public void OnInputUp(InputEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

}
