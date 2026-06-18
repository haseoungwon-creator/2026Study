using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody rb;
    bool TakeDamageStadus = true;

    Vector3 move;
    float x, z;

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
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        move = new Vector3(x, 0, z).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && TakeDamageStadus)
        {
            TakeDamage(1);
            StartCoroutine(TakeDamageColl());
        }
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("현재 HP: " + hp);

        if (hp <= 0)
        {
            Debug.Log("죽음");
        }
    }

    public IEnumerator TakeDamageColl()
    {
        Debug.Log("출동 발생 3초 후 가능");
        TakeDamageStadus = false;
        rend.material.color = Color.red;

        yield return new WaitForSeconds(3f);


        rend.material.color = originalColor;

        TakeDamageStadus = true;
        Debug.Log("출동 가능");
    }
}