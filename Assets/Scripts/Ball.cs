using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float Speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = Vector2.up * Speed;
    }

    private float HitFactor(Transform player, float playerWidth)
    {
        return (transform.position.x - player.position.x) / playerWidth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            float x = HitFactor(collision.transform, collision.collider.bounds.size.x);

            Vector2 direction = new Vector2(x, 1).normalized;

            rb.velocity = direction * Speed;
        }
    }
}
