using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class SummonTable : MonoBehaviour, IFocusable, IInputHandler, ISourceStateHandler {

    public static SummonTable _instance;

    public GameObject _table;
    public Transform _targetTransform;
    public GameObject _cameraObject;
    private Interpolator _tableInterpolator;

    public delegate void MoveAction();
    public MoveAction OnMove;

    void Awake()
    {
        // TODO: Revise Singleton pattern
        _instance = this;
    }

    void Start()
    {
        _tableInterpolator = _table.GetComponent<Interpolator>();
    }

    public void OnFocusEnter()
    {
        // throw new System.NotImplementedException();
    }

    public void OnFocusExit()
    {
        // throw new System.NotImplementedException();
    }

    public void OnInputDown(InputEventData eventData)
    {
        Debug.Log("Clicked");
        // TODO: Placeholder move function
        Vector3 targetPosition = _targetTransform.position;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0.0f, _targetTransform.transform.eulerAngles.y, 0.0f));

        _tableInterpolator.SmoothLerpToTarget = true;
        _tableInterpolator.SetTargetPosition(targetPosition);
        _tableInterpolator.SetTargetRotation(targetRotation);

        if (OnMove != null)
            OnMove();

    }

    public void OnInputUp(InputEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnSourceDetected(SourceStateEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnSourceLost(SourceStateEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

}
