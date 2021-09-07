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
        sphere = transform.GetChild(0); //sphere objemizin ilk child�na e�ittir bu nedenle refarans�n� b�yle ald�k

        if(GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>(); // yoksa e�er rigidbody ekle dedik

            Rigidbody rb = GetComponent<Rigidbody>(); // ekledikten sonra referans�n� alma i�lemi

            rb.useGravity = false;

            rb.constraints = RigidbodyConstraints.FreezeAll;

            //GetComponent<Renderer>().material = playerManager.collectStick;



        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("collectable")){ //e�er ��e toplanabilir durumdaysa kodlara giri� yap demi� olduk
            
            if (playerManager.collectStick.Contains(collision.gameObject)) //e�er listede eleman varsa dedik bunu deme sebebimiz oyun ba��nda listemizde eleman var
            {
                Debug.Log("Buraya girdi");
                collision.gameObject.tag = "CollectedObj"; //�arpan ��enin tag'ini collectable iken CollectedObj olarak ayarla dedik
                collision.transform.parent = playerManager.collectedPoolTransform; //Bu kod collectedPoolTransform'un referans verdi�i gameObject'i temas eden yani collision'a de�en �genin ebeveyn'i yapar

                playerManager.collectStick.Add(collision.gameObject); //�arpan ��eyi listeye ekle dedik
                collision.gameObject.AddComponent<CollectedObjectController>(); //�arpan ��elere de CollectedObjectController scriptini ekle dedik. Buda asl�nda sonradan hiyerar�iye dahil olan eleman�nda �arpt��� ��eye yukar�daki �zelliklerin dahil olmas�n� yani toplama i�lemini ger�ekle�tirebilmesini sa�liyor
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
