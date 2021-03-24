using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionController : MonoBehaviour
{
    private Transform targetObstacle;
    private Vector2 targetScale;
    private bool Scaling = false;
    [SerializeField] private float scalingSpeed = 1.0f;
    [SerializeField] private float scalingAmount = 2.5f;

    void EnlargeDimensions()
    {
       targetScale = new Vector2(targetObstacle.localScale.x * scalingAmount, targetObstacle.localScale.y * scalingAmount);
       Scaling = true;
    }

    void ShrinkDimensions()
    {
       targetScale = new Vector2(targetObstacle.localScale.x / scalingAmount, targetObstacle.localScale.y / scalingAmount);
       Scaling = true;
    }

    private void ItemUsed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider.tag == "Box")
            {
                targetObstacle = hit.collider.transform;
                EnlargeDimensions();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
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
    }
        
    void Update()
    {
        ItemUsed();
        if(Scaling)
             UpdateScale();
    }
}
