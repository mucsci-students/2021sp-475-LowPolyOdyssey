using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(1, 5)]
    public float sensitivity = 1;
    [HideInInspector]
    public bool canMove = true;

    float m_rotX, m_rotY;

    void Start()
    {
        EnableMovement();
        m_rotX = 30;
        m_rotY = 0;
    }

    void Update()
    {
        if (canMove)
        {
            float mouseDeltaY = sensitivity * Input.GetAxis("Mouse Y");
            float mouseDeltaX = sensitivity * Input.GetAxis("Mouse X");
            m_rotX = Mathf.Clamp(m_rotX - mouseDeltaY, -90.0f, 90.0f);
            m_rotY += mouseDeltaX;
            transform.localEulerAngles = new Vector3(m_rotX, m_rotY, 0);
        }
    }

    public void EnableMovement()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canMove = true;
    }

    public void DisableMovement()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canMove = false;
    }
}
