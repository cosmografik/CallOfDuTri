using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Spoke{
	public Quaternion start;
	public Quaternion end;
	public Vector3 Point(float t){
		return Quaternion.Slerp(start, end, t) * Vector3.up;
	}
	public Spoke(float angle){
		start = Random.rotation;
		end = Quaternion.AngleAxis(Random.Range(angle,-angle), Random.onUnitSphere);
	}
}


public class CrisisImpact : MonoBehaviour {

	MeshFilter filter;
	public int spokeCount;
	public AnimationCurve curve;
	public float animationTime;
	public float size;

	Spoke[] spokes;
	float t;
	public bool doubleSided;
	int[] faces;
	Vector2[] uvs;

	// Use this for initialization
	void Start () {
		filter = GetComponent<MeshFilter>();
		InitSpokes();
		Mesh mesh = new Mesh();
		mesh.vertices = GenerateVerts();
		faces = GenerateFaces();
		mesh.triangles = faces;
		uvs = GenerateUVs();
		mesh.uv = uvs;
		filter.mesh = mesh;
	}

	void Update(){
		t += Time.deltaTime/animationTime;
		Mesh mesh = new Mesh();
		mesh.vertices = GenerateVerts();
		mesh.triangles = faces;
		mesh.uv = uvs;
		filter.mesh = mesh;
	}

	void InitSpokes(){
		spokes = new Spoke[spokeCount];
		for (int i = 0; i < spokeCount; i++){
			spokes[i] = new Spoke(60);
		}
	}
	
	// Update is called once per frame
	Vector3[] GenerateVerts () {
		Vector3[] verts = new Vector3[spokes.Length+1];
		verts[0] = Vector3.zero;
		for (int i = 1; i <= spokes.Length; i++){
			Vector3 pt = spokes[i - 1].Point(t) * curve.Evaluate(t) * size;
			verts[i] = pt;
		}
		return verts;
	}
	int[] GenerateFaces (){
		int[] faces = new int[(spokes.Length + 1) * (doubleSided ? 6 : 3)];
		for (int i = 0; i < spokes.Length; i++){
			faces[i * 3] = 0;
			faces[i * 3+1] = i+1;
			faces[i * 3+2] = (i+1)%spokes.Length+1;
			if (doubleSided){
				int i2 = i + spokes.Length;
				faces[i2 * 3] = 0;
				faces[i2 * 3+2] = i+1;
				faces[i2 * 3+1] = (i+1)%spokes.Length+1;
			}
		}
		return faces;
	}

	Vector2[] GenerateUVs (){
		Vector2[] verts = new Vector2[spokes.Length+1];
		verts[0] = Vector2.zero;
		for (int i = 1; i <= spokes.Length; i++){
			Vector2 pt = new Vector2(i%2,1);
			verts[i] = pt;
		}
		return verts;
	}

}
