// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PlayMainWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class PlayMainWindowClass : WindowClass
  {
    private int HexInfoId;
    private int hexinfoid2;
    private int MiniMapId;
    private int minwidth;
    private int detailnr;
    private int MapId;
    private ListClass MapListObj;
    private int b1id;
    private int b2id;
    private int view1id;
    private int view2id;
    private int view3id;

    public PlayMainWindowClass(ref GameClass tGame, int tminwidth = 0)
      : base(ref tGame, 220, tGame.ScreenHeight - (270 + tminwidth), 8)
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

    public void PopUpRefresh() => this.MakeShit();

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

    public void MakeShit()
    {
      SizeF sizeF = new SizeF();
      bool Attack;
      if (this.game.EditObj.OrderType == 14)
        Attack = true;
      if (this.game.EditObj.OrderType == 15)
        Attack = true;
      if (this.game.EditObj.OrderType == 2)
        Attack = true;
      if (this.game.EditObj.OrderType == 12)
        Attack = true;
      if (this.game.EditObj.OrderType == 11)
        Attack = true;
      if (this.game.EditObj.OrderType == 13)
        Attack = true;
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
      if (this.b2id > 0)
      {
        this.RemoveSubPart(this.b2id);
        this.b2id = 0;
      }
      this.NewBackGroundAndClearAll(220, this.game.ScreenHeight - (270 + this.minwidth), -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      int ty = 70;
      int h1 = this.game.ScreenHeight - (270 + this.minwidth);
      this.ClearMouse();
      if (this.game.Data.Round == 0)
        this.game.Data.Turn = -1;
      string str;
      if (this.game.Data.Turn > -1)
      {
        str = this.game.Data.RegimeObj[this.game.Data.Turn].Name;
      }
      else
      {
        str = "Editor";
        DrawMod.DrawTextVic2(ref graphics, "Editor", this.game.VicFont1, 10, 1, this.game.VicColor2, this.game.VicColor1Shade);
      }
      if (this.game.Data.Round > 0)
      {
        DrawMod.DrawBlock(ref graphics, 0, 0, 5, h1, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        DrawMod.DrawBlock(ref graphics, 5, 0, 220, 34, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        DrawMod.DrawBlock(ref graphics, 5, ty + 114, 220, 34, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        int h2 = h1 - (ty + 426);
        DrawMod.DrawBlock(ref graphics, 5, ty + 426, 220, h2, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        DrawMod.drawLine(ref graphics, 0, 34, 0, this.game.ScreenHeight - 265, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref graphics, 5, 34, 218, 34, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref graphics, 4, 34, 4, ty + 114, 50, 50, 50, (int) byte.MaxValue);
        DrawMod.drawLine(ref graphics, 5, 34, 5, ty + 114, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref graphics, 5, ty + 114, 218, ty + 114, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref graphics, 5, ty + 148, 218, ty + 148, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref graphics, 5, ty + 426, 218, ty + 426, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref graphics, 4, ty + 148, 4, ty + 426, 50, 50, 50, (int) byte.MaxValue);
        DrawMod.drawLine(ref graphics, 5, ty + 148, 5, ty + 426, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
      }
      int num1 = ty + 130;
      if (this.game.Data.Round == 0)
      {
        ty = -80;
        num1 = 120;
      }
      if (this.view1id > 0)
      {
        this.RemoveSubPart(this.view1id);
        this.view1id = 0;
      }
      if (this.view2id > 0)
      {
        this.RemoveSubPart(this.view2id);
        this.view2id = 0;
      }
      if (this.view3id > 0)
      {
        this.RemoveSubPart(this.view3id);
        this.view3id = 0;
      }
      int num2 = 190;
      if (this.game.Data.Round == 0)
        num2 = 35;
      if (this.game.Data.Round == 0)
      {
        SubPartClass tsubpart1 = (SubPartClass) new TextButtonPartClass("Hex", 70, "Click here to view info on the hex", ref this.OwnBitmap, 5, num2, tred: (this.game.EditObj.SetViewMode == 0), theight: 26);
        this.view1id = this.AddSubPart(ref tsubpart1, 5, num2, 70, 26, 1);
        SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass("Loc", 70, "Click here to view info on the location. If no location is present hex info is shown.", ref this.OwnBitmap, 75, num2, tred: (this.game.EditObj.SetViewMode == 2), theight: 26);
        this.view2id = this.AddSubPart(ref tsubpart2, 75, num2, 70, 26, 1);
        if (this.game.ScreenHeight <= 928)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("Map", 70, "Click here to view the minimap.", ref this.OwnBitmap, 145, num2, tred: (this.game.EditObj.SetViewMode == 1), theight: 26);
          this.view3id = this.AddSubPart(ref tsubpart3, 145, num2, 70, 26, 1);
        }
      }
      else
      {
        SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("Hex", 70, "Click here to view info on the hex", ref this.OwnBitmap, 40, num2, tred: (this.game.EditObj.SetViewMode == 0), theight: 26);
        this.view1id = this.AddSubPart(ref tsubpart4, 40, num2, 70, 26, 1);
        SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass("Loc", 70, "Click here to view info on the location. If no location is present hex info is shown.", ref this.OwnBitmap, 120, num2, tred: (this.game.EditObj.SetViewMode == 2), theight: 26);
        this.view2id = this.AddSubPart(ref tsubpart5, 120, num2, 70, 26, 1);
      }
      if (this.game.Data.Round > 0)
      {
        int hqSpriteNr = this.game.Data.RegimeObj[this.game.Data.Turn].HQSpriteNr;
        str = this.game.Data.PeopleObj[this.game.Data.RegimeObj[this.game.Data.Turn].People].Name;
        Rectangle paintedPartRect = DrawMod.GetPaintedPartRect(BitmapStore.GetBitmap(hqSpriteNr, 1));
        ref Graphics local1 = ref graphics;
        Bitmap bitmap1 = BitmapStore.GetBitmap(hqSpriteNr, 1);
        ref Bitmap local2 = ref bitmap1;
        Rectangle srcrect = paintedPartRect;
        Rectangle rectangle = new Rectangle(89, 12, 38, 28);
        Rectangle destrect = rectangle;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        rectangle = new Rectangle(80, 9, 53, 36);
        Rectangle trect = rectangle;
        this.AddMouse(ref trect, "", "The current turn is to " + this.game.Data.RegimeObj[this.game.Data.Turn].Name + ". Click to change the color of the regime.", 1);
        ref Graphics local3 = ref graphics;
        Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.ORNAMENT1);
        ref Bitmap local4 = ref bitmap2;
        DrawMod.DrawSimple(ref local3, ref local4, 10, 5);
        if (this.MiniMapId > 0)
          this.RemoveSubPart(this.MiniMapId);
        SubPartClass tsubpart = (SubPartClass) new MiniMapPartClass(this.game, tx: 198, ty: 133);
        this.MiniMapId = this.AddSubPart(ref tsubpart, 11, 45, 198, 133, 0);
        DrawMod.DrawRectangle(ref graphics, 10, 44, 200, 135, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      }
      else
        str = "Editor";
      if (this.game.SelectX == -1)
      {
        this.game.SelectX = 0;
        this.game.SelectY = 0;
      }
      if (this.game.EditObj.Layout == 0 | this.game.Data.Round == 0)
      {
        if (this.game.EditObj.SetViewMode == 0 | this.game.EditObj.SetViewMode == 2 & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location == -1 | this.game.EditObj.SetViewMode == 2 & Attack)
          this.MakeShit0(graphics, ty, Attack);
        else if (this.game.EditObj.SetViewMode == 1)
          this.MakeShit1(graphics, ty);
        else if (this.game.EditObj.SetViewMode == 2)
          this.MakeShit2(graphics, ty);
      }
      else if (this.game.EditObj.Layout != 1)
        ;
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    public void MakeShit0(Graphics g, int ty, bool Attack)
    {
      if (this.game.SelectX == -1 | this.game.SelectY == -1)
        return;
      int regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      int location1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      string str1 = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType].Name;
      if (location1 > -1)
        str1 = str1 + ", " + this.game.Data.LocTypeObj[this.game.Data.LocObj[location1].Type].Name;
      string str2;
      int num1;
      if (this.game.Data.Round > 0 && this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_SeeNow(this.game.Data.Turn) < 1)
      {
        str2 = "Shrouded (" + Conversion.Str((object) this.game.SelectX) + "," + Conversion.Str((object) this.game.SelectY) + ")";
        str1 = "Unkown type";
        num1 = 1;
      }
      int num2 = 0;
      if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
        num2 = 1;
      if (this.game.Data.Round != 0 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon > 0)
        num2 = 1;
      if (!this.game.Data.FOWOn)
        num2 = 1;
      if (this.game.Data.Round == 0)
        num2 = 1;
      string str3;
      if (num1 == 0)
      {
        str3 = "";
        if (Information.IsNothing((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Name))
          this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Name = "";
        if (location1 > -1)
          str2 = this.game.Data.LocObj[location1].Name + " " + "(" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + ", " + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ")";
        else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Name.Length > 0)
          str2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Name + " " + "(" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + ", " + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ")";
        else
          str2 = "(" + Strings.Trim(Conversion.Str((object) this.game.SelectX)) + ", " + Strings.Trim(Conversion.Str((object) this.game.SelectY)) + ")";
      }
      if ((double) this.game.Data.RuleVar[900] == 1.0)
        str2 = str2 + ", rec=" + Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon);
      ty -= 5;
      Rectangle rectangle;
      Rectangle trect;
      if (num1 == 0)
      {
        int index = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
        if (this.game.Data.Round > 0 && this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_SeeNow(this.game.Data.Turn) < 1)
          index = -2;
        if (index > -1)
        {
          int hqSpriteNr = this.game.Data.RegimeObj[index].HQSpriteNr;
          ref Graphics local1 = ref g;
          Rectangle rect1 = new Rectangle(10, ty + 161, 200, 14);
          rectangle = new Rectangle(10, ty + 175, 200, 26);
          Rectangle rect2 = rectangle;
          string txt2 = "        " + str2;
          DrawMod.MakeFullBoxVic2(ref local1, rect1, "SELECTED HEX", rect2, txt2);
          Rectangle paintedPartRect = DrawMod.GetPaintedPartRect(BitmapStore.GetBitmap(hqSpriteNr));
          ref Graphics local2 = ref g;
          Bitmap bitmap = BitmapStore.GetBitmap(hqSpriteNr);
          ref Bitmap local3 = ref bitmap;
          Rectangle srcrect = paintedPartRect;
          rectangle = new Rectangle(15, ty + 179, 26, 20);
          Rectangle destrect = rectangle;
          DrawMod.DrawSimplePart2(ref local2, ref local3, srcrect, destrect);
        }
        else
        {
          ref Graphics local = ref g;
          rectangle = new Rectangle(10, ty + 161, 200, 14);
          Rectangle rect1 = rectangle;
          trect = new Rectangle(10, ty + 175, 200, 26);
          Rectangle rect2 = trect;
          string txt2 = str2;
          DrawMod.MakeFullBoxVic2(ref local, rect1, "SELECTED HEX", rect2, txt2);
        }
      }
      else
      {
        ref Graphics local = ref g;
        rectangle = new Rectangle(10, ty + 161, 200, 14);
        Rectangle rect1 = rectangle;
        trect = new Rectangle(10, ty + 175, 200, 26);
        Rectangle rect2 = trect;
        string txt2 = str2;
        DrawMod.MakeFullBoxVic2(ref local, rect1, "SELECTED HEX", rect2, txt2);
      }
      rectangle = new Rectangle(10, ty + 161, 200, 40);
      trect = rectangle;
      this.AddMouse(ref trect, "", "The hex owners flag, coordinate and if applicable the name of the hex. If location is present you can rename it by clicking.", 2);
      ty += 5;
      string str4 = str1;
      int landscapeType;
      int spriteNr;
      SubPartClass tsubpart;
      if (num1 == 0)
      {
        landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].LandscapeType;
        spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].SpriteNr;
        location1 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
        if (landscapeType > -1 & spriteNr > -1)
        {
          tsubpart = (SubPartClass) new ATHexSubPartClass(this.game.SelectX, this.game.SelectY, this.game, true);
          this.HexInfoId = this.AddSubPart(ref tsubpart, 10, ty + 203, 200, 82, 0);
        }
      }
      if (Attack & this.game.Data.Round > 0)
      {
        int num3 = 0;
        string name = this.game.Data.LandscapeTypeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].LandscapeType].Name;
        string str5;
        if (location1 > -1)
          str5 = name + ", " + this.game.Data.LocTypeObj[this.game.Data.LocObj[location1].Type].Name;
        if (this.game.Data.Round > 0 && this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].get_SeeNow(this.game.Data.Turn) < 1)
        {
          str4 = "Shrouded (" + Conversion.Str((object) this.game.EditObj.TargetX) + "," + Conversion.Str((object) this.game.EditObj.TargetY) + ")";
          str5 = "Unkown type";
          num3 = 1;
        }
        if (num3 == 0)
        {
          str3 = "";
          int location2 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Location;
          if (Information.IsNothing((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Name))
            this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Name = "";
          if (location2 > -1)
            str4 = this.game.Data.LocObj[location2].Name + " " + "(" + Strings.Trim(Conversion.Str((object) this.game.EditObj.TargetX)) + ", " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TargetY)) + ")";
          else if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Name.Length > 0)
            str4 = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.EditObj.TargetX, this.game.EditObj.TargetY].Name + " " + "(" + Strings.Trim(Conversion.Str((object) this.game.EditObj.TargetX)) + ", " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TargetY)) + ")";
          else
            str4 = Strings.Trim(Conversion.Str((object) this.game.EditObj.TargetX)) + ", " + Strings.Trim(Conversion.Str((object) this.game.EditObj.TargetY));
        }
        ref Graphics local = ref g;
        rectangle = new Rectangle(10, ty + 290, 200, 14);
        Rectangle rect1 = rectangle;
        trect = new Rectangle(10, ty + 304, 200, 23);
        Rectangle rect2 = trect;
        string txt2 = str4;
        DrawMod.MakeFullBoxVic2(ref local, rect1, "TARGET HEX", rect2, txt2);
        rectangle = new Rectangle(10, ty + 290, 200, 40);
        trect = rectangle;
        this.AddMouse(ref trect, "", "The hex you are in the process of attacking. Shown below are units selected to participate in attack as well as known defenders.");
        if (!(landscapeType > -1 & spriteNr > -1))
          return;
        tsubpart = (SubPartClass) new ATHexSubPartClass(this.game.SelectX, this.game.SelectY, this.game);
        this.hexinfoid2 = this.AddSubPart(ref tsubpart, 10, ty + 332, 200, 82, 0);
      }
      else
      {
        if (num1 == 0)
        {
          ref Graphics local4 = ref g;
          rectangle = new Rectangle(10, ty + 290, 170, 14);
          Rectangle rect1_1 = rectangle;
          trect = new Rectangle(10, ty + 304, 170, 23);
          Rectangle rect2_1 = trect;
          string txt2_1 = str1;
          DrawMod.MakeFullBoxVic2(ref local4, rect1_1, "LANDSCAPE TYPE", rect2_1, txt2_1);
          ty -= 4;
          string str6 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].VP));
          ref Graphics local5 = ref g;
          rectangle = new Rectangle(10, ty + 335, 35, 14);
          Rectangle rect1_2 = rectangle;
          trect = new Rectangle(10, ty + 349, 35, 23);
          Rectangle rect2_2 = trect;
          string txt2_2 = str6;
          DrawMod.MakeFullBoxVic2(ref local5, rect1_2, "VP", rect2_2, txt2_2);
          rectangle = new Rectangle(10, ty + 335, 35, 40);
          trect = rectangle;
          this.AddMouse(ref trect, "", "Victory Points");
          if (this.game.Data.Turn > -1)
          {
            string str7 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon));
            if ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < (double) this.game.Data.RuleVar[55])
            {
              ref Graphics local6 = ref g;
              rectangle = new Rectangle(65, ty + 335, 35, 14);
              Rectangle rect1_3 = rectangle;
              trect = new Rectangle(65, ty + 349, 35, 23);
              Rectangle rect2_3 = trect;
              string txt2_3 = str7;
              DrawMod.MakeFullBoxVic2(ref local6, rect1_3, "REC", rect2_3, txt2_3);
            }
            else if ((double) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].MaxRecon < (double) this.game.Data.RuleVar[56])
            {
              ref Graphics local7 = ref g;
              rectangle = new Rectangle(65, ty + 335, 35, 14);
              Rectangle rect1_4 = rectangle;
              trect = new Rectangle(65, ty + 349, 35, 23);
              Rectangle rect2_4 = trect;
              string txt2_4 = str7;
              DrawMod.MakeFullBoxVic2(ref local7, rect1_4, "REC", rect2_4, txt2_4);
            }
            else
            {
              ref Graphics local8 = ref g;
              rectangle = new Rectangle(65, ty + 335, 35, 14);
              Rectangle rect1_5 = rectangle;
              trect = new Rectangle(65, ty + 349, 35, 23);
              Rectangle rect2_5 = trect;
              string txt2_5 = str7;
              DrawMod.MakeFullBoxVic2(ref local8, rect1_5, "REC", rect2_5, txt2_5);
            }
          }
          rectangle = new Rectangle(65, ty + 335, 35, 40);
          trect = rectangle;
          this.AddMouse(ref trect, "", "Recon Points");
          if (this.game.Data.Turn > -1)
          {
            string str8 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_ZocPts(this.game.Data.Turn)));
            ref Graphics local9 = ref g;
            rectangle = new Rectangle(120, ty + 335, 35, 14);
            Rectangle rect1_6 = rectangle;
            trect = new Rectangle(120, ty + 349, 35, 23);
            Rectangle rect2_6 = trect;
            string txt2_6 = str8;
            DrawMod.MakeFullBoxVic2(ref local9, rect1_6, "ZOC", rect2_6, txt2_6);
          }
          rectangle = new Rectangle(120, ty + 335, 35, 40);
          trect = rectangle;
          this.AddMouse(ref trect, "", "Zone of Control Points");
          string str9;
          if (num2 == 1)
          {
            str9 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetHexStackPts(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected)));
            if (this.game.Data.FOWOn)
            {
              if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime, this.game.Data.Turn))
                str9 = "?";
              if (this.game.EditObj.UnitSelected > -1 && !this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn))
                str9 = "?";
            }
          }
          else
            str9 = "?";
          ref Graphics local10 = ref g;
          rectangle = new Rectangle(10, ty + 377, 35, 14);
          Rectangle rect1_7 = rectangle;
          trect = new Rectangle(10, ty + 390, 35, 23);
          Rectangle rect2_7 = trect;
          string txt2_7 = str9;
          DrawMod.MakeFullBoxVic2(ref local10, rect1_7, "STK", rect2_7, txt2_7);
          rectangle = new Rectangle(10, ty + 377, 35, 40);
          trect = rectangle;
          this.AddMouse(ref trect, "", "Stack Points");
          if (this.game.Data.Turn > -1)
          {
            int Number = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_APPenalty(this.game.Data.Turn) + this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattlePenalty(this.game.Data.Turn);
            string str10 = Strings.Trim(Conversion.Str((object) Number));
            if (0 > Number)
              str10 = "-" + str10;
            ref Graphics local11 = ref g;
            rectangle = new Rectangle(65, ty + 377, 45, 14);
            Rectangle rect1_8 = rectangle;
            trect = new Rectangle(65, ty + 390, 35, 23);
            Rectangle rect2_8 = trect;
            string txt2_8 = str10;
            DrawMod.MakeFullBoxVic2(ref local11, rect1_8, "+AP", rect2_8, txt2_8);
            rectangle = new Rectangle(65, ty + 377, 45, 40);
            trect = rectangle;
            this.AddMouse(ref trect, "", "Action Point Penalty (for entering hex)");
            string str11 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStack(this.game.Data.Turn)));
            ref Graphics local12 = ref g;
            rectangle = new Rectangle(120, ty + 377, 45, 14);
            Rectangle rect1_9 = rectangle;
            trect = new Rectangle(120, ty + 390, 35, 23);
            Rectangle rect2_9 = trect;
            string txt2_9 = str11;
            DrawMod.MakeFullBoxVic2(ref local12, rect1_9, "BSLND", rect2_9, txt2_9);
            rectangle = new Rectangle(120, ty + 377, 45, 40);
            trect = rectangle;
            this.AddMouse(ref trect, "", "Battlestack points for regular land combat");
            string str12 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStackArt(this.game.Data.Turn)));
            ref Graphics local13 = ref g;
            rectangle = new Rectangle(175, ty + 335, 45, 14);
            Rectangle rect1_10 = rectangle;
            trect = new Rectangle(175, ty + 348, 35, 23);
            Rectangle rect2_10 = trect;
            string txt2_10 = str12;
            DrawMod.MakeFullBoxVic2(ref local13, rect1_10, "BSART", rect2_10, txt2_10);
            rectangle = new Rectangle(175, ty + 335, 45, 40);
            trect = rectangle;
            this.AddMouse(ref trect, "", "Battlestack points for artillery barrages");
            string str13 = Strings.Trim(Conversion.Str((object) this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_BattleStackAir(this.game.Data.Turn)));
            ref Graphics local14 = ref g;
            rectangle = new Rectangle(175, ty + 377, 45, 14);
            Rectangle rect1_11 = rectangle;
            trect = new Rectangle(175, ty + 390, 35, 23);
            Rectangle rect2_11 = trect;
            string txt2_11 = str13;
            DrawMod.MakeFullBoxVic2(ref local14, rect1_11, "BSAIR", rect2_11, txt2_11);
            rectangle = new Rectangle(175, ty + 377, 45, 40);
            trect = rectangle;
            this.AddMouse(ref trect, "", "Battlestack points for air to ground attacks");
          }
        }
        if (!(this.game.Data.Round == 0 & this.game.ScreenHeight > 928))
          return;
        if (this.MiniMapId > 0)
          this.RemoveSubPart(this.MiniMapId);
        tsubpart = (SubPartClass) new MiniMapPartClass(this.game, tx: 198, ty: 133);
        this.MiniMapId = this.AddSubPart(ref tsubpart, 11, DrawMod.TGame.ScreenHeight - 370 - 160, 198, 133, 0);
        DrawMod.DrawRectangle(ref g, 10, ty + 161 - 1, 200, 135, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      }
    }

    public void MakeShit1(Graphics g, int ty)
    {
      if (this.MiniMapId > 0)
        this.RemoveSubPart(this.MiniMapId);
      SubPartClass tsubpart1 = (SubPartClass) new MiniMapPartClass(this.game, tx: 198, ty: 133);
      this.MiniMapId = this.AddSubPart(ref tsubpart1, 11, ty + 161, 198, 133, 0);
      DrawMod.DrawRectangle(ref g, 10, ty + 161 - 1, 200, 135, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
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
      SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(mapListObj, 6, 180, tlistselect, game, tHeader: "Maps", tbackbitmap: (ref local1), bbx: 10, bby: 355, overruleFont: (ref local2));
      this.MapId = this.AddSubPart(ref tsubpart2, 10, 355, 120, 144, 0);
    }

    public void MakeShit2(Graphics g, int ty)
    {
      if (this.game.SelectX == -1 | this.game.SelectY == -1)
        return;
      int regime = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime;
      int location = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
      if (this.game.Data.Round > 0 && this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].get_SeeNow(this.game.Data.Turn) < 1)
      {
        bool Attack;
        if (this.game.EditObj.OrderType == 14)
          Attack = true;
        if (this.game.EditObj.OrderType == 15)
          Attack = true;
        if (this.game.EditObj.OrderType == 2)
          Attack = true;
        if (this.game.EditObj.OrderType == 12)
          Attack = true;
        if (this.game.EditObj.OrderType == 11)
          Attack = true;
        if (this.game.EditObj.OrderType == 13)
          Attack = true;
        this.MakeShit0(g, ty, Attack);
      }
      else
      {
        if (location > -1)
        {
          string name = this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].Name;
          ref Graphics local1 = ref g;
          Rectangle rectangle1 = new Rectangle(10, ty + 161, 160, 14);
          Rectangle rect1_1 = rectangle1;
          Rectangle rectangle2 = new Rectangle(10, ty + 175, 160, 23);
          Rectangle rect2_1 = rectangle2;
          string txt2_1 = name;
          DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "LOCATION TYPE", rect2_1, txt2_1);
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
          rectangle2 = new Rectangle(10, ty + 203, 35, 40);
          Rectangle trect = rectangle2;
          this.AddMouse(ref trect, "", "People that live/work in the location");
          if (this.game.Data.Turn > -1)
          {
            string str2 = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].get_ReconPts(this.game.Data.Turn) <= 0 ? "? / " + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].StructuralPts)) : Strings.Trim(Conversion.Str((object) this.game.Data.LocObj[location].StructuralPts)) + " / " + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].StructuralPts));
            ref Graphics local3 = ref g;
            rectangle2 = new Rectangle(55, ty + 203, 95, 14);
            Rectangle rect1_3 = rectangle2;
            trect = new Rectangle(55, ty + 217, 95, 23);
            Rectangle rect2_3 = trect;
            string txt2_3 = str2;
            DrawMod.MakeFullBoxVic2(ref local3, rect1_3, "STRUCTURAL", rect2_3, txt2_3);
            rectangle2 = new Rectangle(55, ty + 203, 95, 40);
            trect = rectangle2;
            this.AddMouse(ref trect, "", "Structural points the location currently has / can maximum have");
          }
          string str3 = this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].AutoRecoverPts <= 0 ? "0" : "+" + Strings.Trim(Conversion.Str((object) this.game.Data.LocTypeObj[this.game.Data.LocObj[location].Type].AutoRecoverPts));
          ref Graphics local4 = ref g;
          rectangle2 = new Rectangle(160, ty + 203, 55, 14);
          Rectangle rect1_4 = rectangle2;
          trect = new Rectangle(160, ty + 217, 50, 23);
          Rectangle rect2_4 = trect;
          string txt2_4 = str3;
          DrawMod.MakeFullBoxVic2(ref local4, rect1_4, "AUTOREP", rect2_4, txt2_4);
          rectangle2 = new Rectangle(160, ty + 203, 55, 40);
          trect = rectangle2;
          this.AddMouse(ref trect, "", "Number of autorepair points that are applied to the location each round");
          if (!this.game.Data.FOWOn | this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[location].X, this.game.Data.LocObj[location].Y].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
          {
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
            trect = new Rectangle(10, ty + 259, 200, 23);
            Rectangle rect2_5 = trect;
            string txt2_5 = str4;
            DrawMod.MakeFullBoxVic2(ref local5, rect1_5, "HQ", rect2_5, txt2_5);
            rectangle2 = new Rectangle(10, ty + 245, 200, 40);
            trect = rectangle2;
            this.AddMouse(ref trect, "", "The HQ that the location tries to deliver its production too");
            int prodslot = 0;
            do
            {
              float Number = 0.0f;
              if (this.game.Data.LocObj[location].Production[prodslot] > -1)
              {
                int index = this.game.Data.LocObj[location].Production[prodslot];
                string Left = Strings.Left(this.game.Data.ItemTypeObj[index].Name, 12);
                if (this.game.Data.ItemTypeObj[index].IsSupply)
                  Left = "Supplies";
                if (this.game.Data.ItemTypeObj[index].IsResPt)
                  Left = "Political";
                if (this.game.Data.ItemTypeObj[index].IsSFType > -1)
                  Left = Strings.Left(this.game.Data.SFTypeObj[this.game.Data.ItemTypeObj[index].IsSFType].Name, 12);
                Number = (float) this.game.HandyFunctionsObj.GetEstimatedProduction(prodslot, location, true, false, true);
                if (Operators.CompareString(Left, "Supplies", false) == 0)
                  Number = Conversion.Int(Number);
                str4 = Strings.Trim(Conversion.Str((object) Number)) + "x " + Left;
              }
              if ((double) Number <= 0.0)
                str4 = "";
              if (prodslot == 0)
              {
                ref Graphics local6 = ref g;
                rectangle2 = new Rectangle(10, ty + 287, 200, 14);
                Rectangle rect1_6 = rectangle2;
                trect = new Rectangle(10, ty + 301, 200, 23);
                Rectangle rect2_6 = trect;
                string txt2_6 = str4;
                DrawMod.MakeFullBoxVic2(ref local6, rect1_6, "PRODUCTION SLOTS", rect2_6, txt2_6);
              }
              rectangle2 = new Rectangle(10, ty + 301, 200, 23);
              trect = rectangle2;
              this.AddMouse(ref trect, "", "Production slot #1");
              Rectangle rectangle3;
              if (prodslot == 2)
              {
                ref Graphics local7 = ref g;
                Rectangle rect1_7 = rectangle3;
                rectangle2 = new Rectangle(10, ty + 357, 200, 23);
                Rectangle rect2_7 = rectangle2;
                string txt2_7 = str4;
                DrawMod.MakeFullBoxVic2(ref local7, rect1_7, "", rect2_7, txt2_7);
              }
              rectangle2 = new Rectangle(10, ty + 357, 200, 23);
              trect = rectangle2;
              this.AddMouse(ref trect, "", "Production slot #3");
              if (prodslot == 1)
              {
                ref Graphics local8 = ref g;
                Rectangle rect1_8 = rectangle3;
                rectangle2 = new Rectangle(10, ty + 329, 200, 23);
                Rectangle rect2_8 = rectangle2;
                string txt2_8 = str4;
                DrawMod.MakeFullBoxVic2(ref local8, rect1_8, "", rect2_8, txt2_8);
              }
              rectangle2 = new Rectangle(10, ty + 329, 200, 23);
              trect = rectangle2;
              this.AddMouse(ref trect, "", "Production slot #2");
              if (prodslot == 3)
              {
                ref Graphics local9 = ref g;
                Rectangle rect1_9 = rectangle3;
                rectangle2 = new Rectangle(10, ty + 385, 200, 23);
                Rectangle rect2_9 = rectangle2;
                string txt2_9 = str4;
                DrawMod.MakeFullBoxVic2(ref local9, rect1_9, "", rect2_9, txt2_9);
              }
              rectangle2 = new Rectangle(10, ty + 385, 200, 23);
              trect = rectangle2;
              this.AddMouse(ref trect, "", "Production slot #4");
              ++prodslot;
            }
            while (prodslot <= 3);
          }
        }
        if (!(this.game.Data.Round == 0 & this.game.ScreenHeight > 928))
          return;
        if (this.MiniMapId > 0)
          this.RemoveSubPart(this.MiniMapId);
        SubPartClass tsubpart = (SubPartClass) new MiniMapPartClass(this.game, tx: 198, ty: 133);
        this.MiniMapId = this.AddSubPart(ref tsubpart, 11, DrawMod.TGame.ScreenHeight - 370 - 160, 198, 133, 0);
        DrawMod.DrawRectangle(ref g, 10, ty + 161 - 1, 200, 135, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
      }
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] == 1)
          {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.RegimeObj[this.game.Data.Turn].Red, this.game.Data.RegimeObj[this.game.Data.Turn].Green, this.game.Data.RegimeObj[this.game.Data.Turn].Blue);
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
              this.game.Data.RegimeObj[this.game.Data.Turn].Blue = (int) colorDialog.Color.B;
              this.game.Data.RegimeObj[this.game.Data.Turn].Green = (int) colorDialog.Color.G;
              this.game.Data.RegimeObj[this.game.Data.Turn].Red = (int) colorDialog.Color.R;
            }
            this.game.Data.RegimeObj[this.game.Data.Turn].DoTempCounter();
            this.game.Data.RegimeObj[this.game.Data.Turn].DoTempCounterBig();
            this.game.Data.RegimeObj[this.game.Data.Turn].DoTempCounterSmall();
            this.MakeShit();
            windowReturnClass.AddCommand(4, 12);
            windowReturnClass.AddCommand(4, 20);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[index] == 2 && this.game.SelectX > -1 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn)
          {
            int location = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location;
            if (location > -1)
            {
              string str = Interaction.InputBox("Give New Name for Location", "Rename", this.game.Data.LocObj[location].Name);
              if ((double) this.game.Data.RuleVar[419] > 0.0 & Operators.CompareString(Strings.Trim(str), "", false) != 0)
              {
                this.game.HandyFunctionsObj.MakeSpecificAutoLabels(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, (int) Math.Round((double) this.game.Data.RuleVar[419]), Strings.Space(Strings.Len(this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Name)), true);
                this.game.HandyFunctionsObj.MakeSpecificAutoLabels(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, (int) Math.Round((double) this.game.Data.RuleVar[419]), str, true);
              }
              if (Operators.CompareString(Strings.Trim(str), "", false) != 0)
                this.game.Data.LocObj[location].Name = str;
              this.MakeShit();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
      }
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.view1id)
            {
              this.game.EditObj.SetViewMode = 0;
              if (this.MiniMapId > 0)
              {
                this.RemoveSubPart(this.MiniMapId);
                this.MiniMapId = 0;
              }
              this.MakeShit();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.view2id)
            {
              this.game.EditObj.SetViewMode = 2;
              if (this.MiniMapId > 0)
              {
                this.RemoveSubPart(this.MiniMapId);
                this.MiniMapId = 0;
              }
              this.MakeShit();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.view3id)
            {
              this.game.EditObj.SetViewMode = 1;
              if (this.MiniMapId > 0)
              {
                this.RemoveSubPart(this.MiniMapId);
                this.MiniMapId = 0;
              }
              this.MakeShit();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b1id)
            {
              this.game.EditObj.LocTypeSelected = -1;
              this.game.EditObj.PopupValue = 12;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b2id)
            {
              this.game.EditObj.PeopleSelected = this.game.Data.RegimeObj[this.game.Data.Turn].People;
              this.game.EditObj.PopupValue = 13;
              this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
              windowReturnClass.AddCommand(5, 10);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            int selectX;
            int selectY;
            if (num1 == this.MiniMapId)
            {
              selectX = this.game.SelectX;
              selectY = this.game.SelectY;
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.MakeShit();
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.SetFlag(true);
            }
            else
            {
              if (num1 == this.MapId)
              {
                int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                if (num2 > -1)
                {
                  this.detailnr = num2;
                  this.game.EditObj.MapSelected = num2;
                  this.game.CornerX = 0;
                  this.game.CornerY = 0;
                  this.game.SelectX = 0;
                  this.game.SelectY = 0;
                  this.game.EditObj.UnitSelected = -1;
                  this.game.EditObj.TempCoordList = new CoordList();
                  this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 200, 150, false);
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.AddCommand(4, 20);
                  windowReturnClass.AddCommand(4, 18);
                  windowReturnClass.SetFlag(true);
                }
                return windowReturnClass;
              }
              if (num1 == this.HexInfoId || num1 == this.hexinfoid2)
              {
                int num3 = 0;
                selectX = this.game.SelectX;
                selectY = this.game.SelectY;
                int index2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                if (index2 > -1)
                {
                  this.game.EditObj.UnitSelected = index2;
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  if (this.game.SelectX != this.game.Data.UnitObj[index2].X | this.game.SelectY != this.game.Data.UnitObj[index2].Y)
                    num3 = 1;
                  this.game.SelectX = this.game.Data.UnitObj[index2].X;
                  this.game.SelectY = this.game.Data.UnitObj[index2].Y;
                  this.game.EditObj.TempCoordList.AddCoord(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected);
                  windowReturnClass.AddCommand(4, 12);
                  if (this.game.EditObj.OrderType == 9)
                  {
                    if (this.game.EditObj.OrderTarget != this.game.EditObj.UnitSelected && this.game.EditObj.UnitSelected != this.game.EditObj.OrderUnit && this.game.Data.Round > 0 & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
                    {
                      this.game.EditObj.OrderTarget = this.game.EditObj.UnitSelected;
                      windowReturnClass.AddCommand(4, 30);
                      windowReturnClass.AddCommand(4, 18);
                    }
                  }
                  else if (this.game.EditObj.OrderType == 18)
                  {
                    if (this.game.EditObj.OrderTarget != -1 && this.game.EditObj.OrderTarget != this.game.EditObj.UnitSelected && this.game.EditObj.UnitSelected != this.game.EditObj.OrderUnit && this.game.Data.Round > 0 & this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
                    {
                      this.game.EditObj.OrderTarget = this.game.EditObj.UnitSelected;
                      windowReturnClass.AddCommand(4, 35);
                    }
                  }
                  else
                    windowReturnClass.AddCommand(4, 20);
                  windowReturnClass.AddCommand(4, 44);
                  if (num3 == 1)
                    this.MakeShit();
                  else
                    this.PaintSpecific(this.SubPartID[index1]);
                  windowReturnClass.SetFlag(true);
                }
                if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location > -1 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Regime == this.game.Data.Turn && x > 0 & x < 150 & y > 2 & y < 18)
                {
                  string tempstr = Interaction.InputBox("Give New Name for Location", "Rename", this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Name);
                  if ((double) this.game.Data.RuleVar[419] > 0.0)
                  {
                    this.game.HandyFunctionsObj.MakeSpecificAutoLabels(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, (int) Math.Round((double) this.game.Data.RuleVar[419]), Strings.Space(Strings.Len(this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Name)));
                    this.game.HandyFunctionsObj.MakeSpecificAutoLabels(this.game.SelectX, this.game.SelectY, this.game.EditObj.MapSelected, (int) Math.Round((double) this.game.Data.RuleVar[419]), tempstr);
                  }
                  this.game.Data.LocObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].Location].Name = tempstr;
                  this.MakeShit();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
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
