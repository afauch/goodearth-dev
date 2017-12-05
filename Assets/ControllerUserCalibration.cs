using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUserCalibration : MonoBehaviour, IController {

    public TextMesh _counter;
    public TextMesh _buttonText;
    int _counterInt;
    bool _hasCalibrated = false;


    public void SubscribeToAppManager()
    {
        // Subscribing to AppManager
        Debug.Log(this.gameObject.name + "Subscribing to App Manager");
        AppManager.Instance.OnChangeState += OnChangeState;
    }

    void OnChangeState(AppManagerState state)
    {

    }

    public void OnCalibrate()
    {
        if (_hasCalibrated)
        {
            AppManager.Instance.ChangeState(AppManagerState.LoadingData);
        }
        else
        {
            _counterInt = int.Parse(_counter.text);
            _counterInt -= 1;
            _counter.text = _counterInt.ToString();
            if(_counterInt == 0)
            {
                _hasCalibrated = true;
                _buttonText.text = "CONTINUE";
            }
        }
    }

}
