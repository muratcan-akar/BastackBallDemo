using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public bool BlockStop=false;
   
    private GameManager Game_Manager;
    private Control BallControl;
    // Oyun baslamadn hemen once oyun yoneticisi ve kontrol kodunu bul
    private void Awake()
    {
     
        Game_Manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        BallControl = GameObject.FindGameObjectWithTag("Ball").GetComponentInChildren<Control>();
    }
    //Blogun carpma fonksiyonlari
    //Eger blogun is triggeri acik colliderina top carpar ise 
    private void OnCollisionEnter(Collision collision)
    {
        //Oyun yönetisine git skor arttirma fonksiyonunu calistir,kontrole git topu havada degil yap ,blogu durdur
        if (collision.gameObject.tag == "Ball")
        {
            
            Game_Manager.ScoreActive();

            BallControl.BallOnFly = false;
           
            Debug.Log("Top Blogun üstünde");


            BlockStop = true;
        }
    }
    //Eger top blogun kenarlarindaki is triggeri kapali collidera carpar ise
    private void OnTriggerEnter(Collider other)
    {
        //Blogu durdur
        if (other.gameObject.tag == "Ball")
        {
            BlockStop = true;
        }
    }
    void Update()
    {
        //Oyun yonetisindeki oyun bitme degiskeni true ise(Oyun bitmis ise)
        if (Game_Manager.FinishGame == true)
        {
            //bloklari durdur
            BlockStop = true;
        }
        //Bloklar durmamis ise
        if (!BlockStop)
        {
            //Belirledigimiz topun altina yani z ve x de  0 noktasina  belirli bir hizda hareket et
            Vector3 DeserdPosition = new Vector3(0, transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, DeserdPosition, 4f * Time.deltaTime);
        }
    }
}
