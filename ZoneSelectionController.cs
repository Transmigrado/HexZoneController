using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSelectionController : MonoBehaviour {

	public List<Vector2> hexs;
	private Vector3[] vertices;
	private int[] tri;


	void Start () {
		
		MeshFilter mf = GetComponent<MeshFilter>();
		Mesh mesh = new Mesh();
		mf.mesh = mesh;


	
		vertices = new Vector3[hexs.Count * 6];
		tri = new int[hexs.Count * 12];

		for(int i = 0 ; i < hexs.Count;i++){
			addHex (hexs[i],i);
		}

		mesh.vertices = vertices;
		mesh.triangles = tri;

	
	}

	void Update () {
		
	}

	void addHex(Vector2 v2,int index){
		HexMesh hexmesh = new HexMesh ((int) v2.x,(int) v2.y,index);
		for(int i = 0 ; i < 6; i++){
			vertices [index * 6 + i] = hexmesh.vertices [i];
		}

		for(int j = 0 ; j < 12; j++){
			tri [index * 12 + j] = hexmesh.tri [j];
		}
	}

	public class HexMesh {
		public Vector3[] vertices;
		public int[] tri;
		/**/

		public float offsety = 2.0f;
		public float offsetx = 1.64f;
		public int width = 10;
		public int height = 10;

		public HexMesh(int i, int j, int index){

			Vector3 v3 = new Vector3 (i * offsetx ,  -0.5f , j* offsety  + (i%2) * (offsety / 2.0f));
			Debug.Log(v3.x);

			vertices  = new Vector3[6];

			vertices[0] = new Vector3(v3.x - 0.52f, v3.z + 1.0f, 0.0f);
			vertices[1] = new Vector3(v3.x - 0.52f, v3.z - 1.0f, 0.0f);
			vertices[2] = new Vector3(v3.x + 0.52f, v3.z - 1.0f, 0.0f);
			vertices[3] = new Vector3(v3.x + 0.52f, v3.z + 1.0f, 0.0f);
			vertices[4] = new Vector3(v3.x - 1.12f, v3.z + 0.0f, 0.0f);
			vertices[5] = new Vector3(v3.x + 1.12f, v3.z + 0.0f, 0.0f);


			tri  = new int[12];

			tri[0] = 6 * index + 2;
			tri[1] = 6 * index + 1;
			tri[2] = 6 * index + 0;


			tri[3] = 6 * index + 0;
			tri[4] = 6 * index + 3;
			tri[5] = 6 * index + 2;


			tri[6] = 6 * index + 0;
			tri[7] = 6 * index + 1;
			tri[8] = 6 * index + 4;


			tri[9] = 6 * index + 5;
			tri[10] = 6 * index + 2;
			tri[11] = 6 * index + 3;
		}
	}
}
