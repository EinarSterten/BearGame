using UnityEngine;
using TMPro;
public class CollectSalmon : MonoBehaviour
{
    [SerializeField] TMP_Text counterText;
    private int salmonCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);

        if (other.CompareTag("Salmon"))
        {
            salmonCount++;
            UpdateCounterText();
            Destroy(other.gameObject);
        }
    }

    private void UpdateCounterText()
    {
        Debug.Log("Updating counter text: " + salmonCount);
        counterText.text = "Salmon caught: " + salmonCount.ToString();
    }
}
