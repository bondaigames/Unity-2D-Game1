using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //GameSession.Instance.IncreaseShowAdsCount();
        FindObjectOfType<GameSession>().IncreaseShowAdsCount();
        FindObjectOfType<SceneLoader>().LoadGamePlayScene(0);
    }
}
