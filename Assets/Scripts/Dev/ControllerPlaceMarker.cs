using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerPlaceMarker : MonoBehaviour, IController {

    int _currentUserToPlace = 0;
    public TextMesh _instructions;
    public GameObject _placeNextButton;
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

    void OnChangeState(AppManagerState state)
    {
        Debug.Log("Number of users: " + AppManager.Instance._users.Length);

        if(state == AppManagerState.PlacingMarkers)
        {
            UpdateInstructions();
            _placeNextButton.SetActive(true);
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
            Debug.Log("Placed user " + _currentUserToPlace);
            AppManager.Instance._users[_currentUserToPlace].gameObject.transform.position = new Vector3(Camera.main.transform.position.x, GlobalUISettings.Instance._infoSetHeight, Camera.main.transform.position.z);
            _currentUserToPlace += 1;
            UpdateInstructions();
        }

    }

    public void UpdateInstructions()
    {
        if (_currentUserToPlace == AppManager.Instance._users.Length)
        {
            _placeNextButton.SetActive(false);
            _finishedButton.SetActive(true);
            // _instructions.text = "Finished. Select 'Done.'";
        }
        else
        {
            _instructions.text = "Tap to place user " + (_currentUserToPlace);
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
}
