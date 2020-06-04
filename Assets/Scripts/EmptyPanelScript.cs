using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPanelScript : MonoBehaviour
{
    [SerializeField] Vector3 coord;

    [SerializeField] int panelTag;
    [SerializeField] bool isActive;
    GameManager gm;


    private void Start()
    {
        isActive = false;
        gm = GetComponent<GameManager>();
        coord = transform.position;
    }

    private void OnMouseDown()
    {
        if (isActive)
        {
            isActive = false;
            
            gm.StartClipSelect(panelTag);
        }
    }

    public void SetActive(bool tmp)
    {
        isActive = tmp;
        Debug.Log(tmp);
        GetComponent<BoxCollider2D>().enabled = tmp;
    }

    public bool GetActive()
    {
        return isActive;
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
