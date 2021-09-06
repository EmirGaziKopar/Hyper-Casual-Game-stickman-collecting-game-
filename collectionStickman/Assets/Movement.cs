using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float movementSpeed;
    [Range(0,500)]
    [SerializeField] float controlSpeed;

    [SerializeField] bool isTouching;


    float touchPosX;

    private void Update()
    {
        getInput();

    }

    private void FixedUpdate()
    {
        if(playerManager.playerState == PlayerManager.PlayerState.move)
        {
            //transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
            transform.Translate(transform.forward*movementSpeed*Time.deltaTime);  
        }
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
        }

        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z); // yukarýdan gelen x deðerini aldýk
    }
    void getInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
