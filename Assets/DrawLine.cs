using UnityEngine;
using System.Collections;
using Vectrosity;
using System.Collections.Generic;
using System.Linq;

public class DrawLine : MonoBehaviour {
	public VectorObject2D vobj;
	public VectorObject3D vobj3d;
	public Material mat;

	public List<Transform> transf = new List<Transform> ();

	// Use this for initialization
	void Start () {
		VectorManager.useDraw3D = true;

		var pos3d = transf.Select (x => x.position).ToList();
		var pos2d = pos3d.Select(x => new Vector2(x.x, x.y)).ToList();

		//draw 2d
		vobj.vectorLine.Resize (pos2d.Count + 1);
		vobj.vectorLine.points2 = pos2d;
		vobj.vectorLine.points3 = pos3d;
		vobj.vectorLine.Draw ();

		//draw 3d
		var vl = new VectorLine ("a", pos3d, 100f);
		vobj3d.SetVectorLine (vl, vobj.texture, mat);
		vl.points3.ForEach (x => Debug.Log(x));
		vl.Draw3DAuto ();
	}

}
