using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("detect object" + other.gameObject.tag);
        FindObjectOfType<GameSession>().AddScore(1);
        Destroy(gameObject);
    }
}
