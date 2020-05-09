using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPanelScript : MonoBehaviour
{
    public int panelTag;

    bool isActive;
    GameManager gm;

    private void Start()
    {
        isActive = false;
        gm = GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (isActive)
        {
            gm.StartClipSelect(panelTag);
        }
    }

    public void SetActive(bool tmp)
    {
        isActive = tmp;
    }

    public bool GetActive()
    {
        return isActive;
    }
}
