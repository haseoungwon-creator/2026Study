using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    Rigidbody rb;
    [SerializeField] float knockbackDuration = 0.3f;
    bool TakeDamageStadus = true;

    [SerializeField] float knockbackForce = 5f;
    Vector3 move;
    float x, z;
    bool isKnockback = false;

    int hp = 3;
    Renderer rend;
    Color originalColor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void Update()
    {

        if (isKnockback)
        {
            move = Vector3.zero;
            return;
        }
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        move = new Vector3(x, 0, z).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }



    public void TakeDamage(int damage, Transform attacker)
    {
        if (!TakeDamageStadus)
            return;

        hp -= damage;
        Debug.Log("현재 HP: " + hp);

        ApplyKnockback(attacker);

        StartCoroutine(KnockbackRoutine());
        StartCoroutine(TakeDamageColl());
    }

    public IEnumerator TakeDamageColl()
    {
        Debug.Log("무적 3초 후 가능");
        TakeDamageStadus = false;
        rend.material.color = Color.red;

        yield return new WaitForSeconds(3f);


        rend.material.color = originalColor;

        TakeDamageStadus = true;
        Debug.Log("무적 불가능");
    }

    void ApplyKnockback(Transform attacker)
    {
        Vector3 dir = (transform.position - attacker.position).normalized;
        rb.AddForce(dir * 5f, ForceMode.Impulse);
    }

    IEnumerator KnockbackRoutine()
    {
        isKnockback = true;

        yield return new WaitForSeconds(knockbackDuration);

        isKnockback = false;
    }
}