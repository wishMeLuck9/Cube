using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Vector3 startPosition = new Vector3(3.0f, 4.0f, 1.0f);
    public Vector3 startScale = Vector3.one * 1.5f;
    public Vector3 rotationAxis = new Vector3(1.0f, 1.0f, 0.5f);
    public float rotationSpeed = 50.0f;
    public Color startColor = new Color(0.2f, 0.8f, 1.0f, 1.0f);
    public bool randomizeColorOnStart = true;
    public bool pulseScale = true;
    public float pulseAmplitude = 0.2f;
    public float pulseSpeed = 2.0f;

    private Material cubeMaterial;
    private Vector3 baseScale;

    void Start()
    {
        if (Renderer == null)
        {
            Renderer = GetComponent<MeshRenderer>();
        }

        transform.position = startPosition;
        baseScale = startScale;
        transform.localScale = baseScale;

        cubeMaterial = Renderer.material;
        cubeMaterial.color = randomizeColorOnStart
            ? new Color(Random.value, Random.value, Random.value, 1.0f)
            : startColor;
    }

    void Update()
    {
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);

        if (pulseScale)
        {
            float scaleOffset = 1.0f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmplitude;
            transform.localScale = baseScale * scaleOffset;
        }
    }
}
