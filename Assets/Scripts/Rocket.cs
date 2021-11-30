using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private GameManager manager;

    [SerializeField] private float movementSmoothing;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float desiredPositionY;

    [SerializeField] private Vector3 lookRotationOffset;

    [SerializeField] private List<Sprite> flightSprites = new List<Sprite>();

    private SpriteRenderer spriteRenderer;

    public int rocketHealth;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.sprite = flightSprites[0];
    }

    private void FixedUpdate()
    {
        Vector2 worldPoint;
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        worldPoint = Camera.main.ScreenToWorldPoint(mousePoint);

        Vector3 desiredPosition = new Vector3(worldPoint.x, desiredPositionY, transform.position.z);

        Steer(desiredPosition);
    }

    private void Steer (Vector3 desiredPosition)
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, movementSmoothing);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -5f, 5f);
        transform.position = clampedPosition;

        Vector3 lookDirection = (desiredPosition + lookRotationOffset) - transform.position;
        Quaternion desiredRotation = Quaternion.LookRotation(Vector3.forward, lookDirection);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            rocketHealth -= 5;

            collision.gameObject.GetComponent<Obstacle>().OnHit();

            if(rocketHealth <= 20)
            {
                spriteRenderer.sprite = flightSprites[4];
            }
            else if(rocketHealth <= 40)
            {
                spriteRenderer.sprite = flightSprites[3];
            }
            else if (rocketHealth <= 60)
            {
                spriteRenderer.sprite = flightSprites[2];
            }
            else if (rocketHealth <= 80)
            {
                spriteRenderer.sprite = flightSprites[1];
            }

            if (rocketHealth <= 0)
            {
                manager.GameOver();
            }

        }
    }



    private void KillRocket ()
    {

    }

}
