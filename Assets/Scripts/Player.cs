using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 15.0f;
    [SerializeField] float playerLimitMax = 0.95f;
    [SerializeField] float playerLimitMin = 0.05f;
    [SerializeField] int health= 500;
    [SerializeField] float waitForDeath = 3f;
    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 30.0f;
    [SerializeField] float projectileFiringPeriod = .2f;
    [SerializeField] GameObject laserPrefab;
    [Header("Effects")]
    [SerializeField] GameObject explosionParticles;
    [SerializeField] float durationOfExplosion = 1.0f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip playerFireSound;
    [SerializeField] [Range(0, 1)] float fireSoundVolume = 0.7f;
    // [SerializeField] float laserOffset = 0.8f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
        Fire();
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            AudioSource.PlayClipAtPoint(playerFireSound, Camera.main.transform.position, fireSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            if (!damageDealer)
            {
                return;
            }
            ProcessHit(damageDealer);
       
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Debug.Log("DEATH");
            Death();
        }
    }

    private void Death()
    {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionParticles, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, deathSoundVolume);
    }


    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(playerLimitMin, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(playerLimitMax, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, playerLimitMin, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, playerLimitMax, 0)).y;
    }
}
