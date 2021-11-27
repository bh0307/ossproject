using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public ItemType[] itemArr = new ItemType[2];    //내 인벤토리
    public Button[] itemSlot = new Button[2];       //아이템 슬롯(버튼)
    public static Inventory IM;

    PhotonView PV;
    void Awake()
    {
        IM = this;
        PV = GetComponent<PhotonView>();
        
        for(int i=0; i<itemArr.Length; i++)
        {
            itemArr[i] = ItemType.NULL;
        }
    }

    public void GetItem(int curPosX, int curPosY)
    {
        for(int i = 0; i<itemArr.Length; i++)
        {
            if(itemArr[i] == ItemType.NULL)
            {
                SetItemSlot(i, (ItemType)MapManager.MM.map[curPosX, curPosY]);             
                MapManager.MM.RPC_SetMapItem(curPosX, curPosY, 0); //다른 플레이어도 같이 동기화 되어야함
                Debug.Log("획득아이템 : "+(int)itemArr[i]);
                if(itemArr[i] == ItemType.NULL)
                    UiManager.UM.SetNotice("이곳엔 아이템이 없다.");
                else
                    UiManager.UM.SetNotice("아이템을 얻었다.");
                break;
            }
        }
    }

    public void MixItem()
    {
        ItemType itemA = itemArr[0];
        ItemType itemB = itemArr[1];

        if((int)itemA > (int)itemB)
        {
            ItemType temp = itemA;
            itemA = itemB;
            itemB = temp;
        }

        int result = ((int)itemA * 10 + (int)itemB);

        switch(result) {
            case 13:
            case 14:
            case 25:
            case 26:
                break;
            default:
                UiManager.UM.SetNotice("조합할 수 없다.");
            //조합할 수 없습니다 문구.
            Debug.Log("조합할 수 없습니다.");
                return;
        }
        Debug.Log("조합 완료");
        UiManager.UM.SetNotice("아이템을 하나 완성했다.");
        SetItemSlot(0, (ItemType)result);
        SetItemSlot(1, ItemType.NULL);
    }

    public void ThrowItemButton()
    {
        if(MapManager.MM.map[GameManager.GM.myController.curPosX, GameManager.GM.myController.curPosX] == 0)
        {
            if(itemArr[0] == ItemType.NULL && itemArr[1] == ItemType.NULL)
            {
                UiManager.UM.SetNotice("버릴 아이템이 없다.");
                return;
            }
            Debug.Log("버릴 아이템을 선택하세요");
            UiManager.UM.SetNotice("오른쪽에서 버릴 아이템을 선택해야한다.");
            //UI ON, 거기서 아이템 선택시 해당 아이템 사라지고 거기에 아이템 등록됨
            itemSlot[0].interactable = true;
            itemSlot[1].interactable = true;

        }
        else
        {
            UiManager.UM.SetNotice("이미 뭔가 버려져있다.");
            Debug.Log("이미 뭔가 버려져있다.");
        }
    }

    public void ThrowItem(int i)
    {
        itemSlot[0].interactable = false;
        itemSlot[1].interactable = false;
        MapManager.MM.RPC_SetMapItem(GameManager.GM.myController.curPosX, GameManager.GM.myController.curPosY, (int)itemArr[i]);
        SetItemSlot(i, ItemType.NULL);
        UiManager.UM.MyTurnAction();
        
    }

    public void SetItemSlot(int i, ItemType item)
    {
        itemArr[i] = item; //인벤토리 변경
        itemSlot[i].GetComponent<Image>().sprite = ItemContainor.IC.itemImg[(int)item]; //UI 이미지 교체
    }

    
}
