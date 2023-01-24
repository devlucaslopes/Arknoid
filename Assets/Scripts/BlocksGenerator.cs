using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float MinY;
    [SerializeField] private float MaxY;
    [SerializeField] private GameObject[] Blocks;

    void Start()
    {
        for (float row = MinY; row <= MaxY; row += 0.5f)
        {
            for (int column = -8; column <= 8; column++)
            {
                Instantiate(Blocks[Random.Range(0, Blocks.Length)], new Vector3(column, row, 0), Quaternion.identity);
            }
        }    
    }
}
