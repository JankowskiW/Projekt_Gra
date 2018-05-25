using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

    #region Singleton
    public static PlayerStats instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public int maxWeight;



    void Start()
    {
        maxWeight = 100;
      
    }

    public void OnEquipmentChanged (Item newItem, Item oldItem)
    {
        if(newItem != null)
        {
            /*
            Debug.Log("On eq changed newItem != NULL");
            extraHealth.AddModifier(newItem.extraHealth);
            extraMana.AddModifier(newItem.extraMana);
            extraStamina.AddModifier(newItem.extraStamina);
            extraSpeed.AddModifier(newItem.extraSpeed);
            armor.AddModifier(newItem.armor);
            physicalDefense.AddModifier(newItem.physicalDefense);
            physicalDamage.AddModifier(newItem.physicalDamage);
            magicResistance.AddModifier(newItem.magicResistance);
            magicDamage.AddModifier(newItem.magicDamage);*/

            extraHealth += newItem.extraHealth;
            extraMana += newItem.extraMana;
            extraStamina += newItem.extraStamina;
            extraSpeed += newItem.extraSpeed;
            extraArmor += newItem.extraArmor;
            extraPhysicalDefense += newItem.extraPhysicalDefense;
            extraPhysicalDamage += newItem.extraPhysicalDamage;
            extraMagicResistance += newItem.extraMagicResistance;
            extraMagicDamage += newItem.extraMagicDamage;

            //currentHealth += newItem.currentHealth;
            //currentMana += newItem.currentMana;
            //currentStamina += newItem.currentStamina;
        }
        if (oldItem != null)
        {
            /*
            Debug.Log("On eq changed oldItem != NULL");
            extraHealth.RemoveModifier(oldItem.extraHealth);
            extraMana.RemoveModifier(oldItem.extraMana);
            extraStamina.RemoveModifier(oldItem.extraStamina);
            extraSpeed.RemoveModifier(oldItem.extraSpeed);
            armor.RemoveModifier(oldItem.armor);
            physicalDefense.RemoveModifier(oldItem.physicalDefense);
            physicalDamage.RemoveModifier(oldItem.physicalDamage);
            magicResistance.RemoveModifier(oldItem.magicResistance);
            magicDamage.RemoveModifier(oldItem.magicDamage);*/
            extraHealth -= oldItem.extraHealth;
            extraMana -= oldItem.extraMana;
            extraStamina -= oldItem.extraStamina;
            extraSpeed -= oldItem.extraSpeed;
            extraArmor -= oldItem.extraArmor;
            extraPhysicalDefense -= oldItem.extraPhysicalDefense;
            extraPhysicalDamage -= oldItem.extraPhysicalDamage;
            extraMagicResistance -= oldItem.extraMagicResistance;
            extraMagicDamage -= oldItem.extraMagicDamage;
        }


    }

}
