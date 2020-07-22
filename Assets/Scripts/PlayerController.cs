using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<PlayerClipScript> clips;
    [SerializeField] GameManager gm;

    int selectClipTag;

    public void StartPreparation()
    {
        for(int i = 0;i<clips.Count;i++)
        {
            clips[i].SetActive(false);
            clips[i].SetTag(i);
        }
    }

    public void StartClipSelect()
    {
       // Debug.Log("PlayerController");
        SetClips(true);
    }

    public void MoveClip(Vector2 coord)
    {
        clips[selectClipTag].gameObject.transform.position = coord;
    }

    public void EndSelection(Vector2 clipCoord, int clipTag)
    {
        SetClips(false);
        selectClipTag = clipTag;
        gm.StartTileSelect(clipCoord);
    }

    void SetClips(bool tmp)
    {
        foreach (var clip in clips)
        {
            clip.SetActive(tmp);
        }
    }
}
