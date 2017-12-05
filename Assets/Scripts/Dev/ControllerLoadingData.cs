using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity;
using HoloToolkit.Examples.InteractiveElements;

public class ControllerLoadingData : MonoBehaviour, IController
{

    public QueryUserData _queryUserData;
    public GameObject _loadingAnimation;
    public GameObject _finishedButton;

    private void Start()
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

        if(state == AppManagerState.LoadingData)
        {
            _loadingAnimation.SetActive(true);
            _finishedButton.SetActive(false);
            _queryUserData.GetData();
        }

    }

    public void DataWasLoaded()
    {

        _loadingAnimation.SetActive(false);
        _finishedButton.SetActive(true);

    }

    public void ContinueToNextState()
    {
        AppManager.Instance.ChangeState(AppManagerState.BrowsingTags);
    }

    private void OnDestroy()
    {
        AppManager.Instance.OnChangeState -= OnChangeState;
    }

}
