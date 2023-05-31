using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float xSpace;
    public float xOffset;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 21; x++)
        {
            Instantiate(enemyPrefab, new Vector2(x * xSpace + xOffset, 3), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector2(x * xSpace + xOffset, 3.75f), Quaternion.identity);
            Instantiate(enemyPrefab, new Vector2(x * xSpace + xOffset, 4.5f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
