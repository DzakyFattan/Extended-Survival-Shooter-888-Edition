using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Key : MonoBehaviour
{
  // get collider
  private Collider keyCollider;
  // public KeyCounter legacy text
  public UnityEngine.UI.Text keyLeft;

  void Awake()
  {
    keyCollider = GetComponent<Collider>();
  }


  // on colider enter, increment key counter
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {

      // disable collider
      keyCollider.enabled = false;


      // check total key left
      // tag = "Coin"
      // get all game objects with tag "Coin"
      GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

      // update key counter text
      print("Key Left: " +(coins.Length - 1).ToString());
      // keyLeft.text = "Key Left: " + coins.Length;
      // destroy key

      // if no key left, end game
      // tag = "GameMananger"
      // get game object with tag "GameManager"
      if (coins.Length == 1)
      {
        GameObject gameManager = GameObject.FindGameObjectWithTag("QuestManager");
        // call function from game manager
        gameManager.GetComponent<MazeQuestManager>().EndGame();
      }
      Destroy(gameObject);
    }
  }
}
