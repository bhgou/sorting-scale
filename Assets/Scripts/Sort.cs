using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
  
    public void SelectionSorting(List<GameObject> unsorted)
    {
        int min;
        GameObject temp;
        Vector3 position;
        for (int i = 0; i <  unsorted.Count; i++)
        {
            min = i;

            for (int j = i+1; j < unsorted.Count;j++)
            {
                if(unsorted[j].transform.localScale.y < unsorted[min].transform.localScale.y){
                    min = j;
                }    
            }
            if(min != i){
                temp = unsorted[i];
                unsorted[i] = unsorted[min];
                unsorted[min] = temp;

                position = unsorted[i].transform.localPosition;
                unsorted[i].transform.localPosition = new Vector3(unsorted[min].transform.localPosition.x,position.y,position.z);
                unsorted[min].transform.localPosition = new Vector3(position.x,unsorted[min].transform.localPosition.y,unsorted[min].transform.localPosition.z);
            }
        }
    }
    public void Sorting(){
        SelectionSorting(CreateCubes.instance._objects);
    }
    
}
