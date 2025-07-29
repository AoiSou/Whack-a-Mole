using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public float TimerTime=30f;
   public static float Timer;
   [SerializeField] TextMeshProUGUI TimerText;

   public static int Score=0;
   [SerializeField] TextMeshProUGUI ScoreText;
   
   [SerializeField] GameObject TimeUpText;

   void Start()
   {
      Timer = TimerTime;
   }
   
   private void Update()
   {
      EnterScore();
      if (Timer <= 0)
      {
         Time.timeScale = 0;
         TimeUpText.gameObject.SetActive(true);
      }
      else
         CountDownTimer();
   }

   void EnterScore()
   {
      ScoreText.text = ("SCORE:"+Score);
   }

   void CountDownTimer()
   {
      Timer -= Time.deltaTime;
      TimerText.text = Mathf.RoundToInt(Timer).ToString();
   }

   public void RestartGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       Timer = TimerTime;
       Score = 0;
       Time.timeScale = 1;
   }
}
