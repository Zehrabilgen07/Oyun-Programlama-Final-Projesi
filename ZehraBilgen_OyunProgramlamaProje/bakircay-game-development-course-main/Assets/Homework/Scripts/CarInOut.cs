using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarInOut : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI popup,popUpArabadanIn;
    GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(player != null)
            {
                if(player.activeInHierarchy == false)
                {
                    player.SetActive(true);
                    player.transform.parent = null;
                }

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
       
        if(other.gameObject.tag == "Player")
        {
            popup.enabled = true;
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                player = other.gameObject;
                other.gameObject.SetActive(false);
                other.gameObject.transform.SetParent(gameObject.transform.parent);
                popUpArabadanIn.enabled = true;
                popup.enabled = false;
                StartCoroutine(ClosePopUp());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popup.enabled = false;
           
        }
    }
    public IEnumerator ClosePopUp()
    {
        yield return new WaitForSeconds(5);

        popUpArabadanIn.enabled = false;
    }
}
