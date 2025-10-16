using UnityEngine;

public class SceneTriggerArea : MonoBehaviour
{
    [SerializeField] private string targetSceneName;

    private void OnTriggerEnter(Collider other)
    {
        SceneController.Instance.LoadScene(targetSceneName);
    }
}

