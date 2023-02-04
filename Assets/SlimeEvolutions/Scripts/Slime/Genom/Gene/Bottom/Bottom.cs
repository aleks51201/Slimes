using UnityEngine;

public class Bottom: Gene
{
    public Bottom()
    {
        genomResources = Resources.Load<GenomeResources>("Bottom/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Bottom.Id;
    }

    ~Bottom()
    {
        Resources.UnloadUnusedAssets();
    }
}

