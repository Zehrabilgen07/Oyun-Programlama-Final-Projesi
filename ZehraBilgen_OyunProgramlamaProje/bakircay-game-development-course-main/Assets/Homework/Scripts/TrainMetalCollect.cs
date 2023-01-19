using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMetalCollect : MonoBehaviour
{
    public int maxMetalSayisi;
    public int anlikMetalSayisi;
    public List<GameObject> metaller;

    // Start is called before the first frame update
    void Start()
    {
        metaller = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Metal")
        {
            if (anlikMetalSayisi < maxMetalSayisi)
            {
                metaller.Add(other.gameObject);
                anlikMetalSayisi++;
                other.gameObject.SetActive(false);
            }

        }

       
    }
}
