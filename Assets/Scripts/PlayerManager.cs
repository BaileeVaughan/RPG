using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[AddComponentMenu("Intro RPG/Player/PlayerManager")]
public class PlayerManager : MonoBehaviour
{
    #region Variables
    //Movement//
    [Header("Character")]
    public Vector3 moveDir;
    public CharacterController charC;
    [Header("Character Speeds")]
    public float jumpSpeed = 8f;
    public float speed = 5f, gravity = 20f;
    public static bool canMove;
    //Mouse Look//
    [Header("Rotational Axis")]
    public RotationalAxis axis = RotationalAxis.MouseX;
    [Header("Sensitivity")]
    public float sensitivity = 15f;
    [Header("Y Rotation Clamp")]
    public float minY = -60f;
    public float maxY = 60f;
    float rotationY = 0f;
    //Interact//
    [Header("Player and Camera connection")]
    public GameObject player;
    public GameObject mainCamera;
    //EXP//
    [Header("XP Reference")]
    public static float maxXp;
    public static float curXP, delayXp;
    #region PlayerStats
    //Stats//
    [Header("Player Stats")]
    public string[] stats;
    public int[] statData;
    public string playerName;
    public int level;
    public int maxHP, curHP; 
    public float maxExp, curExp;
    [Header("Game Reference")]
    public Slider expBar;
    public Vector3 savePos;
    #endregion
    #endregion

    #region Start  
    void Start()
    {
        //Movement//
        charC = this.GetComponent<CharacterController>();
        //Mouse Look//
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        //Interact//
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //Stats//
        HeartHealth.maxHealth = maxHP;
        //Saving//

    }
    #endregion

    #region Update
    void Update()
    {
        //Movement//
        if (charC.isGrounded)
        {
            moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        charC.Move(moveDir * Time.deltaTime);
        //Mouse Look//
        if (axis == RotationalAxis.MouseXandY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
        }
        //Interact//
        if (Input.GetButtonDown("Interact"))
        {
            Ray interact;
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hitInfo;
            if (Physics.Raycast(interact, out hitInfo, 10))
            {
                #region NPC tag
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    Debug.Log("NPC");
                }
                #endregion
                #region Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Item");
                }
                #endregion
            }
        }
        //Stats//
        expBar.value = Mathf.Clamp01(curExp / maxExp);
    }
    #endregion

    public void Save()
    {
        savePos = this.transform.position;
        SaveToBinary.SaveData(this);
    }

    public void Load()
    {
        DataToSave data = SaveToBinary.LoadData(this);
        level = data.level;
        maxHP = data.maxHP;
        curHP = data.curHP;
        maxXp = data.maxExp;
        curXP = data.curExp;
        savePos = new Vector3(data.x, data.y, data.y);
        this.transform.position = savePos;
    }
}

public enum RotationalAxis
{
    MouseXandY,
    MouseX,
    MouseY
}
