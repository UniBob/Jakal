using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsInfo : ScriptableObject
{
    [SerializeField] List<GameObject> tilesToRandom;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] int playersCount;
}
