using UnityEngine;
using UnityEngine.SceneManagement;
public class CursorHider : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // Optional: lock cursor
    }
}
