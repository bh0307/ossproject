using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum ItemType {
    NULL = 0,
    LongStick = 1,
    ShortStick = 2,
    Iron = 3,
    FlatIron = 4,
    SharpGlass = 5,
    IronStick = 6,


    Hammer,
    Shovels,
    Pickax,
    Sickle
}

public class Inventory : MonoBehaviour
{
    public ItemType[] itemArr = new ItemType[4];
    public static Inventory IM;
    PhotonView PV;
    void Awake()
    {
        IM = this;
        PV = GetComponent<PhotonView>();
        
        for(int i=0; i<4; i++)
        {
            itemArr[i] = ItemType.NULL;
        }
    }

    public void GetItem(int curPosX, int curPosY)
    {
        Debug.Log("GetItem");
        for(int i = 0; i<4; i++)
        {
            if(itemArr[i] == ItemType.NULL)
            {
                Debug.Log("if문 ok");
                itemArr[i] = (ItemType)MapManager.MM.map[curPosX, curPosY];
                Debug.Log("아이템 획득");
                MapManager.MM.RPC_SetMapItem(curPosX, curPosY, 0); //다른 플레이어도 같이 동기화 되어야함
                Debug.Log((int)itemArr[i]);
                break;
            }
        }
    }

    public ItemType MixItem(ItemType itemA, ItemType itemB)
    {
        ItemType result = itemA;

        if(itemA == ItemType.LongStick && itemB == ItemType.IronStick)
            result = ItemType.Pickax;
        if(itemA == ItemType.LongStick && itemB == ItemType.FlatIron)
            result = ItemType.Shovels;
        if(itemA == ItemType.ShortStick && itemB == ItemType.Iron)
            result = ItemType.Hammer;
        if(itemA == ItemType.ShortStick && itemB == ItemType.SharpGlass)
            result = ItemType.Sickle;
        
        return result;
    }

    
}
