using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Image buttonImage; // —сылка на картинку на кнопке

    public void ShowButtonImage()
    {
        // ¬ключаем картинку на кнопке.
        buttonImage.gameObject.SetActive(true);
    }

    public void HideButtonImage()
    {
        // —крываем картинку на кнопке.
        buttonImage.gameObject.SetActive(false);
    }
}


