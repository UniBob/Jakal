using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPanelScript : MonoBehaviour
{
    [SerializeField] int panelTag;
    [SerializeField] bool isActive;
    [SerializeField] bool isWater;
    [SerializeField] GameObject panelOption;
    
    GameManager gm;
    Vector3 coord;

    private void Start()
    {
        isActive = false;
        gm = FindObjectOfType<GameManager>();
        coord = transform.position;
    }

    private void OnMouseDown()
    {
        if (isActive)
        {
            isActive = false;
            panelOption.panelOption(gm,this);
            gm.StartClipSelect(coord);
        }
    }

    public void SetActive(bool tmp)
    {
        isActive = tmp;
        GetComponent<BoxCollider2D>().enabled = tmp;
    }

    public bool GetActive()
    {
        if (!isWater) return isActive;
        else
            return false;
    }

    public void SetTag(int tag)
    {
        panelTag = tag;
    }

    public int GetTag()
    {
        return panelTag;
    }

    public Vector3 GetCoord()
    {
        return coord;
    }
}
