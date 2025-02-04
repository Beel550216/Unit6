using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform Cam;

    public Animator anim;

    public float speed = 5f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //float gravity = 9.8f;
    void Update()
    {
        speed = 5f;
        //GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        anim = GetComponent<Animator>();

        DebugSpeed();
        Animate(1);

        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 9f;

                Animate(3);
                
            }
            else
            {
                speed = 5f;
            }

            Animate(2);
            

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }


    void Animate(int num)
    {
        if (gameObject.tag == "root")
        {
                if (num == 1)
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("run", false);
                }

                if (num == 2)
                {
                    anim.SetBool("walk", true);
                }
                if (num == 3)
                {
                    anim.SetBool("run", true);
                }

        }
    }


    void DebugSpeed()
    {
        if (Input.GetKeyDown("1"))
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown("2"))
        {
            Time.timeScale = 0.8f;
        }
        if (Input.GetKeyDown("3"))
        {
            Time.timeScale = 0.6f;
        }
        if (Input.GetKeyDown("4"))
        {
            Time.timeScale = 0.4f;
        }
        if (Input.GetKeyDown("5"))
        {
            Time.timeScale = 0.2f;
        }
        if (Input.GetKeyDown("0"))
        {
            Time.timeScale = 0.001f;
        }

    }





    void Gravity()
    {
       /*if (CharacterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = 0f;
            }
        }*/
    }
}
