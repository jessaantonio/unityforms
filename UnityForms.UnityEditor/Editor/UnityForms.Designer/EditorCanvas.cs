using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

internal class EditorCanvas : EditorWindow
{
    // This will take care of grids, guides (like PS), etc.
    // TODO: Add pivot/origin

    private Rect _canvasRect;
    private Grid _grid;

    private int _minGridSize = 4;
    private int _maxGridSize = 16;

    [MenuItem("UnityTools/Window/Editor Canvas")]
    public static void Initialize()
    {
        EditorCanvas window = (EditorCanvas)EditorWindow.GetWindow(typeof(EditorCanvas));

        window._canvasRect = new Rect(0, 0, window.maxSize.x, window.maxSize.y);
        window._grid = new Grid(window._canvasRect, 8);

        window.Show();
    }

    public void OnGUI()
    {
       _grid.DoGUI();
    }
}