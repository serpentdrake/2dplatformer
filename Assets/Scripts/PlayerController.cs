using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_playerRb2d;
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private float m_jumpForce;
    [SerializeField]
    private GroundSensor m_groundSensor;

    public float movement;

    private bool canDoubleJump;
    void Start()
    {
        if(m_playerRb2d == null)
        {
          m_playerRb2d.GetComponent<Rigidbody2D>();
        }
        
    }

    
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        m_playerRb2d.velocity = new Vector2(movement * m_speed, m_playerRb2d.velocity.y);

        if (m_groundSensor.IsGrounded() == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_playerRb2d.velocity = Vector2.up * m_jumpForce;
            }
        }
    }
}
