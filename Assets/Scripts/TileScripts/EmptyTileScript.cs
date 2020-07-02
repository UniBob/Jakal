using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileScript : MonoBehaviour
{
    [SerializeField] TileEffect te;

    TableManager tm;

    bool isActive;

    void Start()
    {
        tm = FindObjectOfType<TableManager>();
    }

    public void ClipDown()
    {
        te.RunTileEffect();
        tm.TurnEnd();
    }

}
