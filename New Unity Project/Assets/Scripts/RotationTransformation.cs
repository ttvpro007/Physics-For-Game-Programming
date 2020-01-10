using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTransformation : Transformation
{
    [SerializeField] Vector3 rotation = Vector3.zero;

    public override Matrix4x4 Apply()
    {
        float cosX = Mathf.Cos(rotation.x * Mathf.PI / 180);
        float sinX = Mathf.Sin(rotation.x * Mathf.PI / 180);
        float cosY = Mathf.Cos(rotation.y * Mathf.PI / 180);
        float sinY = Mathf.Sin(rotation.y * Mathf.PI / 180);
        float cosZ = Mathf.Cos(rotation.z * Mathf.PI / 180);
        float sinZ = Mathf.Sin(rotation.z * Mathf.PI / 180);

        Matrix4x4 Rx = new Matrix4x4
        (
            new Vector4(1, 0, 0, 0),
            new Vector4(0, cosX, sinX, 0),
            new Vector4(0, -sinX, cosX, 0),
            new Vector4(0, 0, 0, 1)
        );

        Matrix4x4 Ry = new Matrix4x4
        (
            new Vector4(cosY, 0, -sinY, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(sinY, 0, cosY, 0),
            new Vector4(0, 0, 0, 1)
        );

        Matrix4x4 Rz = new Matrix4x4
        (
            new Vector4(cosZ, sinZ, 0, 0),
            new Vector4(-sinZ, cosZ, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        );

        return Ry * Rx * Rz;
    }
}