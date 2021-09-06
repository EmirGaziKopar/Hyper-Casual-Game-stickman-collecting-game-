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
        playerManager.playerState = PlayerManager.PlayerState.move; //enumlarda de�i�iklik ana classlara ula��larak yap�l�r 
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(this, 1); //isGrounded true olduktan sonra bu koda ihtiyac�m�z yok yer ile temas�ndan 1 saniye sonra yok ediyoruz


    }
}
