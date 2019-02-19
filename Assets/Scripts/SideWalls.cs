using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D ballCollider) {
        if (ballCollider.tag == "Ball") {
            string wallName = transform.name;
            GameManager.instance.Score(wallName);

            if (!GameManager.instance.victory)
                ballCollider.GetComponent<BallControl>().StartBallAfter1Second();
            else
                ballCollider.GetComponent<BallControl>().ResetBall();
        }
    }
}