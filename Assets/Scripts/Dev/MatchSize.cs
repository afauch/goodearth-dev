using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crayon;

public class MatchSize : MonoBehaviour {

	public string text;
	public GameObject label;
	public GameObject tagBody;
	public float xPadding;
	public GameObject sphereCap1;
	public GameObject sphereCap2;
	public float multiplier = 1;

    private Vector3 alignmentPoint;

	// Use this for initialization
	void Start () {

        alignmentPoint = GlobalUISettings.Instance._tagIndent;
        label.GetComponent<TextMesh> ().text = text;
        // SetSize();
	}

    public IEnumerator SetSize() {

        yield return new WaitForSeconds(4.0f);

        // matchToBounds is in a global scale ...
        Vector3 matchToBounds = label.gameObject.GetComponent<Renderer>().bounds.extents;

        // need to find a way to set the scale of tagBody either in global terms,
        // or convert matchToBounds to local terms

        Debug.Log("bounds of " + label.gameObject.name + " = " + matchToBounds);
        Vector3 scale = tagBody.transform.localScale;
        float adjustedXVal = ((matchToBounds.x) / tagBody.transform.lossyScale.x) + xPadding;
        tagBody.transform.localScale = new Vector3(adjustedXVal, scale.y, scale.z);
        // SetGlobalScale(tagBody.transform, new Vector3((matchToBounds.x) + xPadding, scale.y, scale.z));

        Vector3 spherePos1 = sphereCap1.transform.localPosition;
        Vector3 spherePos2 = sphereCap2.transform.localPosition;

        // Put the caps in the correct spot
        sphereCap1.transform.localPosition = new Vector3(tagBody.transform.localScale.x, spherePos1.y, spherePos1.z);
        sphereCap2.transform.localPosition = new Vector3(-tagBody.transform.localScale.x, spherePos2.y, spherePos2.z);

        // Parent them so they can resize correctly
        sphereCap1.transform.SetParent(tagBody.transform);
        sphereCap2.transform.SetParent(tagBody.transform);

        GetComponent<CrayonStateManager>().FreezeTransform();

        // Set collider size
        BoxCollider collider = GetComponent<BoxCollider>();
        // Note: collider sizes stay relative to their attached GameObject
        float adjustedColliderXSize = tagBody.GetComponent<BoxCollider>().size.x * tagBody.transform.localScale.x;
        collider.size = new Vector3(adjustedColliderXSize, collider.size.y, collider.size.z);
        collider.center += new Vector3(adjustedXVal, 0.0f, 0.0f);

        // Left align to the alignment point
        // First, center
        this.gameObject.transform.localPosition = new Vector3(alignmentPoint.x, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
        // Then offset
        // tagBody.transform.localPosition = new Vector3(alignmentPoint.x + adjustedXVal, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z);
        tagBody.transform.localPosition += new Vector3(adjustedXVal, 0.0f, 0.0f);
        label.transform.localPosition += new Vector3(adjustedXVal, 0.0f, 0.0f);

        yield return null;

    }

    public void SetText(string textToSet)
    {
        StartCoroutine(SetTextCoroutine(textToSet));
    }

    IEnumerator SetTextCoroutine(string textToSet)
    {
        text = textToSet;
        label.GetComponent<TextMesh>().text = textToSet;
        StartCoroutine(SetSize());
        yield return null;
    }

}
