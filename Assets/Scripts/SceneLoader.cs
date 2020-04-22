using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGamePlayScene(float delayInSeconds)
    {
        StartCoroutine(WaitAndLoadScene(delayInSeconds, 1));

        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadMenuScene(float delayInSeconds)
    {
        StartCoroutine(WaitAndLoadScene(delayInSeconds, 0));
    }

    IEnumerator WaitAndLoadScene(float delayInSeconds, int sceneNumber)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneNumber);
    }
}
