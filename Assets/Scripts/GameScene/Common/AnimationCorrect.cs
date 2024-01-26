using UnityEngine;

public class AnimationCorrect : MonoBehaviour
{
    private Animator _animation;

    private GameObject _mainModel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);   
    }
}
