using UnityEngine;

public class Top:Gene
{
    public Top()
    {
        genomResources = Resources.Load<GenomeResources>("Top/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Top.Id;
    }

    ~Top()
    {
        Resources.UnloadUnusedAssets();
    }
}
