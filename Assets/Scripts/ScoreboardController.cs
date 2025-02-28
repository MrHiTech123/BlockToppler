using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreboardController : MonoBehaviour
{
    // Start is called before the first frame update
	
	public int score = 0;
	public int requiredScore = 10;
	public int secondsNeededToWin = 5;
	public string nextLevelSceneName;
	private float timeOfWin;
	private bool won = false;
	
	
    void Start()
    {
    }
	
	void CheckIfWon() {
		if (!won) {
			if (score >= requiredScore) {
				won = true;
				timeOfWin = Time.time;
			}
		}
		else if (Time.time - timeOfWin > secondsNeededToWin) {
			SceneManager.LoadScene(nextLevelSceneName, LoadSceneMode.Single);
		}
		else if (score < requiredScore) {
			won = false;
			timeOfWin = -1;
		}
	}
	void PrintScore() {
		GetComponent<TextMeshProUGUI>().text = "Blocks Toppled: " + score + "/" + requiredScore;
	}
	
	
    // Update is called once per frame
    void Update()
    {
        CheckIfWon();
		PrintScore();
    }
}
