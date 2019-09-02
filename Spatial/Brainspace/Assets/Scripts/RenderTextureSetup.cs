using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//using UnityEditor;
using UnityEngine;

public class RenderTextureSetup : MonoBehaviour {

    public Shader textureShader;
    public List<GameObject> rooms;

}

/*[CustomEditor(typeof(RenderTextureSetup))]
public class RenderTextureSetupEditor : Editor {
    
    private const string MAT_PATH = "Assets/Design/Materials/RenderMaterials/",
        TEX_PATH = "Assets/Design/Materials/RenderMaterials/RenderTextures/";
    
    private RenderTextureSetup setup;
    
    public override void OnInspectorGUI() {

        if (!setup)
            setup = (RenderTextureSetup) target;
        
        base.OnInspectorGUI();
        
        if (GUILayout.Button("Generate Texture")) {
            Generate();
        }
        
    }

    private void Generate() {
        
        for (int i = 0; i < setup.rooms.Count; i++){

            foreach (Transform child in setup.rooms[i].transform) {

                if (child.name.Contains("Window")) {
                    
                    
                    int num = int.Parse(setup.rooms[i].name.Replace("Room ", "").Replace("(", "").Replace(")", ""));

                    //generting tex
                    string path = TEX_PATH + child.name + num + ".renderTexture";
                    RenderTexture tex = new RenderTexture(500,500,1);
                    AssetDatabase.CreateAsset(tex, path);

                    //generating mat
                    Material mat = new Material(setup.textureShader);
                    mat.mainTexture = tex;
                    path = MAT_PATH + child.name + num + ".mat";
                    AssetDatabase.CreateAsset(mat, path);
                    
                    //assign camera
                    child.GetComponent<Camera>().targetTexture = tex;

                }
                
            }
            
            

        }
    }

    private void GenMats() {
        
    }

    private void GenTex() {
        
    }

}*/

