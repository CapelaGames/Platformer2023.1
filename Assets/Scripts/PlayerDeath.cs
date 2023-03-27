using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public LayerMask rayMask;
    private CapsuleCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
            float halfHeight =  _collider.bounds.extents.y;
            float distance = halfHeight + 0.1f;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 
                                                    distance, rayMask);


            if(hit.collider != null)
            {
                if(hit.transform == collision.transform)
                {
                    Destroy(hit.transform.gameObject);
                    return; //exits the function early
                }
            }

            Destroy(gameObject);
        }
    }
}
