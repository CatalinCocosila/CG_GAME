using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    private float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vector2.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Colision2D colision)
    {

    }
}
