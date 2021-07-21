using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public Animator animator;
    public float speed = 20.0f;
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    private Vector3 initialPos;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D m_Rigidbody2D;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        this.initialPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        verticalMove = Input.GetAxisRaw("Vertical") * speed;
        
        if(Mathf.Abs(horizontalMove) > Mathf.Abs(verticalMove)){
            Move(horizontalMove * Time.fixedDeltaTime, 0);      
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));
            animator.SetFloat("upSpeed", 0);
            animator.SetFloat("downSpeed", 0);      
        }else {
            Move(0, verticalMove * Time.fixedDeltaTime);

            animator.SetFloat("speed", 0);  

            if(verticalMove < 0){
                animator.SetFloat("downSpeed", verticalMove);
            } else {
                animator.SetFloat("downSpeed", 0);
            }

            animator.SetFloat("upSpeed", verticalMove);
            
        }

              
    }

    public void Move(float horizontal, float vertical)
	{        
        Vector3 targetVelocity = new Vector2(horizontal * 10f, vertical * 10f);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        

        if (horizontal > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        else if (horizontal < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		transform.Rotate(0f, 180f, 0f);
	}

    public void Respawn(){
        this.gameObject.SetActive(true);
        this.transform.position = initialPos;
    }
}
