using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class TrayTableTrigger : MonoBehaviour
{
    public GameObject TrayTableCanvas;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (TrayTableCanvas != null)
        {
            TrayTableCanvas.SetActive(true);
        }
    }
}
