using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private FixedJoint2D playerJoint;
    private float playerSpeed = 1000f;
    private Vector2 playerDirection;
    private Ball ball;
    void Start()
    {
        transform.localScale = new Vector2(1,1);
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerJoint = GetComponent<FixedJoint2D>();
        ball = FindObjectOfType<Ball>();
        playerJoint.connectedBody = ball.gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (GameManager.instance.isInputEnabled)
        {
            playerDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
            if (playerJoint.connectedBody && Input.GetKeyDown(KeyCode.Space))
            {
                playerJoint.connectedBody = null;
                playerJoint.enabled = false;
                ball.ThrowBall();
                ball = null;
            }
        }
    }
    private void FixedUpdate()
    {
        playerRigidbody.velocity = playerDirection * playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            collision.GetComponent<PowerUp>().ApplyPowerUp();
            Destroy(collision.gameObject);
        }
    }
}
