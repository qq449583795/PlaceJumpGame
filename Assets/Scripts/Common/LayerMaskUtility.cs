using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskUtility 
{
    // Start is called before the first frame update
    public static bool Contains(LayerMask layerMask1, int layer)
    {//
        return (layerMask1 & 1 << layer) > 0;
    }
}
