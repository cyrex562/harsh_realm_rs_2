// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEZoneButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SEZoneButtonPartClass : SubPartClass
  {
    private int iconSlotNr;
    private string dataString;
    private string description;
    private bool active;
    private int delta;
    private bool showDelta;
    private int eventpicslotPos;
    private int eventpicslotNeg;
    private int eventpicslotZero;

    public override void SubDispose()
    {
    }

    public SEZoneButtonPartClass(
      int tIconSlotNr,
      string tDataString,
      string tDescript,
      bool tactive,
      bool tshowDelta = false,
      int tdelta = 0)
      : base(220, 40)
    {
      this.iconSlotNr = tIconSlotNr;
      this.Descript = tDescript;
      this.dataString = tDataString;
      this.active = tactive;
      this.showDelta = tshowDelta;
      this.delta = tdelta;
      this.eventpicslotPos = DrawMod.TGame.Data.FindEventPic("", 8, "SE_Present");
      this.eventpicslotNeg = DrawMod.TGame.Data.FindEventPic("", 9, "SE_Present");
      this.eventpicslotZero = DrawMod.TGame.Data.FindEventPic("", 11, "SE_Present");
    }

    public override Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
        ref Graphics local1 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTON);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
      }
      if (this.active)
      {
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONHIGH);
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
        rectangle2 = new Rectangle(0, 3, 48, 32);
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
        rectangle1 = new Rectangle(0, 3, 48, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect, destrect);
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (this.showDelta)
      {
        bool flag = false;
        SizeF sizeF = new SizeF();
        int num1 = this.delta;
        if (num1 < 0)
        {
          num1 = Math.Abs(num1);
          flag = true;
        }
        string str = num1.ToString();
        int num2 = (int) Math.Round(210.0 - ((double) objgraphics.MeasureString(str, DrawMod.TGame.MarcFont16).Width + 4.0 + 16.0));
        int index = this.eventpicslotZero;
        if (flag)
          index = this.eventpicslotNeg;
        else if (this.delta > 0)
          index = this.eventpicslotPos;
        ref Graphics local9 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index]);
        ref Bitmap local10 = ref bitmap;
        int x1 = num2;
        DrawMod.DrawSimple(ref local9, ref local10, x1, 13);
        int x2 = num2 + 15;
        DrawMod.DrawTextColouredConsole(ref objgraphics, str, DrawMod.TGame.MarcFont16, x2, 11, DrawMod.TGame.seColGray);
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
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTON);
        ref Bitmap local2 = ref bitmap;
        DrawMod.DrawSimple(ref local1, ref local2, 0, 0);
        ref Graphics local3 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONHIGH);
        ref Bitmap local4 = ref bitmap;
        DrawMod.Draw(ref local3, ref local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
        ref Graphics local5 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONHIGH);
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
        rectangle2 = new Rectangle(0, 3, 48, 32);
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
        rectangle1 = new Rectangle(0, 3, 48, 32);
        Rectangle destrect = rectangle1;
        DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole(ref objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (this.showDelta)
      {
        bool flag = false;
        SizeF sizeF = new SizeF();
        int num1 = this.delta;
        if (num1 < 0)
        {
          num1 = Math.Abs(num1);
          flag = true;
        }
        string str = num1.ToString();
        int num2 = (int) Math.Round(210.0 - ((double) objgraphics.MeasureString(str, DrawMod.TGame.MarcFont16).Width + 4.0 + 16.0));
        int index = this.eventpicslotZero;
        if (flag)
          index = this.eventpicslotNeg;
        else if (this.delta > 0)
          index = this.eventpicslotPos;
        ref Graphics local11 = ref objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index]);
        ref Bitmap local12 = ref bitmap;
        int x1 = num2;
        DrawMod.DrawSimple(ref local11, ref local12, x1, 13);
        int x2 = num2 + 15;
        DrawMod.DrawTextColouredConsole(ref objgraphics, str, DrawMod.TGame.MarcFont16, x2, 11, DrawMod.TGame.seColGray);
      }
      if (!Information.IsNothing((object) objgraphics))
      {
        objgraphics.Dispose();
        objgraphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }
  }
}
