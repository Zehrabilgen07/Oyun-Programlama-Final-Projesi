using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public Transform[] targets;
    public float hiz;

    private int anlik;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targets[anlik].position)
        {
           transform.position = Vector3.MoveTowards(transform.position, targets[anlik].position, hiz * Time.deltaTime);
           gameObject.transform.LookAt(targets[anlik].transform);
        }
        else
        {
            anlik = (anlik + 1) % targets.Length;
        }
    }
}
