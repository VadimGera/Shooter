using UnityEngine;

namespace DefaultNamespace
{
    public class DestructibleObject : MonoBehaviour
    {   
        //[SerializeField] - переменную можно редачить в юнити
        // текущее здоровье
        [SerializeField] private float hpCurrent = 100;



        //написанный кастомный метод(не юнити метод)
        //void: ничего не возвращает
        //float damage: принимает какое-то дробное число
        public void ReceiveDamage(float damage)
        {
            //Вычитаем из текущего ХП урон
            //hpCurrent = hpCurrent - 1f; можно писать и так
            hpCurrent -= damage;

            // Если ХП уменьшилось меньше нуля, то
            if (hpCurrent < 0f)
            {
                //Уничтожить объект
                Destroy(gameObject);
            }
        }
    }
}