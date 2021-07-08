using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSceneCube : MonoBehaviour
{
    [Header("Rotation")]
    public Vector3 rotation = Vector3.up * 360;
    public float rotationDuration = 10f;

    [Header("Scaling")]
    public Vector3 maxScale = Vector3.one * 2;
    public float scalingDuration = 1f;

    [Header("Material Offset")]
    public Vector3 offset = Vector3.right;
    public float offsetDuration = 1f;

    private Renderer rend;
    private Material mat;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        mat = rend.material;
        transform.DOLocalRotate(rotation, rotationDuration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        transform.DOScale(maxScale, scalingDuration).SetEase(Ease.InOutExpo).SetLoops(-1, LoopType.Yoyo);
        mat.DOOffset(offset, offsetDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
