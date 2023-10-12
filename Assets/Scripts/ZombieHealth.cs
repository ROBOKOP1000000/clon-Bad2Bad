using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public GameObject[] dropPrefabs; // Массив префабов для дропа
    private float currentHealth;
    private Slider healthSlider;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthSlider = GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth <= 0f) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        SetHealthUI();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Проверяем наличие префабов в массиве
        if (dropPrefabs.Length > 0)
        {
            // Выбираем случайный индекс из массива
            int randomIndex = Random.Range(0, dropPrefabs.Length);

            // Создаем случайный префаб на месте зомби
            Instantiate(dropPrefabs[randomIndex], transform.position, Quaternion.identity);
        }

        // Уничтожаем зомби
        Destroy(gameObject);
    }
}


