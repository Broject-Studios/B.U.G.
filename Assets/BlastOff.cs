using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastOff : MonoBehaviour
{

    private Rigidbody2D rb2D;

    public float forceMultiplier;
    public float angularChangeInDegrees;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb2D.AddForce(Vector2.up * forceMultiplier, ForceMode2D.Impulse);

        var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * rb2D.inertia;

        rb2D.AddTorque(impulse, ForceMode2D.Impulse);
    }
}
