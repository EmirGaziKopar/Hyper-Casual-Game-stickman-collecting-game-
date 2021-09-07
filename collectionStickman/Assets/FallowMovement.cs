using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowMovement : MonoBehaviour
{

    public new Transform camera, stickman;

    Vector3 yon;

    public float hiz = 10f;

    [SerializeField] Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    private void FixedUpdate()
    {
        camera.position = Vector3.Lerp(camera.position, stickman.position - distance, .05f); //(hangi posizyondan ba�layacak , hangi pozisyona gidecek , yumu�akl�k de�eri)
        camera.LookAt(stickman);
    }
}
