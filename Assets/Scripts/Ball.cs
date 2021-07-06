using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    private float ballSpeed;
    private float maxBallSpeed = 15f;
    private Vector2 ballDirection = Vector2.zero;
    private Vector2 ballVeloicity;
    void Start()
    {
        ballSpeed = 10f;
        ballRigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(ballDirection != Vector2.zero && ballRigidbody.velocity.magnitude != ballSpeed)
        {
            ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, ballRigidbody.velocity.y).normalized * ballSpeed;
        }
        ballVeloicity = ballRigidbody.velocity;
    }
    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Block" || collision.gameObject.tag == "Player")
            {
                ballDirection = Vector2.Reflect(ballVeloicity.normalized, collision.contacts[0].normal);
            }
        }*/
    public void ThrowBall()
    {
        /*ballRigidbody.AddForce(new Vector2(Random.Range(-0.7f, 0.7f), 1f).normalized * ballSpeed);*/
        ballDirection = new Vector2(Random.Range(-0.7f, 0.7f), 1f).normalized;
        ballRigidbody.velocity = ballDirection * ballSpeed;
    }
    public void ChangeSpeed(float modifier)
    {
        if(ballSpeed < maxBallSpeed)
        {
            ballSpeed += modifier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "LoosePoint")
        {
            GameManager.instance.GameLoose();
        }
    }

}
