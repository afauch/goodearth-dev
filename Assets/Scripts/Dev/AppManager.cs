using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AppManagerState
{
    WaitingForAdmin = 0,
    PlacingMarkers = 1,
    WaitingForUser = 2,
    UserCalibration = 3,
    ScenarioOne = 4,
    ScenarioTwo = 5
}

public class AppManager : MonoBehaviour {

    public static AppManager Instance;
    [HideInInspector] public AppManagerState _currentState;

    public GameObject[] _stateCollections;

    [Header("Users")]
    public GetLocalUser _localUser;
    public FollowTarget[] _users;

    public delegate void ChangeStateDelegate(AppManagerState state);
    public ChangeStateDelegate OnChangeState;

    void Awake ()
    {
        if (Instance == null)
            Instance = this;

        InitStateControllers();

        // Waiting state to start
        _currentState = AppManagerState.WaitingForAdmin;

    }

    // Use this for initialization
    void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitStateControllers()
    {
        for (int i = 0; i < _stateCollections.Length; i++)
        {
            _stateCollections[i].GetComponent<IController>().SubscribeToAppManager();
        }

        HideAllButState(_currentState);

    }

    private void HideAllButState(AppManagerState state)
    {

        int stateAsInt = (int)state;

        for(int i = 0; i < _stateCollections.Length; i++)
        {
            // Does this GameObject collection correspond to our target state
            if(i == stateAsInt)
            {
                _stateCollections[i].SetActive(true);
            } else
            {
                _stateCollections[i].SetActive(false);
            }
        }

    }

    public void ChangeState(AppManagerState targetState)
    {

        Debug.Log("ChangeState called. Current state is " + _currentState + " and target state is " + targetState);

        // TODO: Logic here to change the state
        HideAllButState(targetState);

        if (OnChangeState != null)
            OnChangeState(targetState);

        _currentState = targetState;

        Debug.Log("ChangeState finishd. Current state is " + _currentState);

    }

}
