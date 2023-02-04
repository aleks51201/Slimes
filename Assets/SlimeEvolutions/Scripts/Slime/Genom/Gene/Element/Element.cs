using UnityEngine;
using UnityEngine.UIElements;

public class Element:Gene
{
    public Element()
    {
        genomResources = Resources.Load<GenomeResources>("Element/GenomeResources");
    }

    public int GetCellSlimeId(GameObject cellGameObject)
    {
        return GetCellView(cellGameObject).Slime.Genome.Element.Id;
    }

    ~Element()
    {
        Resources.UnloadUnusedAssets();
    }
}

