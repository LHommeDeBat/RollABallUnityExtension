using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLogic : MonoBehaviour
{

    public Text livesText;
    public Text gameOverText;
    public int amountLives = 10;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOverText.text = "";
        setLivesText(amountLives);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        // If killed by water
        if(other.gameObject.CompareTag("Water")) 
        {
            // Decrement lives counter and update UI
            amountLives--;
            setLivesText(amountLives);
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            gameOverText.text = "You win!";
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    void LateUpdate()
    {
        // If player runs out of lives
        if (amountLives == 0)
        {
           gameOverText.text = "GAME OVER!";
           gameObject.SetActive(false);
           Time.timeScale = 0;
        }
    }

    void setLivesText(int amountLives)
    {
        livesText.text = "Lives left: " + amountLives.ToString();
    }
}
