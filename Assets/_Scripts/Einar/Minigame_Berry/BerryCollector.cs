using UnityEngine;
using UnityEngine.InputSystem;

public class BerryCollector : MonoBehaviour

{
    //[SerializeField] InputAction clickAction;


    public void OnClickAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if (hit.collider != null)
            {
                var collectible = hit.collider.GetComponent<BerryCollectable>();
                if (collectible != null)
                {
                    collectible.Collect();
                }
            }
        }
    }
}
