using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -20.81f;
    public float jumpHeight = 1.5f;
    private bool lerpCrouch,sprinting;
    public bool crouching;
    private float crouchTimer = 0f;

    //Health
    public float health = 100f;
    public float maxhealth = 100f;
    public Image healthSprite;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(lerpCrouch){
            crouchTimer += Time.deltaTime;
            float p = crouchTimer/1;
            p*=p;
            if(crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if(p>1){
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    //receive input from InputManager.cs and apply to character controller
    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if(isGrounded && playerVelocity.y < 0) playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void Jump(){
        if(isGrounded){
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
    public void Crouch(){
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    public void Sprint(){
        sprinting = !sprinting;
        if(sprinting)
            speed = 10f;
        else
            speed = 5f;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthSprite.fillAmount = health/maxhealth;
        
        
    }
}
