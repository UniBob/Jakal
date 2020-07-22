using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileScript : MonoBehaviour
{
    [SerializeField] TileEffect te;
    [SerializeField] TableManager tm;
    [SerializeField] Sprite upSide;
    [SerializeField] Sprite downSide;
    bool isActive;
    //bool isEmpty;
    bool isOpen;


    public void ClipDown()
    {
        Debug.Log("Tile down");
        if (!isOpen)
        {
            isOpen = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = upSide;
        }
        
        te.RunTileEffect();
       // isEmpty = false;
        tm.TurnEnd(gameObject.transform.position);
    }

    public void StartPrep(Vector2 coord)
    {
        gameObject.transform.position = coord;
        SetActive(false);
        isOpen = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = downSide;
        //isEmpty = false;
    }

    public void SetActive(bool tmp)
    {
       // Debug.Log(tmp);
        if (tmp)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
      //  if (isEmpty && tmp) 
        isActive = tmp;
    }

    //public void SetEmpty(bool tmp)
    //{
    //    isEmpty = tmp;
    //}

    public bool GetOpen()
    {
        return isOpen;
    }

    public bool GetActive()
    {
        return isActive;
    }

     void SetClipInHere(int playerTag)
    {

    }

}
