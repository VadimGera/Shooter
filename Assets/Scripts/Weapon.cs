using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        // [SerializeField]-Переменную можно редачить в юнити
        [SerializeField] private float force = 4; // сила выстрела
        [SerializeField] private float damage = 4; // урон от выстрела
        [SerializeField] private GameObject impactPrefab; // префаб эффекта попадания
        [SerializeField] private Transform shootPoint; // точка из которой идет выстрел
        
        //(Update)-стандартный юнити метод вызывает каждый кадр 
        private void Update()
        {   
            //Если нажимаем левую(0) кнопку мыши
            if (Input.GetMouseButtonDown(0))
            {
                //Выпускаем физический луч(Raycast)
                if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
                {
                    //Выводим название объекта в который попали
                    print(hit.transform.gameObject.name);
                    
                    //Создаем префаб эффекта попадания
                    Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
                    
                    //Пытаемся получить из объекта куда попали (DestructibleObject)
                    var destructible = hit.transform.GetComponent<DestructibleObject>();
                    
                    //если DestructibleObject есть то
                    if (destructible != null)
                    {
                        // Нанести урон
                        destructible.ReceiveDamage(damage);
                    }
                    
                    //Пытаемся получить из объекта, куда попали Rigidbody
                    var rigidbody = hit.transform.GetComponent<Rigidbody>();
                    
                    //Если Rigidbody  есть то
                    if (rigidbody != null)
                    {
                        //Добавить отбрасывание
                        ////Вызываем AddForce, в который нужно передать
                        //1) направление силы: shootPoint.forward (куда смотрит наше оружие)
                        //умноженное на force (силу)
                        //2) ForceMode.Impulse - говорит о том, что учитывается вес объекта, к
                        //которому добавляем силу
                        rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
                    }
                }
            }
        }
    }   
}