using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int life;
    public int score;
    public Text scoreText;
    public Text healthline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life = Movement.health;
        score = collidor.score;
        healthline.text = life.ToString();
        scoreText.text = score.ToString();

    }
}
