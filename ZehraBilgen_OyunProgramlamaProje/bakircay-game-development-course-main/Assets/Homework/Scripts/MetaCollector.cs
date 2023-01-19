using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaCollector : MonoBehaviour
{
    public float maxMetal;
    public float anlýkMetal;
    public GameObject toplamaYeri,toplamaYeri2;
    public List<GameObject> metalListesi;
    // Start is called before the first frame update
    void Start()
    {
        anlýkMetal = 0;
        metalListesi = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
   
        if (other.gameObject.tag == "Metal")
        {
            if (anlýkMetal < maxMetal)
            {

                anlýkMetal++;
                metalListesi.Add(other.gameObject);
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.GetComponent<MeshCollider>().enabled = false;
                //other.gameObject.SetActive(false);
                MetalYerlestir();
                

            }

        }
    }
    public void MetalYerlestir()
    {
        float sayac = 0f;
        float sayacCar1 = 0f;
        float sayacCar2 = 0f;
        foreach (var metal in metalListesi)
        {
            if(toplamaYeri.name == "ArabaMetalToplayýcý")
            {
                if(toplamaYeri.transform.childCount < 5)
                {
                    metal.gameObject.transform.SetParent(toplamaYeri.gameObject.transform);
                    metal.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    metal.gameObject.transform.localPosition = new Vector3(0, 3.55f, 0); 
                    metal.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    metal.gameObject.transform.localPosition = new Vector3(metal.transform.localPosition.x, metal.transform.localPosition.y , metal.transform.localPosition.z + sayacCar1);
                    sayacCar1 = sayacCar1 - 0.84f;
                }
                else
                {
                    metal.gameObject.transform.SetParent(toplamaYeri2.gameObject.transform);
                    metal.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    metal.gameObject.transform.localPosition = new Vector3(0, 3.55f, 0);
                    metal.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    metal.gameObject.transform.localPosition = new Vector3(metal.transform.localPosition.x, metal.transform.localPosition.y , metal.transform.localPosition.z + sayacCar2);
                    sayacCar2 = sayacCar2 - 0.84f;
                }
            }
            else
            {
                metal.gameObject.transform.SetParent(toplamaYeri.gameObject.transform);
                metal.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                metal.gameObject.transform.localPosition = Vector3.zero;
                metal.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                metal.gameObject.transform.localPosition = new Vector3(metal.transform.localPosition.x, metal.transform.localPosition.y + sayac, metal.transform.localPosition.z);
                sayac = sayac + 0.55f;
            }
           
        }
    }
  
}
