using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PayToOpen : MonoBehaviour
{
    public float toplanacakMetalSayisi;
    private float anlýkMetal;
    public float katSayi;
    public TextMeshProUGUI anlikMetalText, popUp;
    public GameObject Bar, Araba, Tren;
    bool tikladiMi;
    MetalCreator metalOlusturucu;
    public GameObject trenKilit;
    // Start is called before the first frame update
    void Start()
    {
        metalOlusturucu = GameObject.Find("MetalOlusturma").GetComponent<MetalCreator>();
        tikladiMi = false;
        anlýkMetal = 0;
        anlikMetalText.text = toplanacakMetalSayisi.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "MetalCollector" )
        {
            popUp.enabled = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tikladiMi = true;
                MetaCollector metaCollector = other.gameObject.GetComponent<MetaCollector>();
                float givenMetal = metaCollector.anlýkMetal;

                if (anlýkMetal < toplanacakMetalSayisi)
                {
                    anlýkMetal += givenMetal;
                    if(anlýkMetal >toplanacakMetalSayisi)
                    {
                        anlýkMetal = toplanacakMetalSayisi;
                    }
                    Bar.transform.localScale = new Vector3(((anlýkMetal / toplanacakMetalSayisi)) * katSayi, Bar.transform.localScale.y, Bar.transform.localScale.z);
                    anlikMetalText.text = (toplanacakMetalSayisi - anlýkMetal).ToString();
                    metaCollector.anlýkMetal = 0;
                    foreach (var metal in metaCollector.metalListesi)
                    {
                        metal.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }

                }
            }
            if(anlýkMetal >= toplanacakMetalSayisi)
            {
                AracýAc(other);
                if(gameObject.name == "CarCarpýstýrma")
                {
                    Araba.gameObject.SetActive(true);
                    gameObject.transform.parent.gameObject.SetActive(false);

                }
                else if(gameObject.name == "CarpýstýrýcýTren")
                {
                    Tren.gameObject.SetActive(true);
                    gameObject.transform.parent.gameObject.SetActive(false);
                }

            }
               
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MetalCollector" )
        {
            popUp.enabled = false;
            if (tikladiMi)
            {
                MetaCollector metaCollector = other.gameObject.GetComponent<MetaCollector>();
                List<GameObject> metals = new List<GameObject>();
                if (metaCollector.metalListesi.Count != 0)
                {
                    metals.AddRange(metaCollector.metalListesi);
                    metaCollector.metalListesi.RemoveRange(0, metaCollector.metalListesi.Count);
                    foreach (var metal in metals)
                    {
                        if (metalOlusturucu.metaller.Contains(metal))
                        {
                            metalOlusturucu.metaller.Remove(metal);

                        }
                        Destroy(metal);
                    }
                }
                tikladiMi = false;
            }
        }
           
    }

    public void AracýAc(Collider other) {
        Debug.Log("sea");
        MetaCollector metaCollector = other.gameObject.GetComponent<MetaCollector>();
        List<GameObject> metals = new List<GameObject>();
        if (metaCollector.metalListesi.Count != 0)
        {
            metals.AddRange(metaCollector.metalListesi);
            metaCollector.metalListesi.RemoveRange(0, metaCollector.metalListesi.Count);
            foreach (var metal in metals)
            {
                Debug.Log("silme");
                Destroy(metal);
            }
            if(gameObject.name == "CarCarpýstýrma")
            {
                Debug.Log("train açýldý");
                trenKilit.SetActive(true);
            }
            anlýkMetal = 0;
        }
    }

}
