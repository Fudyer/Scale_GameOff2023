using UnityEngine;
using UnityEditor;

public class UnparentToolsEditor : MonoBehaviour
{
	[MenuItem("Tools/Unparent Selected")]
	static void UnparentSelectedObjects()
	{
		// Get all selected GameObjects in the Inspector
		GameObject[] selectedObjects = Selection.gameObjects;

		foreach (GameObject selectedObject in selectedObjects)
		{
			// Check if the selected GameObject has a parent
			if (selectedObject.transform.parent != null)
			{
				// Unparent the selected GameObject
				selectedObject.transform.parent = null;
			}
		}
	}
}
