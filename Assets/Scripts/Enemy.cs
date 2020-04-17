using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("detect object" + other.gameObject.tag);
        if (other.gameObject.tag.Equals("Player")){
            // StartCoroutine(LoadSceneAfterDelay(3f));
            Time.timeScale = 0f;
            Destroy(other.gameObject, 3f);
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        //Debug.Log("died");
        SceneManager.LoadScene(0);
    }
}
