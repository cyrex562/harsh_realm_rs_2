// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.LocInfoSubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;

namespace WindowsApplication1
{
  public class LocInfoSubPartClass : SubPartClass
  {
    private object OwnBitmapNr;
    private object locnr;
    private GameClass game;
    private int[] mzx;
    private int[] mzy;
    private int[] mznr;
    private int mzcount;

    public LocInfoSubPartClass(int tlocnr, GameClass tgame)
      : base(200, 150)
    {
      this.mzx = new int[41];
      this.mzy = new int[41];
      this.mznr = new int[41];
      this.locnr = (object) tlocnr;
      this.game = tgame;
    }

    public override Bitmap Paint()
    {
      if (Operators.ConditionalCompareObjectLess(this.locnr, (object) 0, false))
        return this.OwnBitmap;
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int type = this.game.Data.LocObj[Conversions.ToInteger(this.locnr)].Type;
      int regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[Conversions.ToInteger(this.locnr)].X, this.game.Data.LocObj[Conversions.ToInteger(this.locnr)].Y].Regime;
      if (this.game.Data.Round > 0)
      {
        int red;
        int green;
        int blue;
        int num1;
        int num2;
        int num3;
        if (regime == -1)
        {
          red = 128;
          green = 128;
          blue = 128;
          num1 = 0;
          num2 = 0;
          num3 = 0;
        }
        else
        {
          red = this.game.Data.RegimeObj[regime].Red;
          green = this.game.Data.RegimeObj[regime].Green;
          blue = this.game.Data.RegimeObj[regime].Blue;
          num1 = this.game.Data.RegimeObj[regime].Red2;
          num2 = this.game.Data.RegimeObj[regime].Green2;
          num3 = this.game.Data.RegimeObj[regime].Blue2;
        }
        Color c1 = Color.FromArgb((int) byte.MaxValue, red, green, blue);
        Color c2 = Color.FromArgb(150, red, green, blue);
        DrawMod.DrawBlockGradient(ref Expression, 0, 0, 200, 50, c1, c2);
      }
      else
      {
        Color c1 = Color.FromArgb((int) byte.MaxValue, 180, 180, 180);
        Color c2 = Color.FromArgb(150, 90, 90, 90);
        DrawMod.DrawBlockGradient(ref Expression, 0, 0, 200, 50, c1, c2);
      }
      if (Strings.Len(this.game.Data.LocObj[Conversions.ToInteger(this.locnr)].Name) > 1)
      {
        string name = this.game.Data.LocObj[Conversions.ToInteger(this.locnr)].Name;
        DrawMod.DrawText(ref Expression, name, new Font("Times New Roman", 16f, FontStyle.Bold, GraphicsUnit.Pixel), 0, 0);
        string tstring = "(" + this.game.Data.LocTypeObj[type].Name + ")";
        DrawMod.DrawText(ref Expression, tstring, new Font("Times New Roman", 13f, FontStyle.Bold, GraphicsUnit.Pixel), 0, 18);
      }
      else
      {
        string name = this.game.Data.LocTypeObj[type].Name;
        DrawMod.DrawText(ref Expression, name, new Font("Times New Roman", 16f, FontStyle.Bold, GraphicsUnit.Pixel), 0, 0);
      }
      if (this.game.Data.LocObj[Conversions.ToInteger(this.locnr)].HQ == -1)
      {
        string tstring = "No HQ assigned!";
        DrawMod.DrawText(ref Expression, tstring, new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 0, 70);
      }
      else
      {
        string tstring = "HQ: " + this.game.Data.UnitObj[this.game.Data.LocObj[Conversions.ToInteger(this.locnr)].HQ].Name;
        DrawMod.DrawText(ref Expression, tstring, new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 0, 68);
      }
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }

    public override int Click(int x, int y, int b = 1)
    {
      if (this.mzcount <= -1)
        return -1;
      int mzcount = this.mzcount;
      for (int index = 0; index <= mzcount; ++index)
      {
        if (x > this.mzx[index] & y > this.mzy[index] & x < this.mzx[index] + 31 & y < this.mzy[index] + 31)
          return this.mznr[index];
      }
      return -1;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
      ref Bitmap local2 = ref bitmap;
      DrawMod.Draw(ref local1, ref local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      return this.OwnBitmap;
    }
  }
}
