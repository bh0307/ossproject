using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class PlayerListItem : MonoBehaviourPunCallbacks
{
   [SerializeField] Text nickname;
   Player player;

    public void SetUp(Player _player)
    {
        player = _player;
        nickname.text = _player.NickName;
    }

    public override void OnPlayerLeftRoom(Player left)
    {
        if (player == left)
        {
            Debug.Log("test 3333");
            Destroy(gameObject);
        }
    }
}
