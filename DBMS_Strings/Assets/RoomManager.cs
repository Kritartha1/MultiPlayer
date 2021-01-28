using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);//if there is alreay a room manager before game start , destroy it
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

     public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex==1)  //1 is the index of game scene. Change it according to the build settings
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"),Vector3.zero,Quaternion.identity);
        }
    }


}
