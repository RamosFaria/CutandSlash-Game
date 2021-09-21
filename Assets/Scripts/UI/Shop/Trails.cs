using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Trails", menuName = "Trails")]
public class Trails : ScriptableObject
{
    public GameObject Trail;
    public bool Unlocked;
    public GameObject ObjectDisplay;
    public int Price;

}
