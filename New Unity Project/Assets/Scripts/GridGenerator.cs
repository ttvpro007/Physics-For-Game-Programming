using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] int dimension = 10;
    [Range(0f,1f)]
    [SerializeField] float alpha = 1;
    [SerializeField] GameObject prefab = null;
    List<Transform> vertices = new List<Transform>();
    List<Vector3> vertexPositions = new List<Vector3>();
    Transformation[] transformations;

    private void Awake()
    {
        GenerateGrid(dimension);
        transformations = GetComponents<Transformation>();
    }

    private void FixedUpdate()
    {
        ApplyTransformation();
    }

    private void ApplyTransformation()
    {
        if (transformations.Length > 0)
        {
            Matrix4x4 transformationMatrix = Matrix4x4.identity;
            for (int i = 0; i < transformations.Length; i++)
            {
                transformationMatrix = transformations[i].Apply() * transformationMatrix;
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                Vector3 vertexPosition = vertexPositions[i];
                Vector4 homogenousCoords = new Vector4
                (
                    vertexPosition.x,
                    vertexPosition.y,
                    vertexPosition.z,
                    1
                );

                Vector4 transformedPos = transformationMatrix * homogenousCoords;
                vertices[i].position = transformedPos;
            }
        }
    }

    private void GenerateGrid(int dimension)
    {
        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                for (int k = 0; k < dimension; k++)
                {
                    CreateVertex(i, j, k);
                }
            }
        }
    }

    private void CreateVertex(int i, int j, int k)
    {
        float x = i - (float)dimension * .5f;
        float y = j - (float)dimension * .5f;
        float z = k - (float)dimension * .5f;

        Transform t = Instantiate(prefab).transform;
        t.position = new Vector3(x, y, z);
        vertices.Add(t);
        vertexPositions.Add(t.position);

        float r = (float)i / (float)dimension;
        float g = (float)j / (float)dimension;
        float b = (float)k / (float)dimension;

        t.GetComponent<Renderer>().material.color = new Color(r, g, b, alpha);
    }
}
