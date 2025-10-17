using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryManager : MonoBehaviour
{
    public static List<GameObject> collectedBerries = new List<GameObject>();
    public GameObject berryPrefab;
    public Vector3 spawnPoint;

    public static BerryManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public static void AddBerry(GameObject berry)
    {
        collectedBerries.Add(berry);
        if (collectedBerries.Count == 5)
        {
            Instance.StartCoroutine(Instance.SpawnBerriesWithDelay());
        }
    }

    public IEnumerator SpawnBerriesWithDelay()
    {
        for (int i = 0; i < collectedBerries.Count; i++)
        {
            GameObject newBerry = Instantiate(berryPrefab, spawnPoint, Quaternion.identity);
            BerryMovement movementScript = newBerry.GetComponent<BerryMovement>();
            if (movementScript != null)
            {
                movementScript.enabled = true;
            }
            yield return new WaitForSeconds(1f);
        }
        collectedBerries.Clear();
    }
}
