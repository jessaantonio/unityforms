using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

internal class EditorCanvas : EditorWindow
{
    // This will take care of grids, guides (like PS), etc.
    // TODO: Add pivot/origin

    private Rect _canvasRect;
    private Grid _grid;
    
    //private Vector2 _minGridCount;
    //private int _minGridSize = 4;
    //private Vector2 _maxGridCount;
    //private int _maxGridSize = 16;

    //private List<List<Vector2[]>> _vertList = new List<List<Vector2[]>>();

    //private static Color _gridColor;
    //private static Material _gridMaterial;

    //private bool _invalid = false;

    [MenuItem("UnityTools/Window/Editor Canvas")]
    public static void Initialize()
    {
        //if (_gridMaterial == null)
        //{
        //    _gridMaterial = EditorGUIUtility.LoadRequired("SceneView/Grid.mat") as Material;
        //}

        EditorCanvas window = (EditorCanvas)EditorWindow.GetWindow(typeof(EditorCanvas));

        window._canvasRect = new Rect(0, 0, 200, 200);
        window._grid = new Grid(window._canvasRect, 8);

        window.Show();
    }

    //public EditorCanvas(Rect canvasRect)
    //{
    //    _canvasRect = canvasRect;
    //    _grid = new Grid(_canvasRect, 8);
    //}

    public void OnGUI()
    {
       _grid.DoGUI();
    }

    public void DoDrawGrid()
    {
    } 
}