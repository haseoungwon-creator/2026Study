using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] Rotate rotate;
    Player playerComponent;

    private void Start()
    {
        playerComponent = FindAnyObjectByType<Player>();
        player  = playerComponent.transform;
    }

    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}