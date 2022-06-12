// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AICoordinateMatrix
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

namespace WindowsApplication1
{
  public class AICoordinateMatrix
  {
    public Coordinate[,] Value;
    public int Width;
    public int Height;
    public int Left;
    public int Top;
    public DC2AIClass ai;

    public AICoordinateMatrix(ref DC2AIClass tai)
    {
      this.Value = new Coordinate[1, 1];
      this.ai = tai;
      this.Width = tai.game.Data.MapObj[0].MapWidth;
      this.Height = tai.game.Data.MapObj[0].MapHeight;
      this.Top = 0;
      this.Left = 0;
      this.Value = new Coordinate[this.Width + 1, this.Height + 1];
    }

    public AICoordinateMatrix(ref DC2AIClass tai, int twidth, int theight, int ttop, int tleft)
    {
      this.Value = new Coordinate[1, 1];
      this.ai = tai;
      this.Width = twidth;
      this.Height = theight;
      this.Left = tleft;
      this.Top = ttop;
      this.Value = new Coordinate[this.Width + 1, this.Height + 1];
    }

    public AICoordinateMatrix Clone()
    {
      AICoordinateMatrix coordinateMatrix = new AICoordinateMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width = this.Width;
      for (int index1 = 0; index1 <= width; ++index1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; ++index2)
          coordinateMatrix.Value[index1, index2] = this.Value[index1, index2];
      }
      return coordinateMatrix;
    }
  }
}
