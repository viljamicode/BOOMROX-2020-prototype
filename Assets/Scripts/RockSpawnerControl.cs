using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawnerControl : MonoBehaviour
{

	/* [Header("VFX")]
	[SerializeField] GameObject spawnVFX;
	[SerializeField] float durationOfExplosion = 1f;

	[Header("Sounds")]
	[SerializeField] AudioClip spawnSound;
	[SerializeField] [Range(0, 1)] float spawnSoundVolume = 0.3f; */


	public Transform[] spawnPoints;
	public GameObject[] rocks;
	public Collider2D[] colliders;
	int randomSpawnPoint, randomRock;
	public static bool spawnAllowed;



	void Start()
	{
		spawnAllowed = true;
		InvokeRepeating("SpawnARock", 0f, 1.5f);
	}


	void SpawnARock()
	{
		if (spawnAllowed)
		{
			randomSpawnPoint = Random.Range(0, spawnPoints.Length);
			randomRock = Random.Range(0, rocks.Length);
			Instantiate(rocks[randomRock], spawnPoints[randomSpawnPoint].position,
			Quaternion.identity);
		}

	}
	
}

    /* if (!spawnVFX) { return; }
	GameObject spawnVFXObject = Instantiate(spawnVFX, transform.position, transform.rotation);
	Destroy(spawnVFXObject, 1f);
	AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position, spawnSoundVolume); */


