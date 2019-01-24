using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameScript), true)]
public class GameScriptEditor: Editor
{
	public override void OnInspectorGUI()
	{
		GameScript view = (GameScript)target;

		if( DrawDefaultInspector() )
		{
		}
		
		if( GUILayout.Button("Update") )
		{
			view.Rebuild();
		}
	}
}
