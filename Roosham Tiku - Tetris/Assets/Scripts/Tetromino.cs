using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    private float previousTime;
    public float fallTime = 0.8f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right);
        }

        float tempTime = fallTime;
        if (Time.time - previousTime > tempTime)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            previousTime = Time.time;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            tempTime = tempTime / 10;
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
