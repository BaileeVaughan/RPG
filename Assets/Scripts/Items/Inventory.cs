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

    public PlayerManager health;
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
                scr.y = Screen.height / 9;
            }
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerManager.canMove = false;
            return true;
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

    void DisplayItem()
    {
        switch (selectedItem.Type)
        {
            case ItemType.Food:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (health.curHP < health.maxHP)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                    {
                        health.curHP += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                    break;
            case ItemType.Weapon:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage + "\nAmount: " + selectedItem.Amount);
                EquipItem(curWeapon, 0);
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                {
                    DepleteAmount();
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Apparel:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Damage + "\nAmount: " + selectedItem.Amount);
                EquipItem(curHelm, 0);
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                {
                    DepleteAmount();
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Crafting:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " +  selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                {
                    DepleteAmount();
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Quest:
                break;
            case ItemType.Ingredients:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (health.curHP < health.maxHP)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                    {
                        health.curHP += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Potion:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (health.curHP < health.maxHP)
                {
                    if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Drink"))
                    {
                        health.curHP += selectedItem.Heal;
                        DepleteAmount();
                    }
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            case ItemType.Scroll:
                GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Heal + "\nAmount: " + selectedItem.Amount);
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Read"))
                {
                    DepleteAmount();
                }
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                {
                    Discard();
                }
                break;
            default:
                break;
        }
    }

    void DepleteAmount()
    {
        if (selectedItem.Amount > 1)
        {
            selectedItem.Amount--;
        }
        else
        {
            inv.Remove(selectedItem);
            selectedItem = null;
        }
        return;
    }

    void Discard()
    {
        if (selectedItem.Type == ItemType.Weapon)
        {
            if (curWeapon != null && selectedItem.Mesh.name == curWeapon.name)
            {
                Destroy(curWeapon);
            }
        }
        else if (selectedItem.Type == ItemType.Apparel)
        {
            if (curHelm != null && selectedItem.Mesh.name == curHelm.name)
            {
                Destroy(curHelm);
            }
        }
        GameObject clone = Instantiate(selectedItem.Mesh, dropLocation.position, Quaternion.identity);
        clone.AddComponent<Rigidbody>().useGravity = true;
        if (clone.GetComponent<Collider>() == null)
        {
            clone.AddComponent<BoxCollider>();
        }
        DepleteAmount();
    }

    void EquipItem(GameObject item, int location)
    {
        if (item == null || selectedItem.Mesh.name != item.name)
        {
            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
            {
                if (item != null)
                {
                    Destroy(item);
                }
                item = Instantiate(selectedItem.Mesh, equippedLocations[location]);
                if(selectedItem.Type == ItemType.Weapon)
                {
                    curWeapon = item;
                }
                else if (selectedItem.Type == ItemType.Apparel)
                {
                    curHelm = item;
                }
                if (item.GetComponent<ItemHandler>() != null)
                {
                    item.GetComponent<ItemHandler>().enabled = false;
                }
                item.name = selectedItem.Mesh.name;
            }
        }
        else
        {
            if (item == null && selectedItem.Mesh.name == item.name)
            {
                if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Unequip"))
                {
                    if (item != null)
                    {
                        Destroy(item);
                    }
                }
            }
        }
    }

    void OnGUI()
    {
        if (showInv)
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
                DisplayItem();
            }
        }
    }
}