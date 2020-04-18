using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainScene(float delayInSeconds)
    {
        StartCoroutine(WaitAndLoadScene(delayInSeconds, 0));
    }

    IEnumerator WaitAndLoadScene(float delayInSeconds, int sceneNumber)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneNumber);
    }


}
