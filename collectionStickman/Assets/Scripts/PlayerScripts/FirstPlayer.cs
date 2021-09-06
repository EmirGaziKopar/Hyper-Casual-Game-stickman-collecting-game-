using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayer : MonoBehaviour
{

    [SerializeField] PlayerManager playerManager;

    private new Rigidbody rigidbody;

    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        //GetComponent<Renderer>().material = playerManager.PlayerMaterial;

        playerManager.collectStick.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
        
    }

    void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.move; //enumlarda deðiþiklik ana classlara ulaþýlarak yapýlýr 
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(this, 1); //isGrounded true olduktan sonra bu koda ihtiyacýmýz yok yer ile temasýndan 1 saniye sonra yok ediyoruz


    }
}
