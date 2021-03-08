using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public int rows, columns;
    public Vector2 cellSize;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        
        // Calculate rows & columns based on number of child objects
        float sqrRt = Mathf.Sqrt(transform.childCount);
        rows = Mathf.CeilToInt(sqrRt);
        columns = Mathf.CeilToInt(sqrRt);

        // Get size of panel
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        // Calculate & set child object sizes
        float cellWidth = parentWidth / (float)columns;
        float cellHeight = parentHeight / (float)rows;

        cellSize.x = cellWidth;
        cellSize.y = cellHeight;

        // Store column & row counts for use
        int columnCount = 0;
        int rowCount = 0;

        // Position each child object in panel
        for (int i=0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount);
            var yPos = (cellSize.y * rowCount);

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 0, yPos, cellSize.y);
        }
    }

    public override void CalculateLayoutInputVertical()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutHorizontal()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutVertical()
    {
        throw new System.NotImplementedException();
    }
}
