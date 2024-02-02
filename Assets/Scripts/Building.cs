using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "New Buidling")]

public class Building : ScriptableObject
{
    public string name;
    [Multiline]
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public int cost;
}
