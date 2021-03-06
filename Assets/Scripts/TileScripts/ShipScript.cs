﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    [SerializeField] bool isActive;
    [SerializeField] int clipTag;

    public void SetActive(bool tmp)
    {
        // Debug.Log("Clip" + tmp);
        if (tmp)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        isActive = tmp;
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
            Vector2 tmp = new Vector2(Mathf.Round(gameObject.transform.position.x), Mathf.Round(gameObject.transform.position.y));
            pc.EndSelection(tmp, 1);
        }
    }


}
