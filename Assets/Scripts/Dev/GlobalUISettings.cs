using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalUISettings : MonoBehaviour {

    public static GlobalUISettings Instance;

    [Header("Connectors")]
    public bool _renderConnections;
    public float _lineWidths;
    public Material _lineMaterial;

    [Header("Prefabs")]
    public GameObject rollupPrefab;
    public GameObject namePrefab;
    public GameObject jobPrefab;
    public GameObject affPrefab;

    [Header("Formatting")]
    public float _tagSpacing;
    public Vector3 _tagIndent;
    public float _infoSetHeight;
    public Color _rollupMatchColor;
    public Color _rollupDefaultColor;
    public float _maximumYTagalong = 0.0f;



    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}
