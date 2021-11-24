using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using static InitManager;
using static GameManager;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public int curPosX;
    public int curPosY;
    public GameObject targetPlanePrefab;
    public GameObject targetPlane;
    
    public Vector2 targetPos;
    public int targetPosX;
    public int targetPosY;
    public int myTurn;
    private bool isMyTurnSelected = false;
    PhotonView PV;
    public static PlayerController playerController;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        playerController = GetComponent<PlayerController>();
        IM.PlayerControllerList.Add(this);
    }

    public void InitTargetPlane()
    {
        targetPlane = Instantiate(targetPlanePrefab, transform);
        targetPlane.SetActive(false);
    }

    public void Bulddeok()
    {
        targetPlane.SetActive(true);
        targetPosX = curPosX;
        targetPosY = curPosY;
        targetPlane.transform.position = MapManager.MM.map_pos[targetPosX, targetPosY];
    }

    public int DistanceCheck()
    {
        return Mathf.Abs(curPosX-targetPosX) + Mathf.Abs(curPosY-targetPosY);
    }

    public void SetTarget(int i)
    {
        if(i==0)
            targetPosX--;
        if(i==1)
            targetPosX++;
        if(i==2)
            targetPosY--;
        if(i==3)
            targetPosY++;

        if(DistanceCheck() > 4 || targetPosX < 0 || targetPosX > 7 || targetPosY <0 || targetPosY > 7 )
        {
            if(i==0)
                targetPosX++;
            if(i==1)
                targetPosX--;
            if(i==2)
                targetPosY++;
            if(i==3)
                targetPosY--;
        }
        else
        {
            targetPlane.transform.position = MapManager.MM.map_pos[targetPosX, targetPosY];
        }  
    }

    public void Move()
    {
        targetPlane.SetActive(false);
        //TODO 이동 로직
    }
    
    
    [PunRPC]
    void SetTurn(int turnNumber)
    {
        if(isMyTurnSelected == false)
        {
            myTurn = turnNumber;
            isMyTurnSelected = true;
        }
    }

    [PunRPC]
    public void CheckMyTurn()
    {
        if(!PV.IsMine)
            return;
        
        Debug.Log(GM.GetCurTurn() + "현재 턴");
        Debug.Log(gameObject.GetComponent<PlayerController>().myTurn + "나의 턴");

        if(myTurn == GM.GetCurTurn())
        {
            Debug.Log("myTurn!");
            UiManager.UM.MyTurnStart();
        }
        else
        {
            Debug.Log("not my Turn");
            UiManager.UM.OthersTurn();
        }
    }
}
