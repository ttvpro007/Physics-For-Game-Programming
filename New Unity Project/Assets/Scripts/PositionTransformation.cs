using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTransformation : Transformation
{
    [SerializeField] Vector3 position = Vector3.zero;

    public override Matrix4x4 Apply()
    {
        Vector4 Column0 = new Vector4(1, 0, 0, 0);
        Vector4 Column1 = new Vector4(0, 1, 0, 0);
        Vector4 Column2 = new Vector4(0, 0, 1, 0);
        Vector4 Column3 = new Vector4(position.x, position.y, position.z, 1);

        return new Matrix4x4(Column0, Column1, Column2, Column3);
    }
}
