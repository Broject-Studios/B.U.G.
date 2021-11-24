using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float movementSmoothing;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float desiredPositionY;

    [SerializeField] private Vector3 lookRotationOffset;

    [SerializeField] private Sprite flightSprite;

    private SpriteRenderer spriteRenderer;

    public int rocketHealth;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.sprite = flightSprite;
        print("helloooo");
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
        Debug.Log("hit something");
        if (collision.gameObject.tag == "Obstacle")
        {
            rocketHealth--;

            collision.gameObject.GetComponent<Obstacle>().OnHit();

            if (rocketHealth <= 0)
            {
                KillRocket();
            }

        }
    }

    private void KillRocket ()
    {

    }

}
