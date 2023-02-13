using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float force = 700f;
    [SerializeField] private float damage = 80f;
    
    
    public GameObject explosionEffect;
    
    private float countdown;
    private bool hasExploded = false;
    
    void Start()
    {
        countdown = delay;
    }

   
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {    
        //Спавн эффекта взрыва
        Instantiate(explosionEffect, transform.position, transform.rotation);
        //Получение ближайших объектов
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            //Находим на объектах Rigidbody
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Если находим, добавляем силу направленную от гранаты
                rb.AddExplosionForce(force, transform.position, radius);
                
            }

             var destructible = nearbyObject.GetComponent<DestructibleObject>();
             if (destructible != null)
             {
                 destructible.ReceiveDamage(damage);
             }
           
            
        }
        
        
        Destroy(gameObject);
    }
}   
