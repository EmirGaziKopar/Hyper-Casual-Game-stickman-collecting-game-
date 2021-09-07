using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Material m_Material;
    [SerializeField] new GameObject gameObject;

    

    
    private void Start()
    {
        m_Material = gameObject.GetComponent<Renderer>().material;

        
        
    }


    private void Update()
    {
        //m_Material.color = Color.blue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CollectedObj"))
        {
            Debug.Log("Buraya girmedi");
            m_Material.color = Color.white;
          
        }
       
    }



}
