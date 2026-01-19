using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator m_playerAnimator;
    [SerializeField]
    private PlayerController m_playerController;
    [SerializeField]
    private GroundSensor m_groundSensor;
    [SerializeField]
    private int m_movementId = Animator.StringToHash("movement");
    [SerializeField]
    private int m_jumpId = Animator.StringToHash("jump");

    private bool isFacingRight = true;

    void Flip()
 {
     isFacingRight = !isFacingRight;

     Vector3 scale = transform.localScale;
     scale.x *= -1;
     transform.localScale = scale;
 }

    void Start()
    {
        if(m_playerAnimator == null)
        {
            m_playerAnimator.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_groundSensor.IsGrounded())
        {
              if (m_playerController.movement > 0 && !isFacingRight)
        {
            Flip();
        }
            
        else if (m_playerController.movement < 0 && isFacingRight)
        {
           Flip(); 
        }
            m_playerAnimator.SetFloat(m_movementId, Mathf.Abs(m_playerController.movement));
        }
        

      
            
    }
}
