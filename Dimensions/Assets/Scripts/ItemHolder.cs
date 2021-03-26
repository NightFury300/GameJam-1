using UnityEngine;
using TMPro;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private int enlargeBallCount = 0;
    [SerializeField]
    private int shrinkBallCount = 0;
    [SerializeField] private TextMeshProUGUI enlargeBallCountText;
    [SerializeField] private TextMeshProUGUI shrinkBallCountText;

    private void Update()
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
        FindObjectOfType<AudioManager>().Play("acquire");
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
