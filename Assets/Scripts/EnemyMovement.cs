using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 20f;

    private int currentWPIndex = 0;
    public Transform[] wayPoints;//  = new Transform[];
                                 // new not need because unity takes care of public arrays
                                 // (also [SerializeField])

    void Update()
    {
        if( Vector2.Distance(transform.position, wayPoints[currentWPIndex].position) < 0.1f)
        {
            currentWPIndex++;

            if(currentWPIndex >= wayPoints.Length)
            {
                currentWPIndex = 0;
            }
        }

        

        transform.position  = Vector2.MoveTowards(transform.position, 
                                                    wayPoints[currentWPIndex].position ,
                                                    speed * Time.deltaTime );

    }
}
