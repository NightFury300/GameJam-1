using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    private int enlargeBallCount = 0;
    private int shrinkBallCount = 0;
    [SerializeField] private Text enlargeBallCountText;
    [SerializeField] private Text shrinkBallCountText;

    void Update()
    {
        UpdateInventory();
    }

    public void AddItemToInventory(int type)
    {
        switch (type)
        {
            case 0:
                enlargeBallCount++;
                break;
            case 1:
                shrinkBallCount++;
                break;        
        }
    }

    public int GetEnlargeCount()
    {
        return enlargeBallCount;
    }

    public int GetShrinkCount()
    {
        return shrinkBallCount;
    }

    public void ReduceEnlargeCount()
    {
        enlargeBallCount--;
    }

    public void ReduceShrinkCount()
    {
        shrinkBallCount--;
    }

    private void UpdateInventory()
    {
        enlargeBallCountText.text = enlargeBallCount.ToString();
        shrinkBallCountText.text = shrinkBallCount.ToString();
    }
}
