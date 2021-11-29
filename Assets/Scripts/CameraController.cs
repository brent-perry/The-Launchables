using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    LoadCharacter _loadCharacter;
    CinemachineTargetGroup _cinemachineTargetGroup;
    Transform characterCloneTransform;

    void Awake()
    {
        _loadCharacter = FindObjectOfType<LoadCharacter>();
        _cinemachineTargetGroup = GameObject.FindGameObjectWithTag("TargetGroup").GetComponent<CinemachineTargetGroup>();
    }

    void Start()
    {
        // characterCloneTransform = LoadCharacter.
        // _cinemachineTargetGroup.AddMember(,1,3);
        //try to get the clone prefab's transform to use for the AddMember method
        //cant seem to access the LoadCharacter script
    }
}
