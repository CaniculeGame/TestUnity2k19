using UnityEngine;

public class PerlinNoiseGenerator 
{
    private int v_hauteur;
    private int v_largeur;
    private float v_echelle;

    private int v_offsetX;
    private int v_offsetY;

    private float[,] perlinMap;
    private Vector2 positionPerlinMap;

    public PerlinNoiseGenerator()
    {
        v_hauteur = 256;
        v_largeur = 256;
        v_echelle = 20f;

        v_offsetX = 0;
        v_offsetY = 0;

        positionPerlinMap = new Vector2(0, 0);
    }

    public PerlinNoiseGenerator(int largeur, int hauteur, int offsetX, int offsetY, int echelle, bool calculate =false)
    {
        v_hauteur = hauteur;
        v_largeur = largeur;
        v_echelle = echelle;

        v_offsetX = offsetX;
        v_offsetY = offsetY;

        if (calculate)
            CalculatePerlinNoise();
    }

    public float[,] CalculatePerlinNoise()
    {
        float coordX = 0;
        float coordY = 0;

        perlinMap = new float[v_largeur, v_hauteur];

        for (int x = 0; x < v_largeur; x++)
        {
            for (int y = 0; y < v_hauteur; y++)
            {
                coordX = (float)x / v_largeur * v_echelle;
                coordY = (float)y / v_hauteur * v_echelle;
                perlinMap[x, y] = Mathf.PerlinNoise(coordX, coordY);
            }
        }

        return perlinMap;
    }

    public float[,] CalculatePerlinNoise(int largeur, int hauteur)
    {
        v_largeur = largeur;
        v_hauteur = hauteur;

        return CalculatePerlinNoise();
    }

    public float[,] RegenerateMap()
    {
        return CalculatePerlinNoise();
    }


    public float[,] RegenerateMap(int largeur, int hauteur)
    {
        v_largeur = largeur;
        v_hauteur = hauteur;

        return CalculatePerlinNoise(largeur, hauteur);
    }

    public int Hauteur { get { return v_hauteur; } set { v_hauteur = value; } }
    public int Largeur { get { return v_largeur; } set { v_largeur = value; } }
    public int OffsetX { get { return v_offsetX; } set { v_offsetX = value; } }
    public int OffsetY { get { return v_offsetY; } set { v_offsetY = value; } }
    public float Echelle { get { return v_echelle; } set { v_echelle = value; } }
    public float[,] PerlinMap { get { return perlinMap; } }
    public Vector2 PositionPerlinMap { get { return positionPerlinMap; } set { positionPerlinMap = value; } }
    public float ValeurPosition { get{ return perlinMap[(int)positionPerlinMap.x, (int)positionPerlinMap.y]; } }
}
