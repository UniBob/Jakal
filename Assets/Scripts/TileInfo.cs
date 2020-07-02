using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info")]

public class TileInfo : ScriptableObject
{
    public List<EmptyTileScript> tilesToRandom;
    public List<EmptyTileScript> allTiles;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] int playersCount;
}

