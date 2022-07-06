using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerawork : MonoBehaviour
{
    public GameObject player;

    [SerializeField]private float lerpValue;
    Vector3 firstPos;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position+firstPos,Time.deltaTime*lerpValue);
    }
}
