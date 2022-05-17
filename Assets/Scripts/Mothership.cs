using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    public int scoreValue;

    private const float MAX_LEFT = -5f;
    private float speed = 5;
    
    void Update()
    {
        transform.Translate(Vector2.left * time.deltaTime * speed);

        if (transform.position.x <= MAX_LEFT)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Colision2D colision)
    {

    }
}
