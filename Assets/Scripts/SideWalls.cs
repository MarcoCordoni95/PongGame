using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.name == "Ball") {
            string wallName = transform.name;
            GameManager.instance.Score(wallName);

            if(!GameManager.instance.victory)
                hitInfo.gameObject.SendMessage("StartBallAfter1Second");
            else
                hitInfo.gameObject.SendMessage("ResetBall");
        }
    }
}