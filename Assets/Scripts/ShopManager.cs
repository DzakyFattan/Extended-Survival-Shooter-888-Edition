using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{

    // get all children then assign them for a function to buy
    // get state singleton
    void Awake(){
        // get button
        // add listener to button
        // disable button if player has bought weapon 2 or doesn't have enough money
        Button buttonWeapon2 = transform.Find("ButtonWeapon2").GetComponent<Button>();
        int weapon2Price = 200;
        buttonWeapon2.onClick.AddListener(() => BuyWeapon2(weapon2Price));

        // button3
        Button buttonWeapon3 = transform.Find("ButtonWeapon3").GetComponent<Button>();
        int weapon3Price = 400;
        buttonWeapon3.onClick.AddListener(() => BuyWeapon3(weapon3Price));


        // button4
        Button buttonWeapon4 = transform.Find("ButtonWeapon4").GetComponent<Button>();
        int weapon4Price = 800;
        buttonWeapon4.onClick.AddListener(() => BuyWeapon4(weapon4Price));

        // handle pet
        // attack, heal, buff
        // list of buttons
        Button buttonPet1 = transform.Find("ButtonPetAttack").GetComponent<Button>();
        // add on click listener
        buttonPet1.onClick.AddListener(() => BuyPet(0, 200));
        Button buttonPet2 = transform.Find("ButtonPetHeal").GetComponent<Button>();
        buttonPet2.onClick.AddListener(() => BuyPet(1, 400));
        Button buttonPet3 = transform.Find("ButtonPetBuff").GetComponent<Button>();
        buttonPet3.onClick.AddListener(() => BuyPet(2, 800));
        Button[] buttons = new Button[] { buttonPet1, buttonPet2, buttonPet3 };
      
    }
    void Update(){
        Text currencyText = transform.Find("CurrencyText").GetComponent<Text>();
        // set currecy text
        currencyText.text = "Currency: " + State.Instance.currency;
        // press Q to exit by disabling this gameobject
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.SetActive(false);
            // enable mouse lock
            Cursor.lockState = CursorLockMode.Locked;
        }


        // get button
        // add listener to button
        // disable button if player has bought weapon 2 or doesn't have enough money
        Button buttonWeapon2 = transform.Find("ButtonWeapon2").GetComponent<Button>();
        int weapon2Price = 200;
        if (State.Instance.boughtShotgun || State.Instance.currency < weapon2Price)
        {
            buttonWeapon2.interactable = false;
        }
        else{
            buttonWeapon2.interactable = true;
        }

        // button3
        Button buttonWeapon3 = transform.Find("ButtonWeapon3").GetComponent<Button>();
        int weapon3Price = 400;
        if (State.Instance.boughtSword || State.Instance.currency < weapon3Price)
        {
            buttonWeapon3.interactable = false;
        }
        else{
            buttonWeapon3.interactable = true;
        }

        // button4
        Button buttonWeapon4 = transform.Find("ButtonWeapon4").GetComponent<Button>();
        int weapon4Price = 800;
        if (State.Instance.boughtBow || State.Instance.currency < weapon4Price)
        {
            buttonWeapon4.interactable = false;
        }
        else{
            buttonWeapon4.interactable = true;
        }

        // handle pet
        // attack, heal, buff
        // list of buttons
        Button buttonPet1 = transform.Find("ButtonPetAttack").GetComponent<Button>();
        Button buttonPet2 = transform.Find("ButtonPetHeal").GetComponent<Button>();
        Button buttonPet3 = transform.Find("ButtonPetBuff").GetComponent<Button>();
        Button[] buttons = new Button[] { buttonPet1, buttonPet2, buttonPet3 };
        // list of prices
        int[] prices = new int[] { 200, 400, 800 };
     
        // disable if player has bought pet or doesn't have enough money
        for (int i = 0; i < buttons.Length; i++)
        {
            if (State.Instance.ownedPets.Contains(i) || State.Instance.currency < prices[i])
            {
                buttons[i].interactable = false;
            }
            else{
                buttons[i].interactable = true;
            }
        }
    }
    // button weapon 2
    public void BuyWeapon2(int price)
    {
        // int price
        if (State.Instance.boughtShotgun || State.Instance.currency < price)
        {
            return;
        }
        // if player has enough money
        if (State.Instance.currency >= price)
        {
            // subtract money
            State.Instance.currency -= price;
            // set weapon 2 to true
            State.Instance.boughtShotgun = true;
            print("Bought Weapon 2");
        }
        // disable button by setting interactable to false
    }
    // button weapon 3
    public void BuyWeapon3(int price)
    {
        // int price
        if (State.Instance.boughtSword || State.Instance.currency < price)
        {
            return;
        }
        // if player has enough money
        if (State.Instance.currency >= price)
        {
            // subtract money
            State.Instance.currency -= price;
            // set weapon 2 to true
            State.Instance.boughtSword = true;
            print("Bought Weapon 3");
        }
    }

    public void BuyWeapon4(int price)
    {
        // int price
        if (State.Instance.boughtBow || State.Instance.currency < price)
        {
            return;
        }
        // if player has enough money
        if (State.Instance.currency >= price)
        {
            // subtract money
            State.Instance.currency -= price;
            // set weapon 2 to true
            State.Instance.boughtBow = true;
            print("Bought Weapon 4");
        }
    }
    public void BuyPet(int number, int price){

        // check if ownedPets contains number
        // if it does, return
        if (State.Instance.ownedPets.Contains(number) || State.Instance.currency < price)
        {
            return;
        }
        // if player has enough money
        if (State.Instance.currency >= price)
        {
            // subtract money
            State.Instance.currency -= price;
            State.Instance.ownedPets.Add(number);
        }
        // disable button by setting interactable to false
        print("Bought Pet " + number);
    }

}
