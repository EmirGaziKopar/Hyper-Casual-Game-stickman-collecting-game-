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
    [Range(8,11)]
    [SerializeField] float distanceBetweenSides;




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
        if (isTouching && transform.position.x > -distanceBetweenSides && transform.position.x< distanceBetweenSides)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
        }
        else if (transform.position.x < -distanceBetweenSides)
        {
            touchPosX += 0.2f;
        }
        else if(transform.position.x > distanceBetweenSides)
        {
            touchPosX -= 0.2f;
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
