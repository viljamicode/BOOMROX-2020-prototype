using UnityEngine;
using System.Collections;

// Huge thanks to @derHugo from stackoverflow for their help in fine tuning the script! -vr

public class Shoot : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 angularVelocity;

    [SerializeField] private DragIndicatorScript dragIndicator;

    [SerializeField] private Rigidbody2D rigidigidy;
    [SerializeField] private float power = 10f;
    [SerializeField] private Camera camera;
    [SerializeField] private float maxLength;

    [Header("VFX")]
    [SerializeField] GameObject freezeVFX;
    [SerializeField] float durationOfFreezeVFX = 1f;

    [Header("Sounds")]
    [SerializeField] AudioClip freezeSound;
    [SerializeField] [Range(0, 1)] float freezeSoundVolume = 0.15f;


    private Vector2 inputStartPosition;

    private void Awake()
    {
        rigidigidy = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // draw the dragindicator line
            inputStartPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            dragIndicator.SetIndicator(Vector2.zero);
            // stop the Player model
            rigidigidy.velocity = Vector3.zero;
            rigidigidy.freezeRotation = true;
            // play VFX when Player model stops
            GameObject explosion = Instantiate(freezeVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfFreezeVFX);
            AudioSource.PlayClipAtPoint(freezeSound, Camera.main.transform.position, freezeSoundVolume);

        }
        if (Input.GetMouseButton(0))
        {
            Vector2 inputCurrentPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            var input = inputCurrentPosition - inputStartPosition;
            input = Vector2.ClampMagnitude(input, maxLength);
            
            // this sets the dragindicator in front (-input) or behind (input) the Player model
            dragIndicator.SetIndicator(-input);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 inputCurrentPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            var input = inputCurrentPosition - inputStartPosition;
            input = Vector2.ClampMagnitude(input, maxLength);
            rigidigidy.freezeRotation = false;
            dragIndicator.HideIndicator();
            Launch(input);
            ShotCounterScript.shotValue += 1;
        }
    }

    private void Launch(Vector2 input)
    {
        rigidigidy.AddForce(-input * power, ForceMode2D.Impulse);
    }
}