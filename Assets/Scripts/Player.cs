using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movement;
    private float movementSqrMagnitude;
    public float walkSpeed = 1.0f;
    Animator animator;

    private bool movedLeft = false;
    private bool movedRight = false;
    private bool movedUp = false;
    private bool movedDown = false;

    void Animation()
    {
        if (movement.x < 0){
            animator.SetBool("IsLeft", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("FacingLeft", false);

            movedLeft = true;
            movedRight = false;
            movedUp = false;
            movedDown = false;
        }
        else if (movement.x > 0){
            animator.SetBool("IsRight", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("FacingRight", false);

            movedLeft = false;
            movedRight = true;
            movedUp = false;
            movedDown = false;
        }
        else if (movement.y < 0){
            animator.SetBool("IsDown", true);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsUp", false);
            animator.SetBool("FacingDown", false);

            movedLeft = false;
            movedRight = false;
            movedUp = false;
            movedDown = true;
        }
        else if (movement.y > 0){
            animator.SetBool("IsUp", true);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("FacingUp", false);

            movedLeft = false;
            movedRight = false;
            movedUp = true;
            movedDown = false;
        }
        else{
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsUp", false);

            if (movedLeft){
                animator.SetBool("FacingLeft", true);
                animator.SetBool("FacingRight", false);
                animator.SetBool("FacingUp", false);
                animator.SetBool("FacingDown", false);
            }
            else if (movedRight){
                animator.SetBool("FacingLeft", false);
                animator.SetBool("FacingRight", true);
                animator.SetBool("FacingUp", false);
                animator.SetBool("FacingDown", false);
            }
            else if (movedUp){
                animator.SetBool("FacingLeft", false);
                animator.SetBool("FacingRight", false);
                animator.SetBool("FacingUp", true);
                animator.SetBool("FacingDown", false);
            }
            else if (movedDown){
                animator.SetBool("FacingLeft", false);
                animator.SetBool("FacingRight", false);
                animator.SetBool("FacingUp", false);
                animator.SetBool("FacingDown", true);
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movementSqrMagnitude = movement.sqrMagnitude;

        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);
        Animation();
    }   
}

