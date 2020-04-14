using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public GameObject gameMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        // PauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        // if (GameIsPaused)
        // {
        //     PauseGame();
        // }
        // else {
        //     StartGame();
        // }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        // gameMenuUI.SetActive(false);
        GameIsPaused = false;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        gameMenuUI.SetActive(true);
        GameIsPaused = true;
    }
}
