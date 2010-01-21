using System.Collections.Generic;
using UnityEngine;

internal class Grid
{
    public Grid(Rect gridBounds, int gridSpacing)
    {
        // Use the fields in constructor to avoid triggers in properties
        _gridBounds = gridBounds;
        _gridSpacing = gridSpacing;

        _gridLineListVertical = new GridLineList();
        _gridLineListHorizontal = new GridLineList();

        DoUpdate();
    }

    private void DoUpdate()
    {
        GridLineListVertical = new GridLineList();
        GridLineListHorizontal = new GridLineList();

        GridCountVertical = (int)(GridBounds.width / GridSpacing);
        GridCountHorizontal = (int)(GridBounds.height / GridSpacing);

        DoGridLineList();
    }

    public void DoGUI()
    {
        GridLineListVertical.GridLines.ForEach(delegate(GridLine line)
        {
            line.GridLineRect.DoGUI();
        });

        GridLineListHorizontal.GridLines.ForEach(delegate(GridLine line)
        {
            line.GridLineRect.DoGUI();
        });
    }

    private Rect _gridBounds;
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

    private int _gridSpacing;
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

    private int _gridCountVertical;
    public int GridCountVertical
    {
        get { return _gridCountVertical; } 
        private set { _gridCountVertical = value; }
    }

    private int _gridCountHorizontal;
    public int GridCountHorizontal
    {
        get { return _gridCountHorizontal; } 
        private set { _gridCountHorizontal = value; }
    }

    private GridLineList _gridLineListVertical;
    public GridLineList GridLineListVertical
    {
        get { return _gridLineListVertical; } 
        private set { _gridLineListVertical = value; }
    }

    private GridLineList _gridLineListHorizontal;
    public GridLineList GridLineListHorizontal
    {
        get { return _gridLineListHorizontal; }
        private set { _gridLineListHorizontal = value; }
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

        // TODO: Alternative implementation using something other than Rects!
        gridLine.GridLineRect.DoUpdate();

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
            end.y = start.x;
        }

        gridPointPair.StartVertex = new Vector2(start.x, start.y);
        gridPointPair.EndVertex = new Vector2(end.x, end.y);

        return gridPointPair;
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
            _gridLineRect = new GUILine(GridVertices.StartVertex, GridVertices.EndVertex);
        }

        private void DoUpdate()
        {
            GridLineRect.Start = GridVertices.StartVertex;
            GridLineRect.End = GridVertices.EndVertex;

            GridLineRect.DoUpdate();
        }

        private GridPointPair _gridVertices;
        public GridPointPair GridVertices
        {
            get { return _gridVertices; } 
            set
            {
                _gridVertices = value;
                DoUpdate();
            }
        }

        private GUILine _gridLineRect;
        public GUILine GridLineRect
        {
            get { return _gridLineRect; } 
            set { _gridLineRect = value; }
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

    internal enum Direction
    {
        Vertical,
        Horizontal
    };
}