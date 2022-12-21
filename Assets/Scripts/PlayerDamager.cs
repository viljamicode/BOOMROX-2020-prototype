using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // temporary, just for testing. move to own script later! 

public class PlayerDamager : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameObject deathVFX;

    [SerializeField] float durationOfExplosion = 1f;

    [Header("Sounds")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.25f;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "PlayerDamager")
        {
            FindObjectOfType<GameSession>().ReloadMap();
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        }

    }

}
