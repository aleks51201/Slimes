using UnityEngine;

public class SlimeForm : Gene
{
    public SlimeForm()
    {
        genomResources = Resources.Load<GenomeResources>("Form/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Form.Id;
    }

    ~SlimeForm()
    {
        Resources.UnloadUnusedAssets();
    }
}

