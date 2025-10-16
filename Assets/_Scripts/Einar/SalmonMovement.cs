using UnityEngine;

public class SalmonMovement : MonoBehaviour
{

    [SerializeField] float speed;
    private int direction;

    private bool isStuck = false;

    public void SetSpeed(float s, int dir)
    {
        speed = s;
        direction = dir;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isStuck && other.CompareTag("Player"))
        {
            transform.parent = other.transform;
            isStuck = true;
            speed = 0;

        }
    }
}
