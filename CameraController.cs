using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ������, ������ �������� ����� ��������� ������
    public float distance = 10.0f; // ��������� ���������� �� �������
    public float minDistance = 1.0f; // ����������� ���������� �� �������
    public float maxDistance = 20.0f; // ������������ ���������� �� �������
    public float xSpeed = 250.0f; // �������� �������� ������ ������ ��� X
    public float ySpeed = 120.0f; // �������� �������� ������ ������ ��� Y

    private float x = 0.0f; // ������� ���� �������� ������ ��� X
    private float y = 0.0f; // ������� ���� �������� ������ ��� Y

    void LateUpdate()
    {
        if (target)
        {
            // �������� ������� ������ �� ����
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            // ������������ ���� �������� �� ��������� �� -90 �� 90 ��������
            y = Mathf.Clamp(y, -45f, 20f);

            // ��������� ����� ��������� ������ � ������������
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 1f, -distance) + target.position;

            // ���������, ��� ���������� �� ������ �� ������� �� ������� �� ������� ���������� ��������
            if (distance > maxDistance)
                distance = maxDistance;
            else if (distance < minDistance)
                distance = minDistance;

            // ���������� ������ � ����� �������
            transform.rotation = rotation;
            transform.position = position;

            // ������������ �������� �������� ���� ��� ��������� ���������� �� �������
            distance -= Input.GetAxis("Mouse ScrollWheel") * 5.0f;
        }
    }
}