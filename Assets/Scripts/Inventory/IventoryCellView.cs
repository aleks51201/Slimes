using UnityEngine;

public class IventoryCellView : MonoBehaviour
{
    private Sprite sprite;
    private int lvl;
    private bool isExplored;
    private int id;

    public Sprite SpriteCell => sprite;
    public int Lvl => lvl;
    public bool IsExplored => isExplored;
    public int Id => id;
}
