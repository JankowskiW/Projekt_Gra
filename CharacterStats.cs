using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStats : MonoBehaviour {

    public int level = 1;               // POZIOM
    public int magicLevel = 1;          // POZIOM MAGICZNY
    public int expToNextLevel = 100;    // PUNKTY DDOŚWIADCZENIA WYMAGANE DO OSIĄGNIĘCIA KOLEJNEGO POZIOMU
    public int currentExp = 0;          // AKTUALNE PUNKTY DOŚWIADCZENIA
    public int skillPoints = 0;         // DOSTĘPNE PUNKTY UMIEJĘTNOŚCI

    public int maxHealth = 100;         // PUNKTY ŻYCIA
    public int currentHealth = 100;           // AKTUALNE ŻYCIE
    public int maxMana = 100;           // PUNKTY MANY
    public int currentMana = 100;             // AKTUALNA MANA

    public int stamina = 0;             // POZIOM STAMINY
    public int maxStamina = 100;        // PUNKTY STAMINY (POZIOM + POZIOM STAMINY) * 100
    public int currentStamina = 100;          // AKTUALNY POZIOM STAMINY
    public int strength = 1;            // SIŁA
    public int agility = 1;             // ZWINNOŚĆ
    public int speed = 100;             // SZYBKOŚĆ
    public int intelligence = 1;        // INTELIGENCJA
    public int charisma = 1;            // CHARYZMA

    public int hunt = 0;                // POLOWANIE / UMIEJĘTNOŚCI ŁOWIECKIE (TO BĘDZIE JAKO JEDNO)
    public int sneak = 0;               // SKRADANIE SIĘ
    public int pickLooks = 0;           // OTWIERANIE ZAMKÓW
    public int pickPocket = 0;          // KRADZIEŻ
    public int acrobatics = 0;          // AKROBATYKA

    public int oneHanded = 0;           // BROŃ JEDNORĘCZNA
    public int twoHanded = 0;           // BROŃ DWURĘCZNA
    public int bow = 0;                 // ŁUK (BRÓN DYSTANSWA)
    public int physicalDamage = 1;      // OBRAŻENIA FIZYCZNE
    public int magicDamage = 0;         // OBRAŻENIA MAGICZNE

    public int physicalDefense = 0;     // OBRONA PRZED OBRAŻENIAMI FIZYCZNYMI
    public int magicResistance = 0;     // OBRONA PRZED OBRAŻENIAMI MAGICZNYMI
    public int spellCastingSpeed = 0;   // PRĘDKOŚĆ RZUCANIA ZAKLĘĆ
    public int readingRunes = 0;        // CZYTANIE RUN
    public int boilingPotions = 0;      // WARZENIE ELIKSIRÓW

    /* BENEFITS FROM ITEMS */
    public int extraHealth;
    public int extraMana;
    public int extraStamina;
    public int extraSpeed;
    public int extraArmor;              // Only for Helmet, Armor, Trousers, Boots, Gauntlets and some kinds of ExtraItems
    public int extraPhysicalDefense; // Only for Weapons, Shields and some kinds of ExtraItems
    public int extraPhysicalDamage; // Only for Weapons and some kinds of ExtraItems
    public int extraMagicResistance; // Only for Helmet, Armor, Trousers, Boots, Gauntlets, Shields and some kinds of ExtraItems
    public int extraMagicDamage; // Only for Weapons and some kinds of ExtraItems


    public Image hpBarSprite;
    public Image manaBarSprite;
    public Image staminaBarSprite;
    /*
    public Stat extraHealth;
    public Stat extraMana;
    public Stat extraStamina;
    public Stat extraSpeed;
    public Stat armor; // Only for Helmet, Armor, Trousers, Boots, Gauntlets and some kinds of ExtraItems
    public Stat physicalDefense; // Only for Weapons, Shields and some kinds of ExtraItems
    public Stat physicalDamage; // Only for Weapons and some kinds of ExtraItems
    public Stat magicResistance; // Only for Helmet, Armor, Trousers, Boots, Gauntlets, Shields and some kinds of ExtraItems
    public Stat magicDamage; // Only for Weapons and some kinds of ExtraItems
    */

    void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        currentStamina = maxStamina;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(25,5);
        }
    }

    public void TakeDamage (int _physicalDamage, int _magicDamage)
    {
        float healthFillFactor;
        float manaFillFactor;
        float staminaFillFactor;
        physicalDamage -= (int)((0.3 * extraArmor + 0.7 * physicalDefense) / _physicalDamage);
        magicDamage -= (int)((0.3 * extraArmor + 0.7 * magicResistance) / _magicDamage);
        currentHealth -= (_physicalDamage + _magicDamage);
        currentStamina -= (int)(currentStamina / 50);
        Debug.Log(transform.name + " takes " + _physicalDamage + " physical damage, " + _magicDamage + " magic damage and " + (int)(currentStamina / 50) + " stamina.");
        healthFillFactor = (float)currentHealth / (float)maxHealth;
        manaFillFactor = (float)currentMana / (float)maxMana;
        staminaFillFactor = (float)currentStamina / (float)maxStamina;
        hpBar(healthFillFactor);
        manaBar(manaFillFactor);
        staminaBar(staminaFillFactor);
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }

    public virtual void Die()
    {
        // DIe in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }

    public void addExp(int exp)
    {
        int numOfLevels = 0;
        currentExp += exp;
        if (currentExp >= expToNextLevel)
        {
            numOfLevels = levelUp(numOfLevels); // funkcja zwraca liczbę dodanych leveli.
            Debug.Log(numOfLevels + " levels Up.");
        }
    }

    int levelUp(int numOfLevels)
    {
        numOfLevels++;
        level++;
        expToNextLevel *= 4;
        skillPoints += 1;
        maxHealth += (int)((maxHealth / 10) + level);
        maxMana += (int)((maxMana / 20) + 2 * magicLevel + (0.5 * level));

        if (currentExp >= expToNextLevel) levelUp(numOfLevels);
        return numOfLevels; 
    }

    void hpBar(float fillFactor)
    {
        if (fillFactor < 0) fillFactor = 0;
        hpBarSprite.fillAmount = fillFactor;
    }

    void manaBar(float fillFactor)
    {
        if (fillFactor < 0) fillFactor = 0;
        manaBarSprite.fillAmount = fillFactor;

    }

    void staminaBar(float fillFactor)
    {
        if (fillFactor < 0) fillFactor = 0;
        staminaBarSprite.fillAmount = fillFactor;

    }
    
    /* 
     * Dopisać funkcje do:
     *  - zwiększania poziomu staminy
     *  - zwiększania ilości staminy
     *  - zwiększania poziomu siły
     *  - zwiększania poziomu zwinności
     *  - zwiększania szybkości
     *  - zwiększania poziomu inteligencji
     *  - zwiększania poziomu charyzmy
     *  - zwiększania poziomu polowania
     *  - zwiększania poziomu skradania się
     *  - zwiększania poziomu otwierania zamków
     *  - zwiększania poziomu kradzieży
     *  - zwiększania poziomu akrobatyki
     *  - zwiększania poziomu walki bronią jednoręczną
     *  - zwiększania poziomu walki bronią dwuręczną
     *  - zwiększania poziomu walki bronią dystansową
     *  - zwiększania obrażeń fizycznych
     *  - zwiększania obrażeń magicznych
     *  - zwiększania obrony przed obrażeniami fizycznymi
     *  - zwiększania obrony przed obrażeniami magicznymi
     *  - zwiększania prędkości rzucania zaklęć
     *  - zwiększania poziomu czytania run
     *  - zwiększania poziomu warzenia eliksirów
     *  
     *  - dodawania extraUmiejętności (dodatki z itemów)
     */
}
