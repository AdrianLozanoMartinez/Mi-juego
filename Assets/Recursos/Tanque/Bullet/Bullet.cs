using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosionPrefab;

    private void Update()
    {
        if (transform.position.y <= 0)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_explosionPrefab, collision.GetContact(0).point, _explosionPrefab.transform.rotation);
        Destroy(gameObject);
    }*/
}
