using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerState playerState;
    public Material PlayerMaterial;

    public Transform collectedPoolTransform;


    public List<GameObject> collectStick; //degdigimiz ogerleri bir arada tutmak için gameobject listesi ekledik. Bu liste sayesinde toplanan tüm objelere istediðimiz zaman eriþebileceðiz
    public enum PlayerState
    {
        stop,move
    }
}
