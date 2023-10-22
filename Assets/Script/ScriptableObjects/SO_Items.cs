using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class SO_Items : ScriptableObject
{
    public float dropRate;
    public GameObject item;
}
