using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Packs", menuName = "Packs")]
public class Packs : ScriptableObject
{
    public GameObject[] ObjectsInPack;
    public GameObject ObjectDisplay;
    public int Price;
    public bool Unlocked;
}
