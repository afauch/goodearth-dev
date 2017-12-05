using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using Crayon;

public class LookDownReminder : MonoBehaviour {

    public GameObject _cursor;
    public GameObject _ui;
    bool _isShowing = true;

    void Update()
    {
        if(_cursor.transform.position.y > GlobalUISettings.Instance._maximumYTagalong)
        {
            _ui.SetActive(true);

            if (!_isShowing)
            {
                // TODO: Tween logic can go here.
            }
            _isShowing = true;
        }
        else
        {
            _ui.SetActive(false);

            if (_isShowing)
            {
                // TODO: Tween logic can go here.
            }
            _isShowing = false;
        }
    }

}
