using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScenarioNumber
{
    One,
    Two
}

public class ControllerScenario : MonoBehaviour, IController {

    public SummonTable _summonTable;
    public GetLocalUser _localUser;
    public float _delayMatchedTagTime;
    public ScenarioNumber _scenario;

    public void SubscribeToAppManager()
    {
        // Subscribing to AppManager
        Debug.Log(this.gameObject.name + "Subscribing to App Manager");
        AppManager.Instance.OnChangeState += OnChangeState;
    }

    void OnChangeState(AppManagerState state)
    {
        if(state == AppManagerState.ScenarioOne)
        {
            // _summonTable.gameObject.SetActive(true);
            StartCoroutine(ShowMatchedTag(_localUser));
        }

    }

    private IEnumerator ShowMatchedTag(GetLocalUser user)
    {

        yield return new WaitForSeconds(_delayMatchedTagTime);

        user.ShowMatchedTag();

        yield return null;

    }

    public void Reset()
    {
        Debug.Log("Heard RESET command");
        AppManager.Instance.ChangeState(AppManagerState.UserCalibration);
    }

}
