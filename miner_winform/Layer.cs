using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miner_winform
{
    public class Layer
    {
        private const int _cellPixelSize = 25;
        private const int _fontSize = 13;
        private const int _horizontalStringMargin = 5;
        private const int _verticalStringMargin = 3;


        public int ZCoordinate { get; set; }
        public PictureBox PictureBox { get; set; }
        
        public Layer(PictureBox pictureBox, int zCoordinate)
        {
            ZCoordinate = zCoordinate;
            PictureBox = pictureBox;
        }

        public void Paint(PaintEventArgs e,
            int _sizeY, 
            int _sizeX,
            int k, 
            Cell[,,] _field)
        {
            for (int i = 0; i < _sizeY; i++)
                for (int j = 0; j < _sizeX; j++)
                    if (_field[i, j, k] != null)
                    {

                        switch (_field[i, j, k].TypeCell)
                        {
                            case CellType.Opened:
                                if (_field[i, j, k].HasMine)
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), j * _cellPixelSize, i * _cellPixelSize, _cellPixelSize, _cellPixelSize);
                                else
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), j * _cellPixelSize, i * _cellPixelSize, _cellPixelSize, _cellPixelSize);
                                if (_field[i, j, k].NeighboursCount != 0)
                                    e.Graphics.DrawString(_field[i, j, k].NeighboursCount.ToString(),
                                        new Font(FontFamily.GenericSansSerif, _fontSize),
                                        new SolidBrush(Color.Black),
                                        j * _cellPixelSize + _horizontalStringMargin,
                                        i * _cellPixelSize + _verticalStringMargin);
                                break;
                            case CellType.Questioned:
                                e.Graphics.DrawString("?",
                                    new Font(FontFamily.GenericSansSerif, _fontSize),
                                    new SolidBrush(Color.Black),
                                    j * _cellPixelSize + _horizontalStringMargin,
                                    i * _cellPixelSize + _verticalStringMargin);
                                break;
                            case CellType.Flagged:
                                e.Graphics.DrawString("X",
                                    new Font(FontFamily.GenericSansSerif, _fontSize),
                                    new SolidBrush(Color.Black),
                                    j * _cellPixelSize + _horizontalStringMargin,
                                    i * _cellPixelSize + _verticalStringMargin);
                                break;
                        }
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), j * _cellPixelSize, i * _cellPixelSize, _cellPixelSize, _cellPixelSize);
                    }
        }

    }
}
