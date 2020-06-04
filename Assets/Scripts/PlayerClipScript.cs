using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClipScript : MonoBehaviour
{
    public int standingPanel;

    int clipTag;
    [SerializeField] bool isActive;
    Player pl;
    [SerializeField] Vector3 coord;

    private void Start()
    {
        isActive = false;
        coord = transform.position;
        pl = GetComponentInParent<Player>();
    }

    public void Move(Vector3 newCoord)
    {
        coord = newCoord;
        transform.position = coord;
    }

    public void SetActive(bool set)
    {
        isActive = set;
    }

    public bool GetActive()
    {
        return isActive;
    }

    public void SetTag(int tag)
    {
        clipTag = tag;
    }

    private void OnMouseDown()
    {

        if (isActive)
        {
            isActive = false;
            pl.StartPanelSelect(clipTag);
        }
    }

    public Vector3 GetCoord()
    {
        return coord;
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(coord, 2);
    //}
}
