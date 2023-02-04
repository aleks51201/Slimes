using UnityEngine;
using UnityEngine.UIElements;

public class Bottom: Gene
{
    public Bottom()
    {
        genomResources = Resources.Load<GenomeResources>("Eyes/GenomeResources");
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

