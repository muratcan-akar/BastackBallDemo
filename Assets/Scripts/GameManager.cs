using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Scrollbar LevelBar;
    public Scrollbar XpBar;
    public int ScorePoint=0;
    public Text ScoreText;
    public Animator ScoreAnimator;
    public Animator XpAnimator;
    public GameObject GameOverUý, WinnerUi;
    public bool FinishGame=false;
   //Oyun baslangýcinda kaybetme ve kazama ekranlarini kapat
    private void Start()
    {
        GameOverUý.SetActive(false);
        WinnerUi.SetActive(false);
    }


    // Bu fonksiyon calistýginda level xp barlarini,skoru arttir , barlari doldur ve skor  artma animasyonunu calistir
    public void ScoreActive() 
    {
      ScoreAnimator.SetTrigger("ScoreActive");
       ScorePoint++;
      LevelBar.size = LevelBar.size + 0.1f;
      XpBar.size = XpBar.size + 0.2f;

        // Eger Xp bar doldu ise   elmaslari alma animasyonunu calistir
        if (XpBar.size == 1)
        {
            Debug.Log("Xpleri Al");
            XpAnimator.SetBool("XpActive", true);
        }
        //Eger level bari doldu ise kazanma ekranini acacak fonksiyonu calistir
        if (LevelBar.size == 1)
        {
            Debug.Log("Kazandýn");
            OpenWinnerUi();
        }

    }

    // Bu fonksiyon calistýginda kazanma ekranini ac oyunu bitir
    public void OpenGameOverUi()
    {
        FinishGame = true;
        GameOverUý.SetActive(true);
    }
    // Bu fonksiyon calistýginda kaybetme ekranini ac oyunu bitir
    public void OpenWinnerUi()
    {
        FinishGame = true;
        WinnerUi.SetActive(true);
    }
    // Bu fonksiyon calistýginda oyunu yeniden baslat
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Skor sayýsisini skor textine yazdir
    void Update()
    {
        ScoreText.text ="Score: "+ ScorePoint;
    }
}
