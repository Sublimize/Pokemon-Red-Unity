//Color code of MrSquishy's map layout of their Pokemon Red recreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MinecraftMapColorCode : MonoBehaviour
{
[System.Serializable]
public struct NamedImage
{
	public Color color;
	public Texture2D image;
}
	public List<NamedImage> tilecolor = new List<NamedImage>();
}
//[CustomEditor(typeof(MinecraftMapColorCode))]
//public class MapColorEditor : Editor
//{

//public override void OnInspectorGUI()
//{
//	DrawDefaultInspector();
//	MinecraftMapColorCode mccolor = (MinecraftMapColorCode)target;
//	if (GUILayout.Button("Add New Entry"))
//	{
//			mccolor.tilecolor.Add(new MinecraftMapColorCode.NamedImage());
	
//	}	
//	}


//}
