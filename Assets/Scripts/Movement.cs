using UnityEngine;
//this script can be found in the Component section under the option Intro PRG/Character Movement
[AddComponentMenu("Intro RPG/Player/Character Movement")]
//This script requires the component Character controller to be attached to the Game Object
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    #region Variables
    [Header("Character")]
    public Vector3 moveDir; //we will use this to apply movement in worldspace
    public CharacterController charC;
    [Header("Character Speeds")]
    public float jumpSpeed = 8f;
    public float speed = 5f, gravity = 20f;
    #endregion

    #region Start  
    void Start()
    {
        //_charc is set to the Character controller on this GameObject
        charC = this.GetComponent<CharacterController>();
    }
    #endregion

    #region Update
    void Update()
    {
        //if our character is grounded
        if (charC.isGrounded)
        {
            moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
            //if the input button for jump is pressed then               
            if (Input.GetButton("Jump"))
            {
                //our moveDir.y is equal to our jump speed
                moveDir.y = jumpSpeed;
            }
        }
        //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
        moveDir.y -= gravity * Time.deltaTime;
        //we then tell the character Controller that it is moving in a direction multiplied Time.deltaTime
        charC.Move(moveDir * Time.deltaTime);
    }
    #endregion

    #region Extra Study
    //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
    //Input(https://docs.unity3d.com/ScriptReference/Input.html)
    //CharacterController allows you to move the character kinda like Rigidbody (https://docs.unity3d.com/ScriptReference/
    #endregion
}










