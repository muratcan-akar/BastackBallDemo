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
    public GameObject GameOverU�, WinnerUi;
    public bool FinishGame=false;
   //Oyun baslang�cinda kaybetme ve kazama ekranlarini kapat
    private void Start()
    {
        GameOverU�.SetActive(false);
        WinnerUi.SetActive(false);
    }


    // Bu fonksiyon calist�ginda level xp barlarini,skoru arttir , barlari doldur ve skor  artma animasyonunu calistir
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
            Debug.Log("Kazand�n");
            OpenWinnerUi();
        }

    }

    // Bu fonksiyon calist�ginda kazanma ekranini ac oyunu bitir
    public void OpenGameOverUi()
    {
        FinishGame = true;
        GameOverU�.SetActive(true);
    }
    // Bu fonksiyon calist�ginda kaybetme ekranini ac oyunu bitir
    public void OpenWinnerUi()
    {
        FinishGame = true;
        WinnerUi.SetActive(true);
    }
    // Bu fonksiyon calist�ginda oyunu yeniden baslat
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    //Skor say�sisini skor textine yazdir
    void Update()
    {
        ScoreText.text ="Score: "+ ScorePoint;
    }
}
