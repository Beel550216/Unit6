using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform Cam;

    public Animator anim;

    public float speed = 5f;

    public float turnSmoothTime = 0.3f;
    float turnSmoothVelocity;

    private Vector3 playerVelocity;
    public float jumpPower = 1f;

    float gravity = -9.8f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 1f;


   bool isGrounded;

    public GameObject axe;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        speed = 5f;
        //GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        //anim = GetComponent<Animator>();

        DebugSpeed();
        Animate(1);

        Movement();
        DetectJump();
        Attack();


        //print("velocity y=" + playerVelocity.y);
    }

    void Movement()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        Attack();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y = 1f ; //Mathf.Sqrt(jumpHeight * -2f * gravity);
            print("Jump");

            Animate(4);
        }*/


        if (controller.isGrounded)
        {
            print("grounded");
            playerVelocity.y = Input.GetKeyDown(KeyCode.Space) ? jumpPower : 0;
        }
        else 
        {
            print("not grounded");
        }

        
        
        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);



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
    
    
    void DetectJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animate(4);

        }
    }

    public void JumpFromEvent()
    {
        playerVelocity.y = 11f;  //Mathf.Sqrt(jumpHeight * -2f * gravity);
        print("Jump");

    }


    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Animate(6);
        }
    }


    void DisableAxe()
    {
        if (axe.gameObject.activeSelf == true)
        {
            axe.SetActive(false);

        }

    }
    void EnableAxe()
    {
        if (axe.gameObject.activeSelf == false)
        {
            axe.SetActive(true);

            print("axe has been enabled");

            //GameObject.FindGameObjectWithTag("axe").SetActive(false);

        }
    }

    void Animate(int num)
    {
                if (num == 1)
                {
                    anim.SetBool("walk", false);
                    anim.SetBool("run", false);
                    anim.SetBool("jump", false);
                    anim.SetBool("attack", false);
                }

                if (num == 2)
                {
                    anim.SetBool("walk", true);
                }
                if (num == 3)
                {
                    anim.SetBool("run", true);
                }

                if (num == 4)
                {
                   anim.SetBool("jump", true);
                }
                if (num == 5)
                {
                    anim.SetBool("jump", false);
                }

                if (num == 6)
                {
                    anim.SetBool("attack", true);
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
