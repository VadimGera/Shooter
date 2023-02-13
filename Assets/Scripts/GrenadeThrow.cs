using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [SerializeField] private float throwForce = 50f;
    [SerializeField] private GameObject grenadePrefab;

   
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GrenadeThrowForward();
        }
    }

    private void GrenadeThrowForward()
    {   
        // создаем экземпляр гранаты
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        //берем из нее Rigidbody
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        // задаем толчок силы
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
