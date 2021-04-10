using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float ShootPower;
    public bool BallOnFly;
    public GameManager Game_Manager;
   //Ziplama butanuna her basildinda top havada degil ise ve oyun bitmemis ise
    public void ShootButton()
    { 
        //Rigidbody velocty kuvveti ile top havaya atilsin ve top havda degiskeni true olsun
        if (!BallOnFly && !Game_Manager.FinishGame)
        {


           this.gameObject.GetComponent<Rigidbody>().velocity = transform.up * ShootPower;
           BallOnFly = true;
        }
    }

  
}
