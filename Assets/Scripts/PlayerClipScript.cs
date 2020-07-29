using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClipScript : MonoBehaviour
{
    [SerializeField] PlayerController pc;

    [SerializeField] bool isActive;
    [SerializeField] int clipTag;
    public bool isTakingCoin;


    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite clipWithCoin;
    [SerializeField] Sprite clipWithoutCoin;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        isTakingCoin = false;
        sprite.sprite = clipWithoutCoin;
    }

    public void SetActive(bool tmp)
    {
        // Debug.Log("Clip" + tmp);
        if (tmp)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.white;
        }
        isActive = tmp;
    }

    public void TakeCoin()
    {
        sprite.sprite = clipWithCoin;
        isTakingCoin = true;
    }

    public void DropCoin()
    {
        sprite.sprite = clipWithoutCoin;
        isTakingCoin = false;
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
            pc.EndSelection(tmp, clipTag);
        }
    }
}
