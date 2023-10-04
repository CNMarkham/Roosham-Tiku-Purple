using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koopa : MonoBehaviour
{
    private bool shelled;
    private bool shellMoving;
    public float shellSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        shelled = false;
        shellMoving = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 

    }

    private void Launch()
    {
        GetComponent<EnemyMovement>().speed = 15;
        GetComponent<Rigidbody2D>().velocity = Vector3.right * 15;
        shellMoving = true;
    }

}
