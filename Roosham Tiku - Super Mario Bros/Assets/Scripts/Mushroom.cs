using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("transform");
    }
}
