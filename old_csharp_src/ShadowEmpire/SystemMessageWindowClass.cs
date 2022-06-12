// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SystemMessageWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SystemMessageWindowClass : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int TAid;
    private int His;
    private int Card;
    private int Unr;

    public SystemMessageWindowClass(ref GameClass tGame)
      : base(ref tGame, 600, 200, 8)
    {
      this.View();
    }

    public void View()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(600, 200, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, 600, 200);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      SizeF sizeF1 = new SizeF();
      string str1 = this.game.EditObj.FeedBackString;
      sizeF1 = graphics.MeasureString(str1, this.game.MarcFont4);
      int num1 = -1;
      while (Strings.Len(str1) > 0)
      {
        ++num1;
        int Length = Strings.InStr(str1, ".");
        int num2 = 0;
        if (Length > 0)
          num2 = Strings.InStr(Length + 1, str1, ".");
        string str2;
        if (Length > 0 & num2 > 0)
        {
          str2 = Strings.Left(str1, Length);
          str1 = Strings.Mid(str1, Length + 1);
        }
        else
        {
          str2 = str1;
          str1 = "";
        }
        SizeF sizeF2 = graphics.MeasureString(str2, this.game.MarcFont4);
        DrawMod.DrawTextColouredMarc(ref graphics, str2, this.game.MarcFont4, (int) Math.Round(300.0 - (double) sizeF2.Width / 2.0), 40 + num1 * 20, Color.White);
      }
      SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("OK", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 200, bby: 100, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart, 200, 100, 200, 36, 1);
      Rectangle trect = new Rectangle(200, 100, 200, 35);
      this.AddMouse(ref trect, "", "Close this message");
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          windowReturnClass.AddCommand(6, 0);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && this.SubPartID[index] == this.cancelid)
          {
            windowReturnClass.AddCommand(6, 0);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
