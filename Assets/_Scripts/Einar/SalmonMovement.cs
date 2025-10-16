using UnityEngine;

public class SalmonMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private int direction;

    public void SetSpeed(float s, int dir)
    {
        speed = s;
        direction = dir;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
    }
}
