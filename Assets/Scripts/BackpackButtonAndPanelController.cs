using UnityEngine;
using UnityEngine.UI;

public class BackpackButtonAndPanelController : MonoBehaviour
{
    public GameObject backpackPanel; // Ссылка на объект панели рюкзака
    public Button backpackButton; // Ссылка на кнопку "рюкзак"

    private void Start()
    {
        // Отключаем панель рюкзака при запуске игры.
        backpackPanel.SetActive(false);

        // Назначаем метод OnBackpackButtonClick() обработчиком события при нажатии кнопки "рюкзак".
        backpackButton.onClick.AddListener(OnBackpackButtonClick);
    }

    private void OnBackpackButtonClick()
    {
        // Инвертируем состояние активности панели (если была отключена, то включим, и наоборот).
        backpackPanel.SetActive(!backpackPanel.activeSelf);

        // При желании, здесь можно добавить код для остановки игры или скрытия других элементов интерфейса.
        // Например, Time.timeScale = 0; для остановки времени в игре.
    }
}

