using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClipScript : MonoBehaviour
{
    public int clipTag;
    public int playerTag;
    bool isActive;
    GameManager gm;

    private void Start()
    {
        isActive = false;
        gm = FindObjectOfType<GameManager>();
    }

    public void SetActive(bool set)
    {
        isActive = set;
    }

    public bool GetActive()
    {
        return isActive;
    }

    private void OnMouseDown()
    {
        if (isActive)
        {
            gm.StartPanelSelect(clipTag,playerTag);
            isActive = false;
        }
    }
}
