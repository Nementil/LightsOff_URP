using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class SO_Enemy1 : ScriptableObject
{
    public Sprite sprite;
    public int rangeLook;
    public float speed;
    public int treshold;
    public List<SO_Items> lootTable;
}
