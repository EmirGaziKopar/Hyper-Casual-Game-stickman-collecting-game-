using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerState playerState;
    public Material PlayerMaterial;

    public Transform collectedPoolTransform;


    public List<GameObject> collectStick; //degdigimiz ogerleri bir arada tutmak i�in gameobject listesi ekledik. Bu liste sayesinde toplanan t�m objelere istedi�imiz zaman eri�ebilece�iz
    public enum PlayerState
    {
        stop,move
    }
}
