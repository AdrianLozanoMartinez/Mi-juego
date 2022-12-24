using UnityEngine;
using UnityEngine.InputSystem;

public class Tank : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; // Añadirle aceleración
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private Transform turret;
    [SerializeField]
    private float turretRotateSpeed;
    [SerializeField]
    private Transform canon;
    [SerializeField]
    private float canonRotateSpeed;
    [SerializeField]
    private Vector2 canonRotationLimits;
    [SerializeField]
    private Transform endCanon;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Vector2 bulletImpulse;

    private PlayerInput _playerInput;

    private void Awake()//antes del start se llama y luego el resto
    {
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.actions["Shoot"].performed += (_) => Shoot();
    }

    void Update()
    {
        MoveTank();
        MoveTurret();
    }

    private void MoveTank()
    {
        Vector2 input = _playerInput.actions["Move"].ReadValue<Vector2>();

        transform.Translate(new Vector3(0, 0, input.y * moveSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(0, input.x * rotateSpeed * Time.deltaTime, 0));
    }

    private void MoveTurret()
    {
        Vector2 input = _playerInput.actions["Turret"].ReadValue<Vector2>();
        //input = Vector2.one;

        float canonRotation = canon.transform.localEulerAngles.x;
        if (canonRotation > 180) canonRotation -= 360;
        float newCanonRotation = canonRotation - input.y * canonRotateSpeed * Time.deltaTime;
        newCanonRotation = Mathf.Clamp(newCanonRotation, canonRotationLimits.x, canonRotationLimits.y);
        canon.localEulerAngles = new Vector3(newCanonRotation, 0, 0);

        turret.Rotate(new Vector3(0, input.x * turretRotateSpeed * Time.deltaTime, 0));
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, endCanon.position, bulletPrefab.transform.rotation); //Crea la bala, con posicion, inclinacion y rotacion, posicion
        Vector3 force = canon.forward * Random.Range(bulletImpulse.x, bulletImpulse.y); //Fuerza
        bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}
