using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

namespace Platformer // basically a folder for your code
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private BoxCollider2D boxCollider;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask deathLayer;

        private Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsColliding(deathLayer))
            {
                Destroy(gameObject);
            };

            //Movement
            float moveInput = Input.GetAxis("Horizontal");
            
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && IsColliding(groundLayer))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);   
            }
        }

        private bool IsColliding(LayerMask layerMask)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + 0.1f, layerMask);
            return hit.collider != null;
        }
    }
}
