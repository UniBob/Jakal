using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  //  public GameObject[] tilesToRandom;
  //  public GameObject playerPrefab;

    EmptyPanelScript[] allTilesOnField;
    Player[] activePlayers;
    int currentPlayerID;
    int playerAmmount;
    int currentPlayerClipTag;

    private void Start()
    {
        activePlayers = FindObjectsOfType<Player>();
        int j = 0;
        foreach(var i in activePlayers)
        {
            i.SetID(j);
            j++;
        }
        allTilesOnField = FindObjectsOfType<EmptyPanelScript>();
        j = 0;
        foreach (var i in allTilesOnField)
        {
            i.SetTag(j);
            i.SetActive(false);
            j++;
        }
        StartGame();
        
    }

    void StartGame()
    {
        activePlayers[0].StartTurn();
    }

    public void StartClipSelect(int tileTag)
    {
        SetActivePanel(activePlayers[currentPlayerID].GetClipCoord(currentPlayerClipTag), false);
        activePlayers[currentPlayerID].MoveClip(allTilesOnField[tileTag].GetCoord(), currentPlayerClipTag);
    }

    public void StartPanelSelect(int playerClipTag, int playerTag)
    {
        currentPlayerID = playerTag;
        currentPlayerClipTag = playerClipTag;
        SetActivePanel(activePlayers[playerTag].GetClipCoord(playerClipTag), true);
    }
    
    void SetActivePanel(Vector3 coord, bool tmp)
    {
        Collider2D[] tilesToMove = Physics2D.OverlapCircleAll(coord, 2, LayerMask.GetMask("Panel"));
        foreach (Collider2D i in tilesToMove)
        {
            i.GetComponent<EmptyPanelScript>().SetActive(tmp);
            Debug.Log(i.GetComponent<EmptyPanelScript>().GetTag());
        }
    }

    
}
