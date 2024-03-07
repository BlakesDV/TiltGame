using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LvlGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteController;
    [SerializeField, Range(3f, 100f)] private int lvlLenght = 50;
    [SerializeField, Range(1f, 50f)] private float xMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float yMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] private float curveSmoothness = 0.5f;
    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float bottom = 10f;

    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        spriteController.spline.Clear();

        for(int i = 0; i < lvlLenght; i++) 
        {
            //perlin noise ayuda a hacer las curvas suaves interpolando entre puntos aleatorios
            lastPos = transform.position + new Vector3(i * xMultiplier, Mathf.PerlinNoise(0, i * noiseStep) * yMultiplier);
            spriteController.spline.InsertPointAt(i, lastPos);
            if(i != 0 && i != lvlLenght - 1)
            {
                spriteController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                spriteController.spline.SetLeftTangent(i, Vector3.left * xMultiplier * curveSmoothness);
                spriteController.spline.SetRightTangent(i, Vector3.right * xMultiplier * curveSmoothness);
            }
        }
        spriteController.spline.InsertPointAt(lvlLenght, new Vector3(lastPos.x, transform.position.y - bottom));
        spriteController.spline.InsertPointAt(lvlLenght + 1, new Vector3(transform.position.x, transform.position.y - bottom));
    }
}
