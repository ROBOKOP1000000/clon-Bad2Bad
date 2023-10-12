using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button deleteButton; // Ссылка на кнопку "удалить"
    public Image buttonImage; // Ссылка на картинку на основной кнопке
    public CanvasManager canvasManager; // Ссылка на CanvasManager

    private void Start()
    {
        // Отключаем кнопку "удалить" при старте игры.
        deleteButton.gameObject.SetActive(false);
    }

    public void OnMainButtonClick()
    {
        // Активируем кнопку "удалить" при нажатии на основную кнопку.
        deleteButton.gameObject.SetActive(true);
    }

    public void OnDeleteButtonClick()
    {
        // Скрываем картинку на основной кнопке
        buttonImage.gameObject.SetActive(false);

        // Скрываем кнопку "удалить" после нажатия
        deleteButton.gameObject.SetActive(false);
    }

    // Добавляем метод, который будет вызываться при соприкосновении с триггером "makarov"
    public void OnMakarovCollision()
    {
        // Показываем картинку на основной кнопке
        canvasManager.ShowButtonImage();
    }
}







