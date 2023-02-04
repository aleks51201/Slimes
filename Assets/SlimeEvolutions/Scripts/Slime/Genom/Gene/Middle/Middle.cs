using UnityEngine;

public class Middle:Gene
{
    public Middle()
    {
        genomResources = Resources.Load<GenomeResources>("Middle/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Middle.Id;
    }

    ~Middle()
    {
        Resources.UnloadUnusedAssets();
    }
}
