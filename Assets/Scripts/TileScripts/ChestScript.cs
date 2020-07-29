using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : TileEffect
{
    [SerializeField] int coinsAmount;
    [SerializeField] List<Sprite> coinsAmountSprite;
    TableManager tm;
    SpriteRenderer sprite;

    public override void RunTileEffect(Vector2 coord)
    {
        tm = FindObjectOfType<TableManager>();
        coinsAmount--;
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = coinsAmountSprite[coinsAmount];
        tm.GiveACoin(gameObject.transform.position);
        GetComponent<EmptyTileScript>().TurnEnd();
    }
    public override void ActivatePanel(Vector2 tmp) 
    {
        if (coinsAmount >= 0)
        {
            coinsAmount--;
            sprite.sprite = coinsAmountSprite[coinsAmount];
            tm.GiveACoin(gameObject.transform.position);
        }
    }
}

