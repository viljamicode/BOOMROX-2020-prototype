using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpFX : MonoBehaviour
{
    //when Player bumps into something, play this VFX

    [Header("VFX")]
    [SerializeField] GameObject bumpVFX;
    [SerializeField] float durationOfExplosion = 1f;

    [Header("Sounds")]
    [SerializeField] AudioClip bumpSound;
    [SerializeField] [Range(0, 1)] float bumpSoundVolume = 0.75f;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
            Destroy(coll.gameObject);
        GameObject explosion = Instantiate(bumpVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(bumpSound, Camera.main.transform.position, bumpSoundVolume);
    }
}
