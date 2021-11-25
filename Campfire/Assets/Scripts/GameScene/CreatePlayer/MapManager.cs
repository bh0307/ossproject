using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MapManager : MonoBehaviour
{
    public int[,] map = new int[8, 8];      //게임 맵 8x8에 배치된 아이템에 대한 배열
    public Vector3[,] map_pos = new Vector3[8,8];
    public bool[,] isGreenZone = new bool[8,8];
    public int count = 10;                  //찍어낼 오브젝트 갯수

    public static MapManager MM;
    PhotonView PV;

    void Awake()
    {
        MM=this;
        PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < count; i++)     //count 수 만큼 생성한다.
            {
                Spawn();
            }
        }
        
    }

    public void SetMapPos()
    {
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
               map_pos[i,j] = new Vector3( 2 * j, 0, -2 * i);
            }
        }
    }

    public void SetGreenZone()
    {
        for(int i=0; i<8; i++)
        {
            for(int j=0; j<8; j++)
            {
                if( (1 < i && i < 6) && ( 1 < j && j < 6) )
                {
                    isGreenZone[i, j] = true;
                }
                else
                {
                    isGreenZone[i, j] = false;
                }
            }
        }
    }

    [PunRPC]
    public void SetMapItem(int posX, int posY, int item)
    {
        map[posX, posY] = item;
    }

    public void RPC_SetMapItem(int posX, int posY, int item)
    {
        PV.RPC("SetMapItem", RpcTarget.All, posX, posY, item);
        Debug.Log(posX + " " + posY);
    }

    private void Spawn()
    {
        int posX;
        int posY;
        int selection;

        while(true)
        {
            posX = Random.Range(0, 8);
            posY = Random.Range(0, 8);

            if (map[posX, posY] == 0 && !isGreenZone[posX,posY])           // map 배열의 값이 0이면 해당 위치에는 아이템이 없다는 뜻
            {
                selection = Random.Range(1, 7);
                PV.RPC("SetMapItem", RpcTarget.All, posX,posY,selection);    // map 배열에 생성할 아이템 정보 저장
                break;
            }
        }

        Debug.Log(posX + " " + posY);
    }
}