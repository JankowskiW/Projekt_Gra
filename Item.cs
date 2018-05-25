using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string name = "New Item";
    public Sprite icon = null;
    
    public int money;
    public int weight;

    public EquipmentSlot equipSlot;

    public int extraHealth;
    public int extraMana;
    public int extraStamina;
    public int extraSpeed;
    public int extraArmor;              // Only for Helmet, Armor, Trousers, Boots, Gauntlets and some kinds of ExtraItems
    public int extraPhysicalDefense;    // Only for Weapons, Shields and some kinds of ExtraItems
    public int extraPhysicalDamage;     // Only for Weapons and some kinds of ExtraItems
    public int extraMagicResistance;    // Only for Helmet, Armor, Trousers, Boots, Gauntlets, Shields and some kinds of ExtraItems
    public int extraMagicDamage;        // Only for Weapons and some kinds of ExtraItems

    public int currentHealthRegeneration;   // Only for health potions
    public int currentManaRegeneration;     // Only for mana potions
    public int currentStaminaRegeneration;  // Only for stamina potions

    /*
    public void SetStats(Item Item)
    {
        this.name = Item.name;
        this.icon = Item.icon;
        this.money = Item.money;
        this.weight = Item.weight;
        this.equipSlot = Item.equipSlot;

        this.extraHealth = Item.extraHealth;
        this.extraMana = Item.extraMana;
        this.extraStamina = Item.extraStamina;
        this.extraSpeed = Item.extraSpeed;
        this.extraArmor = Item.extraArmor;
        this.extraPhysicalDefense = Item.extraPhysicalDefense;
        this.extraPhysicalDamage = Item.extraPhysicalDamage;
        this.extraMagicResistance = Item.extraMagicResistance;
        this.extraMagicDamage = Item.extraMagicDamage;
        this.currentHealthRegeneration = Item.currentHealthRegeneration;
        this.currentManaRegeneration = Item.currentManaRegeneration;
        this.currentStaminaRegeneration = Item.currentStaminaRegeneration;
    }
    */
}

public enum EquipmentSlot { Helmet, Armor, Trousers, Boots, Gauntlets, Weapon1, Weapon2, Shield, ExtraItem1, ExtraItem2, ExtraItem3, Money, Potion }