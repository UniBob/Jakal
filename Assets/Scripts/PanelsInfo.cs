using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info")]

public class PanelsInfo : ScriptableObject
{
    public List<EmptyPanelScript> tilesToRandom;
    public List<GameObject> allTiles;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] int playersCount;
}
