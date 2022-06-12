// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TransportWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TransportWindowClass : WindowClass
  {
    private int okid;
    private int cancelid;
    private int oktextid;
    private int Pic1Id;
    private int His;
    private int Card;
    private int Unr;
    private UnitList UL;
    private int[] attachButton;
    private int[] attachButtonB;
    private int[] attachButtonUnr;
    private int[] detachButton;
    private int[] detachButtonUnr;

    public TransportWindowClass(ref GameClass tGame)
      : base(ref tGame, 1000, 760, 8)
    {
      this.attachButton = new int[30];
      this.attachButtonB = new int[30];
      this.attachButtonUnr = new int[30];
      this.detachButton = new int[30];
      this.detachButtonUnr = new int[30];
      this.SetUnits();
      this.View();
    }

    public void SetUnits()
    {
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
            {
              this.game.EditObj.TipButton = true;
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = this.SubPartList[index].Descript;
              return;
            }
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    public void View()
    {
      int x = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].X;
      int y = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Y;
      if (this.cancelid > 0)
      {
        this.RemoveSubPart(this.cancelid);
        this.cancelid = 0;
      }
      int index1 = 0;
      do
      {
        this.attachButtonUnr[index1] = -1;
        if (this.attachButton[index1] > 0)
        {
          this.RemoveSubPart(this.attachButton[index1]);
          this.attachButton[index1] = 0;
        }
        if (this.attachButtonB[index1] > 0)
        {
          this.RemoveSubPart(this.attachButtonB[index1]);
          this.attachButtonB[index1] = 0;
        }
        this.detachButtonUnr[index1] = -1;
        if (this.detachButton[index1] > 0)
        {
          this.RemoveSubPart(this.detachButton[index1]);
          this.detachButton[index1] = 0;
        }
        ++index1;
      }
      while (index1 <= 29);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(1000, 760, -1);
      Graphics toG = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref toG, 0, 0, 1000, 760);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      int x1 = 40;
      int w = 920;
      int h1 = 40;
      int h2 = 24;
      int y1_1 = 20;
      int num1 = 1;
      do
      {
        DrawMod.DrawBlockGradient2(ref toG, x1, y1_1, w, h2, this.game.MarcCol1, this.game.MarcCol2);
        string tstring1;
        if (num1 == 1)
          tstring1 = "Transporter Unit";
        if (num1 == 2)
          tstring1 = "Attached Units";
        if (num1 == 3)
          tstring1 = "Other Units";
        DrawMod.DrawTextColouredMarc(ref toG, tstring1, this.game.MarcFont3, x1 + 20, y1_1 + 2, Color.White);
        int y1_2 = y1_1 + h2;
        SimpleList simpleList = new SimpleList();
        if (num1 == 1)
          simpleList.Add(this.game.EditObj.UnitSelected, 1);
        int index2;
        if (num1 == 2)
        {
          int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
          for (int index3 = 0; index3 <= unitCounter; ++index3)
          {
            index2 = this.game.Data.MapObj[0].HexObj[x, y].UnitList[index3];
            if (this.game.Data.UnitObj[index2].attachedTo == this.game.EditObj.UnitSelected)
              simpleList.Add(index2, 1);
          }
        }
        if (num1 == 3)
        {
          int unitCounter = this.game.Data.MapObj[0].HexObj[x, y].UnitCounter;
          for (int index4 = 0; index4 <= unitCounter; ++index4)
          {
            index2 = this.game.Data.MapObj[0].HexObj[x, y].UnitList[index4];
            int num2 = 1;
            if (index2 == this.game.EditObj.UnitSelected)
              num2 = 0;
            if (!this.game.HandyFunctionsObj.CanAttach(index2))
              num2 = 0;
            if (num2 == 1)
              simpleList.Add(index2, 1);
          }
        }
        int num3 = this.game.HandyFunctionsObj.GiveTransporterMaxCarry(this.game.EditObj.UnitSelected);
        int num4 = this.game.HandyFunctionsObj.GiveTransporterCurrentCarry(this.game.EditObj.UnitSelected);
        int num5 = this.game.HandyFunctionsObj.GiveTransporterMaxManpowerCarry(this.game.EditObj.UnitSelected);
        int num6 = this.game.HandyFunctionsObj.GiveTransporterCurrentManpowerCarry(this.game.EditObj.UnitSelected);
        int counter = simpleList.Counter;
        for (int index5 = 0; index5 <= counter; ++index5)
        {
          DrawMod.DrawBlock(ref toG, x1, y1_2, w, h1, 0, 0, 0, 64);
          this.Unr = simpleList.Id[index5];
          this.game.CustomBitmapObj.DrawUnit(this.Unr, toG: toG, tx: (x1 + 18), ty: (y1_2 + 2));
          string name = this.game.Data.UnitObj[this.Unr].Name;
          DrawMod.DrawTextColouredMarc(ref toG, name, this.game.MarcFont4, x1 + 60, y1_2 + 5, Color.White);
          index2 = this.game.Data.UnitObj[this.Unr].HQ;
          string tstring2 = index2 <= -1 ? "no HQ" : "HQ: " + this.game.Data.UnitObj[index2].Name;
          DrawMod.DrawTextColouredMarc(ref toG, tstring2, this.game.MarcFont5, x1 + 62, y1_2 + 22, Color.LightGray);
          if (num1 == 1)
          {
            string tstring3 = "ATTACHED CARRY";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring3, this.game.MarcFont5, x1 + 512 + 30, y1_2 + 5, Color.LightGray);
            string tstring4 = num4.ToString();
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring4, this.game.MarcFont4, x1 + 510 + 30, y1_2 + 17, Color.White);
            string tstring5 = "ATTACHED MANPOWER";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring5, this.game.MarcFont5, x1 + 512 + 160, y1_2 + 5, Color.LightGray);
            string tstring6 = num6.ToString();
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring6, this.game.MarcFont4, x1 + 510 + 160, y1_2 + 17, Color.White);
            string tstring7 = "MAX WGT.CARRY";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring7, this.game.MarcFont5, x1 + 312, y1_2 + 5, Color.LightGray);
            string tstring8 = num3.ToString();
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring8, this.game.MarcFont4, x1 + 310, y1_2 + 17, Color.White);
            string tstring9 = "MAX MANP.CARRY";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring9, this.game.MarcFont5, x1 + 312 + 120, y1_2 + 5, Color.LightGray);
            tstring1 = num5.ToString();
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring1, this.game.MarcFont4, x1 + 310 + 120, y1_2 + 17, Color.White);
          }
          else
          {
            index2 = this.game.HandyFunctionsObj.GiveAttachablesWeight(this.Unr);
            string tstring10 = "WEIGHT";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring10, this.game.MarcFont5, x1 + 512 + 30, y1_2 + 5, Color.LightGray);
            string tstring11 = index2.ToString();
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring11, this.game.MarcFont4, x1 + 510 + 30, y1_2 + 17, Color.White);
            index2 = this.game.HandyFunctionsObj.GiveAttachablesManpowerWeight(this.Unr);
            string tstring12 = "MANPOWER";
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring12, this.game.MarcFont5, x1 + 512 + 160, y1_2 + 5, Color.LightGray);
            tstring1 = index2.ToString();
            DrawMod.DrawTextColouredMarcCenter(ref toG, tstring1, this.game.MarcFont4, x1 + 510 + 160, y1_2 + 17, Color.White);
          }
          switch (num1)
          {
            case 2:
              int[] detachButton = this.detachButton;
              int index6 = index5;
              SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Detach", 150, "Click to Detach Unit from the Transporter Unit.", ref this.OwnBitmap, x1 + 750, y1_2 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              int num7 = this.AddSubPart(ref tsubpart1, x1 + 750, y1_2 + 5, 150, 35, 1);
              detachButton[index6] = num7;
              this.detachButtonUnr[index5] = this.Unr;
              break;
            case 3:
              index2 = this.game.HandyFunctionsObj.GiveAttachablesWeight(this.Unr);
              int num8 = this.game.HandyFunctionsObj.GiveAttachablesManpowerWeight(this.Unr);
              if (index2 <= num3 - num4 & index2 > 0 & num8 <= num5 - num6)
              {
                int[] attachButton = this.attachButton;
                int index7 = index5;
                SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Attach", 150, "Click to Attach Unit to the Transporter Unit.", ref this.OwnBitmap, x1 + 750, y1_2 + 5, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
                int num9 = this.AddSubPart(ref tsubpart2, x1 + 750, y1_2 + 5, 150, 35, 1);
                attachButton[index7] = num9;
                this.attachButtonUnr[index5] = this.Unr;
                break;
              }
              int[] attachButtonB = this.attachButtonB;
              int index8 = index5;
              SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Attach", 150, "Cannot be attached.", ref this.OwnBitmap, x1 + 750, y1_2 + 5, true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              int num10 = this.AddSubPart(ref tsubpart3, x1 + 750, y1_2 + 5, 150, 35, 0);
              attachButtonB[index8] = num10;
              break;
          }
          y1_2 += h1;
        }
        y1_1 = y1_2 + (int) Math.Round((double) h2 / 2.0);
        ++num1;
      }
      while (num1 <= 3);
      SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("OK", 250, "Click to return to main screen.", ref this.OwnBitmap, 375, 700, theight: 40, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.cancelid = this.AddSubPart(ref tsubpart, 375, 700, 250, 40, 1);
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
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] >= 0)
        {
          this.View();
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
label_17:
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int index2 = 0;
            while (!(this.SubPartID[index1] == this.attachButton[index2] & this.attachButtonUnr[index2] > -1))
            {
              if (this.SubPartID[index1] == this.detachButton[index2] & this.detachButtonUnr[index2] > -1)
              {
                this.game.ProcessingObj.DetachUnit(this.detachButtonUnr[index2], this.game.EditObj.UnitSelected);
                this.View();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              ++index2;
              if (index2 > 29)
              {
                if (this.SubPartID[index1] == this.cancelid)
                {
                  windowReturnClass.AddCommand(6, 0);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                goto label_17;
              }
            }
            this.game.ProcessingObj.AttachUnit(this.attachButtonUnr[index2], this.game.EditObj.UnitSelected);
            this.View();
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
