using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class SandWaves : MonoBehaviour
{
/*
	[SerializeField] int m_NumberRings = 20;
	[SerializeField] int m_NumberSegments = 20;
	[SerializeField] float m_Size = 10.0f;
*/

	[SerializeField] int m_SegmentsX;
	[SerializeField] int m_SegmentsY;
	[SerializeField] Vector2 m_Size;

	// Use this for initialization
	void Start () 
	{
		m_MeshFilter = GetComponent<MeshFilter>();
		m_Mesh = new Mesh();
		m_MeshFilter.mesh = m_Mesh;

		RebuildMesh();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_SegmentsX != m_MeshSegmentsX || m_SegmentsY != m_MeshSegmentsY || m_Size != m_MeshSize)
		{
			RebuildMesh();
		}

		if (Application.isPlaying)
		{
			UpdateMesh();
		}
/*
		List<Vector3> verts = new List<Vector3>();
		List<int> indices = new List<int>();

		float ringSize = m_Size / m_NumberRings;

		verts.Add(Vector3.zero);
		for (int ring = 0; ring < m_NumberRings + 1; ring++)
		{
			float distance = ring * ringSize;

			for (int segment = 0; segment < m_NumberSegments; segment++)
			{
				float angle = (segment / m_NumberSegments) * Mathf.PI * 2.0f;

				Vector3 vert = Vector3.zero;
				vert.x = Mathf.Sin(angle) * distance;
				vert.z = Mathf.Cos(angle) * distance;
				verts.Add(vert);

				if (ring < m_NumberRings)
				{
					indices.Add(ring * m_NumberRings + segment);
					indices.Add(ring * (m_NumberRings + 1) + segment);
				}
			}
		}

		m_Mesh.SetVertices(verts);
		m_Mesh.SetIndices(indices.ToArray(), MeshTopology.Quads, 0);
*/
	}

	void OnValidate()
	{
		m_SegmentsX = Mathf.Max(m_SegmentsX, 1);
		m_SegmentsY = Mathf.Max(m_SegmentsY, 1);
	}

	void RebuildMesh()
	{
		List<Vector3> verts = new List<Vector3>();
		List<Vector3> normals = new List<Vector3>();
		List<int> quads = new List<int>();

		m_MeshSegmentsX = m_SegmentsX;
		m_MeshSegmentsY = m_SegmentsY;
		m_MeshSize = m_Size;

		Vector3 offset = new Vector3(-m_MeshSize.x / 2, 0, -m_MeshSize.y / 2);
		float deltaX = m_MeshSize.x / m_MeshSegmentsX;
		float deltaY = m_MeshSize.y / m_MeshSegmentsY;

		for (int y = 0; y <= m_MeshSegmentsY; y++)
		{
			for (int x = 0; x <= m_MeshSegmentsX; x++)
			{
				verts.Add(offset + new Vector3(x * deltaX, 0, y * deltaY));
				normals.Add(Vector3.up);

				if (y < m_MeshSegmentsY && x < m_MeshSegmentsX)
				{
					int startIndex = y * (m_MeshSegmentsX + 1) + x;

					quads.Add(startIndex);
					quads.Add(startIndex + m_MeshSegmentsX + 1);
					quads.Add(startIndex + m_MeshSegmentsX + 2);
					quads.Add(startIndex + 1);
				}
			}
		}

		m_Mesh.Clear();
		m_Mesh.SetVertices(verts);
		m_Mesh.SetNormals(normals);
		m_Mesh.SetIndices(quads.ToArray(), MeshTopology.Quads, 0);
	}

	void UpdateMesh()
	{
		Vector3[] verts = m_Mesh.vertices;
		Vector3[] normals = m_Mesh.normals;

		for (int i = 0; i < verts.Length; i++)
		{
			verts[i].y = Mathf.Sin(-Time.timeSinceLevelLoad + new Vector3(verts[i].x, 0, verts[i].z).magnitude);
			normals[i].x = -Mathf.Cos(-Time.timeSinceLevelLoad + verts[i].x);
			normals[i].y = 1.0f;
			normals[i].z = -Mathf.Cos(-Time.timeSinceLevelLoad + verts[i].z);
			normals[i] = normals[i].normalized;
		}

		m_Mesh.vertices = verts;
		m_Mesh.normals = normals;
	}

	int m_MeshSegmentsX;
	int m_MeshSegmentsY;
	Vector2 m_MeshSize;

	Vector4[] m_VectorField;

	MeshFilter m_MeshFilter;
	Mesh m_Mesh;
}
