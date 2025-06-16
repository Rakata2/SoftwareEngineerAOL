using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class StickyTrigger : MonoBehaviour
{
    public GameObject StickyCanvas;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (StickyCanvas != null)
        {
            StickyCanvas.SetActive(true);
        }
    }
}
