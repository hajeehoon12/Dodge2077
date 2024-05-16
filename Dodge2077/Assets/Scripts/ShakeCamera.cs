using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{

    public static ShakeCamera instance;

    // ������ ī�޶��� transform
    public Transform shakeCamera;
    // ȸ����ų �������� �Ǵ��� ����
    public bool shakeRotate = false;
    // �ʱ� ��ǥ�� ȸ������ ������ ����
    public Vector3 originPos;
    public Quaternion originRot;

    // Use this for initialization

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        // �ʱ갪 ����
        originPos = shakeCamera.localPosition;
        originRot = shakeCamera.localRotation;
        MakeCameraShake(1f, 0.1f, 0.1f); // to call Camera Shake()
    }

    public void MakeCameraShake(float duration, float Position, float Rotation)
    {
        StartCoroutine(Shake(duration, Position, Rotation));
    }


    public IEnumerator Shake(float duration = 5f, float magnitudePos = 0.03f, float magnitudeRot = 0.1f)
    {
        // ������ �ð��� ������ ����
        float passTime = 0.0f;
        // �����ð����� ���� ����
        while (passTime < duration)
        {
            // �ұ�Ģ�� ��ġ�� ����
            Vector3 shakePos = Random.insideUnitCircle;
            // ī�޶��� ��ġ�� ����
            shakePos.z = originPos.z / magnitudePos;
            shakeCamera.localPosition = shakePos * magnitudePos;

            // �ұ�Ģ�� ȸ���� ����� ���
            if (shakeRotate)
            {
                // �޸��������Լ��� �ұ�Ģ�� ȸ���� ����
                Vector3 shakeRot = new Vector3(0, 0, Mathf.PerlinNoise(Time.time * magnitudeRot, 0.0f));
                // ī�޶� ȸ���� ����
                shakeCamera.localRotation = Quaternion.Euler(shakeRot);
            }

            // �����ð� ����
            passTime += Time.deltaTime;
            yield return null;
        }
        // ���� �� ���󺹱�
        shakeCamera.localPosition = originPos;
        shakeCamera.localRotation = originRot;

    }

}