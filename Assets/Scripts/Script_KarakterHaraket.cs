using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public float Karaktergecenzaman;
    public GameObject Player;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask winMask;
    bool isGrounded;
    bool isWin;
    
    public Camera Kamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    
    
    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "GroundReset")
        {
            Debug.Log("U Die MF");
        }
    }


    CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Karaktergecenzaman += Time.deltaTime;
        
      

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded )
        {
            Debug.Log("You Fail");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        isWin = Physics.CheckSphere(groundCheck.position, groundDistance, winMask);
        if (isWin)
        {
            Debug.Log("YOU WON");
            if(SceneManager.GetActiveScene().name == "SampleScene")
            { if (PlayerPrefs.GetFloat("Time1") == 0f)
                {
                    PlayerPrefs.SetFloat("Time1", Karaktergecenzaman);
                }
                else if (PlayerPrefs.GetFloat("Time1") > Karaktergecenzaman) {
                    PlayerPrefs.SetFloat("Time1", Karaktergecenzaman);
                } SceneManager.LoadScene(2);
            
            } else if (SceneManager.GetActiveScene().name == "2SampleScene")
            {
                if (PlayerPrefs.GetFloat("Time2") == 0f)
                {
                    PlayerPrefs.SetFloat("Time2", Karaktergecenzaman);
                }
                else if (PlayerPrefs.GetFloat("Time2") > Karaktergecenzaman)
                {
                    PlayerPrefs.SetFloat("Time2", Karaktergecenzaman);
                }
                SceneManager.LoadScene(4);
            }
            Debug.Log(PlayerPrefs.GetFloat("Time1"));
            Debug.Log(PlayerPrefs.GetFloat("Time2"));
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;


        }


        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

      
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            Kamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }
}