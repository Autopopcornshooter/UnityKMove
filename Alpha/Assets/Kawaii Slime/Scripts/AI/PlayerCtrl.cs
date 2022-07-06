using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;

    public float jump_rate;
    Animator anim;
    Rigidbody rgd;
    Vector3 move_dir=Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        move_dir.x = Input.GetAxis("Horizontal");
        move_dir.z = Input.GetAxis("Vertical");
        //rgd.velocity = move_dir * speed * Time.deltaTime;
        //rgd.AddForce(move_dir * speed*Time.deltaTime);
        anim.SetFloat("Speed", 0);
        transform.position += move_dir.normalized * speed * Time.deltaTime;
        if (move_dir.x != 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(move_dir.x));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move_dir), Time.deltaTime * 50);
        }
        if (move_dir.z != 0)
        {
            anim.SetFloat("Speed", Mathf.Abs( move_dir.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move_dir), Time.deltaTime * 50);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rgd.AddForce(new Vector3(0, jump_rate*100* Time.deltaTime, 0));
        }
    }
}
