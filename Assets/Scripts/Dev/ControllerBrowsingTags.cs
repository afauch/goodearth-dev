using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBrowsingTags : MonoBehaviour, IController {

    public SummonTable _summonTable;
    public GetLocalUser _localUser;
    public float _delayMatchedTagTime;

    public void SubscribeToAppManager()
    {
        // Subscribing to AppManager
        Debug.Log(this.gameObject.name + "Subscribing to App Manager");
        AppManager.Instance.OnChangeState += OnChangeState;
    }

    void OnChangeState(AppManagerState state)
    {
        if(state == AppManagerState.BrowsingTags)
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

}
