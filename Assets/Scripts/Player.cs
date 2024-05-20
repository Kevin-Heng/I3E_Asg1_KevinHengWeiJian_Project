/*
 * Author: Kevin Heng
 * Date: 11/05/24 
 * Description: Player class is used for player capsule to store variables from other scripts and interaction
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    //---------------UI---------------------------
    public TextMeshProUGUI pointsText; //show total points on screen
    public TextMeshProUGUI powerUpText; //show power up count
    public TextMeshProUGUI totalCoinsText; //show coins count
    [SerializeField] GameObject textBoxImage; //text box image for text
    public TextMeshProUGUI textMessage; //text to show on screen

    //--------------Variables---------------------------
    public int totalPowerUps = 0; //initial number of power ups
    int totalPoints = 0; //initial number of points
    public int totalCoins = 0; //initial number of coins
    public bool collectKey = false; //key has not been collected
    public bool collectRedPowerUp = false; //red power up has not been collected
    public bool collectBluePowerUp = false; //blue power up has not been collected
    public bool collectYellowPowerUp = false; //yellow power up has not been collected

    //--------Interaction----------------
    //Door class will access Door.cs and currentDoor is the variable to assign the door object to interact with
    Door currentDoor;
    //LockedDoor class will access LockedDoor.cs and lockedDoor is the variable to assign the lockeDoor object to interact with
    LockedDoor lockedDoor;
    //to interact and pick up power ups
    BluePowerUp bluePowerUp; //access BluePowerUp.cs for bluePowerUp interaction
    RedPowerUp redPowerUp; //access RedPowerUp.cs for redPowerUp interaction
    YellowPowerUp yellowPowerUp; //access YellowPowerUp.cs for yellowPowerUp interaction
    Key key; //access Key.cs for key interaction
    MainPuzzleHint hint; //access MainPuzzleHint.cs for hint interaction
    YellowLvlHint yellowLvlHint; //access YellowLvlHint.cs for hint interaction
    BlueLvlHint blueLvlHint; //access BlueLvlHint.cs for hint interaction
    OutsideBlueLvl outsideBlueLvl; //accesss OutsideBlueLvl.cs for hint interaction
    OutsideYellowLvl outsideYellowLvl; //accesss OutsideYellowLvl.cs for hint interaction

    //function to count and show number of power ups picked up
    public void TotalPowerUps(int powerUp)
    {
        totalPowerUps += powerUp; //totalPowerUps should increase by 1 everytime a power up is picked
        powerUpText.text = "Power ups collected: " + totalPowerUps + "/3"; //show text on screen as Power Ups collected: _/3
        if (totalPowerUps == 3) //when all 3 powers up area picked up, text turns yellow
        {
            powerUpText.color = Color.yellow; //text becomes yellow
        }
    }

    //function to show total points on screen
    public void TotalPoints(int collectCoin)
    {
        totalPoints += collectCoin; //current total + one coin worth of points
        pointsText.text = "Points: " + totalPoints; //display text on screen as Points: __ 
    }

    //function to count number of coins collected
    public void TotalCoins(int coin)
    {
        totalCoins += coin; //totalCoins increases by 1 everytime a coin is collected
        totalCoinsText.text = "Coins collected: " + totalCoins + "/50"; //text shows as Coins collected: _/50
        if (totalCoins == 50) //when all 50 coins are collected
        {
            totalCoinsText.color = Color.yellow; //text turns yellow
        }
    }

    //function to change collectKey to true if key is collected
    public void CollectKey(bool key)
    {
        collectKey = key; 
    }

    //function to change collectRedPowerUp to true if red power up is collected
    public void CollectRedPowerUp(bool powerUp)
    {
        collectRedPowerUp = powerUp; 
    }

    //function to change collectBluePowerUp to true if blue power up is collected
    public void CollectBluePowerUp(bool powerUp)
    {
        collectBluePowerUp = powerUp; 
    }

    //function to change collectGreenPowerUp to true if yellow power up is collected
    public void CollectYellowPowerUp(bool powerUp)
    {
        collectYellowPowerUp = powerUp; 
    }

    //function to link door to interact keybind
    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor; 
    }

    //function to link locked door to interact keybind
    public void UpdateLockedDoor(LockedDoor newLockedDoor)
    {
        lockedDoor = newLockedDoor; 
    }
    //function to link blue power up to interact keybind
    public void PickUpBluePowerUp(BluePowerUp powerUp)
    {
        bluePowerUp = powerUp;
    }
    //function to link red power up to interact keybind
    public void PickUpRedPowerUp(RedPowerUp powerUp)
    {
        redPowerUp = powerUp;
    }
    //function to link yellow power up to interact keybind
    public void PickUpYellowPowerUp(YellowPowerUp powerUp)
    {
        yellowPowerUp = powerUp;
    }
    //function to link key to interact keybind
    public void PickUpKey(Key collectKey)
    {
        key = collectKey;
    }

    //function to link main puzzle hint to interact keybind
    public void OpenHint(MainPuzzleHint puzzleHint)
    {
        hint = puzzleHint;
    }

    //function to link yellow level hint to interact keybind
    public void OpenYellowHint(YellowLvlHint puzzleHint)
    {
        yellowLvlHint = puzzleHint;
    }

    //function to link yellow level hint to interact keybind
    public void OpenBlueHint(BlueLvlHint puzzleHint)
    {
        blueLvlHint = puzzleHint;
    }

    //function to link outside blue level hint to interact keybind
    public void OutsideBlueLvl(OutsideBlueLvl hint)
    {
        outsideBlueLvl = hint;
    }

    //function to link outside yellow level hint to interact keybind
    public void OutsideYellowLvl(OutsideYellowLvl hint)
    {
        outsideYellowLvl = hint;
    }

    //---------------------IN CLASS ------------------------
    Interact currentInteractable;
    public void UpdateInteractable(Interact newInteractable)
    {
        currentInteractable = newInteractable;
    }

    //----------------------------------------------------------


    //function for interaction
    void OnInteract()
    {
        //------IN CLASS------------
        if(currentInteractable != null)
        {
            //Interact with object
            currentInteractable.Interacted();
        }

        //-------------------------------------------------------------

        if (currentDoor != null) //null check if there is a door
        { 
            currentDoor.OpenDoor(); //open door function carries out on referenced door    
            currentDoor = null; //door only can turn about pivot once
        }

        if(lockedDoor != null) //null check if locked door is referenced
        {
            lockedDoor.OpenDoor(); //open door function carries out on refernced locked door
            lockedDoor = null; //after locked door open, door cannot be opened again
        }

        if(bluePowerUp != null) //null check if blue power up is referenced
        {
            bluePowerUp.PickUpPowerUp(); //pick up function carries out on referenced blue power up
        }

        if(redPowerUp != null) //null check if red power up is referenced
        {
            redPowerUp.PickUpPowerUp(); //after its picked up, cannot pick up again
        }

        if (yellowPowerUp != null) //null check if yellow power up is referenced
        {
            yellowPowerUp.PickUpPowerUp(); //after its picked up, cannot pick up again
        }

        if(key != null) //null check if key is referenced
        {
            key.CollectKey(); //collect key function carries out and key is picked up
        }

        if(hint != null) //null check if main puzzle hint is referenced
        {
            hint.OpenHint(); //open hint on screen
        }

        if(yellowLvlHint != null) //null check if yellow level hint is referenced
        {
            yellowLvlHint.OpenHint(); //open hint
        }

        if(blueLvlHint != null) //null check if blue level hint is referenced
        {
            blueLvlHint.OpenHint(); //open hint
        }
        if(outsideBlueLvl != null) //null check if outside blue level hint is referenced
        {
            outsideBlueLvl.OpenHint(); //open hint
        }
        if(outsideYellowLvl != null) //null check if outside yellow level hint is referenced
        {
            outsideYellowLvl.OpenHint(); //open hint
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        pointsText.text = "Points: " + totalPoints;//show starting number of points as Points: 0
        powerUpText.text = "Power ups collected: " + totalPowerUps + "/3"; //show starting number of powers ups as Power ups collected: 0/3
        totalCoinsText.text = "Coins collected: " + totalCoins + "/50"; //show starting number of coins collected as Coins collected: 0/50
    }

    // Update is called once per frame
    void Update()
    {
        if(totalPowerUps == 3 && totalCoins == 50) //congratulatory text when all items are collected
        {
            textMessage.text = "All items collected";
            textBoxImage.SetActive(true);
        }
    }
}
