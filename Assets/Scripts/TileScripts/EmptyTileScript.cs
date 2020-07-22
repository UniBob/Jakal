using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileScript : MonoBehaviour
{
    [SerializeField] TileEffect te;
    [SerializeField] TableManager tm;
    [SerializeField] Sprite upSide;
    [SerializeField] Sprite downSide;
    SpriteRenderer sprite;
    bool isActive;
    //bool isEmpty;
    bool isOpen;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>(); 
    }

    public void ClipDown()
    {
        //Debug.Log("Tile down");
        if (!isOpen)
        {
            isOpen = true;
            sprite.sprite = upSide;
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
        
        sprite.sprite = downSide;
        //isEmpty = false;
    }

    public void SetActive(bool tmp)
    {
       // Debug.Log(tmp);
        if (tmp)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.white;
        }
      //  if (isEmpty && tmp) 
        isActive = tmp;
    }

    public void SetActive(bool tmp, Vector2 coord)
    {
        // Debug.Log(tmp);
        if (tmp)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.white;
        }
        //  if (isEmpty && tmp) 
        isActive = tmp;
        te.ActivatePanel(coord);
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


}
