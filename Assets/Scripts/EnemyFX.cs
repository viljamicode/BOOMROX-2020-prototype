using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFX : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameObject deathVFX;

    [SerializeField] float durationOfExplosion = 1f;
    /*
    public float explosionRadius = 5.0F;
    public float explosionPower = 10.0F;
    */
    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.25f;


    // this won't work since the collider&rigidbody is 2D:
    /*
    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(explosionPower, explosionPos, explosionRadius, 3.0F);
        }
    }
    */

void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        }

    }

}
