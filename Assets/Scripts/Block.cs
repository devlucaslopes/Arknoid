using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int Life;
    [SerializeField] private int Score;
    [SerializeField] private float RateOfDrop;
    [SerializeField] private GameObject[] Drops;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            Life--;

            if (Life <= 0)
            {
                ShouldDrop();
                GameManager.Instance.UpdateScore(Score);
                Destroy(gameObject);
            }
        }
    }

    private void ShouldDrop()
    {
        if (Random.Range(0, 101) < RateOfDrop)
        {
            GameObject randomDrop = Drops[Random.Range(0, Drops.Length)];
            Instantiate(randomDrop, transform.position, Quaternion.identity);
        }
    }
}
