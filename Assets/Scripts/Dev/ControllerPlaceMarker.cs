using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;


public class ControllerPlaceMarker : MonoBehaviour, IController, IInputHandler {

    int _currentUserToPlace = 0;
    public TextMesh _instructions;
    public GameObject _cursor;
    public GameObject _finishedButton;

    private void Start()
    {
        HoloToolkit.Unity.InputModule.InputManager.Instance.PushFallbackInputHandler(this.gameObject);
    }

    public void SubscribeToAppManager()
    {
        // Subscribing to AppManager
        Debug.Log(this.gameObject.name + "Subscribing to App Manager");
        AppManager.Instance.OnChangeState += OnChangeState;
    }

    void OnChangeState(AppManagerState state)
    {
        Debug.Log("Number of products: " + AppManager.Instance._users.Length);

        if(state == AppManagerState.PlacingMarkers)
        {
            UpdateInstructions();
            _finishedButton.SetActive(false);
        }
    }

    public void PlaceNextUser()
    {

        if (_currentUserToPlace == AppManager.Instance._users.Length)
        {
            return;
        }
        else
        {
            Debug.Log("Placed product " + _currentUserToPlace);
            AppManager.Instance._users[_currentUserToPlace].gameObject.transform.position = _cursor.transform.position;
            _currentUserToPlace += 1;
            UpdateInstructions();
        }

    }

    public void UpdateInstructions()
    {
        if (_currentUserToPlace == AppManager.Instance._users.Length)
        {
            _finishedButton.SetActive(true);
            // _instructions.text = "Finished. Select 'Done.'";
        }
        else
        {
            _instructions.text = "Tap to place product " + (_currentUserToPlace);
        }
    }

    public void ContinueToNextState()
    {
        AppManager.Instance.ChangeState(AppManagerState.UserCalibration);
    }

    private void OnDestroy()
    {
        AppManager.Instance.OnChangeState -= OnChangeState;
    }

    public void OnInputUp(InputEventData eventData)
    {
        // Debug.LogFormat("Input heard from {0}", this.gameObject.name);
    }

    public void OnInputDown(InputEventData eventData)
    {
        // Debug.LogFormat("Input down heard from {0}", this.gameObject.name);
        PlaceNextUser();

    }
}
