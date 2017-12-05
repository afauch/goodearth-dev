using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;

public class Card : MonoBehaviour
{

    //public HandDraggable _handDraggable;
    //public SummonTable _summonTable;

    //public GameObject _cardObject;
    //public bool _descriptionIsShown;
    //public float _descriptionYBounds;

    public GameObject _label;
    public GameObject _title;
    //public GameObject _testQuad;

    public GameObject _titleSet;    // includes label and title
    private Vector3 _titleSetStartPosition;

    //public GameObject _descriptionSet;
    //private Vector3 _descriptionSetStartPosition;

    //public float _yBuffer = .02f;

    // Use this for initialization
    void Start()
    {

        // Where should the text start
        //ResetStartVectors();
        //SetDescriptionYBounds();

        // Subscribe to events
        //_handDraggable.StoppedDragging += ResetStartVectors;
        //_summonTable.OnMove += ResetStartVectors;

        // Start the description
        //_descriptionSet.SetActive(false);

    }

    public void SetNewData(string label, string title)
    {
        _label.GetComponent<TextMesh>().text = label;
        _title.GetComponent<TextMesh>().text = title;

    }

}
