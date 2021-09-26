using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class ObjectPool
{
    private static ObjectPool _objectPool;
    private GameObject _pool;

    private GameObject _camera;
    private int _countWarriorsInPool = 20;
    private Queue<GameObject> _warriors;
    //private GameObject _backGround;

    private ObjectFactory _objectFactory;

    public static ObjectPool Instance
    {
        get
        {
            if (_objectPool == null)
            {
                _objectPool = new ObjectPool();
            }
            return _objectPool;
        }
    }

    public ObjectPool()
    {
        _objectFactory = new ObjectFactory();
        _pool = new GameObject("[Pool]");
        _camera = _objectFactory.Camera;
        _warriors = new Queue<GameObject>();

        //_backGround = _objectFactory.BackGround;


        for (int i = 0; i < _countWarriorsInPool; i++)
        {
            GameObject go = _objectFactory.Warrior;
            go.transform.SetParent(_pool.transform);
            _warriors.Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject GetObject(ObjectType objectType)
    {
        GameObject go;

        switch (objectType)
        {
            //case ObjectType.BackGround:
            //    go = _backGround;
            //    go.transform.position = Vector3.zero;
            //    break;
            case ObjectType.Camera:
                go = _camera;
                break;
            case ObjectType.Warrior:
                go = _warriors.Dequeue();
                break;

            default:
                go = null;
                break;
        }

        //go.SetActive(true);

        return go;
    }

    public void ReturnInPool(ObjectType objectType, GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(_pool.transform);

        switch (objectType)
        {
            case ObjectType.Camera:
                break;
            case ObjectType.Warrior:
                _warriors.Enqueue(gameObject);
                break;

        }
    }

    public Dictionary<string, Sprite> GetSprites()
    {
        return _objectFactory.Sprites;
    }
}
