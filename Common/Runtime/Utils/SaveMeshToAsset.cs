using System.IO;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

namespace AFStudio.Common.Utils
{
    public class SaveMeshToAsset : MonoBehaviour
    {
        public MeshFilter MeshToSave;
        [FolderPath(RequireExistingPath = true)]
        public string AssetPath = "Assets/Assets Core/Meshes";
        
        [Button]
        public void SaveMesh()
        {
            if (!MeshToSave || !MeshToSave.sharedMesh)
            {
                Debug.LogError("No mesh assigned to save.");
                return;
            }

            // Ensure the directories exist
            if (!Directory.Exists(AssetPath))
            {
                Directory.CreateDirectory(AssetPath);
            }

            // Save the mesh as an asset
            string meshAssetPath = $"{AssetPath}/{MeshToSave.name}.asset";
            AssetDatabase.CreateAsset(MeshToSave.sharedMesh, meshAssetPath);
            AssetDatabase.SaveAssets();

            Debug.Log($"Mesh saved successfully at {meshAssetPath}");
        }
    }
}

#endif