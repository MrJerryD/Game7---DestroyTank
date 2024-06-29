using UnityEngine;

public class MoveTank : MonoBehaviour
{
    Rigidbody rig;
    AudioSource steps;

    public float speed = 5f;
    public float speedAttitude = 2.5f;
    public float rotateSpeed = 80f;

    private void Start()
    {
        //steps = GetComponent<AudioSource>();

        rig = GetComponent<Rigidbody>();
        rig.interpolation = RigidbodyInterpolation.Interpolate; // Включить интерполяцию Rigidbody типо плавость
    }

    private void FixedUpdate()
    {
        Movement();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Вращение объекта (ниже вместо Horizontal идет 0, чтобы объект мог на месте поворачиваться)
        if (horizontal != 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * horizontal * rotateSpeed);
        }
        Vector3 moveDirection = transform.forward * vertical * speed * Time.deltaTime; // при сталкивании с обьектами, не проходит внутрь (тут помагает физическое свойство в materials)
        rig.MovePosition(transform.position + moveDirection);
    }
}
