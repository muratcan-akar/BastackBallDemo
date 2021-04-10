using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
   Animator BallAnimator;
   private CameraControl Camera_Control;
    private GameManager Game_Manager;
    public Control BallControl;
    // Oyun baslamadn hemen once oyun yoneticisi, kamera kontrol,ve bu objedeki animatoru bul 
    void Awake ()
    {
        Game_Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        Camera_Control = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<CameraControl>();
        BallAnimator = this.gameObject.GetComponentInParent<Animator>();
    }
    //Topun carpma fonksiyonlari
    
    //Top eger blogun yalarýndaki is triggeri acýk collidera carpar ise Gameover animasyonunu ve oyun yoneticisine gidip kaynetme animasyonunu acan fonksiyonu calistir
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.tag == "Block")
        {
            Camera_Control.GameOver = true;
           
            Debug.Log("YANDIN");
            BallAnimator.SetBool("GameOver", true);
            Game_Manager.OpenGameOverUi();
        }
    }
   // Eger Top blok haricinde zemine carpar ise topun tekrar zýplamasi icin havada olmadýgýný top kontrol koduna ilet
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            BallControl.BallOnFly = false;
        }
    }
   
}
