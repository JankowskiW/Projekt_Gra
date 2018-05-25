using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public static int ile_podniesiono;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 42;  
    
    public List<Item> items = new List<Item>();

    public int money;
    public int maxWeight;
    public int currentWeight;

    public GameObject parentObject;
    public GameObject bpObject;
    public GameObject currentWeightObject;
    public GameObject maxWeightObject;
    public GameObject currentMoneyObject;

    public Text currentCoins;
    public Text currentWeightText;
    public Text maxWeightText;

    void Start()
    {
        ile_podniesiono = 0;
        parentObject = GameObject.Find("Canvas");
        bpObject = parentObject.transform.GetChild(0).gameObject;
        bpObject = bpObject.transform.GetChild(1).gameObject;
        bpObject = bpObject.transform.GetChild(0).gameObject;

        currentWeightObject = maxWeightObject = bpObject.transform.GetChild(1).gameObject;
        currentWeightObject = currentWeightObject.transform.GetChild(1).gameObject; // ActualCarryWeight
        maxWeightObject = maxWeightObject.transform.GetChild(2).gameObject;
        currentWeightText = currentWeightObject.GetComponent<Text>();
        maxWeightText = maxWeightObject.GetComponent<Text>();

        currentMoneyObject = bpObject.transform.GetChild(0).gameObject;
        currentMoneyObject = currentMoneyObject.transform.GetChild(1).gameObject;
        currentCoins = currentMoneyObject.GetComponent<Text>();

        currentWeightText.text = currentWeight.ToString();
        maxWeightText.text = maxWeight.ToString();

        maxWeight = 100;
        currentWeight = 0;
    }

    public bool Add(Item item)
    {
        if (item.equipSlot.ToString()!="Money")
        {
            if ((items.Count >= space) || (currentWeight >= maxWeight))
            {
                Debug.Log("Not enough items slots or items are too heavy.");
                return false;
            }

            items.Add(item);
            currentWeight += item.weight;
            currentWeightText.text = currentWeight.ToString();
            maxWeightText.text = maxWeight.ToString();
            Debug.Log("Current items weight = " + currentWeight);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }else
        {
            money += item.money;
            currentCoins.text = money.ToString();
            Debug.Log("You earned " + money +"SomeCurrency.");

        }

        return true;
    }
    
    public void Remove(Item item)
    {
        items.Remove(item);
        currentWeight -= item.weight;
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
