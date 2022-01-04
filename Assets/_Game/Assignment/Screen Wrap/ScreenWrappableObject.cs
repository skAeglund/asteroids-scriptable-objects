using UnityEngine;
using DefaultNamespace.ScriptableEvents;

public class ScreenWrappableObject : MonoBehaviour
{
    [SerializeField] private ScriptableEventTransform _onBecameInvisible;
    [SerializeField] private int _maxWrapCount; 
    [SerializeField] private GameObject _objectToDestroy;
    private int _count = 0;
    private Transform _root;

    private void Start()
    {
        _root = transform.root;
    }

    private void OnBecameInvisible()
    {
        if (_maxWrapCount > 0) // unlimited wrapping if left at 0 or negative
        {
            _count++;
            if (_count > _maxWrapCount && _objectToDestroy != null)
            {
                Destroy(_objectToDestroy);
                return;
            }
        }
        Debug.Log(_root.name + " became invisible");
        _onBecameInvisible.Raise(_root);
    }
}