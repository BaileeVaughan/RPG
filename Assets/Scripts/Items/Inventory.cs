using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public static int money;
    public static Item selectedItem;

    public Vector2 scr;
    public Vector2 scrollPos;

    public string[] sortTypes;
    public string selectedType;

    public Transform[] equippedLocations;
    public Transform dropLocation;
    public GameObject curWeapon;
    public GameObject curHelm;
    #endregion

    void Start()
    {
        sortTypes = new string[]
        {
            "All", "Food", "Weapon", "Apparel", "Crafting", "Quest", "Ingredient", "Potion", "Scroll"
        };
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(302));
        inv.Add(ItemData.CreateItem(400));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(selectedItem.Name);
        }
    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerManager.canMove = true;
            return false;
        }
        else
        {
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.width / 9;
            }
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerManager.canMove = false;
            return true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(0));
            inv.Add(ItemData.CreateItem(1));
            inv.Add(ItemData.CreateItem(2));
            inv.Add(ItemData.CreateItem(100));
            inv.Add(ItemData.CreateItem(101));
            inv.Add(ItemData.CreateItem(102));
            inv.Add(ItemData.CreateItem(200));
            inv.Add(ItemData.CreateItem(201));
            inv.Add(ItemData.CreateItem(202));
            inv.Add(ItemData.CreateItem(300));
            inv.Add(ItemData.CreateItem(301));
            inv.Add(ItemData.CreateItem(302));
            inv.Add(ItemData.CreateItem(400));
            inv.Add(ItemData.CreateItem(401));
            inv.Add(ItemData.CreateItem(402));
            inv.Add(ItemData.CreateItem(500));
            inv.Add(ItemData.CreateItem(501));
            inv.Add(ItemData.CreateItem(502));
        }
    }

    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))
        {
            ItemType type = (ItemType)System.Enum.Parse(typeof(ItemType), sortType);
            int a = 0; //amount of item
            int s = 0; //slot position of item
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)
                {
                    a++;
                }
            }
            if (a <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type) //if it is the desired type
                    {
                        //we display a button that is of this type and slot them under the last one
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i]; //selct the time from its position in the inventory
                            Debug.Log(selectedItem.Name);
                        }
                        s++; //increase the slot position by one
                    }
                }
            }
            else //if more than the amount of viewable items
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((a - 34) * (0.25f * scr.y))), false, true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0, s * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.x), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        s++;
                    }
                }

                GUI.EndScrollView();
            }
        }
        else //if we are viewing all
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }

                }
            }
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0.5f * scr.x, 0.25f * scr.y, 3.5f * scr.x, 8.5f * scr.y), scrollPos, new Rect(0, 0, 0, 8.5f * scr.y + ((inv.Count - 34) * (0.25f * scr.y))), true, true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0, i * (0.25f * scr.y), 3f * scr.x, 0.25f * scr.x), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }


                GUI.EndScrollView();
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
        for (int i = 0; i < sortTypes.Length; i++)
        {
            if (GUI.Button(new Rect(5.5f * scr.x + i * (scr.x), 0.25f * scr.y, scr.x, 0.25f * scr.y), sortTypes[i]))
            {
                selectedType = sortTypes[i];
            }
        }
        DisplayInv(selectedType);
        if (selectedItem != null)
        {
            GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
        }
    }
}
