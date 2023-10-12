using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D; // Ссылка на компонент Rigidbody2D игрока.
    [SerializeField] private FixedJoystick _joystick; // Ссылка на джойстик для управления движением.
    [SerializeField] private Animator _animator; // Ссылка на компонент аниматора для управления анимациями.
    [SerializeField] private float _moveSpeed; // Скорость движения игрока.
    public TextMeshProUGUI ammoTextMesh; // Сылка на текст с паторонами 


    public AutomaticGun automaticGun; // Ссылка на объект AutomaticGun.

    private Vector2 lastMoveDirection = Vector2.right; // Начальное направление движения игрока.
    private Vector2 lastPosition; // Последняя позиция игрока.
    private float lastScaleX; // Последний масштаб по оси X игрока.

    private float minX = -10f; // Минимальное значение координаты X, ограничивающее положение игрока
    private float maxX = 10f; // Максимальное значение координаты X, ограничивающее положение игрока
    private float minY = -10f; // Минимальное значение координаты Y, ограничивающее положение игрока
    private float maxY = 10f; // Максимальное значение координаты Y, ограничивающее положение игрока

    private void Start()
    {
        // Инициализация начальных значений при старте сцены. Начальная позиция и масштаб.
        lastPosition = transform.position;
        lastScaleX = transform.localScale.x;
    }

    private void Update()
    {
        // Получаем входные данные с джойстика.
        Vector2 moveDirection = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        // Проверяем, двигается ли игрок.
        bool isMoving = moveDirection.magnitude > 0.1f;

        // Обновляем анимацию и масштаб игрока.
        UpdateAnimation(isMoving, moveDirection);
        UpdateScale(isMoving, moveDirection);

        // Если игрок двигается, обновляем его позицию и сохраняем ее.
        if (isMoving)
        {
            Vector2 newPosition = (Vector2)transform.position + moveDirection.normalized * _moveSpeed * Time.fixedDeltaTime;

            // Ограничиваем новую позицию игрока в пределах minX, maxX, minY, maxY.
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            // Устанавливаем новую позицию.
            _rigidbody2D.MovePosition(newPosition);

            // Обновляем lastPosition на новую позицию.
            lastPosition = newPosition;
        }
        else
        {
            // Если игрок не двигается, останавливаем его.
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void UpdateAnimation(bool isMoving, Vector2 moveDirection)
    {
        // Управляем анимацией движения игрока в зависимости от его состояния.
        if (isMoving)
        {
            // Включаем анимацию "Player move".
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            // Выключаем анимацию "Player move", когда игрок не двигается.
            _animator.SetBool("IsMoving", false);
        }
    }

    private void UpdateScale(bool isMoving, Vector2 moveDirection)
    {
        // Управляем масштабом игрока в зависимости от его направления движения.
        if (isMoving)
        {
            // Если движение вправо, устанавливаем масштаб по X на 1, влево -1.
            if (moveDirection.x > 0)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                lastScaleX = 1f;
            }
            else if (moveDirection.x < 0)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                lastScaleX = -1f;
            }
        }
        else
        {
            // Если игрок стоит на месте, сохраняем последний масштаб.
            transform.localScale = new Vector3(lastScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void LateUpdate()
    {
        // При остановке игрока, сохраняем последнюю позицию и масштаб.
        lastPosition = transform.position;
        lastScaleX = transform.localScale.x;
    }
    public Vector3 GetPlayerDirection()
    {
        return new Vector3(lastScaleX, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("патроны"))
        {
            Destroy(other.gameObject);
            int ammoToAdd = 10; // Количество патронов для добавления
            automaticGun.AddAmmo(ammoToAdd); // Вызываем метод AddAmmo из объекта automaticGun
            UpdateAmmoText();
        }
    }

    private void UpdateAmmoText()
    {
        ammoTextMesh.text = automaticGun.GetAmmo().ToString(); // Обновляем отображение количества патронов из AutomaticGun
    }
}




