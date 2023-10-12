using UnityEngine;

public class ZombieCollision : MonoBehaviour
{
    private float collisionTime = 0f; // Время начала столкновения
    public float collisionDurationThreshold; // Пороговое время столкновения
    public float damageInterval; // Время между отниманием здоровья при столкновении
    private float damageTimer = 0f; // Время последнего отнимания здоровья

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Начинаем отслеживать столкновение при первом вхождении в коллайдер
            collisionTime = Time.time;

            // Наносим урон при первом столкновении
            DealDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Если столкновение продолжается достаточно долго или прошло 0.5 секунды с последнего урона,
            // отнимаем здоровье
            if (Time.time - collisionTime >= collisionDurationThreshold && Time.time - damageTimer >= damageInterval)
            {
                // Наносим урон
                DealDamage();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Сбрасываем таймер при выходе из столкновения
            collisionTime = 0f;
        }
    }

    private void DealDamage()
    {
        // Найдем объект Player в сцене
        HealthBar playerHealth = FindObjectOfType<HealthBar>();

        if (playerHealth != null)
        {
            // Уменьшим здоровье игрока на 20%
            playerHealth.SetHealth(playerHealth.currentHealth - (playerHealth.maxHealth * 0.2f));

            // Обновляем время последнего отнимания здоровья
            damageTimer = Time.time;
        }
    }
}





