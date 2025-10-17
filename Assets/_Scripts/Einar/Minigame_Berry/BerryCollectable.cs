using UnityEngine;

public class BerryCollectable : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
