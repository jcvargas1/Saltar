using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{
    public int scoreToGive;

    private ScoreManager someScoreManager;
   //private AudioSource gemSound;

    // Start is called before the first frame update
    void Start()
    {
        someScoreManager = FindObjectOfType<ScoreManager>();
       // gemSound = GameObject.Find("GemSound");

    }

  

   public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.name == "Player")
        {
            someScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }
         
    }

}
