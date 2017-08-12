using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D rb;
    public float BallReleaseVelocity = 10;
    private bool isStarted = false;
    private AudioSource audioBall;

	void Start () {
        audioBall = GetComponent<AudioSource>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(2f, BallReleaseVelocity);
            isStarted = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 AddRandomVelocity = new Vector2(Random.Range(-1f, 1f),
                                                Random.Range(-1f, 1f));
        rb.velocity += AddRandomVelocity;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -12, 12),
                                  Mathf.Clamp(rb.velocity.y, -12, 12));
        if (isStarted)
        {
            audioBall.Play();
        }
    }
}
