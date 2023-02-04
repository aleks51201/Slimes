using UnityEngine;

public class Peculiarity:Gene
{
    public Peculiarity()
    {
        genomResources = Resources.Load<GenomeResources>("Peculiarity/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Peculiarity.Id;
    }

    ~Peculiarity()
    {
        Resources.UnloadUnusedAssets();
    }
}

