using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutomaticGun : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули, которую мы будем стрелять
    public Transform bulletSpawnPoint; // Место, откуда пуля будет выпущена
    public TextMeshProUGUI ammoTextMesh; // Используем TextMeshProUGUI для отображения количества патронов
    private int currentAmmo; // Текущее количество патронов
    public PlayerController playerController;


    private void Start()
    {
        currentAmmo = 30; // Устанавливаем начальное количество патронов равным 30 (изначальное значение)
        UpdateAmmoText(); // Обновляем отображение количества патронов
    }

    public void Shoot()
    {
        if (currentAmmo > 0) // Проверяем, есть ли у нас патроны
        {
            // Создаем экземпляр пули
            GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            Bullet bullet = bulletObject.GetComponent<Bullet>();

            // Получаем направление взгляда игрока из PlayerController
            Vector3 playerDirection = playerController.GetPlayerDirection();

            // Пуля движется в направлении взгляда игрока
            bullet.SetMoveDirection(playerDirection);

            currentAmmo--; // Уменьшаем количество патронов после выстрела
            UpdateAmmoText(); // Обновляем отображение количества патронов
        }
    }

    private void UpdateAmmoText()
    {
        ammoTextMesh.text = currentAmmo.ToString(); // Обновляем текст с количеством патронов
    }

    public bool CanShoot()
    {
        return currentAmmo > 0; // Проверяем, можем ли мы стрелять (есть ли патроны)
    }

    public int GetAmmo()
    {
        return currentAmmo; // Получаем текущее количество патронов
    }

    public void AddAmmo(int amount)
    {
        currentAmmo += amount; // Увеличиваем количество патронов на указанную величину
        UpdateAmmoText(); // Обновляем отображение количества патронов
    }
}



