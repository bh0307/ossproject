using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemType[] itemArr = new ItemType[4];    //내 인벤토리
    public Image[] ItemSlotImage;                   //UI의 Image
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
        for(int i = 0; i<4; i++)
        {
            if(itemArr[i] == ItemType.NULL)
            {
                itemArr[i] = (ItemType)MapManager.MM.map[curPosX, curPosY];             //인벤토리에 저장
                ItemSlotImage[i].sprite = ItemContainor.IC.itemImg[(int)itemArr[i]];    //이미지 교체
                MapManager.MM.RPC_SetMapItem(curPosX, curPosY, 0); //다른 플레이어도 같이 동기화 되어야함
                Debug.Log("획득아이템 : "+(int)itemArr[i]);
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

    public void ThrowItem()
    {

    }

    
}
