using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenomeSprite))]
public class GenomeSpriteEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var genomeSprite = target as GenomeSprite;
        GUILayout.Label("IMAGE");
        GUILayout.BeginHorizontal();
        genomeSprite.spr = EditorGUILayout.ObjectField(genomeSprite.spr, typeof(Sprite), false, GUILayout.Width(250), GUILayout.Height(250)) as Sprite;
        GUILayout.BeginVertical();
        genomeSprite.genes =(Genome.Genes) EditorGUILayout.EnumPopup("Type of part", genomeSprite.genes);
        genomeSprite.id = EditorGUILayout.IntField(label: "Id", genomeSprite.id);
        genomeSprite.name = EditorGUILayout.TextField("Name of part", genomeSprite.name);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}
