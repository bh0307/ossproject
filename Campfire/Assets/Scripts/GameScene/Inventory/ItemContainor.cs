using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType {
    NULL = 0,
    LongStick = 1,
    ShortStick = 2,
    Iron = 3,
    FlatIron = 4,
    SharpGlass = 5,
    IronStick = 6,


    Hammer = 7,
    Shovels = 8,
    Pickax = 9,
    Sickle = 10
}

public class ItemContainor : MonoBehaviour
{
    public Sprite[] itemImg = new Sprite[11];
    public static ItemContainor IC;

    void Awake()
    {
        IC = this;
    }
}
