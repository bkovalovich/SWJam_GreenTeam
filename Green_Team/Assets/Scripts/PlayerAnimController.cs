using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject spriteParent;

    //use PlayerJumpScript.canJump for isGrounded
    public static float velocityVertical;
    public static float velocityHorizontal;
    public static bool isGliding;
    public static Vector3 facingRight;
    public static Vector3 facingLeft;


    // Start is called before the first frame update
    void Start()
    {
        facingRight = new Vector3(1, 1, 1);
        facingLeft = new Vector3(-1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isGrounded", PlayerJumpScript.canJump);
        velocityVertical = Vector2.Dot(rb.velocity, Vector2.up);
        velocityHorizontal = Vector2.Dot(rb.velocity, Vector2.right);

        if (PlayerJumpScript.canJump)
        {
            if (velocityHorizontal > 0.01 && velocityHorizontal > 3)
            {
                if (anim.GetFloat("runningTo") < 0)
                {
                    spriteParent.transform.localScale = facingLeft;
                    anim.Play("Player_Land", -1, 0.05f);
                }
                else
                {
                    spriteParent.transform.localScale = facingRight;
                }
            }
            else if (velocityHorizontal < -0.01 && velocityHorizontal < -3)
            {
                if (anim.GetFloat("runningTo") > 0)
                {
                    spriteParent.transform.localScale = facingRight;
                    anim.Play("Player_Land", -1, 0.05f);
                }
                else
                {
                    spriteParent.transform.localScale = facingLeft;
                }
            }
        }

        float speedHorizontal = Mathf.Abs(velocityHorizontal);

        ;
        anim.SetFloat("velocityVertical", velocityVertical);
        anim.SetFloat("speedHorizontal", speedHorizontal);
        anim.SetBool("isGliding", isGliding);
    }
}
