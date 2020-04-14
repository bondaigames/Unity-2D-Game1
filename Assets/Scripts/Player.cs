using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rigidbody2D;
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
            // rigidbody2D.AddForce(Vector2.up * 10 * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    public bool IsPlayerMoving()
    {
        if (transform.hasChanged)
        {
            return true;
        }
        return false;
    }

    private void FixedUpdate() {
        
    }
}
