using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Arawn.Editor
{
	public class NameBasedMaterialTransfer : EditorWindow
	{
		private GameObject sourceModel;
		private GameObject targetModel;

		[MenuItem("Window/ARAWN/Name-Based Material Transfer")]
		static void Init()
		{
			NameBasedMaterialTransfer window = (NameBasedMaterialTransfer)EditorWindow.GetWindow(typeof(NameBasedMaterialTransfer));
			window.Show();
		}

		void OnGUI()
		{
			GUILayout.Label("Transfer Materials from Source to Target", EditorStyles.boldLabel);

			sourceModel = (GameObject)EditorGUILayout.ObjectField("Source Model", sourceModel, typeof(GameObject), true);
			targetModel = (GameObject)EditorGUILayout.ObjectField("Target Model", targetModel, typeof(GameObject), true);

			if (GUILayout.Button("Transfer Materials"))
			{
				if (sourceModel != null && targetModel != null)
				{
					Dictionary<string, SkinnedMeshRenderer> sourceRenderers = new Dictionary<string, SkinnedMeshRenderer>();
					GetAllRenderers(sourceModel.transform, sourceRenderers);
					TransferMaterials(targetModel.transform, sourceRenderers);
				}
				else
				{
					Debug.LogError("Source or target model is not set. Please set both models before transferring.");
				}
			}
		}

		void GetAllRenderers(Transform source, Dictionary<string, SkinnedMeshRenderer> renderers)
		{
			SkinnedMeshRenderer sourceRenderer = source.GetComponent<SkinnedMeshRenderer>();
			if (sourceRenderer != null)
			{
				renderers[source.name] = sourceRenderer;
			}

			for (int i = 0; i < source.childCount; i++)
			{
				GetAllRenderers(source.GetChild(i), renderers);
			}
		}

		void TransferMaterials(Transform target, Dictionary<string, SkinnedMeshRenderer> sourceRenderers)
		{
			SkinnedMeshRenderer targetRenderer = target.GetComponent<SkinnedMeshRenderer>();
			if (targetRenderer != null)
			{
				if (sourceRenderers.ContainsKey(target.name))
				{
					targetRenderer.sharedMaterials = sourceRenderers[target.name].sharedMaterials;
				}
				else
				{
					Debug.LogError("No matching renderer found in source model for " + target.name);
				}
			}

			for (int i = 0; i < target.childCount; i++)
			{
				TransferMaterials(target.GetChild(i), sourceRenderers);
			}
		}
	}
}

