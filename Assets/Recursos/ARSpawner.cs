using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private UnityEvent onSpawn;

    private ARRaycastManager arRaycastManager;
    private GameObject instance;
    private bool isInstantiated;

    private void Awake()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Start()
    {
        instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        if (!isInstantiated)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            Vector2 middlePointScreen = new Vector2(Screen.width / 2, Screen.height / 2);
            if (arRaycastManager.Raycast(middlePointScreen, hits, TrackableType.Planes) && hits.Count > 0)
            {
                instance.transform.position = hits[0].pose.position;
                //instance.transform.rotation = hits[0].pose.rotation;
            }
        }
    }

    public void Spawn()
    {
        isInstantiated = true;
        onSpawn.Invoke();
    }
}
