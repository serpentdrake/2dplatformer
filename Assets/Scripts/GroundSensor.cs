using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D m_sensorCollider;
    [SerializeField]
    private LayerMask m_layerMask;

    public bool isGrounded;

    public bool IsGrounded()
    {
       RaycastHit2D raycastHit2D = Physics2D.BoxCast(m_sensorCollider.bounds.center, m_sensorCollider.bounds.size, 0f, Vector2.down, .1f, m_layerMask);

        return raycastHit2D.collider != null;
    }

     private void OnCollisionExit2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("movingPlatform"))
        {
            this.transform.parent = null;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
