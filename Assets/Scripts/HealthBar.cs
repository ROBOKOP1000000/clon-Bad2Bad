using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    public GameObject gameOverPanel; // Ссылка на панель Game Over

    public float currentHealth; // Изменим уровень защиты на public

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ShowGameOver(); // Вызываем метод отображения панели Game Over
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        healthSlider.value = healthPercentage;
    }

    private void ShowGameOver()
    {
        gameOverPanel.GetComponent<GameOverManager>().ShowGameOver();
    }
}

