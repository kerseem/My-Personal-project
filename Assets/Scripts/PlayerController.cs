using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 200.0f;
    private float topBound = 14;
    private float bottomBoun = -2;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayer();
        ConstrainPlayerPosition();
    }

    // move the player with the arrow keys
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertcalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * vertcalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // upper and lower z axis boundary for the player
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < bottomBoun)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBoun);
        }
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with an enemy");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
