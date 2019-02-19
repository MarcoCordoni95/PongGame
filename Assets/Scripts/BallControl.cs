using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public int delayStart = 1;

    private Rigidbody2D rb2d;

    void Start() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        StartBallAfter1Second();
    }

    public void ResetBall() {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public void StartBallAfter1Second() {
        ResetBall();
        StartCoroutine(Waiting(delayStart));
    }

    IEnumerator Waiting(int sec) {
        yield return new WaitForSeconds(sec);

        int rand = Random.Range(0, 4);
        if (rand == 3)
            rb2d.AddForce(new Vector2(20, 15));
        else if (rand == 2)
            rb2d.AddForce(new Vector2(20, -15));
        else if (rand == 1)
            rb2d.AddForce(new Vector2(-20, 15));
        else
            rb2d.AddForce(new Vector2(-20, -15));
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            float x = rb2d.velocity.x;
            float y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = new Vector2(x, y);
        }
    }
}
