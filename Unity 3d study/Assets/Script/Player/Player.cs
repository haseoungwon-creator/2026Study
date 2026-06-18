using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody rb;
    Vector3 move;
    float x, z;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        move = new Vector3(x, 0, z).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(move * speed, ForceMode.Force);
    }


}
