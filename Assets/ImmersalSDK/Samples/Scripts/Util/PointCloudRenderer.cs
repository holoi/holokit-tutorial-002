﻿/*===============================================================================
Copyright (C) 2019 Immersal Ltd. All Rights Reserved.

This file is part of the Immersal AR Cloud SDK Early Access project.

The Immersal AR Cloud SDK cannot be copied, distributed, or made available to
third-parties for commercial purposes without written permission of Immersal Ltd.

Contact sdk@immersal.com for licensing requests.
===============================================================================*/

using UnityEngine;

namespace Immersal.Samples.Util
{
	public class PointCloudRenderer : MonoBehaviour
	{
		private Material mat;
		private Mesh mesh;
		public GameObject go;
        public int handle;
		public static bool visible = true;

		// Use this for initialization
		void Awake()
		{
			mat = new Material(Shader.Find("Immersal/pointcloud3d"));
			go = new GameObject("meshcontainer");
			mesh = new Mesh();
			go.hideFlags = HideFlags.HideAndDontSave;
			go.transform.SetParent(gameObject.transform);
			MeshRenderer mr = go.AddComponent<MeshRenderer>();
			go.AddComponent<MeshFilter>().mesh = mesh;
			mr.material = mat;
			go.SetActive(false);
		}

		void Update()
		{
			go.SetActive(visible);
		}

		public void CreateCloud(Vector3[] points, int totalPoints)
		{
			const int max_vertices = 65536;
			int numPoints = totalPoints >= max_vertices ? max_vertices : totalPoints;
            Color32 fix_col  = Random.ColorHSV(0f, 1f, 0.8f, 0.8f, 0.85f, 0.85f);
            int[] indices = new int[numPoints];
			Vector3[] pts = new Vector3[numPoints];
			Color32[] col = new Color32[numPoints];
			for (int i = 0; i < numPoints; ++i)
			{
				indices[i] = i;
				pts[i] = points[i];
				col[i] = fix_col;
			}

			mesh.Clear();
			mesh.vertices = pts;
			mesh.colors32 = col;
			mesh.SetIndices(indices, MeshTopology.Points, 0);
			mesh.bounds = new Bounds(transform.position, new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
		}

		public void ClearCloud()
		{
			mesh.Clear();
            Destroy(this);
		}
	}
}