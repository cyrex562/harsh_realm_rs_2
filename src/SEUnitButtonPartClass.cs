// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEUnitButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System.Drawing;

namespace WindowsApplication1
{
  public class SEUnitButtonPartClass : SubPartClass
  {
    private int iconSlotNr;
    private string dataString;
    private string dataString2;
    private string description;
    private bool active;
    private int overruleR;
    private int overruleG;
    private int overruleB;

    public override void SubDispose()
    {
    }

    public SEUnitButtonPartClass(
      int tIconSlotNr,
      string tDataString,
      string tDataString2,
      string tDescript,
      bool tactive,
      int tOverruleR = -1,
      int tOverruleG = -1,
      int tOverruleB = -1)
      : base(44, 97)
    {
      this.iconSlotNr = tIconSlotNr;
      this.Descript = tDescript;
      this.dataString = tDataString;
      this.dataString2 = tDataString2;
      this.active = tactive;
      this.overruleG = tOverruleG;
      this.overruleB = tOverruleB;
      this.overruleR = tOverruleR;
    }

    public override Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
      }
      if (this.active)
      {
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5HIGH);
        ref Bitmap local4 = ref bitmap;
        DrawMod.DrawSimple(ref local3, ref local4, 0, 0);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
        ref Bitmap local6 = ref bitmap;
        rectangle1 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
        Rectangle srcrect = rectangle1;
        rectangle2 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle2;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect, destrect);
      }
      if (this.active)
      {
        ref Graphics local7 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
        ref Bitmap local8 = ref bitmap;
        rectangle2 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
      }
      if (this.overruleB > -1)
      {
        if (this.dataString2.Length > 0)
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
        else
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
      }
      else if (this.dataString2.Length > 0)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColWhite);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColWhite);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5HIGH);
        ref Bitmap local4 = ref bitmap;
        DrawMod.Draw(ref local3, ref local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_VARBOX5HIGH);
        ref Bitmap local6 = ref bitmap;
        DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
        ref Graphics local7 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
        ref Bitmap local8 = ref bitmap;
        rectangle1 = new Rectangle(this.iconSlotNr * 42, 0, 42, 32);
        Rectangle srcrect = rectangle1;
        rectangle2 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle2;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
      }
      if (this.active)
      {
        ref Graphics local9 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
        ref Bitmap local10 = ref bitmap;
        rectangle2 = new Rectangle(this.iconSlotNr * 42, 32, 42, 32);
        Rectangle srcrect = rectangle2;
        rectangle1 = new Rectangle(2, 10, 42, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
      }
      if (this.overruleB > -1)
      {
        if (this.dataString2.Length > 0)
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
        else
        {
          if (!this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
          if (this.active)
            DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, Color.FromArgb((int) byte.MaxValue, this.overruleR, this.overruleG, this.overruleB));
        }
      }
      else if (this.dataString2.Length > 0)
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 51, DrawMod.TGame.seColWhite);
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString2, DrawMod.TGame.MarcFont16, 22, 65, DrawMod.TGame.seColWhite);
      }
      else
      {
        if (!this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColGray);
        if (this.active)
          DrawMod.DrawTextColouredConsoleCenter(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 22, 58, DrawMod.TGame.seColWhite);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }
  }
}
