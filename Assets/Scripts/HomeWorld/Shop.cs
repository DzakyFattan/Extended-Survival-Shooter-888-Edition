using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject shopHUD;
    public GameObject ShopCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if K is pressed and trigger is true go to shop
        if (Input.GetKeyDown(KeyCode.K) && shopHUD.activeSelf)
        {
            // go to shop
            Debug.Log("Going to shop");
            // enable ShopCanvas
            ShopCanvas.SetActive(true);
            // disable mouse lock
            Cursor.lockState = CursorLockMode.None;
            
            
        }
    }
    // on cube colider, enable HUD which tell the player to press enter to go to shop
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopHUD.SetActive(true);
        }
    }

    // on cube colider, disable HUD which tell the player to press enter to go to shop
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopHUD.SetActive(false);
        }
    }

}
