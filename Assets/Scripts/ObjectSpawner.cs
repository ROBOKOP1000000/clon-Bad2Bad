using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public CanvasManager canvasManager; // Ссылка на компонент CanvasManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, коснулся ли игрок объекта с тегом "makarov".
        if (other.CompareTag("makarov"))
        {
            // Включаем картинку на кнопке с помощью CanvasManager.
            canvasManager.ShowButtonImage();

            // Отключаем объект "makarov" при столкновении.
            Destroy(other.gameObject);
        }
    }
}



