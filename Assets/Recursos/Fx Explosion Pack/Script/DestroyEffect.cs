using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

    private void Start()
    {
        Destroy(transform.gameObject, 4);
    }
}
