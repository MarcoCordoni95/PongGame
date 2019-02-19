using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls2 : MonoBehaviour {

    public float speed = 10.0f;
    public float boundY = 2.25f;

    private void Update() {
        float verticalMovement = Input.GetAxis("Vertical2");
        Vector3 direction = new Vector3(0, 0, 0);

        if (verticalMovement != 0)
            direction.y = verticalMovement;
        
        transform.Translate(direction * (speed * Time.deltaTime));

        if (transform.position.y > boundY)
            transform.position = new Vector2(transform.position.x, boundY);
        
        else if (transform.position.y < -boundY)
            transform.position = new Vector2(transform.position.x, -boundY);
    }
}
