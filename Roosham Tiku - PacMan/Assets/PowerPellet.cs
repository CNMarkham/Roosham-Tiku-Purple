using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    protected override void Eat()
    {
        base.Eat();

        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Ghost>().Frighten();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
