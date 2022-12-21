using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject rockDeathVFX;
    [SerializeField] Sprite[] hitSprites;

    [SerializeField] int timesHit; // Only serialized for debug purposes!

    /*
    Level level;
    */

    /*
    private void Start()
    {
        CountBreakableRocks();
    }
    */

    /*
    private void CountBreakableRocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountRocks();
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyRock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Rock sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyRock()
    {
        PlayRockDestroySFX();
        Destroy(gameObject);
        /* 
        level.RockDestroyed();
        */
        TriggerDeathVFX();
    }

    private void PlayRockDestroySFX()
    {
        /*
        FindObjectOfType<GameSession>().AddToScore();
        */
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerDeathVFX()
    {
        GameObject sparkles = Instantiate(rockDeathVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
