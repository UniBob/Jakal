using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClipScript : MonoBehaviour
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
            Vector2 tmp = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            pc.EndSelection(tmp, clipTag);
        }
    }


}
