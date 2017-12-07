using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule;

public class ControllerWaitingForAdmin : MonoBehaviour, IController
{

    private void Start()
    {
    }

    private void Update()
    {

    }

    public void SubscribeToAppManager()
    {
        // Subscribing to AppManager
        Debug.Log(this.gameObject.name + "Subscribing to App Manager");
        AppManager.Instance.OnChangeState += OnChangeState;
    }

    private void OnChangeState(AppManagerState state)
    {

    }

    public void ContinueToNextState()
    {
        AppManager.Instance.ChangeState(AppManagerState.PlacingMarkers);
    }

    private void OnDestroy()
    {
        AppManager.Instance.OnChangeState -= OnChangeState;
    }

}
