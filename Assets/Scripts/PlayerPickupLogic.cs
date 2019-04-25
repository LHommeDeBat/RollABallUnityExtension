using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickupLogic : MonoBehaviour
{

    public Text countText;
    public Text winText;
    private int pickupCounter;
    private int amountOfPickUps;
    public GameObject[] pickUps;

    // Start is called before the first frame update
    void Start()
    {
        pickUps = GameObject.FindGameObjectsWithTag("Pick Up");
        amountOfPickUps = pickUps.Length;
        pickupCounter = 0;
        SetCountText (pickupCounter, pickUps.Length);
        winText.text = "";
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up")) 
        {
            other.gameObject.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = other.gameObject.GetComponent<Renderer>().material.color;
            pickupCounter++;
            SetCountText(pickupCounter, amountOfPickUps);
        }
    }

    void SetCountText(int pickupCounter, int amountOfActiveObjects)
    {
        countText.text = "Eggs collected: " + pickupCounter.ToString() + "/" + amountOfActiveObjects.ToString();
        if (pickupCounter == amountOfPickUps) 
        {
            winText.text = "You win!";
        }
    }
}
