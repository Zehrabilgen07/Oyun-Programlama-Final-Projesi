using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalCreator : MonoBehaviour
{
    public Vector3 pozisyonlar;
    public float olusturmaZamani;
    public float maksimumOlusturmaZamaný;
    public GameObject metal;
    public List<GameObject> metaller;
    // Start is called before the first frame update
    void Start()
    {
        metaller = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        olusturmaZamani -= Time.deltaTime;
        if(olusturmaZamani  <= 0)
        {
            if(metaller.Count <= 100)
            {
                pozisyonlar = new Vector3(Random.Range(-95.3f, 307.6f), pozisyonlar.y, Random.Range(-314.3f, 99.5f));
                GameObject clone = Instantiate(metal, pozisyonlar, Quaternion.identity);
                olusturmaZamani = maksimumOlusturmaZamaný;
                metaller.Add(clone);
            }
        }
    }
}
