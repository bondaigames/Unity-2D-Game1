using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rigidbody2D;
    public GameObject deathVFX;

    [Header("Dead Sound Config")]
    public AudioClip deathSound;
    public float deathSoundVolume;
    public float durationOfExplosion;

    [Header("Jump Sound Config")]
    public AudioClip jumpSound;
    public float jumpSoundVolume;

    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
            rigidbody2D.velocity = Vector2.up * jumpForce;
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, jumpSoundVolume);
            // rigidbody2D.AddForce(Vector2.up * 10 * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Bar"))
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            FindObjectOfType<SceneLoader>().LoadMenuScene(durationOfExplosion);
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(explosion, durationOfExplosion);
        }
    }
}
