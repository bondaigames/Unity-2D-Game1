using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("detect object" + other.gameObject.tag);
        //if (other.gameObject.tag.Equals("Player")){
        //    // StartCoroutine(LoadSceneAfterDelay(3f));
            
            
        //}
    }

    private IEnumerator LoadSceneAfterDelay(float delay) 
    {
        yield return new WaitForSeconds(delay);
        //Debug.Log("died");
        //SceneManager.LoadScene(0);
    }
}
