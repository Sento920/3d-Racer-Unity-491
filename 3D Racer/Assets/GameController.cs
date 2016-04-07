using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text timer;
    public Text scoreText;
    [SerializeField]
    float Timer = 60f;
    public int Score;
	
    void Start()
    {
        Score  = 0;
    }

	// Update is called once per frame
	void Update () {
	    if(Timer > 0)
        {
            Timer -= Time.deltaTime;
            timer.text = "Time Left: " + Mathf.Ceil(Timer);
        }else
        {
            PlayerPrefs.SetInt("Score",Score);
        }
	}

    public void addOneScore()
    {
        this.Score += 1;
        scoreText.text = "Score: " + Score;
    }
}
