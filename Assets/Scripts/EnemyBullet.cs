using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vector2.down * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Colision2D colision)
    {

    }
}
