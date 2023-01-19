using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    [SerializeField] bool isWalking;
    public float hiz;
    public float turnSmoothTime ;
    float turnSmoothVelocity;
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");

        Vector3 yon = new Vector3(yatay, 0f, dikey).normalized; 

        if(yon.magnitude >= 0.1f)
        {
            float hedefAcý = Mathf.Atan2(yon.x,yon.z)* Mathf.Rad2Deg +cam.eulerAngles.y;
            float acý = Mathf.SmoothDampAngle(transform.eulerAngles.y, hedefAcý, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, acý, 0f);

            Vector3 hareketYonu = Quaternion.Euler(0f, acý, 0f)*Vector3.forward;
            controller.Move(hareketYonu.normalized * hiz * Time.deltaTime);
            isWalking = true;
            animator.SetBool("IsWalking", isWalking);
        }
        else
        {
            isWalking = false;
            animator.SetBool("IsWalking", isWalking);
        }

        gameObject.transform.position = new Vector3(transform.position.x,0,transform.position.z);






    }
}
