using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetTexture : MonoBehaviour {

    public void GetTextureData(string url)
    {
        StartCoroutine(SendRequest(url));
    }


    public IEnumerator SendRequest(string requestString)
    {
        Debug.Log("SendRequest called.");

        // Make the request
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(requestString);
        yield return request.Send();

        // UnityEngine.Debug.Log(request.downloadHandler.text);

        Texture t = ((DownloadHandlerTexture)request.downloadHandler).texture;
        AssignTexture(t);

        yield return null;


    }

    void AssignTexture(Texture t)
    {
        // assign texture
        Material quadM = GetComponent<Renderer>().material;
        quadM.mainTexture = t;

        float ratio = (float)t.width / t.height;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.x/ratio, transform.localScale.z);
    }

}
