using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LIstTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ListUICanvas;

    // Update is called once per frame
    void OnMouseDown()
    {
        if(ListUICanvas != null)
        {
            ListUICanvas.SetActive(true);
        }
    }
}
