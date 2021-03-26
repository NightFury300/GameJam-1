using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionController : MonoBehaviour
{
    [SerializeField] private ItemHolder inventory;

    private Transform targetObstacle;
    private Vector2 targetScale;
    private bool isScaling = false;
    [SerializeField] private float scalingSpeed = 0.5f;
    [SerializeField] private float scalingAmount = 2.5f;


    /*private void Start()
    {
        inventory = GetComponent<ItemHolder>();
    }*/
    void EnlargeDimensions()
    {
        targetScale = new Vector2(targetObstacle.localScale.x * scalingAmount, targetObstacle.localScale.y * scalingAmount);
        inventory.ReduceEnlargeCount();
        FindObjectOfType<AudioManager>().Play("enlarge");
        isScaling = true;
    }

    void ShrinkDimensions()
    {
        targetScale = new Vector2(targetObstacle.localScale.x / scalingAmount, targetObstacle.localScale.y / scalingAmount);
        inventory.ReduceShrinkCount();
        FindObjectOfType<AudioManager>().Play("shrink");
        isScaling = true;
    }

    private void ItemUsed()
    {            
        if (Input.GetMouseButtonDown(0) && inventory.GetEnlargeCount() > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (!hit)
                return;
            if (hit.collider.tag == "Box")
            {
                targetObstacle = hit.collider.transform;
                EnlargeDimensions();
            }
        }
        if (Input.GetMouseButtonDown(1) && inventory.GetShrinkCount() > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (!hit)
                return;
            if (hit.collider.tag == "Box")
            {
                targetObstacle = hit.collider.transform;
                ShrinkDimensions();
            }
        }
    }

    private void UpdateScale()
    {      
        targetObstacle.localScale = Vector2.MoveTowards(targetObstacle.localScale, targetScale, scalingSpeed * Time.deltaTime);
        if(targetObstacle.localScale.x == targetScale.x && targetObstacle.localScale.y == targetScale.y)
        {
            isScaling = false;
        }
    }
        
    void Update()
    {
        ItemUsed();
        if (isScaling)
        {
            UpdateScale();
        }
    }
}
