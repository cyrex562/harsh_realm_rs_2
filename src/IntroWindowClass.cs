// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.IntroWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class IntroWindowClass : WindowClass
  {
    private int BStartGameID;
    private int BLoadGameID;
    private int BSaveGameID;
    private int BRandomID;
    private int BEditorID;
    private int bWebsiteID;
    private int TempText;
    private int TempText2;
    private int txt1;
    private int txt2;
    private int txt3;
    private int minimapid;
    private int opt1;
    private int opt2;
    private int opt3;
    private int opt4;
    private int opt5;
    private int opt6;
    private int opt7;
    private int txt7;
    private int txt4;
    private int txt5;
    private int txt6;
    private int txt8;
    private int opt8;
    private int txt9;
    private int opt9;
    private int txt10;
    private int cancelID;
    private int[] vari;
    private int[] varitext;
    private ATListClass RegimeListObj;
    private int RegimeListId;
    private float tempBlink;
    private int detailnr;

    public IntroWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND2MARC)
    {
      this.vari = new int[13];
      this.varitext = new int[13];
      this.tempBlink = 0.0f;
      this.detailnr = -1;
      this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 395, 144, false);
      this.DoStuff();
    }

    public void DoStuff()
    {
      SizeF sizeF1 = new SizeF();
      if (this.TempText > 0)
        this.RemoveSubPart(this.TempText);
      if (this.TempText2 > 0)
        this.RemoveSubPart(this.TempText2);
      if (this.BStartGameID > 0)
        this.RemoveSubPart(this.BStartGameID);
      if (this.BRandomID > 0)
        this.RemoveSubPart(this.BRandomID);
      if (this.BLoadGameID > 0)
        this.RemoveSubPart(this.BLoadGameID);
      if (this.BEditorID > 0)
        this.RemoveSubPart(this.BEditorID);
      if (this.bWebsiteID > 0)
        this.RemoveSubPart(this.bWebsiteID);
      if (this.minimapid > 0)
        this.RemoveSubPart(this.minimapid);
      if (this.opt1 > 0)
        this.RemoveSubPart(this.opt1);
      if (this.txt1 > 0)
        this.RemoveSubPart(this.txt1);
      if (this.opt2 > 0)
        this.RemoveSubPart(this.opt2);
      if (this.txt2 > 0)
        this.RemoveSubPart(this.txt2);
      if (this.opt3 > 0)
        this.RemoveSubPart(this.opt3);
      if (this.txt3 > 0)
        this.RemoveSubPart(this.txt3);
      if (this.opt4 > 0)
        this.RemoveSubPart(this.opt4);
      if (this.txt4 > 0)
        this.RemoveSubPart(this.txt4);
      if (this.opt5 > 0)
        this.RemoveSubPart(this.opt5);
      if (this.txt5 > 0)
        this.RemoveSubPart(this.txt5);
      if (this.opt6 > 0)
        this.RemoveSubPart(this.opt6);
      if (this.txt6 > 0)
        this.RemoveSubPart(this.txt6);
      if (this.opt7 > 0)
        this.RemoveSubPart(this.opt7);
      if (this.txt7 > 0)
        this.RemoveSubPart(this.txt7);
      if (this.opt8 > 0)
        this.RemoveSubPart(this.opt8);
      if (this.txt8 > 0)
        this.RemoveSubPart(this.txt8);
      if (this.opt9 > 0)
        this.RemoveSubPart(this.opt9);
      if (this.txt9 > 0)
        this.RemoveSubPart(this.txt9);
      if (this.txt10 > 0)
        this.RemoveSubPart(this.txt10);
      int index1 = 0;
      do
      {
        if (this.vari[index1] > 0)
          this.RemoveSubPart(this.vari[index1]);
        if (this.varitext[index1] > 0)
          this.RemoveSubPart(this.varitext[index1]);
        ++index1;
      }
      while (index1 <= 12);
      if (this.cancelID > 0)
        this.RemoveSubPart(this.cancelID);
      this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND2MARC);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      DrawMod.DrawBlock(ref graphics, 35, 93, 945, 587, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) Math.Round((double) this.game.VicColor4.A / 2.0));
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref graphics, 35, 93, 945, 587, -1, -1);
      int num1 = 115;
      int num2 = 25;
      int index2 = 0;
      SubPartClass tsubpart;
      int num3;
      do
      {
        if (this.game.Data.Variants[index2] > -1)
        {
          if (this.game.Data.GameSlot[this.game.Data.Variants[index2]] <= 0)
          {
            int[] vari = this.vari;
            int index3 = index2;
            tsubpart = (SubPartClass) new SteveButtonPartClass25(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 276, bby: (3 + num1 + index2 * num2));
            int num4 = this.AddSubPart(ref tsubpart, 276, 3 + num1 + index2 * num2, num2, num2, 1);
            vari[index3] = num4;
          }
          else
          {
            int[] vari = this.vari;
            int index4 = index2;
            tsubpart = (SubPartClass) new SteveButtonPartClass25(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 276, bby: (3 + num1 + index2 * num2));
            int num5 = this.AddSubPart(ref tsubpart, 276, 3 + num1 + index2 * num2, num2, num2, 1);
            vari[index4] = num5;
          }
          ++num3;
          int[] varitext = this.varitext;
          int index5 = index2;
          tsubpart = (SubPartClass) new ATTextPartClass(this.game.Data.GameSlotName[this.game.Data.Variants[index2]], this.game.VicFont3, 150, 16, false, toutline: true);
          int num6 = this.AddSubPart(ref tsubpart, 305, num1 + 7 + index2 * num2, 150, 16, 0);
          varitext[index5] = num6;
        }
        ++index2;
      }
      while (index2 <= 11);
      ref Graphics local1 = ref graphics;
      Rectangle rectangle1 = new Rectangle(100, 498, 300, 14);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2;
      Rectangle rect2_1 = rectangle2;
      DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "OPPONENTS", rect2_1, "");
      string txt;
      if (Strings.Len(this.game.Data.Designer) < 1)
      {
        txt = "";
      }
      else
      {
        txt = "by: " + this.game.Data.Designer;
        if (Strings.Len(this.game.Data.Designer2) > 0)
          txt = txt + " & " + this.game.Data.Designer2;
      }
      if (Strings.InStr(this.game.Data.Description, "[tab]") > 0)
      {
        DrawMod.DrawTextVic(ref graphics, this.game.Data.Name, this.game.VicFont8, 78, 29, this.game.VicColor2, this.game.VicColor1Shade);
        tsubpart = (SubPartClass) new MiniMapPartClass(this.game, false, 395, 144);
        this.minimapid = this.AddSubPart(ref tsubpart, 520, 120, 395, 144, 0);
        DrawMod.DrawRectangle(ref graphics, 519, 119, 397, 146, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
        int num7 = 490 + this.game.EditObj.MiniMap.Width;
        int num8 = (int) Math.Round((double) (graphics.MeasureString(this.game.Data.Name, this.game.VicFont8).Width + 4f));
        DrawMod.DrawTextVic(ref graphics, ", " + txt, this.game.VicFont2, 78 + num8, 38, this.game.VicColor2, this.game.VicColor1Shade);
        DrawMod.drawLine(ref graphics, 82, 58, 78 + num8 - 8, 58, (int) this.game.VicColor2.R, (int) this.game.VicColor2.G, (int) this.game.VicColor2.B, (int) this.game.VicColor2.A, 2);
        if (Strings.Len(this.game.Data.RuleSetName) > 1)
        {
          tsubpart = (SubPartClass) new TextAreaClass(this.game, 430, 18, this.game.VicFont3, "Description", true, this.game.Data.Description, Color.White, tItemSize: 18, tbackbitmap: (ref this.OwnBitmap), bbx: 520, bby: 295);
          this.TempText = this.AddSubPart(ref tsubpart, 520, 295, 430, 342, 0);
        }
        else
        {
          tsubpart = (SubPartClass) new TextAreaClass(this.game, 430, 20, this.game.VicFont3, "Description", true, this.game.Data.Description, Color.White, tItemSize: 18, tbackbitmap: (ref this.OwnBitmap), bbx: 520, bby: 295);
          this.TempText = this.AddSubPart(ref tsubpart, 520, 295, 430, 378, 0);
        }
      }
      else
      {
        tsubpart = (SubPartClass) new ATTextPartClass(this.game.Data.Name, this.game.VicFont8, 810, 28, true, tBlackBack: true);
        this.TempText2 = this.AddSubPart(ref tsubpart, 100, 26, 850, 28, 0);
        tsubpart = (SubPartClass) new ATTextPartClass(txt, this.game.VicFont3, 810, 14, true, tBlackBack: true);
        this.BRandomID = this.AddSubPart(ref tsubpart, 100, 53, 850, 14, 0);
        int num9 = 0;
        if (num3 == 0)
          num9 = 200;
        DrawMod.DrawPaperSheet(ref graphics, 519 - num9, 115, 405 + num9, 362);
        tsubpart = (SubPartClass) new PaperAreaClass(this.game, 370 + num9, 16, (Font) null, "Description", false, this.game.Data.Description, this.game.VicColor8, tItemSize: 20, tbackbitmap: (ref this.OwnBitmap), bbx: (540 - num9), bby: 136);
        this.TempText = this.AddSubPart(ref tsubpart, 540 - num9, 136, 370 + num9, 342, 0);
        tsubpart = (SubPartClass) new MiniMapPartClass(this.game, false, 395, 144);
        this.minimapid = this.AddSubPart(ref tsubpart, 520, 513, 395, 144, 0);
        DrawMod.DrawRectangle(ref graphics, 519, 512, 397, 146, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
        ref Graphics local2 = ref graphics;
        rectangle1 = new Rectangle(520, 498, 300, 14);
        Rectangle rect1_2 = rectangle1;
        Rectangle rect2_2 = rectangle2;
        DrawMod.MakeFullBoxVic2(ref local2, rect1_2, "MINIMAP", rect2_2, "");
      }
      this.doregimelist();
      tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: (ref this.OwnBitmap), bbx: 20, bby: 710);
      this.cancelID = this.AddSubPart(ref tsubpart, 20, 710, 35, 35, 1);
      tsubpart = (SubPartClass) new TextButtonPartClass("Edit", 70, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 710);
      this.BEditorID = this.AddSubPart(ref tsubpart, 100, 710, 70, 35, 1);
      tsubpart = (SubPartClass) new TextButtonPartClass("Start", 120, tBackbitmap: (ref this.OwnBitmap), bbx: 335, bby: 695, theight: 50);
      this.BStartGameID = this.AddSubPart(ref tsubpart, 335, 695, 120, 50, 1);
      if (Strings.Len(this.game.Data.RuleSetName) > 1)
      {
        SizeF sizeF2 = graphics.MeasureString("Ruleset: " + this.game.Data.RuleSetName, this.game.VicFont3);
        DrawMod.DrawSteveBlock(ref graphics, (int) Math.Round(916.0 - ((double) sizeF2.Width + 10.0)), 682, (int) Math.Round((double) (sizeF2.Width + 10f)), 20);
        DrawMod.DrawTextVic2(ref graphics, "Ruleset: " + this.game.Data.RuleSetName, this.game.VicFont3, (int) Math.Round(916.0 - ((double) sizeF2.Width + 5.0)), 687, this.game.VicColor2, this.game.VicColor2Shade);
      }
      if (!this.game.Data.FOWOn)
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 115);
        this.opt1 = this.AddSubPart(ref tsubpart, 100, 115, 35, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 115);
        this.opt1 = this.AddSubPart(ref tsubpart, 100, 115, 35, 35, 1);
      }
      tsubpart = (SubPartClass) new ATTextPartClass("Fog of War", this.game.VicFont2, 100, 16, false, toutline: true);
      this.txt1 = this.AddSubPart(ref tsubpart, 140, 122, 100, 16, 0);
      if (!this.game.Data.PasswordsOn)
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 185);
        this.opt3 = this.AddSubPart(ref tsubpart, 100, 185, 35, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 185);
        this.opt3 = this.AddSubPart(ref tsubpart, 100, 185, 35, 35, 1);
      }
      tsubpart = (SubPartClass) new ATTextPartClass("Passwords", this.game.VicFont2, 100, 16, false, toutline: true);
      this.txt3 = this.AddSubPart(ref tsubpart, 140, 192, 100, 16, 0);
      if (!this.game.Data.PBEM)
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 150);
        this.opt5 = this.AddSubPart(ref tsubpart, 100, 150, 35, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 150);
        this.opt5 = this.AddSubPart(ref tsubpart, 100, 150, 35, 35, 1);
      }
      tsubpart = (SubPartClass) new ATTextPartClass("PBEM protection", this.game.VicFont2, 110, 16, false, toutline: true);
      this.txt5 = this.AddSubPart(ref tsubpart, 140, 157, 110, 16, 0);
      if ((double) this.game.Data.RuleVar[353] == 0.0)
      {
        if (!this.game.Data.ShrowdOn)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: ((int) byte.MaxValue));
          this.opt2 = this.AddSubPart(ref tsubpart, 100, (int) byte.MaxValue, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: ((int) byte.MaxValue));
          this.opt2 = this.AddSubPart(ref tsubpart, 100, (int) byte.MaxValue, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new ATTextPartClass("Shroud", this.game.VicFont2, 100, 16, false, toutline: true);
        this.txt2 = this.AddSubPart(ref tsubpart, 140, 262, 100, 16, 0);
        if (!this.game.Data.ShrowdPeek)
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 290);
          this.opt7 = this.AddSubPart(ref tsubpart, 100, 290, 35, 35, 1);
        }
        else
        {
          tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 290);
          this.opt7 = this.AddSubPart(ref tsubpart, 100, 290, 35, 35, 1);
        }
        tsubpart = (SubPartClass) new ATTextPartClass("Shroud Peak", this.game.VicFont2, 100, 16, false, toutline: true);
        this.txt7 = this.AddSubPart(ref tsubpart, 140, 297, 100, 16, 0);
      }
      if (!this.game.Data.DontShowAIMove)
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.CANCELBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 220);
        this.opt9 = this.AddSubPart(ref tsubpart, 100, 220, 35, 35, 1);
      }
      else
      {
        tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.OKBALL, tBackbitmap: (ref this.OwnBitmap), bbx: 100, bby: 220);
        this.opt9 = this.AddSubPart(ref tsubpart, 100, 220, 35, 35, 1);
      }
      tsubpart = (SubPartClass) new ATTextPartClass("Hide realtime AI", this.game.VicFont2, 110, 16, false, toutline: true);
      this.txt9 = this.AddSubPart(ref tsubpart, 140, 227, 110, 16, 0);
    }

    public void doregimelist()
    {
      if (!this.game.Data.NoPlayChoice)
      {
        int tlistselect = -1;
        int num = -1;
        this.RegimeListObj = new ATListClass();
        if (this.game.Data.RegimeCounter > -1)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int tdata = 0; tdata <= regimeCounter; ++tdata)
          {
            if (!this.game.Data.RegimeObj[tdata].Sleep)
            {
              ++num;
              string name = this.game.Data.RegimeObj[tdata].Name;
              if (tdata == this.detailnr)
                tlistselect = num;
              string tvalue = !this.game.Data.RegimeObj[tdata].Sleep ? (!this.game.Data.RegimeObj[tdata].AI ? "HUMAN" : (this.game.Data.UseAI != 1 ? (this.game.Data.RegimeObj[tdata].ProdBonus > -25 ? (this.game.Data.RegimeObj[tdata].ProdBonus != 0 ? (this.game.Data.RegimeObj[tdata].ProdBonus > 100 ? "AI++" : "AI+") : "AI") : "AI-") : "AI")) : (!this.game.Data.RegimeObj[tdata].AI ? "FIXED HUMAN" : "FIXED AI");
              this.RegimeListObj.add(name, tdata, tvalue);
            }
          }
        }
        if (this.RegimeListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.RegimeListId)].Refresh(this.RegimeListObj, tlistselect);
          this.SubPartFlag[this.SubpartNr(this.RegimeListId)] = true;
        }
        else
        {
          string tHeader = "OPPONENTS";
          if (this.game.Data.NoAIAdvice)
            tHeader = "OPPONENTS (AI blocked)";
          SubPartClass tsubpart = (SubPartClass) new ATListSubPartClass(this.RegimeListObj, 8, 355, tlistselect, this.game, true, tHeader, false, false, tShowPair: true, tValueWidth: 130, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: 95, bby: 513);
          this.RegimeListId = this.AddSubPart(ref tsubpart, 95, 513, 355, 176, 0);
        }
      }
      else
      {
        if (this.RegimeListId <= 0)
          return;
        this.RemoveSubPart(this.RegimeListId);
      }
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.TempText)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.RegimeListId)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                if (!this.game.Data.NoAIAdvice)
                {
                  this.detailnr = num2;
                  if (!this.game.Data.RegimeObj[this.detailnr].Sleep)
                  {
                    if (this.game.Data.UseAI == 1)
                    {
                      if (!this.game.Data.RegimeObj[this.detailnr].AI)
                        this.game.Data.RegimeObj[this.detailnr].AI = true;
                      else if (this.game.Data.RegimeObj[this.detailnr].AI)
                        this.game.Data.RegimeObj[this.detailnr].AI = false;
                    }
                    else if (!this.game.Data.RegimeObj[this.detailnr].AI)
                    {
                      this.game.Data.RegimeObj[this.detailnr].AI = true;
                      this.game.Data.RegimeObj[this.detailnr].ProdBonus = 0;
                    }
                    else if (this.game.Data.RegimeObj[this.detailnr].AI & this.game.Data.RegimeObj[this.detailnr].ProdBonus == 0)
                    {
                      this.game.Data.RegimeObj[this.detailnr].AI = true;
                      this.game.Data.RegimeObj[this.detailnr].ProdBonus = 100;
                    }
                    else if (this.game.Data.RegimeObj[this.detailnr].AI & this.game.Data.RegimeObj[this.detailnr].ProdBonus >= 0 & this.game.Data.RegimeObj[this.detailnr].ProdBonus <= 100)
                    {
                      this.game.Data.RegimeObj[this.detailnr].AI = true;
                      this.game.Data.RegimeObj[this.detailnr].ProdBonus = 250;
                    }
                    else if (this.game.Data.RegimeObj[this.detailnr].AI & this.game.Data.RegimeObj[this.detailnr].ProdBonus > 100)
                    {
                      this.game.Data.RegimeObj[this.detailnr].AI = true;
                      this.game.Data.RegimeObj[this.detailnr].ProdBonus = -25;
                    }
                    else
                    {
                      this.game.Data.RegimeObj[this.detailnr].AI = false;
                      this.game.Data.RegimeObj[this.detailnr].ProdBonus = 0;
                    }
                    this.detailnr = num2;
                    this.doregimelist();
                  }
                }
                else
                {
                  int num3 = (int) Interaction.MsgBox((object) "Scenario is not suitable for playing the AI.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.DoStuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.cancelID)
            {
              BitmapStore.ReloadSystemGraphics(this.game.ModSystemGraphicsDirectory);
              this.game.EditObj.ShowInitialMenu = true;
              windowReturnClass.AddCommand(3, 1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.opt1)
            {
              this.game.Data.FOWOn = !this.game.Data.FOWOn;
              if (this.game.Data.ShrowdOn)
                this.game.Data.FOWOn = true;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.opt2)
            {
              if (!this.game.Data.CreatedWithShrowd)
              {
                this.game.Data.ShrowdOn = !this.game.Data.ShrowdOn;
                if (this.game.Data.ShrowdOn)
                  this.game.Data.FOWOn = true;
                if (!this.game.Data.ShrowdOn)
                  this.game.Data.ShrowdPeek = false;
                windowReturnClass.AddCommand(3, 1);
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num4 = (int) Interaction.MsgBox((object) "Not possible. This is a random game created with a shroud.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
            }
            else if (num1 == this.opt3)
            {
              this.game.Data.PasswordsOn = !this.game.Data.PasswordsOn;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.opt5)
            {
              this.game.Data.PBEM = !this.game.Data.PBEM;
              this.game.Data.TerrorMode = false;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.opt6)
            {
              int aiHelpMove = this.game.Data.RegimeObj[0].AIHelpMove;
              int regimeCounter = this.game.Data.RegimeCounter;
              for (int index2 = 0; index2 <= regimeCounter; ++index2)
              {
                switch (aiHelpMove)
                {
                  case 0:
                    this.game.Data.RegimeObj[index2].AIHelpMove = 20;
                    this.game.Data.RegimeObj[index2].AIHelpCombat = 25;
                    this.game.Data.RegimeObj[index2].AIHelpStrategic = 50;
                    break;
                  case 20:
                    this.game.Data.RegimeObj[index2].AIHelpMove = 30;
                    this.game.Data.RegimeObj[index2].AIHelpCombat = 50;
                    this.game.Data.RegimeObj[index2].AIHelpStrategic = 100;
                    break;
                  case 30:
                    this.game.Data.RegimeObj[index2].AIHelpMove = 40;
                    this.game.Data.RegimeObj[index2].AIHelpCombat = 75;
                    this.game.Data.RegimeObj[index2].AIHelpStrategic = 150;
                    break;
                  case 40:
                    this.game.Data.RegimeObj[index2].AIHelpMove = 50;
                    this.game.Data.RegimeObj[index2].AIHelpCombat = 100;
                    this.game.Data.RegimeObj[index2].AIHelpStrategic = 200;
                    break;
                  case 50:
                    this.game.Data.RegimeObj[index2].AIHelpMove = 0;
                    this.game.Data.RegimeObj[index2].AIHelpCombat = 0;
                    this.game.Data.RegimeObj[index2].AIHelpStrategic = 0;
                    break;
                }
              }
              this.DoStuff();
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.opt9)
            {
              this.game.Data.DontShowAIMove = !this.game.Data.DontShowAIMove;
              this.DoStuff();
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.opt7)
            {
              if (this.game.Data.ShrowdOn)
              {
                this.game.Data.ShrowdPeek = !this.game.Data.ShrowdPeek;
                this.DoStuff();
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num5 = (int) Interaction.MsgBox((object) "This option can only be activated if map is shrouded.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
            }
            else if (num1 == this.opt8)
            {
              if (this.game.Data.PBEM)
              {
                this.game.Data.TerrorMode = !this.game.Data.TerrorMode;
                if (this.game.Data.TerrorMode)
                {
                  int num6 = (int) Interaction.MsgBox((object) "Be warned that you can only play your turn once with Terror Mode on. After it had been opened once it cannot be reopened again. This is a very safe mode, but if anything goes wrong it will ruin your pbem game because it will not allow you to continue play. Be warned if you play with this ultimate protection mode on.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
              }
              else
              {
                int num7 = (int) Interaction.MsgBox((object) "This terror mode anti cheat option can only be activated if normal Anti Cheat is already on.", Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
            }
            else
            {
              if (num1 == this.BRandomID)
              {
                windowReturnClass.AddCommand(1, 49);
                windowReturnClass.AddCommand(2, 50);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.BStartGameID)
              {
                int num8 = 0;
                int aiHelpMove = this.game.Data.RegimeObj[0].AIHelpMove;
                int regimeCounter1 = this.game.Data.RegimeCounter;
                for (int index3 = 0; index3 <= regimeCounter1; ++index3)
                {
                  switch (aiHelpMove)
                  {
                    case 20:
                      this.game.Data.RegimeObj[index3].AIHelpMove = 20;
                      this.game.Data.RegimeObj[index3].AIHelpCombat = 25;
                      this.game.Data.RegimeObj[index3].AIHelpStrategic = 50;
                      break;
                    case 30:
                      this.game.Data.RegimeObj[index3].AIHelpMove = 30;
                      this.game.Data.RegimeObj[index3].AIHelpCombat = 50;
                      this.game.Data.RegimeObj[index3].AIHelpStrategic = 100;
                      break;
                    case 40:
                      this.game.Data.RegimeObj[index3].AIHelpMove = 40;
                      this.game.Data.RegimeObj[index3].AIHelpCombat = 75;
                      this.game.Data.RegimeObj[index3].AIHelpStrategic = 150;
                      break;
                    case 50:
                      this.game.Data.RegimeObj[index3].AIHelpMove = 50;
                      this.game.Data.RegimeObj[index3].AIHelpCombat = 100;
                      this.game.Data.RegimeObj[index3].AIHelpStrategic = 200;
                      break;
                  }
                  if (!this.game.Data.RegimeObj[index3].AI)
                  {
                    this.game.Data.RegimeObj[index3].AIHelpMove = 0;
                    this.game.Data.RegimeObj[index3].AIHelpCombat = 0;
                    this.game.Data.RegimeObj[index3].AIHelpStrategic = 0;
                  }
                }
                int regimeCounter2 = this.game.Data.RegimeCounter;
                for (int index4 = 0; index4 <= regimeCounter2; ++index4)
                {
                  if (this.game.Data.RegimeObj[index4].AI | this.game.Data.RegimeObj[index4].Sleep)
                    ++num8;
                }
                if (num8 == this.game.Data.RegimeCounter + 1 & this.game.Data.CampaignRoom == -1)
                {
                  int num9 = (int) Interaction.MsgBox((object) "There must be at least 1 human player", Title: ((object) "Shadow Empire : Planetary Conquest"));
                  if (MsgBoxResult.No == Interaction.MsgBox((object) "Do you want to proceed anyway?", MsgBoxStyle.YesNo))
                    goto label_157;
                }
                int num10 = 0;
                int regimeCounter3 = this.game.Data.RegimeCounter;
                for (int index5 = 0; index5 <= regimeCounter3; ++index5)
                {
                  if (this.game.Data.RegimeObj[index5].AI)
                    ++num10;
                }
                if (this.game.Data.NoAIAdvice & num10 > 0)
                {
                  int num11 = (int) Interaction.MsgBox((object) "The scenario creator has allowed no AIs in this scenario. You are not allowed to play for your own good.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.Data.Round = 0;
                  int mapWidth = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth;
                  for (int index6 = 0; index6 <= mapWidth; ++index6)
                  {
                    int mapHeight = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight;
                    for (int index7 = 0; index7 <= mapHeight; ++index7)
                    {
                      int regimeCounter4 = this.game.Data.RegimeCounter;
                      for (int Index = 0; Index <= regimeCounter4; ++Index)
                      {
                        this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index6, index7].set_LastLT(Index, -1);
                        this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index6, index7].set_LastSpr(Index, -1);
                        this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index6, index7].set_LastReg(Index, -1);
                        this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[index6, index7].set_SeeNow(Index, 0);
                      }
                    }
                  }
                  int unitCounter = this.game.Data.UnitCounter;
                  for (int unr = 0; unr <= unitCounter; ++unr)
                  {
                    if (!this.game.Data.UnitObj[unr].IsHQ && this.game.Data.UnitObj[unr].Supply > this.game.HandyFunctionsObj.UnitSupplyStore(unr))
                      this.game.Data.UnitObj[unr].Supply = this.game.HandyFunctionsObj.UnitSupplyStore(unr);
                  }
                  if (this.game.Data.DoAllied)
                  {
                    int regimeCounter5 = this.game.Data.RegimeCounter;
                    for (int index8 = 0; index8 <= regimeCounter5; ++index8)
                    {
                      int regimeCounter6 = this.game.Data.RegimeCounter;
                      for (int index9 = 0; index9 <= regimeCounter6; ++index9)
                      {
                        if (index8 != index9 & this.game.Data.RegimeObj[index8].AI & this.game.Data.RegimeObj[index9].AI)
                        {
                          if ((double) this.game.Data.RuleVar[524] == 1.0)
                          {
                            this.game.Data.RegimeObj[index8].RegimeRel[index9] = 2;
                            this.game.Data.RegimeObj[index9].RegimeRel[index8] = 2;
                          }
                          else
                          {
                            this.game.Data.RegimeObj[index8].RegimeRel[index9] = 1;
                            this.game.Data.RegimeObj[index9].RegimeRel[index8] = 1;
                          }
                        }
                      }
                    }
                  }
                  if (this.game.Data.Turn > -1)
                  {
                    int turn = this.game.Data.Turn;
                    for (int regnr = 0; regnr <= turn; ++regnr)
                    {
                      this.game.ProcessingObj.SetInitialReconAndZOC(regnr);
                      this.game.HandyFunctionsObj.ClearHistory((object) regnr);
                    }
                  }
                  VBMath.Randomize();
                  this.game.Data.GameID = (int) Math.Round((double) (VBMath.Rnd() * 1E+08f));
                  this.game.HandyFunctionsObj.RedimStats();
                  this.game.HandyFunctionsObj.DoResMod();
                  windowReturnClass.AddCommand(3, 4);
                  SoundMod.StopWave();
                }
              }
              else if (num1 == this.BSaveGameID)
              {
                string str = this.game.HandyFunctionsObj.SaveSomething("Text Files (*.pt2)|*.pt2", "Give save name...", this.game.AppPath + "scenarios\\", false);
                if (Strings.Len(str) < 2)
                {
                  int num12 = (int) Interaction.MsgBox((object) "Operation is Cancelled", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
                else
                {
                  this.game.Data.serialize(str);
                  this.RemoveSubPart(this.TempText);
                  SubPartClass tsubpart = (SubPartClass) new TextPartClass(this.game.Data.Name + " is saved.", this.game.VicFont1, 400, 20, true);
                  this.TempText = this.AddSubPart(ref tsubpart, 0, 41, 400, 19, 0);
                  windowReturnClass.SetFlag(true);
                }
              }
              else if (num1 == this.BLoadGameID)
              {
                string str = this.game.HandyFunctionsObj.LoadSomething("Scenario file (*.pt2)|*.pt2|Master File (*.ptmaster)|*.ptmaster|Hidden File (*.pthidden)|*.pthidden", "Pick a scenario to load...", this.game.AppPath + "scenarios\\", false);
                if (File.Exists(str))
                {
                  this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                  if (this.game.Data.UseAI == 1)
                    this.game.NewAIObj.LastRegime = -1;
                  this.game.SelectX = -1;
                  this.game.SelectY = -1;
                  this.game.Data = DataClass.deserialize(str);
                  if (Strings.Len(this.game.Data.MasterFile) > 0 & this.game.Data.Round == 0)
                    this.game.HandyFunctionsObj.LoadMasterFile(this.game.Data.MasterFile);
                  if (this.game.Data.Round > 0)
                  {
                    BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                    this.game.Data.LoadGraphics((Form1) null);
                    this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 210, 115, false);
                    if (!this.game.Data.InTurn)
                    {
                      windowReturnClass.AddCommand(3, 4);
                      this.game.EditObj.Phase = -1;
                    }
                    else
                      windowReturnClass.AddCommand(3, 3);
                    return windowReturnClass;
                  }
                  if (Strings.Len(this.game.Data.LoadPass) > 0)
                  {
                    if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by a load password. Please give it in order to load it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.LoadPass), false) == 0)
                    {
                      int num13 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      int num14 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Load this file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      this.game.Data = new DataClass();
                      this.RemoveSubPart(this.TempText);
                      SubPartClass tsubpart = (SubPartClass) new TextPartClass(this.game.Data.Name + " is loaded instead.", this.game.VicFont1, 400, 20, true);
                      this.TempText = this.AddSubPart(ref tsubpart, 0, 41, 400, 19, 0);
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                  }
                  BitmapStore.ReloadSystemGraphics(this.game.Data.SystemGfx);
                  this.game.Data.LoadGraphics((Form1) null);
                  this.RemoveSubPart(this.TempText);
                  windowReturnClass.AddCommand(3, 1);
                  windowReturnClass.SetFlag(true);
                }
                else
                {
                  int num15 = (int) Interaction.MsgBox((object) "File could not be found or op. is cancelled.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
              else if (num1 == this.BEditorID)
              {
                int unitCounter = this.game.Data.UnitCounter;
                for (int index10 = 0; index10 <= unitCounter; ++index10)
                {
                  this.game.Data.UnitObj[index10].Name = this.game.Data.UnitObj[index10].Name.Replace("3th", "3rd");
                  this.game.Data.UnitObj[index10].Name = this.game.Data.UnitObj[index10].Name.Replace("11st", "11th");
                  this.game.Data.UnitObj[index10].Name = this.game.Data.UnitObj[index10].Name.Replace("12nd", "12th");
                  this.game.Data.UnitObj[index10].Name = this.game.Data.UnitObj[index10].Name.Replace("13rd", "13th");
                }
                if (!this.game.Data.CreatedWithShrowd)
                {
                  if (Strings.Len(this.game.Data.EditPass) > 0)
                  {
                    if (Operators.CompareString(Strings.LCase(Interaction.InputBox("This File is protected by an edit password. Please give it in order to edit it.", "Shadow Empire : Planetary Conquest")), Strings.LCase(this.game.Data.EditPass), false) == 0)
                    {
                      int num16 = (int) Interaction.MsgBox((object) "You are cleared.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                    }
                    else
                    {
                      int num17 = (int) Interaction.MsgBox((object) "Wrong Password. You cannot Edit this file", Title: ((object) "Shadow Empire : Planetary Conquest"));
                      return windowReturnClass;
                    }
                  }
                  this.game.EditObj.InEditor = true;
                  this.game.SelectX = 0;
                  this.game.SelectY = 0;
                  this.game.EditObj.UnitSelected = -1;
                  this.game.CornerX = 0;
                  this.game.CornerY = 0;
                  this.game.CustomBitmapObj.MakeMiniMap(this.game.EditObj.MiniMap, 210, 115, false);
                  windowReturnClass.AddCommand(3, 2);
                  SoundMod.StopWave();
                }
                else
                {
                  int num18 = (int) Interaction.MsgBox((object) "Not possible. This is a random game created with a shroud.", Title: ((object) "Shadow Empire : Planetary Conquest"));
                }
              }
            }
label_157:
            int index11 = 0;
            do
            {
              if (this.SubPartID[index1] == this.vari[index11])
              {
                if (this.game.Data.GameSlot[this.game.Data.Variants[index11]] <= 0)
                  this.game.Data.GameSlot[this.game.Data.Variants[index11]] = 1;
                else
                  this.game.Data.GameSlot[this.game.Data.Variants[index11]] = 0;
                if (this.game.Data.VariantEvent[index11] > -1)
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.Data.VariantEvent[index11]);
                  this.game.FormRef.Cursor = Cursors.Default;
                }
                this.DoStuff();
                windowReturnClass.SetFlag(true);
              }
              ++index11;
            }
            while (index11 <= 11);
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
