// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HeaderPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class HeaderPartClass : SubPartClass
  {
    private object OwnBitmapNr;
    private GameClass game;
    private int width;
    private int height;
    private string header;
    private int regnr;

    public HeaderPartClass(GameClass tgame, int twidth, int theight, string theader, int tregnr)
      : base(twidth, theight)
    {
      this.game = tgame;
      this.width = twidth;
      this.height = theight;
      this.header = theader;
      this.regnr = tregnr;
    }

    public override Bitmap Paint()
    {
      SizeF sizeF1 = new SizeF();
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int round = this.game.Data.Round;
      int red1;
      int green1;
      int blue1;
      if (this.regnr > -1)
      {
        int red2 = this.game.Data.RegimeObj[this.regnr].Red;
        int green2 = this.game.Data.RegimeObj[this.regnr].Green;
        int blue2 = this.game.Data.RegimeObj[this.regnr].Blue;
        red1 = this.game.Data.RegimeObj[this.regnr].Red2;
        green1 = this.game.Data.RegimeObj[this.regnr].Green2;
        blue1 = this.game.Data.RegimeObj[this.regnr].Blue2;
        Color c1 = Color.FromArgb((int) byte.MaxValue, red2, green2, blue2);
        Color c2 = Color.FromArgb(150, red2, green2, blue2);
        DrawMod.DrawBlockGradient(ref graphics, 0, 0, this.width, this.height, c1, c2);
      }
      else if (this.regnr == -2)
      {
        Color black1 = Color.Black;
        Color black2 = Color.Black;
        DrawMod.DrawBlock(ref graphics, 0, 0, this.width, this.height, 0, 0, 0, (int) byte.MaxValue);
        red1 = (int) byte.MaxValue;
        green1 = (int) byte.MaxValue;
        blue1 = (int) byte.MaxValue;
      }
      else
      {
        Color c1 = Color.FromArgb((int) byte.MaxValue, 180, 180, 180);
        Color c2 = Color.FromArgb(150, 90, 90, 90);
        DrawMod.DrawBlockGradient(ref graphics, 0, 0, this.width, this.height, c1, c2);
        red1 = (int) byte.MaxValue;
        green1 = (int) byte.MaxValue;
        blue1 = (int) byte.MaxValue;
      }
      Color c = Color.FromArgb((int) byte.MaxValue, red1, green1, blue1);
      string header = this.header;
      SizeF sizeF2 = graphics.MeasureString(header, new Font("Times New Roman", 25f, FontStyle.Regular, GraphicsUnit.Pixel));
      DrawMod.DrawTextColoured(ref graphics, header, new Font("Times New Roman", 25f, FontStyle.Regular, GraphicsUnit.Pixel), (int) Math.Round((double) this.width / 2.0 - (double) sizeF2.Width / 2.0), (int) Math.Round((double) this.height / 2.0 - (double) sizeF2.Height / 2.0), c);
      return this.OwnBitmap;
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
