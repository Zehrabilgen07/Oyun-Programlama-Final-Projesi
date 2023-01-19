using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float ilerlemeHizi;
    [SerializeField] private float dondurmehizi;

    [SerializeField] private GameObject Car, Player;

    private void FixedUpdate()
    {
      
        if(Player.activeInHierarchy ==  true)
        {
            target = Player.transform;
        }
        else
        {
            target = Car.transform;
        }
        Ilerle();
        Dondur();
    }

    private void Dondur()
    {
        var yon = target.position - transform.position;
        var dondurme = Quaternion.LookRotation(yon, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, dondurme, dondurmehizi * Time.deltaTime);
    }

    private void Ilerle()
    {
        var hedefPozisyonu = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, hedefPozisyonu, ilerlemeHizi * Time.deltaTime);

    }
}
