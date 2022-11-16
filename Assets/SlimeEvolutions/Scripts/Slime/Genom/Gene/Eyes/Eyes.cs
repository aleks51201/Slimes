using UnityEngine;

public class Eyes : Gene
{
    public Eyes()
    {
        genomResources = Resources.Load<GenomeResources>("Eyes/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Eyes.Id;
    }

    ~Eyes()
    {
        Resources.UnloadUnusedAssets();
    }
}
