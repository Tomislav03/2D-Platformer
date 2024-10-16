using System;
using System.Collections;
using System.Collections.Generic;
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
        
        private Rigidbody2D rb;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float moveInput = Input.GetAxis("Horizontal");
            
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);   
            }
        }

        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, boxCollider.bounds.extents.y + 0.1f,groundLayer);
            return hit.collider != null;
        }
    }
}
