using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

internal class Grid
{
    private Material _lineMaterial;
    private Color _lineColor;
    private Color _lineColor2;
    private Rect _gridBounds;
    private int _gridSpacing;
    private int _gridSpacing2;
    private int _gridCountVertical;
    private int _gridCountHorizontal;
    private GridLineList _gridLineListVertical;
    private GridLineList _gridLineListHorizontal;

    public Grid(GridParams args)
    {
        DoLineMaterial();

        _lineColor = args.GridColor;
        _lineColor2 = args.GridColorSmall;

        _gridBounds = new Rect(0, 0, 1, 1);
        
        _gridSpacing = args.GridSize / args.GridSmallSizeMultiplier;
        _gridSpacing2 = args.GridSize;

        _gridLineListVertical = new GridLineList();
        _gridLineListHorizontal = new GridLineList();

        DoUpdate();
    }

    private void DoUpdate()
    {
        GridLineListVertical = new GridLineList();
        GridLineListHorizontal = new GridLineList();

        GridCountVertical = (int)(GridBounds.width / GridSpacing + 1);
        GridCountHorizontal = (int)(GridBounds.height / GridSpacing + 1);

        DoGridLineList();
    }

    public void DoGUI()
    {  
        _lineMaterial.SetPass(0);

        // must be repaint event or else you see the GL lines everywhere!
        if (Event.current.type == EventType.repaint)
        {
            GL.Begin(GL.LINES);

            GridLineListVertical.GridLines.ForEach(delegate(GridLine line)
            {
                Vector2 l = line.GridVertices.StartVertex;

                if (l.x % GridSpacing2 != 0f || l.y % GridSpacing2 != 0f)
                {
                    // Then it's a major gridline
                    GL.Color(LineColor);
                }
                else
                {
                    GL.Color(LineColor2);
                }

                GL.Vertex(line.GridVertices.StartVertex);
                GL.Vertex(line.GridVertices.EndVertex);
            });

            GridLineListHorizontal.GridLines.ForEach(delegate(GridLine line)
            {
                Vector2 l = line.GridVertices.StartVertex;

                if (l.x % GridSpacing2 != 0f || l.y % GridSpacing2 != 0f)
                {
                    GL.Color(LineColor);
                }
                else
                {
                    // Then it's a major gridline
                    GL.Color(LineColor2);
                }

                GL.Vertex(line.GridVertices.StartVertex);
                GL.Vertex(line.GridVertices.EndVertex);
            });

            GL.End();
        }
    }

    private void DoGridLineList()
    {
        if (GridLineListVertical != null && GridLineListHorizontal != null)
        {
            for (int i = 0; i < GridCountVertical; i++)
            {
                GridLineListVertical.GridLines.Add(DoGridLine(i, Direction.Vertical));
            }

            for (int j = 0; j < GridCountHorizontal; j++)
            {
                GridLineListHorizontal.GridLines.Add(DoGridLine(j, Direction.Horizontal));
            }
        }
    }

    private GridLine DoGridLine(int index, Direction direction)
    {
        GridLine gridLine = new GridLine();

        gridLine.GridVertices = DoGridPointPair(index, direction);

        return gridLine;
    }

    private GridPointPair DoGridPointPair(int index, Direction direction)
    {
        GridPointPair gridPointPair = new GridPointPair();

        Vector2 start = new Vector2();
        Vector2 end = new Vector2();

        if (direction == Direction.Vertical)
        {
            // then x has the offset
            start.x = index * GridSpacing;
            start.y = 0;

            end.x = start.x;
            end.y = GridBounds.height;
        }
        else
        {
            // y has the offset
            start.x = 0;
            start.y = index * GridSpacing;

            end.x = GridBounds.width;
            end.y = start.y;
        }

        gridPointPair.StartVertex = new Vector2(start.x, start.y);
        gridPointPair.EndVertex = new Vector2(end.x, end.y);

        return gridPointPair;
    }

    private void DoLineMaterial()
    {
        _lineMaterial = new Material("Shader \"Lines/Colored Blended\" {" +
            "SubShader { Pass { " +
            "    Blend SrcAlpha OneMinusSrcAlpha " +
            "    ZWrite Off Cull Off Fog { Mode Off } " +
            "    BindChannels {" +
            "      Bind \"vertex\", vertex Bind \"color\", color }" +
            "} } }");
        _lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        _lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
    }

    public Material LineMaterial
    {
        get { return _lineMaterial; }
        set { _lineMaterial = value; }
    }
    public Color LineColor
    {
        get { return _lineColor; }
        set { _lineColor = value; }
    }
    public Rect GridBounds
    {
        get { return _gridBounds; }
        set
        {
            if (_gridBounds != value)
            {
                _gridBounds = value;
                DoUpdate();
            }
        }
    }
    public int GridSpacing
    {
        get { return _gridSpacing; }
        set
        {
            if (_gridSpacing != value)
            {
                _gridSpacing = value;
                DoUpdate();
            }
        }
    }
    public int GridCountVertical
    {
        get { return _gridCountVertical; }
        private set { _gridCountVertical = value; }
    }
    public int GridCountHorizontal
    {
        get { return _gridCountHorizontal; }
        private set { _gridCountHorizontal = value; }
    }
    public GridLineList GridLineListVertical
    {
        get { return _gridLineListVertical; }
        private set { _gridLineListVertical = value; }
    }
    public GridLineList GridLineListHorizontal
    {
        get { return _gridLineListHorizontal; }
        private set { _gridLineListHorizontal = value; }
    }
    public Color LineColor2
    {
        get { return _lineColor2; }
        set { _lineColor2 = value; }
    }
    public int GridSpacing2
    {
        get { return _gridSpacing2; }
        set { _gridSpacing2 = value; }
    }

    internal class GridLineList
    {
        public GridLineList()
        {
            _gridLines = new List<GridLine>();
        }

        private List<GridLine> _gridLines;
        public List<GridLine> GridLines
        {
            get { return _gridLines; } 
            set { _gridLines = value; }
        }
    }

    internal class GridLine
    {
        public GridLine()
        {
            _gridVertices = new GridPointPair();
        }

        private GridPointPair _gridVertices;
        public GridPointPair GridVertices
        {
            get { return _gridVertices; } 
            set { _gridVertices = value; }
        }
    }

    internal class GridPointPair
    {
        public GridPointPair()
        {
            _startVertex = new Vector2();
            _endVertex = new Vector2();
        }

        private Vector2 _startVertex;
        public Vector2 StartVertex
        {
            get { return _startVertex; }
            set { _startVertex = value; }
        }

        private Vector2 _endVertex;
        public Vector2 EndVertex
        {
            get { return _endVertex; }
            set { _endVertex = value; }
        }

        public override string ToString()
        {
            return string.Format("(Start: ({0:F1},{1:F1})  End: ({2:F1},{3:F1})", StartVertex.x, StartVertex.y, EndVertex.x, EndVertex.y);
        }
    }

    public class GridParams
    {
        public GridParams(int gridSize, Color gridColor) : this(gridSize, gridColor, 0, new Color())
        {
        }

        public GridParams(int gridSize, Color gridColor, int gridSmallSizeMultiplier, Color gridColorSmall) : this(gridSize, gridColor, gridSmallSizeMultiplier, gridColorSmall, false)
        {
        }

        public GridParams(int gridSize, Color gridColor, int gridSmallSizeMultiplier, Color gridColorSmall, bool snapToGrid)
        {
            _gridSize = gridSize;
            _gridColor = gridColor;

            if (gridSmallSizeMultiplier != 0)
            {
                _gridSmallSizeMultiplier = gridSmallSizeMultiplier;
                _gridColorSmall = gridColorSmall;
            }
            else
            {
                _gridSmallSizeMultiplier = 4;
                Color c = gridColor;
                _gridColorSmall = new Color(c.r * 2, c.b * 2, c.g * 2, c.a * 2);
            }

            _snapToGrid = snapToGrid;
        }

        private int _gridSize;
        public int GridSize
        {
            get { return _gridSize; }
            set { _gridSize = value; }
        }

        private Color _gridColor;
        public Color GridColor
        {
            get { return _gridColor; }
            set { _gridColor = value; }
        }

        private int _gridSmallSizeMultiplier;
        public int GridSmallSizeMultiplier
        {
            get { return _gridSmallSizeMultiplier; }
            set { _gridSmallSizeMultiplier = value; }
        }

        private Color _gridColorSmall;
        public Color GridColorSmall
        {
            get { return _gridColorSmall; }
            set { _gridColorSmall = value; }
        }

        private bool _snapToGrid;
        public bool SnapToGrid
        {
            get { return _snapToGrid; }
            set { _snapToGrid = value; }
        }
    }

    internal enum Direction
    {
        Vertical,
        Horizontal
    };
}