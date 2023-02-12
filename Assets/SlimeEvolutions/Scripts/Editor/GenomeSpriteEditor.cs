using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenomeSprite))]
public class GenomeSpriteEditor : Editor
{
    private GenomeSprite genomeSprite;
    public override void OnInspectorGUI()
    {
        genomeSprite = target as GenomeSprite;
        ShowImgBlock();
        ShowBalanceBlock();
        asdj();
    }

    private void ShowVerticalImgInfo()
    {
        GUILayout.BeginVertical();
        genomeSprite.genes = (Genome.Genes)EditorGUILayout.EnumPopup("Type of part", genomeSprite.genes);
        genomeSprite.id = EditorGUILayout.IntField(label: "Id", genomeSprite.id);
        genomeSprite.name = EditorGUILayout.TextField("Name of part", genomeSprite.name);
        GUILayout.EndVertical();
    }
    private void ShowImgBlock()
    {
        GUILayout.Label("IMAGE");
        GUILayout.BeginHorizontal();
        genomeSprite.spr = EditorGUILayout.ObjectField(genomeSprite.spr, typeof(Sprite), false, GUILayout.Width(250), GUILayout.Height(250)) as Sprite;
        ShowVerticalImgInfo();
        GUILayout.EndHorizontal();
    }

    private void ShowBalanceBlock()
    {
        GUILayout.Label("BAlANCE");
        genomeSprite.lvlForDrop = EditorGUILayout.IntField("lvl for drop", genomeSprite.lvlForDrop);
        genomeSprite.weight = EditorGUILayout.IntField("Weight of part", genomeSprite.weight);
    }

    private void asdj()
    {
        if (GUI.changed)
        {
            // записываем изменения над testScriptable в Undo
            Undo.RecordObject(genomeSprite, "Test Scriptable Editor Modify");
            // помечаем тот самый testScriptable как "грязный" и сохраняем.
            EditorUtility.SetDirty(genomeSprite);
        }
    }
}
