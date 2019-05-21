using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject somePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] somePlatformArray;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private GemGenerator someGemGenerator;
    public float randomGemThresh;

    // Start is called before the first frame update
    void Start()
    {
        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i ++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;

        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
        someGemGenerator = FindObjectOfType<GemGenerator>();


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            //distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax + 3f);
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, transform.position.y, transform.position.z);

            platformSelector = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);
            //Instantiate(/*somePlatform*/ somePlatformArray[platformSelector], transform.position, transform.rotation);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }



            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomGemThresh)
            {
                someGemGenerator.SpawnGems(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), heightChange, transform.position.z);


        }

    }
}
