using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public GameObject ball;

    public int balls = 1;
    public int winScore = 3;
    public GameObject continueButton;
    public GameObject labelPause;
    public Text scoreP1;
    public Text scoreP2;
    public Text matchP1;
    public Text matchP2;
    public Text winner;
    public Text winScores;

    [HideInInspector] public bool victory = false;

    private int playerScore1 = 0;
    private int playerScore2 = 0;
    private int playerWins1 = 0;
    private int playerWins2 = 0;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        continueButton.SetActive(false);
        winScores.text = "Win scores: " + winScore;

        /*for (int i = 0; i < balls - 1; i++)
            Instantiate(ball);*/

    }

    public void Score(string wallID) {
        if (wallID == "RightWall")
            playerScore1++;
        else
            playerScore2++;

        if (playerScore1 == winScore) {
            playerWins1++;
            MatchWin("ONE");
        }
        else if (playerScore2 == winScore) {
            playerWins2++;
            MatchWin("TWO");
        }
        UpdateAllTexts();
    }

    void MatchWin(string name) {
        victory = true;
        continueButton.SetActive(true);
        winner.text = "PLAYER " + name + " WINS";
        ball.GetComponent<BallControl>().ResetBall();
    }

    public void RestartGame() {
        playerScore1 = 0;
        playerScore2 = 0;
        playerWins1 = 0;
        playerWins2 = 0;
        UpdateAllTexts();
        victory = false;
        continueButton.SetActive(false);
        labelPause.SetActive(false);
        ball.GetComponent<BallControl>().StartBallAfter1Second();
    }

    public void Continue() {
        playerScore1 = 0;
        playerScore2 = 0;
        UpdateAllTexts();
        victory = false;
        ball.GetComponent<BallControl>().StartBallAfter1Second();
        continueButton.SetActive(false);
    }

    void UpdateAllTexts() {
        scoreP1.text = "Score: " + playerScore1;
        scoreP2.text = "Score: " + playerScore2;
        matchP1.text = "Match won: " + playerWins1;
        matchP2.text = "Match won: " + playerWins2;
    }
}
