using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour //SWAP
{
    public GameObject BlocksPrefab;

    public Vector3 CreatePosition;
    public Vector3 DeserdPosition;

    //Oyun basladigi zaman olusma noktasini belirle ve belirli bir surede bir olusturacak  IEnumeratoru calistir 
    void Start()
    {
       
        CreatePosition = new Vector3(10f, -3f, 0);
        StartCoroutine(BlocksCreating());
    }
    //Her 3 saniyede bir yeni bir blok olustur ve olusma noktasini degistirecek kodu calistir
  public  IEnumerator BlocksCreating()
    {
        yield return new WaitForSeconds(3f);
        GameObject CreateBlock = Instantiate(BlocksPrefab, CreatePosition, Quaternion.identity);
    
        ChangePosition();
        
    }
    //Bu fonksiyon calistiginda olusma noktasini tam bir blok kadar yukari arttirsin ve tekrar olusturacak  IEnumeratoru calistirsin 
    public void ChangePosition()
    {
        CreatePosition = new Vector3(CreatePosition.x, CreatePosition.y+0.74f, CreatePosition.z);
        StartCoroutine(BlocksCreating());
    }


    
  
}
