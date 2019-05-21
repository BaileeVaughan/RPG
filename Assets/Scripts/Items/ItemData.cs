using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        int heal = 0;
        int damage = 0;
        int protection = 0;
        int armour = 0;
        int amount = 0;

        switch (itemID)
        {
            #region Food 0-99
            case 0:
                name = "Apple";
                value = 5;
                description = "Picked from the cursed Blood Tree";
                icon = "Food/Apple_Icon";
                mesh = "Food/Apple_Mesh";
                type = ItemType.Food;
                heal = 5;
                amount = 1;
                break;
            case 1:
                name = "Coffee";
                value = 10;
                description = "Coffee beans freshly picked from the corpse of a Caffinated Treant";
                icon = "Food/Coffee_Icon";
                mesh = "Food/Coffee_Mesh";
                type = ItemType.Food;
                heal = 7;
                amount = 1;
                break;
            case 2:
                name = "Spicy Cheese";
                value = 15;
                description = "Made from the milk of the Burning Cattle";
                icon = "Food/Spicy_Cheese_Icon";
                mesh = "Food/Spicy_Cheese_Mesh";
                type = ItemType.Food;
                heal = 10;
                amount = 1;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "Demon Bone Knuckles";
                value = 30;
                description = "Sawn off of the demons at Uncle Jack's Demon Farm";
                icon = "Weapons/Demon_Bone_Knuckles_Icon";
                mesh = "Weapons/Demon_Bone_Knuckles_Mesh";
                type = ItemType.Weapon;
                damage = 20;
                amount = 1;
                break;
            case 101:
                name = "Hell Axe";
                value = 150;
                description = "A sacred weapon, weilded only by the previous lord of Hell";
                icon = "Weapons/Hell_Axe_Icon";
                mesh = "Weapons/Hell_Axe_Mesh";
                type = ItemType.Weapon;
                damage = 100;
                amount = 1;
                break;
            case 102:
                name = "Satan's Shield";
                value = 140;
                description = "A sacred shield, used only by the previous lord of Hell";
                icon = "Weapons/Satans_Shield_Icon";
                mesh = "Weapon/Satans_Shield_Mesh";
                type = ItemType.Weapon;
                protection = 80;
                amount = 1;
                break;
            #endregion
            #region Apparel 200-299
            case 200:
                name = "Bowel Belt";
                value = 20;
                description = "Cut from a previous enemy";
                icon = "Apparel/Bowel_Belt_Icon";
                mesh = "Apparel/Bowel_Belt_Mesh";
                type = ItemType.Apparel;
                protection = 5;
                amount = 1;
                break;
            case 201:
                name = "Deathly Eye";
                value = 40;
                description = "One of the many crystalised eyes, torn from Satan's right hand demon";
                icon = "Apparel/Deathly_Eye_Icon";
                mesh = "Apparel/Deathly_Eye_Mesh";
                type = ItemType.Apparel;
                protection = 10;
                amount = 1;
                break;
            case 202:
                name = "Human Skin Pouch";
                value = 0;
                description = "An item you hold dear to you, as it reminds you of your family";
                icon = "Apparel/Human_Skin_Pouch_Icon";
                mesh = "Apparel/Human_Skin_Pouch_Mesh";
                type = ItemType.Apparel;
                amount = 1;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                name = "Flesh Wood";
                value = 10;
                description = "Harvested from the Flesh Treants";
                icon = "Crafting/Flesh_Wood_Icon";
                mesh = "Crafting/Flesh_Wood_Mesh";
                type = ItemType.Crafting;
                amount = 5;
                break;
            case 301:
                name = "Liquid Demon";
                value = 45;
                description = "A rare drop, caused by killing a demon in perfect conditions";
                icon = "Crafting/Liquid_Demon_Item";
                mesh = "Crafting/Liquid_Demon_Mesh";
                type = ItemType.Crafting;
                amount = 1;
                break;
            case 302:
                name = "Witch Bone";
                value = 5;
                description = "An item you hold dear to you, as it reminds you of your family";
                icon = "Crafting/Witch_Bone_Icon";
                mesh = "Crafting/Witch_Bone_Mesh";
                type = ItemType.Crafting;
                amount = 5;
                break;
            #endregion
            #region Quest 400-499
            case 400:
                name = "Satan's Testicle";
                value = 0;
                description = "Harvested by goblins after the fall of the previous ruler, this has now been passed around as a sacred relic";
                icon = "Quest/Satans_Testicle_Icon";
                mesh = "Quest/Satans_Testicle_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 401:
                name = "Tainted Holy Stone";
                value = 0;
                description = "Soaked in the blood of the most heinous demons, yet it was still not enough to completely stain the stone";
                icon = "Quest/Tainted_Holy_Stone_Icon";
                mesh = "Quest/Tainted_Holy_Stone_Mesh";
                type = ItemType.Quest;
                amount = 1;
                break;
            case 402:
                name = "War Badge";
                value = 0;
                description = "Lost by the town veteran, he is unable to stay sane without his precious badge";
                icon = "Quest/War_Badge_Icon";
                mesh = "Quest/War_Badge_Mesh";
                type = ItemType.Quest;
                break;
                #endregion
                #region Ingredients 500-599

                #endregion
                #region Potions 600-699

                #endregion
                #region Scrolls 700-799

                #endregion
        }
        Item temp = new Item
        {
            Name = name,
            Description = description,
            ID = itemID,
            Value = value,
            Damage = damage,
            Protection = protection,
            Armour = armour,
            Amount = amount,
            Heal = heal,
            Type = type,
            Mesh = Resources.Load("Prefabs/" + mesh) as GameObject,
            Icon = Resources.Load("Icon/" + icon) as Sprite
        };
        return temp;
    }
}
