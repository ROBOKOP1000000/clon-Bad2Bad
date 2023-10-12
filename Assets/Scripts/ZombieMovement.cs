
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    private Transform target; // Цель (Player)
    public Animator animator; // Ссылка на компонент аниматора Zombie
    NavMeshAgent agent; // Ссылка на компонент NavMeshAgent для перемещения Zombie

    public float radius = 4f; // Радиус, в котором Zombie начнет двигаться к игроку
    public AnimationClip[] randomIdleAnimations; // Массив случайных анимаций в покое

    private bool isPlayingIdleAnimation = false; // Флаг, указывающий, проигрывается ли анимация в покое

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Получаем компонент NavMeshAgent
        agent.updateRotation = false; // Отключаем автоматическое вращение агента
        agent.updateUpAxis = false; // Отключаем автоматическое выравнивание агента по вертикали
        animator = GetComponent<Animator>(); // Получаем компонент аниматора Zombie
        target = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока (Player) по тегу и получаем его Transform
    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position); // Расстояние до игрока

        if (distanceToTarget <= radius) // Если игрок находится в радиусе действия Zombie
        {
            agent.SetDestination(target.position); // Устанавливаем позицию игрока как цель для агента

            float moveX = target.position.x - transform.position.x; // Рассчитываем разницу по X между Zombie и игроком

            // Устанавливаем параметры аниматора в зависимости от направления движения
            animator.SetBool("IsMovingLeft", moveX < 0f);
            animator.SetBool("IsMovingRight", moveX > 0f);

            // Если Zombie движется, останавливаем проигрывание анимаций в покое
            if (isPlayingIdleAnimation)
            {
                StopCoroutine(PlayRandomIdleAnimation());
                isPlayingIdleAnimation = false;
            }
        }
        else
        {
            agent.SetDestination(transform.position); // Останавливаем движение агента и устанавливаем текущую позицию Zombie

            // Если Zombie стоит неподвижно и не проигрывается анимация в покое, запускаем корутину для проигрывания анимаций в покое
            if (!isPlayingIdleAnimation && !animator.GetBool("IsMovingLeft") && !animator.GetBool("IsMovingRight"))
            {
                StartCoroutine(PlayRandomIdleAnimation());
            }

            // Сбрасываем параметры анимации движения
            animator.SetBool("IsMovingLeft", false);
            animator.SetBool("IsMovingRight", false);
        }
    }

    private IEnumerator PlayRandomIdleAnimation()
    {
        isPlayingIdleAnimation = true;

        // Проигрываем случайную анимацию из массива
        if (randomIdleAnimations.Length > 0)
        {
            int randomIndex = Random.Range(0, randomIdleAnimations.Length);
            animator.Play(randomIdleAnimations[randomIndex].name);
        }

        // Ждем случайное время перед проигрыванием следующей анимации
        float waitTime = Random.Range(1f, 5f);
        yield return new WaitForSeconds(waitTime);

        isPlayingIdleAnimation = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius); // Рисуем красный круг в редакторе Unity, представляющий радиус действия Zombie
    }
}



















