using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public static CreateCubes instance = null;


    public List<GameObject> _objects;
    [SerializeField] private int _countCubes;

    [SerializeField] private int _maxHeight = 10;
    [SerializeField] private int _minHeight = 2;
    [SerializeField] private GameObject _createButton;
    int i = 0;
    private void Awake(){
        SetRandomScale();

        if(instance == null){
            instance = this;
        }else if(instance == this){
            Destroy(gameObject);
        }        
    }
    public void Clear(){
        for (int i = 0; i < _countCubes; i++)
        {
            _objects.Clear();
            Destroy(transform.GetChild(i).gameObject);
        }
        _createButton.SetActive(true);
    }
    public void SetRandomScale(){
        _createButton.SetActive(false);
        _objects.Clear();
        for (int i = 0; i < _countCubes; i++)
        {
            float scale = Random.Range(_minHeight,_maxHeight);
            GameObject _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.transform.localScale = new Vector3(0.8f,scale,1);
            _cube.transform.position = new Vector3(i, scale/2.0f,0);

            _cube.transform.parent = this.transform;
            _objects.Add(_cube);
        }

    }
}
