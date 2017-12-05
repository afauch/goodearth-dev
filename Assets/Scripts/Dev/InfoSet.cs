using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crayon;

public class InfoSet : MonoBehaviour {

    public FollowTarget _followTargetInstance;
    public Vector3 _offset;

    public Transform _connectionNode;
    private LineRenderer _lr;

    // Use this for initialization
    void Start() {

        InitConnection();

    }

    // Update is called once per frame
    void FixedUpdate() {

        LookAtUser();

        // if (_followTargetInstance._isTracking)
            EvaluateAdjustPosition();

        if (GlobalUISettings.Instance._renderConnections)
            RenderConnection();

    }

    private void InitConnection()
    {

        _lr = this.gameObject.AddComponent<LineRenderer>();
        _lr.material = GlobalUISettings.Instance._lineMaterial;
        _lr.startWidth = GlobalUISettings.Instance._lineWidths;
        _lr.endWidth = GlobalUISettings.Instance._lineWidths;
        _lr.enabled = false;
    }

    private void LookAtUser()
    {
        // Turn to face the camera
        Vector3 position = Camera.main.transform.position - this.gameObject.transform.position;
        position.y = 0.0f;
        this.gameObject.transform.rotation = Quaternion.LookRotation(position) * Quaternion.Euler(new Vector3 (0.0f, 180.0f, 0.0f));
    }

    private void EvaluateAdjustPosition()
    {
        // TODO: There could be some more smoothing logic here
        this.gameObject.SetPosition((_followTargetInstance.transform.position + _offset), 1.0f, Easing.CubicInOut);

    }

    private void RenderConnection()
    {

        if (_lr.enabled == false)
            _lr.enabled = true;

        _lr.SetPosition(0, _followTargetInstance.gameObject.transform.position);
        _lr.SetPosition(1, _connectionNode.position);

    }
}
