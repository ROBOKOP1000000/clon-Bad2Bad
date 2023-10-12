using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public Transform spawnPoint; // Ссылка на точку появления игрока

    void Start()
    {
        // Позиционируем игрока в точке появления
        if (spawnPoint != null)
        {
            // Перемещаем игрока к точке появления
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.transform.position = spawnPoint.position;
            }
        }
    }
}

