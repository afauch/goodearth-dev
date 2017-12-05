using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticUtilities {

    /// <summary>
    /// Used to grab the original material of a GameObject.
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    public static Material GetOriginalMaterial(GameObject g)
    {
        Material m = null;
        Renderer r = g.GetComponent<Renderer>();
        if (r != null)
            m = r.material;
        return m;
    }

}
