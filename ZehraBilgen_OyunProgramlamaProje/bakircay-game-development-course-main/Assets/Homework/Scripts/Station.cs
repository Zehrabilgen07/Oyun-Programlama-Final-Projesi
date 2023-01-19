using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Station : MonoBehaviour
{
    public float anlýkMetalsayisi;
    [SerializeField] TextMeshProUGUI toplamMetalSayisiText;
    MetalCreator metalOlusturucu;
    // Start is called before the first frame update
    void Start()
    {
        metalOlusturucu = GameObject.Find("MetalOlusturma").GetComponent<MetalCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        toplamMetalSayisiText.text = anlýkMetalsayisi.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Train")
        {
            List<GameObject> temp = new List<GameObject>();
            anlýkMetalsayisi+=  other.gameObject.GetComponent<TrainMetalCollect>().anlikMetalSayisi;
            other.gameObject.GetComponent<TrainMetalCollect>().anlikMetalSayisi = 0;
            temp.AddRange(other.gameObject.GetComponent<TrainMetalCollect>().metaller);
            metalOlusturucu.metaller.RemoveRange(0, metalOlusturucu.metaller.Count);
            other.gameObject.GetComponent<TrainMetalCollect>().metaller.RemoveRange(0, other.gameObject.GetComponent<TrainMetalCollect>().metaller.Count);

            foreach (var metal in temp)
            {
                Destroy(metal);
            }
        }
    }
}
