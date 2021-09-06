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
        
        if (collision.gameObject.CompareTag("collectable")){
            
            if (playerManager.collectStick.Contains(collision.gameObject)) //e�er listede eleman yoksa
            {
                Debug.Log("Buraya girdi");
                collision.gameObject.tag = "CollectedObj";
                collision.transform.parent = playerManager.collectedPoolTransform;

                playerManager.collectStick.Add(collision.gameObject);
                collision.gameObject.AddComponent<CollectedObjectController>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
