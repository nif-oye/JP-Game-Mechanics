using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 700;
    float powerupStrength = 20;
    Rigidbody playerRb;
    GameObject focalPoint;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        playerRb.AddForce(focalPoint.transform.forward * verticalInput);
        playerRb.AddForce(focalPoint.transform.right * horizontalInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        powerupIndicator.transform.Rotate(Vector3.up, .5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(10);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(away * powerupStrength, ForceMode.Impulse);
            Debug.Log("Player collided with enemy and has a powerup");
        }
    }
}
