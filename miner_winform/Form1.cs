using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace miner_winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int countLives;
        int sizeX = 0;
        int sizeY = 0;
        int sizeZ = 0;
        int countMines = 0;
        int notOpenedCells = 0;
        GameStatements gameState = new GameStatements();
        Cell[,,] Field;
        int[] layerState = { 0, 1, 2 };

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (textDepth.Text.Equals(String.Empty))
            {
                MessageBox.Show("Enter the depth of field");
            }
            else if (textWidth.Text.Equals(String.Empty))
            {
                MessageBox.Show("Enter the width of field");
            }
            else if (textHeight.Text.Equals(String.Empty))
            {
                MessageBox.Show("Enter the height of field");
            }
            else
            {
                try
                {
                    sizeX = Convert.ToInt32(textWidth.Text);
                    sizeY = Convert.ToInt32(textHeight.Text);
                    sizeZ = Convert.ToInt32(textDepth.Text);
                    countLives = Convert.ToInt32(textLives.Text);
                }
                catch
                {
                    MessageBox.Show("Wrong data");
                    return;
                }

                if (sizeX < 3 || sizeX > 10)
                {
                    MessageBox.Show("Width must be more than 3 and lesss than 10");
                    return;
                }

                if (sizeY < 3 || sizeY > 10)
                {
                    MessageBox.Show("Height must be more than 3 and lesss than 10");
                    return;
                }

                if (sizeZ < 3 || sizeZ > 10)
                {
                    MessageBox.Show("Depth must be more than 3 and lesss than 10");
                    return;
                }

                if (countLives < 1)
                {
                    MessageBox.Show("Count of lives must be more than 0");
                    return;
                }

                Field = new Cell[sizeY, sizeX, sizeZ];
                Fillempty();
                layer1.Width = 25 * sizeX + 1;
                layer1.Height = 25 * sizeY + 1;
                layer2.Width = 25 * sizeX + 1;
                layer2.Height = 25 * sizeY + 1;
                layer3.Width = 25 * sizeX + 1;
                layer3.Height = 25 * sizeY + 1;
                layerRefresh();
                labelLayer1.Text = "Layer: 1";
                labelLayer2.Text = "Layer: 2";
                labelLayer3.Text = "Layer: 3";
                labelLayer1.Location = new Point(labelLayer1.Location.X, layer1.Location.Y + layer1.Height + 10);
                labelLayer2.Location = new Point(labelLayer2.Location.X, layer2.Location.Y + layer2.Height + 10);
                labelLayer3.Location = new Point(labelLayer3.Location.X, layer3.Location.Y + layer3.Height + 10);
                btnTurnLeft.Location = new Point(btnTurnLeft.Location.X, layer2.Location.Y + layer2.Height + 10);
                btnTurnRight.Location = new Point(btnTurnRight.Location.X, layer2.Location.Y + layer2.Height + 10);
                btnTurnLeft.Visible = true;
                btnTurnRight.Visible = true;
                labelMineCount.Text = Convert.ToString((int)(sizeX * sizeY * sizeZ / 10));
                labelCountLives.Text = countLives.ToString();
                labelMines.Text = "Mines count:";
                labelLives.Text = "Lives count:";
                int[] layerState = { 0, 1, 2 };
                if (sizeZ > 3)
                    btnTurnRight.Enabled = true;
                changeState(GameStatements.newgame);
            }
        }

        private bool isValid(int x, int y, int z, int xx, int yy ,int zz)
        {
            return (x >= 0 && x < xx && y >= 0 && y < yy && z >= 0 && z < zz);
        }

        private void Fillempty()
        {
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    for (int k = 0; k < sizeZ; k++)
                    {
                        Field[j, i, k] = new Cell();
                        Field[j, i, k].TypeCell = CellType.Closed;
                    }
        }

        private void layer1_Paint(object sender, PaintEventArgs e)
        {
            int k = layerState[0];
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    if (Field[i, j, k] != null)
                    {

                        switch (Field[i, j, k].TypeCell)
                        {
                            case CellType.Opened:
                                if (Field[i, j, k].HasMine)
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), j * 25, i * 25, 25, 25);
                                else
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), j * 25, i * 25, 25, 25);
                                if (Field[i, j, k].Neighbours != 0)
                                    e.Graphics.DrawString(Field[i, j, k].Neighbours.ToString(), new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                            case CellType.Questioned:
                                e.Graphics.DrawString("?", new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                            case CellType.Flagged:
                                e.Graphics.DrawString("X", new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                        }
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), j * 25, i * 25, 25, 25);
                    }
        }

        private void layer2_Paint(object sender, PaintEventArgs e)
        {
            int k = layerState[1];
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    if (Field[i, j, k] != null)
                    {

                        switch (Field[i, j, k].TypeCell)
                        {
                            case CellType.Opened:
                                if (Field[i, j, k].HasMine)
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), j * 25, i * 25, 25, 25);
                                else
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), j * 25, i * 25, 25, 25);
                                if (Field[i, j, k].Neighbours != 0)
                                    e.Graphics.DrawString(Field[i, j, k].Neighbours.ToString(), new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                            case CellType.Questioned:
                                e.Graphics.DrawString("?", new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                            case CellType.Flagged:
                                e.Graphics.DrawString("X", new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                        }
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), j * 25, i * 25, 25, 25);
                    }
        }

        private void layer3_Paint(object sender, PaintEventArgs e)
        {
            int k = layerState[2];
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    if (Field[i, j, k] != null)
                    {

                        switch (Field[i, j, k].TypeCell)
                        {
                            case CellType.Opened:
                                if (Field[i, j, k].HasMine)
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), j * 25, i * 25, 25, 25);
                                else
                                    e.Graphics.FillRectangle(new SolidBrush(Color.Green), j * 25, i * 25, 25, 25);
                                if (Field[i, j, k].Neighbours != 0)
                                    e.Graphics.DrawString(Field[i, j, k].Neighbours.ToString(), new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                            case CellType.Questioned:
                                e.Graphics.DrawString("?", new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                            case CellType.Flagged:
                                e.Graphics.DrawString("X", new Font(FontFamily.GenericSansSerif, 13), new SolidBrush(Color.Black), j * 25 + 5, i * 25 + 3);
                                break;
                        }
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), j * 25, i * 25, 25, 25);
                    }
        }

        private void layer1_MouseDown(object sender, MouseEventArgs e)
        {
            int xID = e.X / 25;
            int yID = e.Y / 25;
            int zID = layerState[0];
            switch (MouseButtons)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    if (gameState == GameStatements.newgame || gameState == GameStatements.gameproc)
                    {
                        if (gameState == GameStatements.newgame)
                        {
                            changeState(GameStatements.gameproc);
                            Fill(xID, yID, zID);
                            labelMines.Text = "Mines count:";
                            labelMineCount.Text = Convert.ToString(countMines);
                            notOpenedCells = sizeX * sizeY * sizeZ - countMines;
                        }
                        Field[yID, xID, zID].TypeCell = CellType.Opened;
                        if (Field[yID, xID, zID].HasMine)
                        {
                            countLives--;
                            labelCountLives.Text = countLives.ToString();
                            labelMineCount.Text = (Convert.ToInt32(labelMineCount.Text) - 1).ToString();
                            if (countLives == 0)
                            {
                                OpenField();
                                layerRefresh();
                                changeState(GameStatements.fail);
                            }
                            else
                            {
                                Field[yID, xID, zID].TypeCell = CellType.Opened;
                                layerRefresh();
                                MessageBox.Show("Count of lives: " + countLives.ToString());
                            }
                        }
                        else if (Field[yID, xID, zID].Neighbours == 0)
                        {
                            notOpenedCells--;
                            OpenEmpty(xID, yID, zID);
                        }
                        else
                            notOpenedCells--;
                    }
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    if (gameState == GameStatements.gameproc)
                    {
                        switch (Field[yID, xID, zID].TypeCell)
                        {
                            case CellType.Closed:
                                Field[yID, xID, zID].TypeCell = CellType.Flagged;
                                countMines--;
                                labelMineCount.Text = Convert.ToString(countMines);
                                break;
                            case CellType.Flagged:
                                Field[yID, xID, zID].TypeCell = CellType.Questioned;
                                countMines++;
                                labelMineCount.Text = Convert.ToString(countMines);
                                break;
                            case CellType.Questioned:
                                Field[yID, xID, zID].TypeCell = CellType.Closed;
                                break;

                        }
                    }
                    break;
            }
            if (notOpenedCells == 0 && gameState == GameStatements.gameproc)
            {
                OpenField();
                layerRefresh();
                changeState(GameStatements.win);
            }
            if (gameState != GameStatements.newgame)
            {
                layerRefresh();
            }
        }

        private void layer2_MouseDown(object sender, MouseEventArgs e)
        {
            int xID = e.X / 25;
            int yID = e.Y / 25;
            int zID = layerState[1];
            switch (MouseButtons)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    if (gameState == GameStatements.newgame || gameState == GameStatements.gameproc)
                    {
                        if (gameState == GameStatements.newgame)
                        {
                            changeState(GameStatements.gameproc);
                            Fill(xID, yID, zID);
                            labelMines.Text = "Mines count:";
                            labelMineCount.Text = Convert.ToString(countMines);
                            notOpenedCells = sizeX * sizeY * sizeZ - countMines;
                        }
                        Field[yID, xID, zID].TypeCell = CellType.Opened;
                        if (Field[yID, xID, zID].HasMine)
                        {
                            countLives--;
                            labelCountLives.Text = countLives.ToString();
                            labelMineCount.Text = (Convert.ToInt32(labelMineCount.Text) - 1).ToString();
                            if (countLives == 0)
                            {
                                OpenField();
                                layerRefresh();
                                changeState(GameStatements.fail);
                            }
                            else
                            {
                                Field[yID, xID, zID].TypeCell = CellType.Opened;
                                layerRefresh();
                                MessageBox.Show("Count of lives: " + countLives.ToString());
                            }
                        }
                        else if (Field[yID, xID, zID].Neighbours == 0)
                        {
                            notOpenedCells--;
                            OpenEmpty(xID, yID, zID);
                        }
                        else
                            notOpenedCells--;
                    }
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    if (gameState == GameStatements.gameproc)
                    {
                        switch (Field[yID, xID, zID].TypeCell)
                        {
                            case CellType.Closed:
                                Field[yID, xID, zID].TypeCell = CellType.Flagged;
                                countMines--;
                                labelMineCount.Text = Convert.ToString(countMines);
                                break;
                            case CellType.Flagged:
                                Field[yID, xID, zID].TypeCell = CellType.Questioned;
                                countMines++;
                                labelMineCount.Text = Convert.ToString(countMines);
                                break;
                            case CellType.Questioned:
                                Field[yID, xID, zID].TypeCell = CellType.Closed;
                                break;

                        }
                    }
                    break;
            }
            if (notOpenedCells == 0 && gameState == GameStatements.gameproc)
            {
                OpenField();
                layerRefresh();
                changeState(GameStatements.win);

            }
            if (gameState != GameStatements.newgame)
            {
                layerRefresh();
            }
        }

        private void layer3_MouseDown(object sender, MouseEventArgs e)
        {
            int xID = e.X / 25;
            int yID = e.Y / 25;
            int zID = layerState[2];
            switch (MouseButtons)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    if (gameState == GameStatements.newgame || gameState == GameStatements.gameproc)
                    {
                        if (gameState == GameStatements.newgame)
                        {
                            changeState(GameStatements.gameproc);
                            Fill(xID, yID, zID);
                            labelMines.Text = "Mines count:";
                            labelMineCount.Text = Convert.ToString(countMines);
                            notOpenedCells = sizeX * sizeY * sizeZ - countMines;
                        }
                        Field[yID, xID, zID].TypeCell = CellType.Opened;
                        if (Field[yID, xID, zID].HasMine)
                        {
                            countLives--;
                            labelCountLives.Text = countLives.ToString();
                            labelMineCount.Text = (Convert.ToInt32(labelMineCount.Text) - 1).ToString();
                            if (countLives == 0)
                            {
                                OpenField();
                                layerRefresh();
                                changeState(GameStatements.fail);
                            }
                            else
                            {
                                Field[yID, xID, zID].TypeCell = CellType.Opened;
                                layerRefresh();
                                MessageBox.Show("Count of lives: " + countLives.ToString());
                            }
                        }
                        else if (Field[yID, xID, zID].Neighbours == 0)
                        {
                            notOpenedCells--;
                            OpenEmpty(xID, yID, zID);
                        }
                        else
                            notOpenedCells--;
                    }
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    if (gameState == GameStatements.gameproc)
                    {
                        switch (Field[yID, xID, zID].TypeCell)
                        {
                            case CellType.Closed:
                                Field[yID, xID, zID].TypeCell = CellType.Flagged;
                                countMines--;
                                labelMineCount.Text = Convert.ToString(countMines);
                                break;
                            case CellType.Flagged:
                                Field[yID, xID, zID].TypeCell = CellType.Questioned;
                                countMines++;
                                labelMineCount.Text = Convert.ToString(countMines);
                                break;
                            case CellType.Questioned:
                                Field[yID, xID, zID].TypeCell = CellType.Closed;
                                break;

                        }
                    }
                    break;
            }
            if (notOpenedCells == 0 && gameState == GameStatements.gameproc)
            {
                OpenField();
                layerRefresh();
                changeState(GameStatements.win);

            }
            if (gameState != GameStatements.newgame)
            {
                layerRefresh();
            }
        }

        private void OpenField()
        {
            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    for (int k = 0; k < sizeZ; k++)
                        if (Field[i, j, k].HasMine)
                        {
                            Field[i, j, k].TypeCell = CellType.Opened;
                        }
            
        }

        private void OpenEmpty(int CoordX, int CoordY, int CoordZ)
        {
            for (int dx = -1; dx < 2; dx++)
                for (int dy = -1; dy < 2; dy++)
                    for (int dz = -1; dz < 2; dz++)
                    {
                        if (isValid(CoordY + dy, CoordX + dx, CoordZ + dz, sizeY, sizeX, sizeZ))
                            if ((Field[CoordY + dy, CoordX + dx, CoordZ + dz].TypeCell == CellType.Closed) &&
                                (!Field[CoordY + dy, CoordX + dx, CoordZ + dz].HasMine))
                            {
                                Field[CoordY + dy, CoordX + dx, CoordZ + dz].TypeCell = CellType.Opened;
                                notOpenedCells--;
                                if (Field[CoordY + dy, CoordX + dx, CoordZ + dz].Neighbours == 0)
                                    OpenEmpty(CoordX + dx, CoordY + dy, CoordZ + dz);
                            }
                    }
        }

        private void OpenEmptyWithoutFlag(int CoordX, int CoordY, int CoordZ)
        {
            int[] dx = { 1, -1, 0, 0, 0, 0 };
            int[] dy = { 0, 0, 1, -1, 0, 0 };
            int[] dz = { 0, 0, 0, 0, 1, -1 };
            for (int i = 0; i < 6; i++)
                if (isValid(CoordY + dy[i], CoordX + dx[i], CoordZ + dz[i], sizeY, sizeX, sizeZ))
                {
                    if ((Field[CoordY + dy[i], CoordX + dx[i], CoordZ + dz[i]].TypeCell == CellType.Closed) &&
                        (Field[CoordY + dy[i], CoordX + dx[i], CoordZ + dz[i]].TypeCell != CellType.Flagged))
                    {
                        Field[CoordY + dy[i], CoordX + dx[i], CoordZ + dz[i]].TypeCell = CellType.Opened;
                        if (!Field[CoordY + dy[i], CoordX + dx[i], CoordZ + dz[i]].HasMine)
                            notOpenedCells--;
                        else
                        {
                            OpenField();
                            layerRefresh();
                            changeState(GameStatements.fail);
                        }
                        if (Field[CoordY + dy[i], CoordX + dx[i], CoordZ + dz[i]].Neighbours == 0)
                            OpenEmpty(CoordX + dx[i], CoordY + dy[i], CoordZ + dz[i]);
                    }
                }
        }

        private void Fill(int CoordX, int CoordY, int CoordZ)
        {
            Random r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

            countMines = sizeX * sizeY * sizeZ / 10;

            for (int i = 0; i < countMines; i++)
            {
                int x = r.Next(sizeX);
                int y = r.Next(sizeY);
                int z = r.Next(sizeZ);
                while (Field[y, x, z].HasMine || (x == CoordX && y == CoordY && z == CoordZ))
                {
                    x = r.Next(sizeX);
                    y = r.Next(sizeY);
                    z = r.Next(sizeZ);
                }
                Field[y, x, z].HasMine = true;
            }

            for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    for (int k = 0; k < sizeZ; k++)
                        if (Field[i, j, k].HasMine == false)
                            for (int dx = -1; dx < 2; dx++)
                                for (int dy = -1; dy < 2; dy++)
                                    for (int dz = -1; dz < 2; dz++)
                                    {
                                        if (isValid(i + dy, j + dx, k + dz, sizeY, sizeX, sizeZ))
                                            if (Field[i + dy, j + dx, k + dz].HasMine)
                                                Field[i, j, k].Neighbours++;
                                    }
        }   

        private void changeState(GameStatements newState)
        {
            gameState = newState;
            if (gameState == GameStatements.win)
                MessageBox.Show("You win");
            if (gameState == GameStatements.fail)
                MessageBox.Show("You lose");
        }

        private void layerRefresh()
        {
            layer1.Refresh();
            layer2.Refresh();
            layer3.Refresh();
        }

        private void btnTurnLeft_Click(object sender, EventArgs e)
        {
            layerState[0]--;
            layerState[1]--;
            layerState[2]--;
            labelLayer1.Text = "Layer: " + (layerState[0] + 1).ToString();
            labelLayer2.Text = "Layer: " + (layerState[1] + 1).ToString();
            labelLayer3.Text = "Layer: " + (layerState[2] + 1).ToString();
            if (layerState[2] == sizeZ - 2)
                btnTurnRight.Enabled = true;
            if (layerState[0] == 0)
                btnTurnLeft.Enabled = false;
            layerRefresh();
        }

        private void btnTurnRight_Click(object sender, EventArgs e)
        {
            layerState[0]++;
            layerState[1]++;
            layerState[2]++;
            labelLayer1.Text = "Layer: " + (layerState[0] + 1).ToString();
            labelLayer2.Text = "Layer: " + (layerState[1] + 1).ToString();
            labelLayer3.Text = "Layer: " + (layerState[2] + 1).ToString();
            if (layerState[2] == sizeZ - 1)
                btnTurnRight.Enabled = false;
            if (layerState[0] == 1)
                btnTurnLeft.Enabled = true;
            layerRefresh();
        }
    }

}

class Cell
    {
        public bool HasMine { get; set; }
        public CellType TypeCell { get; set; }
        public int Neighbours { get; set; }
    }

    enum CellType
    {
        Closed,
        Opened,
        Flagged,
        Questioned
    }

enum GameStatements
{
    newgame,
    gameproc,
    win,
    fail,
    end
}
