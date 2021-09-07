using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjectController : MonoBehaviour
{

    PlayerManager playerManager;

    [SerializeField] Transform sphere;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        sphere = transform.GetChild(0); //sphere objemizin ilk childýna eþittir bu nedenle refaransýný böyle aldýk

        if(GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>(); // yoksa eðer rigidbody ekle dedik

            Rigidbody rb = GetComponent<Rigidbody>(); // ekledikten sonra referansýný alma iþlemi

            rb.useGravity = false;

            rb.constraints = RigidbodyConstraints.FreezeAll;

            //GetComponent<Renderer>().material = playerManager.collectStick;



        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("collectable")){ //eðer öðe toplanabilir durumdaysa kodlara giriþ yap demiþ olduk
            
            if (playerManager.collectStick.Contains(collision.gameObject)) //eðer listede eleman varsa dedik bunu deme sebebimiz oyun baþýnda listemizde eleman var
            {
                Debug.Log("Buraya girdi");
                collision.gameObject.tag = "CollectedObj"; //çarpan öðenin tag'ini collectable iken CollectedObj olarak ayarla dedik
                collision.transform.parent = playerManager.collectedPoolTransform; //Bu kod collectedPoolTransform'un referans verdiði gameObject'i temas eden yani collision'a deðen ögenin ebeveyn'i yapar

                playerManager.collectStick.Add(collision.gameObject); //çarpan öðeyi listeye ekle dedik
                collision.gameObject.AddComponent<CollectedObjectController>(); //çarpan öðelere de CollectedObjectController scriptini ekle dedik. Buda aslýnda sonradan hiyerarþiye dahil olan elemanýnda çarptýðý öðeye yukarýdaki özelliklerin dahil olmasýný yani toplama iþlemini gerçekleþtirebilmesini saðliyor
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
