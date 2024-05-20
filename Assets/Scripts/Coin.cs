/*
 * Author: Kevin Heng
 * Date: 11/05/24
 * Description: Coin class is for the collectibles(coins) in the game to increase player's score and record how many coins have been picked up
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public int coinPoints = 10; //each coin is worth 10 points
    int coinCount = 1; //used to count number of coins collected
    

    //function to increase score
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") //check if player collides with coin
        {
            collision.gameObject.GetComponent<Player>().TotalPoints(coinPoints); //access coin function from Player.cs to increase total points
            Destroy(gameObject);  //remove coin from game
            collision.gameObject.GetComponent<Player>().TotalCoins(coinCount); //access TotalCoins function in PLayer.cs to record how many coins have been collected

        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
