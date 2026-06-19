using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 3f;

    [SerializeField] float chaseRange = 10f;
    [SerializeField] float stopDistance = 1.5f;

    [SerializeField] int attackDamage = 1;
    [SerializeField] float attackCooldown = 2f;

    bool canAttack = true;

    Player playerComponent;


    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerComponent = FindAnyObjectByType<Player>();
        player = playerComponent.transform;


    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > chaseRange)
            return;

        // 방향 계산 (회전용)
        Vector3 direction = (player.position - transform.position);
        direction.y = 0f; // 기울어지지 않게 Y 제거

        // 회전 적용
        if (direction != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            Quaternion smoothRot = Quaternion.Slerp(rb.rotation, targetRot, 100f * Time.fixedDeltaTime);
            rb.MoveRotation(smoothRot);
        }

        if (distance < stopDistance)
        {
            TryAttack();
            return;
        }

        // 이동
        Vector3 moveDir = direction.normalized;
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }

    void TryAttack()
    {
        if (!canAttack)
            return;
        playerComponent.TakeDamage(attackDamage, transform);

        StartCoroutine(AttackCooldown());
    }

     IEnumerator AttackCooldown()
    {
        Debug.Log("공격 쿨다운 시작");
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        Debug.Log("공격 쿨다운 끝");
    }
}