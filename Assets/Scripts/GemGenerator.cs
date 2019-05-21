using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour
{
    public ObjectPooler gemPool;
    public float distanceBetweenGems;

    public void SpawnGems(Vector3 startPosition)
    {
        GameObject gem1 = gemPool.GetPooledObject();
        gem1.transform.position = startPosition;
        gem1.SetActive(true);

        GameObject gem2 = gemPool.GetPooledObject();
        gem2.transform.position = new Vector3(startPosition.x - distanceBetweenGems, startPosition.y,startPosition.z);
        gem2.SetActive(true);

        GameObject gem3 = gemPool.GetPooledObject();
        gem3.transform.position = new Vector3(startPosition.x + distanceBetweenGems, startPosition.y, startPosition.z);
        gem3.SetActive(true);
    }


}
