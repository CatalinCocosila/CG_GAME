using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ShipStats shipStats;
    public GameObject bulletPrefab;

    private Vector2 offScreenPos = new Vector2(0, -20f);
    private Vector2 startPos = new Vector2(0, -4.5f);

    private const float MAX_LEFT = -3.1f;
    private const float MAX_RIGHT = 3.1f;

    private bool isShooting;

    void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLives = shipStats.maxLives;

        transform.position = startPos;

        //UIManager.UpdateHealthbar(shipStats.currentHealth);
        //UIManager.UpdateLives(shipStats.currentLives);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > MAX_LEFT)
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < MAX_RIGHT)
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
#endif
    }

    private void TakeDamage()
    {
        shipStats.currentHealth--;
        //UIManager.UpdateHealthbar(shipStats.currentHealth); 

        if(shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--;
            //UIManager.UpdateLives(shipStats.currentLives);

            if(shipStats.currentLives <= 0)
            {
                Debug.Log("GAME OVER");
                SaveManager.SaveProgress();
            }
            else
            {
                StartCoroutine(Respawn()); 
            }
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        shipStats.currentHealth = shipStats.maxHealth;

        transform.position = startPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player HIT");
            Destroy(collision.gameObject);
        }
    }
}
