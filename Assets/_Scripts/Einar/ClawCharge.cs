using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClawCharge : MonoBehaviour
{
    private CharacterController _characterController;
    private SalmonControls inputActions;
    private float chargeTime = 0f;
    [SerializeField] float maxChargeTime = 2f;
    [SerializeField] float minDropDistance = 2f;
    [SerializeField] float maxDropDistance = 10f;
    private Vector3 originalPosition;

    private bool isCharging = false;
    private bool isClawActive = false;

    //UI
    [SerializeField] Slider chargeBar;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        inputActions = new SalmonControls();

        inputActions.Player.ClawCharge.started += ctx => StartCharging();
        inputActions.Player.ClawCharge.canceled += ctx => ReleaseClaw();

        originalPosition = transform.position;

        if (chargeBar != null)
        {
            chargeBar.value = 0f;
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void StartCharging()
    {
        if (isClawActive) return;
        isClawActive = true;
        isCharging = true;
        chargeTime = 0f;
    }

    private void ReleaseClaw()
    {
        if (!isCharging || !isClawActive) return;
        if (isCharging)
        {
            PerformClawDrop();
            chargeTime = 0f;
            isCharging = false;
            if (chargeBar != null)
                chargeBar.value = 0f;
            StartCoroutine(ResetClawPositionAfterDelay(0.5f));
        }
    }

    private IEnumerator ResetClawPositionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // move back to original position and reset isclawactive bool
        float duration = 0.3f; // Duration of reset animation
        Vector3 startPosition = transform.position;
        float elapsed = 0f;
        isClawActive = false;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, originalPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }

    private void Update()
    {
        if (isCharging)
        {
            chargeTime += Time.deltaTime;
            if (chargeTime > maxChargeTime)
                chargeTime = maxChargeTime;
            if (chargeBar != null)
                chargeBar.value = chargeTime / maxChargeTime;
           
        }
    }

    private void PerformClawDrop()
    {
        float chargePercent = chargeTime / maxChargeTime;
        float dropDistance = Mathf.Lerp(minDropDistance, maxDropDistance, chargePercent);

        Vector3 targetPosition = transform.position + Vector3.down * dropDistance;
        transform.position = targetPosition;
        
    }
}

