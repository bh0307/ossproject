using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType {
    NULL = 0,

    LongStick = 1,
    ShortStick = 2,

    
    IronStick = 3,
    FlatIron = 4,
    SharpGlass = 5,
    Iron = 6,
    

    Pickax = 13,
    Shovels = 14,
    Sickle = 25,
    Hammer = 26
}

public class ItemContainor : MonoBehaviour
{
    public Sprite[] itemImg = new Sprite[27];
    public static ItemContainor IC;

    void Awake()
    {
        IC = this;
    }
}
