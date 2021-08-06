using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private NetworkManager networkManager;

    public void ChangeScene()
    {
        StartCoroutine(LoadLobby());
    }

    IEnumerator LoadLobby()
    {
        networkManager.Connect();
        yield return new WaitUntil(() => NetworkManager.GetStatus() == "isOnLobby");
        SceneManager.LoadScene("LobbyScene");
    }
}
