using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HW1ScriptManager : MonoBehaviour {

    // The player object.
    public GameObject player;

    // The initial spawn point.
   

    // How many gateways the player has passed through.
    public int currentScore;

    // How many gateways there are total.
    public int maxScore;

    // The text objs for displaying count (score) and a win message.
    public Text scoreText;
    public GameObject[] gates;

    // Use this for initialization
    void Start () {
        // Initialize the current spawn.
      

        // Initialize the score.
        currentScore = 0;

        // Initialize the text.
        scoreText.text = "";
    

	}

    
    public void resetscore()
    {
        currentScore = 0;
        scoreText.text = "";
        gates = GameObject.FindGameObjectsWithTag("Gate");
        foreach (GameObject gate1 in gates)
        {
            var referenceScript = gate1.GetComponent<Gateway>();
            referenceScript.activated = false;
        }
    }
    // Bump the score up by one, and update the GUI appropriately.
    public void ProcessGatewayActivation(Gateway gateway)
    {
        // Increase the score.
        currentScore += 1;

        // Update the progress text.
        SetScoreText();

        // Update the spawn location.
        //currentSpawnPoint = gateway.spawnPointObject.transform.position;
    }

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetScoreText()
    {
        // Update the text field of our 'countText' variable
        var maxScore2=maxScore+1;
        scoreText.text = "Gates passed: " + currentScore.ToString() + "/" + maxScore2.ToString();
    }
}
