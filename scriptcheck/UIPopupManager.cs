using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPoppupManager : MonoBehaviour
{
    public static UIPoppupManager Instance;
    public GameObject GlobalBlocker;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalBlocker != null)
        {
            GlobalBlocker.SetActive(false);
        }
    }

    public void ShowPopup(GameObject Popup)
    {
        if (GlobalBlocker != null)
        {
            GlobalBlocker.SetActive(true);
        }
        Popup.SetActive(true);
    }
    // Update is called once per frame
    public void ClosePopup(GameObject Popup)
    {
        Popup.SetActive(false);

        if (GlobalBlocker != null)
        {
            GlobalBlocker.SetActive(false);    
        }
        
    }
}
