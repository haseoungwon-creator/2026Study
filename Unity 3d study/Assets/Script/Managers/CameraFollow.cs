using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] Rotate rotate;

    private void Start()
    {

    }

    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}