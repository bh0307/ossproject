using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public static HeartManager HM;
    public int heart = 1;

    void Awake()
    {
        HM = this;
    }

    public void HeartMove()
    {
        if (MapManager.MM.isGreenZone[GameManager.GM.myController.curPosX, GameManager.GM.myController.curPosY])
        {
            if (heart < 4)
                heart += 1;
        }
        else
        {
            if (heart > 0)
                heart -= 1;
        }
    }
}
