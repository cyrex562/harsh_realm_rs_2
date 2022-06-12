// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PlaySecondMainWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Drawing;

namespace WindowsApplication1
{
  public class PlaySecondMainWindowClass : WindowClass
  {
    private int HexInfoId;
    private int hexinfoid2;
    private int MiniMapId;
    private int minwidth;
    private int detailnr;
    private int MapId;
    private ListClass MapListObj;
    private int b1id;

    public PlaySecondMainWindowClass(ref GameClass tGame, int tminwidth = 0)
      : base(ref tGame, 220, tGame.ScreenHeight - (305 + tminwidth), 8)
    {
      this.minwidth = tminwidth;
      this.detailnr = this.game.EditObj.MapSelected;
      this.MakeShit();
      this.mainframe = false;
    }

    public override void DoRefresh()
    {
      this.detailnr = this.game.EditObj.MapSelected;
      this.MakeShit();
    }

    public override string WindowDescription(int x, int y)
    {
      if (this.game.SelectX < 0 || this.game.Data.Turn == -1)
        return "";
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
          return this.MouseText[index];
      }
      return "";
    }

    public void PopUpRefresh() => this.MakeShit();

    public void MakeShit()
    {
      SizeF sizeF = new SizeF();
      bool flag;
      if (this.game.EditObj.OrderType == 14)
        flag = true;
      if (this.game.EditObj.OrderType == 15)
        flag = true;
      if (this.game.EditObj.OrderType == 2)
        flag = true;
      if (this.game.EditObj.OrderType == 12)
        flag = true;
      if (this.game.EditObj.OrderType == 11)
        flag = true;
      if (this.game.EditObj.OrderType == 13)
        flag = true;
      if (this.MapId > 0)
        this.RemoveSubPart(this.MapId);
      if (this.HexInfoId > 0)
        this.RemoveSubPart(this.HexInfoId);
      if (this.hexinfoid2 > 0)
        this.RemoveSubPart(this.hexinfoid2);
      if (this.b1id > 0)
      {
        this.RemoveSubPart(this.b1id);
        this.b1id = 0;
      }
      this.NewBackGroundAndClearAll(220, this.game.ScreenHeight - (305 + this.minwidth), -1);
      Graphics.FromImage((Image) this.OwnBitmap);
    }

    public void MakeShit0(Graphics g, int ty, bool Attack)
    {
    }

    public void MakeShit1(Graphics g, int ty)
    {
      Rectangle rect2;
      DrawMod.MakeFullBoxVic2(ref g, new Rectangle(10, ty + 161, 200, 14), "MINIMAP", rect2, "");
      if (this.MiniMapId > 0)
        this.RemoveSubPart(this.MiniMapId);
      SubPartClass tsubpart = (SubPartClass) new MiniMapPartClass(this.game, tx: 198, ty: 138);
      this.MiniMapId = this.AddSubPart(ref tsubpart, 11, ty + 176, 198, 138, 0);
      DrawMod.DrawRectangle(ref g, 10, ty + 175, 200, 140, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      if (this.game.Data.MapCounter <= 0)
        return;
      int num1 = -1;
      int num2 = -1;
      this.MapListObj = new ListClass();
      int mapCounter = this.game.Data.MapCounter;
      for (int tdata = 0; tdata <= mapCounter; ++tdata)
      {
        int num3 = 0;
        if (this.game.Data.Round == 0)
          num3 = 1;
        if (this.game.EditObj.OrderType < 1 & this.game.Data.MapObj[tdata].CanSee)
          num3 = 1;
        if (this.game.EditObj.OrderType < 1 & !this.game.Data.ShrowdOn)
          num3 = 1;
        if (this.game.EditObj.OrderType > 0 & this.game.Data.MapObj[tdata].TempCanSee)
          num3 = 1;
        if (num3 == 1)
        {
          ++num2;
          this.MapListObj.add(this.game.Data.MapObj[tdata].Name, tdata);
          if (this.detailnr == tdata)
            num1 = num2;
        }
      }
      ListClass mapListObj = this.MapListObj;
      int tlistselect = num1;
      GameClass game = this.game;
      ref Bitmap local1 = ref this.OwnBitmap;
      Font font = (Font) null;
      ref Font local2 = ref font;
      tsubpart = (SubPartClass) new ListSubPartClass(mapListObj, 6, 180, tlistselect, game, tHeader: "Maps", tbackbitmap: (ref local1), bbx: 10, bby: 355, overruleFont: (ref local2));
      this.MapId = this.AddSubPart(ref tsubpart, 10, 355, 120, 144, 0);
    }

    public void MakeShit2(Graphics g, int ty)
    {
      if (this.game.SelectX == -1 | this.game.SelectY == -1)
        return;
      int regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      int location = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (location == -1)
      {
        string str = "No location in hex";
        ref Graphics local = ref g;
        rectangle1 = new Rectangle(10, ty + 161, 200, 14);
        Rectangle rect1 = rectangle1;
        rectangle2 = new Rectangle(10, ty + 175, 200, 23);
        Rectangle rect2 = rectangle2;
        string txt2 = str;
        DrawMod.MakeFullBoxVic2(ref local, rect1, "LOCATION TYPE", rect2, txt2);
      }
      if (location <= -1)
        return;
      string name = this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].Name;
      ref Graphics local1 = ref g;
      rectangle2 = new Rectangle(10, ty + 161, 165, 14);
      Rectangle rect1_1 = rectangle2;
      rectangle1 = new Rectangle(10, ty + 175, 165, 23);
      Rectangle rect2_1 = rectangle1;
      string txt2_1 = name;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "LOCATION TYPE", rect2_1, txt2_1);
      SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("?", 30, "Get more information on selected landscape and/or location type", ref this.OwnBitmap, 180, ty + 175, theight: 25);
      this.b1id = this.AddSubPart(ref tsubpart, 180, ty + 175, 30, 25, 1);
      int people = this.game.Data.LocObj[location].People;
      int hq = this.game.Data.LocObj[location].HQ;
      string str1 = Strings.UCase(Strings.Left(this.game.Data.PeopleObj[people].Name, 3));
      ref Graphics local2 = ref g;
      rectangle2 = new Rectangle(10, ty + 203, 35, 14);
      Rectangle rect1_2 = rectangle2;
      rectangle1 = new Rectangle(10, ty + 217, 35, 23);
      Rectangle rect2_2 = rectangle1;
      string txt2_2 = str1;
      DrawMod.MakeFullBoxVic2(ref local2, rect1_2, "PPL", rect2_2, txt2_2);
      string str2 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_ReconPts(this.game.Data.Turn) <= 0 ? "? / " + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].StructuralPts)) : Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[location].StructuralPts)) + " / " + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].StructuralPts));
      ref Graphics local3 = ref g;
      rectangle2 = new Rectangle(55, ty + 203, 95, 14);
      Rectangle rect1_3 = rectangle2;
      rectangle1 = new Rectangle(55, ty + 217, 95, 23);
      Rectangle rect2_3 = rectangle1;
      string txt2_3 = str2;
      DrawMod.MakeFullBoxVic2(ref local3, rect1_3, "STRUCTURAL", rect2_3, txt2_3);
      string str3 = this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].AutoRecoverPts <= 0 ? "0" : "+" + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].AutoRecoverPts));
      ref Graphics local4 = ref g;
      rectangle2 = new Rectangle(160, ty + 203, 55, 14);
      Rectangle rect1_4 = rectangle2;
      rectangle1 = new Rectangle(160, ty + 217, 50, 23);
      Rectangle rect2_4 = rectangle1;
      string txt2_4 = str3;
      DrawMod.MakeFullBoxVic2(ref local4, rect1_4, "AUTOREP", rect2_4, txt2_4);
      if (!(!this.game.Data.FOWOn | this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[location].X, this.game.Data.LocObj[location].Y].Regime == this.game.Data.Turn | this.game.Data.Round == 0))
        return;
      string str4;
      if (this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].NoHQ)
      {
        str4 = "Needs no Hq";
        this.game.Data.LocObj[location].HQ = -1;
      }
      else
        str4 = hq <= -1 ? "No Hq" : this.game.Data.UnitObj[hq].Name;
      ref Graphics local5 = ref g;
      rectangle2 = new Rectangle(10, ty + 245, 200, 14);
      Rectangle rect1_5 = rectangle2;
      rectangle1 = new Rectangle(10, ty + 259, 200, 23);
      Rectangle rect2_5 = rectangle1;
      string txt2_5 = str4;
      DrawMod.MakeFullBoxVic2(ref local5, rect1_5, "HQ", rect2_5, txt2_5);
      int index1 = 0;
      do
      {
        float Number = 0.0f;
        if (this.game.Data.LocObj[location].Production[index1] > -1)
        {
          int index2 = this.game.Data.LocObj[location].Production[index1];
          string Left = Strings.Left(this.game.Data.ItemTypeObj[index2].Name, 12);
          if (this.game.Data.ItemTypeObj[index2].IsSupply)
            Left = "Supplies";
          if (this.game.Data.ItemTypeObj[index2].IsResPt)
            Left = "Political";
          if (this.game.Data.ItemTypeObj[index2].IsSFType > -1)
            Left = Strings.Left(this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[index2].IsSFType].Name, 12);
          Number = Conversions.ToSingle(Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[location].TempProdPredict[index1])));
          if (Operators.CompareString(Left, "Supplies", false) == 0)
            Number = Conversion.Int(Number);
          str4 = Strings.Trim(Conversion.Str((object) Number)) + "x " + Left;
        }
        if ((double) Number <= 0.0)
          str4 = "";
        if (index1 == 0)
        {
          ref Graphics local6 = ref g;
          rectangle2 = new Rectangle(10, ty + 287, 200, 14);
          Rectangle rect1_6 = rectangle2;
          rectangle1 = new Rectangle(10, ty + 301, 200, 23);
          Rectangle rect2_6 = rectangle1;
          string txt2_6 = str4;
          DrawMod.MakeFullBoxVic2(ref local6, rect1_6, "PRODUCTION SLOTS", rect2_6, txt2_6);
        }
        Rectangle rectangle3;
        if (index1 == 2)
        {
          ref Graphics local7 = ref g;
          Rectangle rect1_7 = rectangle3;
          rectangle2 = new Rectangle(10, ty + 357, 200, 23);
          Rectangle rect2_7 = rectangle2;
          string txt2_7 = str4;
          DrawMod.MakeFullBoxVic2(ref local7, rect1_7, "", rect2_7, txt2_7);
        }
        if (index1 == 1)
        {
          ref Graphics local8 = ref g;
          Rectangle rect1_8 = rectangle3;
          rectangle2 = new Rectangle(10, ty + 329, 200, 23);
          Rectangle rect2_8 = rectangle2;
          string txt2_8 = str4;
          DrawMod.MakeFullBoxVic2(ref local8, rect1_8, "", rect2_8, txt2_8);
        }
        if (index1 == 3)
        {
          ref Graphics local9 = ref g;
          Rectangle rect1_9 = rectangle3;
          rectangle2 = new Rectangle(10, ty + 385, 200, 23);
          Rectangle rect2_9 = rectangle2;
          string txt2_9 = str4;
          DrawMod.MakeFullBoxVic2(ref local9, rect1_9, "", rect2_9, txt2_9);
        }
        ++index1;
      }
      while (index1 <= 3);
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width)
        {
          int num = y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height ? 1 : 0;
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num = this.SubPartID[index];
            if (num == this.b1id)
            {
              this.game.EditObj.LocTypeSelected = -1;
              this.game.EditObj.PopupValue = 12;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num == this.MiniMapId)
            {
              int selectX = this.game.SelectX;
              int selectY = this.game.SelectY;
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.MakeShit();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
            }
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
