using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<PlayerClipScript> clips;
    [SerializeField] ShipScript ship;
    [SerializeField] GameManager gm;

    int selectClipTag;
    bool isClip;

    int coinAmount;

    public void StartPreparation()
    {
        for(int i = 0;i<clips.Count;i++)
        {
            clips[i].SetActive(false);
            clips[i].SetTag(i);
        }
    }

    public bool CheckToAddCoins(Vector3 coord)
    {
        foreach (PlayerClipScript clip in clips)
        {
            if (!clip.isTakingCoin && (clip.gameObject.transform.position == coord))
            {
                clip.TakeCoin();
            }
        }
        return false;
    }

    public void StartClipSelect()
    {
       // Debug.Log("PlayerController");
        SetClips(true);
    }

    public void MoveClip(Vector2 coord)
    {
        clips[selectClipTag].gameObject.transform.position = coord;
        CheckOnSameTile();
    }

    public void EndSelection(Vector2 clipCoord, int clipTag)
    {
        SetClips(false);
        isClip = true;
        selectClipTag = clipTag;
        CheckOnSameTile();
        gm.StartTileSelect(clipCoord);
    }
    public void EndSelection(Vector2 clipCoord)
    {
        SetClips(false);
        isClip = false;
        CheckOnSameTile();
        gm.StartTileSelect(clipCoord);
    }

    void SetClips(bool tmp)
    {
        foreach (var clip in clips)
        {
            clip.SetActive(tmp);
        }
    }

    public Vector2 GetChosenClipCoord()
    {
        if (isClip) return clips[selectClipTag].gameObject.transform.position;
        else return ship.gameObject.transform.position;
    }

    public bool CheckAtack(Vector3 coord)
    {
        foreach (PlayerClipScript clip in clips)
        {
            if (clip.gameObject.transform.position == coord) return true;
        }
        return false;

    }

    public bool CheckShip(Vector3 coord)
    {
        if (ship.gameObject.transform.position == coord) return true;
        return false;
    }

    void CheckOnSameTile()
    {
        if ((clips[0].gameObject.transform.position == clips[1].gameObject.transform.position) && (clips[2].gameObject.transform.position == clips[1].gameObject.transform.position))
        {
            Vector3 position = new Vector3(-0.25f, 0.25f, 0);
            var tmp = position;
            foreach (var clip in clips)
            {
                clip.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                clip.gameObject.transform.position = new Vector3 (Mathf.Round(clip.gameObject.transform.position.x) + position.x, Mathf.Round(clip.gameObject.transform.position.y) + position.y, 0);
                position = position - tmp;
            }
        }
        else
            if ((clips[0].gameObject.transform.position == clips[1].gameObject.transform.position))
        {
            Vector3 position = new Vector3(-0.25f, 0.25f, 0);
            clips[0].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            clips[1].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            clips[2].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            clips[2].gameObject.transform.position = new Vector3(Mathf.Round(clips[2].gameObject.transform.position.x), Mathf.Round(clips[2].gameObject.transform.position.y), 0);
            clips[1].gameObject.transform.position = new Vector3(Mathf.Round(clips[1].gameObject.transform.position.x) + position.x, Mathf.Round(clips[1].gameObject.transform.position.y) + position.y, 0);
            clips[0].gameObject.transform.position = new Vector3(Mathf.Round(clips[0].gameObject.transform.position.x) - position.x, Mathf.Round(clips[0].gameObject.transform.position.y) - position.y, 0);
        }
        else
                if ((clips[2].gameObject.transform.position == clips[1].gameObject.transform.position))
        {
            Vector3 position = new Vector3(-0.25f, 0.25f, 0);
            clips[1].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            clips[2].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            clips[0].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            clips[0].gameObject.transform.position = new Vector3(Mathf.Round(clips[0].gameObject.transform.position.x), Mathf.Round(clips[0].gameObject.transform.position.y), 0);
            clips[1].gameObject.transform.position = new Vector3(Mathf.Round(clips[1].gameObject.transform.position.x) + position.x, Mathf.Round(clips[1].gameObject.transform.position.y) + position.y, 0);
            clips[2].gameObject.transform.position = new Vector3(Mathf.Round(clips[2].gameObject.transform.position.x) - position.x, Mathf.Round(clips[2].gameObject.transform.position.y) - position.y, 0);
        }   
        else
        if ((clips[2].gameObject.transform.position == clips[0].gameObject.transform.position))
        {
            Vector3 position = new Vector3(-0.25f, 0.25f, 0);
            clips[0].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            clips[2].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            clips[1].gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            clips[1].gameObject.transform.position = new Vector3(Mathf.Round(clips[1].gameObject.transform.position.x), Mathf.Round(clips[1].gameObject.transform.position.y), 0);
            clips[0].gameObject.transform.position = new Vector3(Mathf.Round(clips[0].gameObject.transform.position.x) + position.x, Mathf.Round(clips[0].gameObject.transform.position.y) + position.y, 0);
            clips[2].gameObject.transform.position = new Vector3(Mathf.Round(clips[2].gameObject.transform.position.x) - position.x, Mathf.Round(clips[2].gameObject.transform.position.y) - position.y, 0);
        }
        else
        {
            foreach (PlayerClipScript clip in clips)
            {
                clip.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                Vector3 tmp;
                tmp.x = Mathf.Round(clip.gameObject.transform.position.x);
                tmp.y = Mathf.Round(clip.gameObject.transform.position.y);
                tmp.z = 0;
                clip.gameObject.transform.position = tmp;
            }
        }
    }

    public void RetutnToShip(Vector3 coord)
    {
        foreach (PlayerClipScript clip in clips)
        {
            if (clip.gameObject.transform.position == coord)
            {
                clip.gameObject.transform.position = ship.gameObject.transform.position;
                if (clip.isTakingCoin)
                {
                    clip.DropCoin();
                    CheckCoins(coord);
                }
            }
        }
        CheckOnSameTile();
    }

    public void CheckCoins(Vector3 coord)
    {
        foreach (PlayerClipScript clip in clips)
        {
            if (!clip.isTakingCoin)
            {
                clip.TakeCoin();
            }
        }
    }
}
