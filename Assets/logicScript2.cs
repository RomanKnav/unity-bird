using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // since we'll be working with the scene at restartGame()

// responsible for all high level shit, like score
public class logicScript2 : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public bool disableScore = false;

    // what's this again?
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!disableScore)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    // this will RESTART THE SCENE:
    public void restartGame()
    {
        // gets the currently active scene and fucking restarts it!!!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        disableScore = true;
        gameOverScreen.SetActive(true);     // disabled. This enables it.
    }
}
