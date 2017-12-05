﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;

public class CardTarget : MonoBehaviour, IFocusable, IInputHandler, ISourceStateHandler
{
    public Card _card;
    public Material _focusMaterial;
    public Material _clickedMaterial;
    private Material _originalMaterial;
    private Renderer r;

    // Use this for initialization
    void Start()
    {
        r = gameObject.GetComponent<Renderer>();
        _originalMaterial = StaticUtilities.GetOriginalMaterial(this.gameObject);

    }

    public void OnFocusEnter()
    {
        Debug.Log("Enter " + gameObject.name);
        // TODO: Replace with color tween function.
        r.material = _focusMaterial;
    }

    public void OnFocusExit()
    {
        Debug.Log("Exit " + gameObject.name);
        r.material = _originalMaterial;
    }

    public void OnInputDown(InputEventData eventData)
    {
        Debug.Log("Input Down " + gameObject.name);
        r.material = _clickedMaterial;
        //_card.ToggleDescription();
    }

    public void OnInputUp(InputEventData eventData)
    {
        Debug.Log("Input Up " + gameObject.name);
        r.material = _focusMaterial;
    }

    public void OnSourceDetected(SourceStateEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnSourceLost(SourceStateEventData eventData)
    {
        throw new System.NotImplementedException();
    }


}