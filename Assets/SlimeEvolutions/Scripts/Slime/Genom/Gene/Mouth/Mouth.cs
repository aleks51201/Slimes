using UnityEngine;

public class Mouth : Gene
{
    public Mouth()
    {
        genomResources = Resources.Load<GenomeResources>("Mouth/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Mouth.Id;
    }

    ~Mouth()
    {
        Resources.UnloadUnusedAssets();
    }
}
