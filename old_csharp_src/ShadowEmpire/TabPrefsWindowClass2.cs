// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabPrefsWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class TabPrefsWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int CurrentView;
    private int currentCat;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int saveid;
    private int quitid;
    private int minId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int B4Id;
    private int B4TextId;
    private int B5Id;
    private int B5TextId;
    private int B6Id;
    private int B6TextId;
    private int B7Id;
    private int B7TextId;
    private int B8Id;
    private int B8TextId;
    private int B9Id;
    private int B9TextId;
    private int B10Id;
    private int B10TextId;
    private int B11Id;
    private int B11TextId;
    private int B12Id;
    private int B12TextId;
    private int B13Id;
    private int B13TextId;
    private int B14Id;
    private int B14TextId;
    private int B15Id;
    private int B15TextId;
    private int B16Id;
    private int B16TextId;
    private int B17Id;
    private int B17TextId;
    private int B17bId;
    private int B17bTextId;
    private int B17cId;
    private int B17cTextId;
    private int B17dId;
    private int B17dTextId;
    private int B17eId;
    private int B17eTextId;
    private int B17fId;
    private int B17fTextId;
    private int B18Id;
    private int B18TextId;
    private int B19Id;
    private int B19TextId;
    private int B20Id;
    private int B20TextId;
    private int B21Id;
    private int B21TextId;
    private int B22Id;
    private int B22TextId;
    private int B23Id;
    private int B23TextId;
    private int B24Id;
    private int B24TextId;
    private int b25id;
    private int b25Textid;
    private int b26id;
    private int b26Textid;
    private int b27id;
    private int b27Textid;
    private int b28id;
    private int b28Textid;
    private int b29id;
    private int b29Textid;
    private int b30id;
    private int b30Textid;
    private int b31id;
    private int b31Textid;
    private int b32id;
    private int b32Textid;
    private int b33id;
    private int b33Textid;
    private int b34id;
    private int b34Textid;
    private int b35id;
    private int b35Textid;
    private int b36id;
    private int b36Textid;
    private int slider1id;
    private int slider2id;
    private ListClass OptionsListObj;
    private int optionsListId;
    private int detailnr;
    private SimpleList resList;

    public TabPrefsWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.detailnr = -1;
      this.w = trect.Width;
      this.h = trect.Height;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.currentCat = 1;
      this.dostuff();
      this.detailnr = -1;
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.B4Id > 0)
        this.RemoveSubPart(this.B4Id);
      if (this.B4TextId > 0)
        this.RemoveSubPart(this.B4TextId);
      if (this.B5Id > 0)
        this.RemoveSubPart(this.B5Id);
      if (this.B5TextId > 0)
        this.RemoveSubPart(this.B5TextId);
      if (this.B6Id > 0)
        this.RemoveSubPart(this.B6Id);
      if (this.B6TextId > 0)
        this.RemoveSubPart(this.B6TextId);
      if (this.B7Id > 0)
        this.RemoveSubPart(this.B7Id);
      if (this.B7TextId > 0)
        this.RemoveSubPart(this.B7TextId);
      if (this.B8Id > 0)
        this.RemoveSubPart(this.B8Id);
      if (this.B8TextId > 0)
        this.RemoveSubPart(this.B8TextId);
      if (this.B9Id > 0)
        this.RemoveSubPart(this.B9Id);
      if (this.B9TextId > 0)
        this.RemoveSubPart(this.B9TextId);
      if (this.B10Id > 0)
        this.RemoveSubPart(this.B10Id);
      if (this.B10TextId > 0)
        this.RemoveSubPart(this.B10TextId);
      if (this.B11Id > 0)
        this.RemoveSubPart(this.B11Id);
      if (this.B11TextId > 0)
        this.RemoveSubPart(this.B11TextId);
      if (this.B12Id > 0)
        this.RemoveSubPart(this.B12Id);
      if (this.B12TextId > 0)
        this.RemoveSubPart(this.B12TextId);
      if (this.B13Id > 0)
        this.RemoveSubPart(this.B13Id);
      if (this.B13TextId > 0)
        this.RemoveSubPart(this.B13TextId);
      if (this.B14Id > 0)
        this.RemoveSubPart(this.B14Id);
      if (this.B14TextId > 0)
        this.RemoveSubPart(this.B14TextId);
      if (this.B15Id > 0)
        this.RemoveSubPart(this.B15Id);
      if (this.B15TextId > 0)
        this.RemoveSubPart(this.B15TextId);
      if (this.B16Id > 0)
        this.RemoveSubPart(this.B16Id);
      if (this.B16TextId > 0)
        this.RemoveSubPart(this.B16TextId);
      if (this.B17Id > 0)
        this.RemoveSubPart(this.B17Id);
      if (this.B17TextId > 0)
        this.RemoveSubPart(this.B17TextId);
      if (this.B17bId > 0)
        this.RemoveSubPart(this.B17bId);
      if (this.B17bTextId > 0)
        this.RemoveSubPart(this.B17bTextId);
      if (this.B17cId > 0)
        this.RemoveSubPart(this.B17cId);
      if (this.B17cTextId > 0)
        this.RemoveSubPart(this.B17cTextId);
      if (this.B17dId > 0)
        this.RemoveSubPart(this.B17dId);
      if (this.B17dTextId > 0)
        this.RemoveSubPart(this.B17dTextId);
      if (this.B17eId > 0)
        this.RemoveSubPart(this.B17eId);
      if (this.B17eTextId > 0)
        this.RemoveSubPart(this.B17eTextId);
      if (this.B17fId > 0)
        this.RemoveSubPart(this.B17fId);
      if (this.B17fTextId > 0)
        this.RemoveSubPart(this.B17fTextId);
      if (this.B18Id > 0)
        this.RemoveSubPart(this.B18Id);
      if (this.B18TextId > 0)
        this.RemoveSubPart(this.B18TextId);
      if (this.B19Id > 0)
        this.RemoveSubPart(this.B19Id);
      if (this.B19TextId > 0)
        this.RemoveSubPart(this.B19TextId);
      if (this.B20Id > 0)
        this.RemoveSubPart(this.B20Id);
      if (this.B20TextId > 0)
        this.RemoveSubPart(this.B20TextId);
      if (this.B21Id > 0)
        this.RemoveSubPart(this.B21Id);
      if (this.B21TextId > 0)
        this.RemoveSubPart(this.B21TextId);
      if (this.B22Id > 0)
        this.RemoveSubPart(this.B22Id);
      if (this.B22TextId > 0)
        this.RemoveSubPart(this.B22TextId);
      if (this.B23Id > 0)
        this.RemoveSubPart(this.B23Id);
      if (this.B23TextId > 0)
        this.RemoveSubPart(this.B23TextId);
      if (this.B24Id > 0)
        this.RemoveSubPart(this.B24Id);
      if (this.B24TextId > 0)
        this.RemoveSubPart(this.B24TextId);
      if (this.b25id > 0)
        this.RemoveSubPart(this.b25id);
      if (this.b25Textid > 0)
        this.RemoveSubPart(this.b25Textid);
      if (this.b26id > 0)
        this.RemoveSubPart(this.b26id);
      if (this.b26Textid > 0)
        this.RemoveSubPart(this.b26Textid);
      if (this.b27id > 0)
        this.RemoveSubPart(this.b27id);
      if (this.b27Textid > 0)
        this.RemoveSubPart(this.b27Textid);
      if (this.b28id > 0)
        this.RemoveSubPart(this.b28id);
      if (this.b28Textid > 0)
        this.RemoveSubPart(this.b28Textid);
      if (this.b29id > 0)
        this.RemoveSubPart(this.b29id);
      if (this.b30id > 0)
        this.RemoveSubPart(this.b30id);
      if (this.b30Textid > 0)
        this.RemoveSubPart(this.b30Textid);
      if (this.b31id > 0)
        this.RemoveSubPart(this.b31id);
      if (this.b31Textid > 0)
        this.RemoveSubPart(this.b31Textid);
      if (this.b32id > 0)
        this.RemoveSubPart(this.b32id);
      if (this.b32Textid > 0)
        this.RemoveSubPart(this.b32Textid);
      if (this.b33id > 0)
        this.RemoveSubPart(this.b33id);
      if (this.b33Textid > 0)
        this.RemoveSubPart(this.b33Textid);
      if (this.b34id > 0)
        this.RemoveSubPart(this.b34id);
      if (this.b34Textid > 0)
        this.RemoveSubPart(this.b34Textid);
      if (this.b35id > 0)
        this.RemoveSubPart(this.b35id);
      if (this.b35Textid > 0)
        this.RemoveSubPart(this.b35Textid);
      if (this.b36id > 0)
        this.RemoveSubPart(this.b36id);
      if (this.b36Textid > 0)
        this.RemoveSubPart(this.b36Textid);
      if (this.minId > 0)
        this.RemoveSubPart(this.minId);
      if (this.slider1id > 0)
      {
        this.RemoveSubPart(this.slider1id);
        this.slider1id = 0;
      }
      if (this.slider2id > 0)
      {
        this.RemoveSubPart(this.slider2id);
        this.slider2id = 0;
      }
      if (this.currentCat != 4 && this.optionsListId > 0)
      {
        this.RemoveSubPart(this.optionsListId);
        this.optionsListId = 0;
      }
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      Rectangle trect1 = DrawMod.DrawBackTab(g, this.w, this.h, "PREFS", 8);
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC/F1]", 999);
      if (this.currentCat < 1)
        this.currentCat = 1;
      g.SmoothingMode = SmoothingMode.None;
      DrawMod.drawLineDot(ref g, 135, 0, 135, 240, Color.White);
      DrawMod.drawLineDot(ref g, 15, 20, 135, 20, Color.White);
      int num1 = 1;
      do
      {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        int num2 = num1;
        if (num2 > 6)
          num2 = 6;
        if (num2 > 0 & this.currentCat < 1)
          this.currentCat = num1;
        if (num1 == this.currentCat)
          DrawMod.DrawBlockGradient(ref g, 35, 40 * num1 - 20, 100, 40, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        string tstring;
        if (num1 == 1)
          tstring = "General";
        if (num1 == 2)
          tstring = "Map";
        if (num1 == 3)
          tstring = "Sound";
        if (num1 == 4)
          tstring = "Gfx & Resolution";
        if (num1 == 5)
          tstring = "AI Speed";
        Rectangle trect2 = new Rectangle(15, 40 * num1 - 20, 120, 40);
        this.AddMouse(ref trect2, "Preferences Category " + tstring, "Click to see all all preference settings in this category", 1000 + num1);
        int y = 40 * num1 - 20 + 13;
        DrawMod.DrawTextColouredMarcCenter(ref g, tstring, this.game.MarcFont5, 75, y, Color.White);
        g.SmoothingMode = SmoothingMode.None;
        DrawMod.drawLineDot(ref g, 15, 20 + num1 * 40, 135, 20 + num1 * 40, Color.White);
        ++num1;
      }
      while (num1 <= 5);
      g.SmoothingMode = SmoothingMode.AntiAlias;
      int num3 = 200;
      int num4 = 25;
      int num5 = 45;
      int num6 = 220;
      int num7 = num4;
      if (this.currentCat == 5)
      {
        int num8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0))].GetData(0, 56, 2)));
        if (num8 != 0)
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "The time the AI takes to make it moves.", ref this.OwnBitmap, num3, num4);
          this.b35id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "The time the AI takes to make it moves.", ref this.OwnBitmap, num3, num4);
          this.b35id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "NORMAL AI PROCESSING - Level 0", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        int num9 = num4 + num5;
        if (num8 != 1)
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "The time the AI takes to make it moves.", ref this.OwnBitmap, num3, num9);
          this.b33id = this.AddSubPart(ref tsubpart, num3, num9, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "The time the AI takes to make it moves.", ref this.OwnBitmap, num3, num9);
          this.b33id = this.AddSubPart(ref tsubpart, num3, num9, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "SLOW AI PROCESSING - Level 100", this.game.MarcFont4, num3 + 50, num9 + 8, Color.White);
        int num10 = num9 + num5;
        if (num8 != 2)
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "The time the AI takes to make it moves.", ref this.OwnBitmap, num3, num10);
          this.b34id = this.AddSubPart(ref tsubpart, num3, num10, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "The time the AI takes to make it moves.", ref this.OwnBitmap, num3, num10);
          this.b34id = this.AddSubPart(ref tsubpart, num3, num10, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "VERY SLOW AI PROCESSING - Level 250", this.game.MarcFont4, num3 + 50, num10 + 8, Color.White);
        num4 = num10 + num5;
      }
      int num11;
      if (this.currentCat == 3)
      {
        if (!this.game.EditObj.IntroSoundOn)
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "Music is currently turned off.", ref this.OwnBitmap, num3, num4);
          this.B8Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "Music is currently turned on.", ref this.OwnBitmap, num3, num4);
          this.B8Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "MUSIC", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        int num12 = num4 + num5;
        if ((double) this.game.Data.RuleVar[990] > 0.0 & this.game.Data.TempString[730].Length > 0)
        {
          if (!this.game.EditObj.AlternateMusic)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "Click to switch to alternate music configuration. ", ref this.OwnBitmap, num3, num12);
            this.B19Id = this.AddSubPart(ref tsubpart, num3, num12, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "Click to switch to defeault music configuration. ", ref this.OwnBitmap, num3, num12);
            this.B19Id = this.AddSubPart(ref tsubpart, num3, num12, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, this.game.Data.TempString[730].ToUpper(), this.game.MarcFont4, num3 + 50, num12 + 8, Color.White);
        }
        int num13 = num12 + num5;
        if (!this.game.EditObj.SoundOn)
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "Sound effects are currently turned off.", ref this.OwnBitmap, num3, num13);
          this.B1Id = this.AddSubPart(ref tsubpart, num3, num13, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "Sound effects are  currently turned on.", ref this.OwnBitmap, num3, num13);
          this.B1Id = this.AddSubPart(ref tsubpart, num3, num13, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "SOUND FX", this.game.MarcFont4, num3 + 50, num13 + 8, Color.White);
        num11 = num13 + num5;
        int num14 = num7 - 5;
        num3 += num6;
        if (this.slider1id < 1)
        {
          SubPartClass tsubpart = (SubPartClass) new NumberSliderSubPartClass2(this.game, "Music Volume = ", "%", 200, 0, 100, this.game.EditObj.Volume, tbackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num14, tMarc: true);
          this.slider1id = this.AddSubPart(ref tsubpart, num3, num14, 200, 40, 0);
        }
        num4 = num14 + (num5 + num5 - 5);
        if (this.slider2id < 1)
        {
          SubPartClass tsubpart = (SubPartClass) new NumberSliderSubPartClass2(this.game, "SFX Volume = ", "%", 200, 0, 100, this.game.EditObj.Volume2, tbackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num4, tMarc: true);
          this.slider2id = this.AddSubPart(ref tsubpart, num3, num4, 200, 40, 0);
        }
      }
      if (this.currentCat == 2)
      {
        if (!this.game.EditObj.PrefShowFOW)
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "Either hide or show the FOW area with a dark shrowd.", ref this.OwnBitmap, num3, num4);
          this.B2Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "Either hide or show the FOW area with a dark shrowd.", ref this.OwnBitmap, num3, num4);
          this.B2Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "SHOW FOW", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        int num15 = num4 + num5;
        if (this.game.Data.Product != 7)
        {
          if (!this.game.EditObj.HexRasterOn)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "Either hide or show the hex grid.", ref this.OwnBitmap, num3, num15);
            this.B4Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "Either hide or show the hex grid.", ref this.OwnBitmap, num3, num15);
            this.B4Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "HEX GRID", this.game.MarcFont4, num3 + 50, num15 + 8, Color.White);
          num15 += num5;
        }
        if (this.game.Data.Product != 7)
        {
          if (!this.game.EditObj.ShowLabel)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option is not active text labels will be hidden.", ref this.OwnBitmap, num3, num15);
            this.B10Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option is not active text labels will be hidden.", ref this.OwnBitmap, num3, num15);
            this.B10Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "SHOW LABEL", this.game.MarcFont4, num3 + 50, num15 + 8, Color.White);
          num15 += num5;
        }
        if (this.game.Data.Product != 7)
        {
          if (!this.game.EditObj.RegimeColoring)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active hexes will be colored\r\non a regime-to-regime basis.", ref this.OwnBitmap, num3, num15);
            this.B16Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active hexes will be colored\r\non a regime-to-regime basis.", ref this.OwnBitmap, num3, num15);
            this.B16Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "REGIME COLORING", this.game.MarcFont4, num3 + 50, num15 + 8, Color.White);
          num15 += num5;
        }
        if ((double) this.game.Data.RuleVar[408] > 0.0)
        {
          if (this.game.EditObj.HideUnit == 2)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "You can toggle 'nato style' counters on/off here. ", ref this.OwnBitmap, num3, num15);
            this.B21Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "You can toggle 'nato style' counters on/off here. ", ref this.OwnBitmap, num3, num15);
            this.B21Id = this.AddSubPart(ref tsubpart, num3, num15, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "NATO counters", this.game.MarcFont4, num3 + 50, num15 + 8, Color.White);
          int num16 = num15 + num5;
          if (this.game.EditObj.SpreadUnit)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "You can toggle 'having multiple counters on same hex in full zoom in mode' on/off here. ", ref this.OwnBitmap, num3, num16);
            this.B22Id = this.AddSubPart(ref tsubpart, num3, num16, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "You can toggle 'having multiple counters on same hex in full zoom in mode' counters on/off here. ", ref this.OwnBitmap, num3, num16);
            this.B22Id = this.AddSubPart(ref tsubpart, num3, num16, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "Smaller counters", this.game.MarcFont4, num3 + 50, num16 + 8, Color.White);
          num11 = num16 + num5;
        }
        num4 = num7;
        num3 += num6;
        if (this.game.Data.Product <= 6)
        {
          if (!this.game.EditObj.PrefMinimalistCounter)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active minimalist counter graphics will be shown. ", ref this.OwnBitmap, num3, num4);
            this.B15Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active minimalist counter graphics will be shown.", ref this.OwnBitmap, num3, num4);
            this.B15Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "MINIMALIST COUNTERS", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
          num4 += num5;
        }
        if (this.game.Data.Product != 7)
        {
          if (!this.game.EditObj.ShowHQPower)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active HQ Power will be shown on map\r\nCan slow down performance. Hotkey: 5", ref this.OwnBitmap, num3, num4);
            this.B12Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active HQ Power will be shown on map\r\nCan slow down performance. Hotkey: 5", ref this.OwnBitmap, num3, num4);
            this.B12Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "HQ POWER RANGE", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
          num4 += num5;
        }
        if (this.game.Data.Product != 7)
        {
          if (!this.game.EditObj.ShowUnderHQ)
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option active subordinate units will be highlighted when you select a HQ.", ref this.OwnBitmap, num3, num4);
            this.B3Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option active subordinate units will be highlighted when you select a HQ.", ref this.OwnBitmap, num3, num4);
            this.B3Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "HQ SUBORDINATES", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
          num4 += num5;
        }
        if (this.game.Data.Product != 7)
        {
          if ((double) this.game.Data.RuleVar[976] == 1.0)
          {
            if (!this.game.EditObj.ShowSameHistorical)
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option active non-HQ units belonging to same HQ will be highlighted.", ref this.OwnBitmap, num3, num4);
              this.B6Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            else
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option active non-HQ units belonging to same HQ will be highlighted.", ref this.OwnBitmap, num3, num4);
              this.B6Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            DrawMod.DrawTextColouredMarc(ref g, "SHOW DIVISIONS", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
            num4 += num5;
          }
          else
          {
            if (!this.game.EditObj.ShowSameHistorical)
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option active units belonging to same division will be highlighted.", ref this.OwnBitmap, num3, num4);
              this.B6Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            else
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option active units belonging to same division will be highlighted.", ref this.OwnBitmap, num3, num4);
              this.B6Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            DrawMod.DrawTextColouredMarc(ref g, "SHOW DIVISIONS", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
            num4 += num5;
          }
        }
        if (this.game.Data.Product != 7)
        {
          if ((double) this.game.Data.RuleVar[419] > 0.0)
          {
            if (!this.game.EditObj.ShowAirRange)
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active the LOS range of the Unit is shown. Hotkey: 6 ", ref this.OwnBitmap, num3, num4);
              this.B14Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            else
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active the LOS range of the Unit is shown. Hotkey: 6 ", ref this.OwnBitmap, num3, num4);
              this.B14Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            DrawMod.DrawTextColouredMarc(ref g, "LINE OF SIGHT", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
            num4 += num5;
          }
          else if ((double) this.game.Data.RuleVar[976] < 1.0 && (double) this.game.Data.RuleVar[990] < 1.0)
          {
            if (!this.game.EditObj.ShowAirRange)
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active air intercept range will be shown on map when selecting air unit. \r\nAnd showing artillery range when selecting artillery unit. \r\nCan slow down performance. Hotkey: 6 ", ref this.OwnBitmap, num3, num4);
              this.B14Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            else
            {
              SubPartClass tsubpart = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active air intercept range will be shown on map when selecting air unit. \r\nAnd showing artillery range when selecting artillery unit. \r\nCan slow down performance. Hotkey: 6 ", ref this.OwnBitmap, num3, num4);
              this.B14Id = this.AddSubPart(ref tsubpart, num3, num4, 35, 35, 1);
            }
            DrawMod.DrawTextColouredMarc(ref g, "AIR + ART RANGE", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
            num4 += num5;
          }
        }
      }
      SubPartClass tsubpart1;
      if (this.currentCat == 1)
      {
        if (!this.game.EditObj.AutoSave)
        {
          SubPartClass tsubpart2 = (SubPartClass) new MarcRadioPartClass(0, false, "Auto-saves are made moment you press end turn button.", ref this.OwnBitmap, num3, num4);
          this.B9Id = this.AddSubPart(ref tsubpart2, num3, num4, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart3 = (SubPartClass) new MarcRadioPartClass(0, true, "Auto-saves are made moment you press end turn button.", ref this.OwnBitmap, num3, num4);
          this.B9Id = this.AddSubPart(ref tsubpart3, num3, num4, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "AUTO SAVE", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        int num17 = num4 + num5;
        if (!this.game.EditObj.Screenshoton)
        {
          SubPartClass tsubpart4 = (SubPartClass) new MarcRadioPartClass(0, false, "At start and end of turn automatic screenshots can enabled.\r\nLook in screenshots directory to find them.", ref this.OwnBitmap, num3, num17);
          this.B13Id = this.AddSubPart(ref tsubpart4, num3, num17, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart5 = (SubPartClass) new MarcRadioPartClass(0, true, "At start and end of turn automatic screenshots can enabled.\r\nLook in screenshots directory to find them.", ref this.OwnBitmap, num3, num17);
          this.B13Id = this.AddSubPart(ref tsubpart5, num3, num17, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "SCREENSHOTS", this.game.MarcFont4, num3 + 50, num17 + 8, Color.White);
        int num18 = num17 + num5;
        if (this.game.Data.Product != 7)
        {
          if (!this.game.EditObj.CombatNumbers)
          {
            SubPartClass tsubpart6 = (SubPartClass) new MarcRadioPartClass(0, false, "Change the way combat results are presented", ref this.OwnBitmap, num3, num18);
            this.B5Id = this.AddSubPart(ref tsubpart6, num3, num18, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart7 = (SubPartClass) new MarcRadioPartClass(0, true, "Change the way combat results are presented", ref this.OwnBitmap, num3, num18);
            this.B5Id = this.AddSubPart(ref tsubpart7, num3, num18, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "COMBAT NUMBERS", this.game.MarcFont4, num3 + 50, num18 + 8, Color.White);
          num18 += num5;
        }
        if (!this.game.EditObj.ShowMouseOver)
        {
          SubPartClass tsubpart8 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is not active mouse overs will only appear on right click.", ref this.OwnBitmap, num3, num18);
          this.B7Id = this.AddSubPart(ref tsubpart8, num3, num18, 35, 35, 1);
        }
        else
        {
          SubPartClass tsubpart9 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is not active mouse overs will only appear on right click.", ref this.OwnBitmap, num3, num18);
          this.B7Id = this.AddSubPart(ref tsubpart9, num3, num18, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "AUTO MOUSE OVER", this.game.MarcFont4, num3 + 50, num18 + 8, Color.White);
        int num19 = num18 + num5;
        if (this.game.Data.Product >= 6)
        {
          if (!this.game.EditObj.AutoCombat)
          {
            SubPartClass tsubpart10 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is not active combat will not automaticly commence resolution.", ref this.OwnBitmap, num3, num19);
            this.b26id = this.AddSubPart(ref tsubpart10, num3, num19, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart11 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is not active combat will not automaticly commence resolution.", ref this.OwnBitmap, num3, num19);
            this.b26id = this.AddSubPart(ref tsubpart11, num3, num19, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "AUTO COMBAT", this.game.MarcFont4, num3 + 50, num19 + 8, Color.White);
          num19 += num5;
        }
        if (this.game.Data.Product == 7)
        {
          if (!this.game.EditObj.maximumInterfaceSpace)
          {
            SubPartClass tsubpart12 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is not active Troops and Asset display space in the bottom will be slightly reduced.", ref this.OwnBitmap, num3, num19);
            this.b27id = this.AddSubPart(ref tsubpart12, num3, num19, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart13 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active Troops and Asset display space in the bottom will be maximalized.", ref this.OwnBitmap, num3, num19);
            this.b27id = this.AddSubPart(ref tsubpart13, num3, num19, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "MAX ASSET SPACE", this.game.MarcFont4, num3 + 50, num19 + 8, Color.White);
          num11 = num19 + num5;
        }
        int num20 = num7;
        num3 += num6;
        if (this.game.Data.Product != 7)
        {
          if (!this.game.EditObj.useLeftRightClickMode)
          {
            SubPartClass tsubpart14 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active you'll use the new left/right click interface for moving.", ref this.OwnBitmap, num3, num20);
            this.b28id = this.AddSubPart(ref tsubpart14, num3, num20, 35, 35, 1);
          }
          else
          {
            SubPartClass tsubpart15 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active you'll use the new left/right click interface for moving.", ref this.OwnBitmap, num3, num20);
            this.b28id = this.AddSubPart(ref tsubpart15, num3, num20, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "LEFT/RIGHT CLICK INTERFACE", this.game.MarcFont4, num3 + 50, num20 + 8, Color.White);
          num20 += num5;
        }
        if ((double) this.game.Data.RuleVar[408] > 0.0)
        {
          if (!this.game.Data.PBEM | this.game.SuperAdminRights)
          {
            tsubpart1 = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONSAVE, tDescript: "Save", tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num20);
            this.B23Id = this.AddSubPart(ref tsubpart1, num3, num20, 35, 35, 1);
            DrawMod.DrawTextColouredMarc(ref g, "SAVE GAME", this.game.MarcFont4, num3 + 50, num20 + 8, Color.White);
            num20 += num5;
          }
          tsubpart1 = (SubPartClass) new MarcButtonPartClass(this.game.BUTTONQUIT, tDescript: "Quit", tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num20);
          this.b25id = this.AddSubPart(ref tsubpart1, num3, num20, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "QUIT GAME", this.game.MarcFont4, num3 + 50, num20 + 8, Color.White);
          num20 += num5;
          tsubpart1 = (SubPartClass) new MarcButtonPartClass(this.game.SYSTEM1, tDescript: "Minimize", tBackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num20);
          this.minId = this.AddSubPart(ref tsubpart1, num3, num20, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "MINIMIZE GAME", this.game.MarcFont4, num3 + 50, num20 + 8, Color.White);
        }
        int num21 = num20 - num5 * 2;
        if (!this.game.EditObj.allowMetrics)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active some (1<KB) game progress core data will at times be sent to " + this.game.MetricsURL + " to help us improve the game balance. You will remain anonymous. It will be appreciated if you switch this on since balancing requires lots of player feedback. ", ref this.OwnBitmap, num3 + 170, num21);
          this.B18Id = this.AddSubPart(ref tsubpart1, num3 + 170, num21, 35, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active some (1<KB) game progress core data will at times be sent to " + this.game.MetricsURL + " to help us improve the game balance. You will remain anonymous. It will be appreciated if you switch this on since balancing requires lots of player feedback. ", ref this.OwnBitmap, num3 + 170, num21);
          this.B18Id = this.AddSubPart(ref tsubpart1, num3 + 170, num21, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "SHARE METRICS", this.game.MarcFont4, num3 + 170 + 50, num21 + 8, Color.White);
        int num22 = num21 + num5 * 3;
        this.game.Data.DontShowAIMove = this.game.EditObj.dontShowAImoves;
        if (this.game.EditObj.dontShowAImoves)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active you'll be in History Screen while AI makes moves.", ref this.OwnBitmap, num3, num22);
          this.b30id = this.AddSubPart(ref tsubpart1, num3, num22, 35, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is not active you'll just get a popup window while AI is making moves.", ref this.OwnBitmap, num3, num22);
          this.b30id = this.AddSubPart(ref tsubpart1, num3, num22, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "SHOW AI MOVES", this.game.MarcFont4, num3 + 50, num22 + 8, Color.White);
        int num23 = num22 + num5;
        if (!this.game.EditObj.showAdvice)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active the Advise window will be available.", ref this.OwnBitmap, num3, num23);
          this.b32id = this.AddSubPart(ref tsubpart1, num3, num23, 35, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is not active no Advise window will be available.", ref this.OwnBitmap, num3, num23);
          this.b32id = this.AddSubPart(ref tsubpart1, num3, num23, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "SHOW ADVICE", this.game.MarcFont4, num3 + 50, num23 + 8, Color.White);
        num4 = num23 + num5;
      }
      if (this.currentCat != 4)
        return;
      int num24 = 1;
      int num25 = 1024;
      if (!this.game.EditObj.DoubleSize)
      {
        if (this.game.Data.Product == 7)
        {
          num25 = 1280;
          if (!((double) this.game.RealScreenWidth >= 1600.0 * (double) num24 & (double) this.game.RealScreenHeight >= 960.0 * (double) num24))
            DrawMod.DrawTextColouredMarc(ref g, "Your need to have a resolution equal or above 1280x960 to have >100% DPI prefs. ", this.game.MarcFont4, num3, num4, Color.White);
        }
        else if (!((double) this.game.RealScreenWidth >= 1280.0 * (double) num24 & (double) this.game.RealScreenHeight >= 960.0 * (double) num24))
          DrawMod.DrawTextColouredMarc(ref g, "Your need to have a resolution equal or above 1280x960 to have >100% DPI prefs. ", this.game.MarcFont4, num3, num4, Color.White);
      }
      if (this.game.EditObj.DoubleSizePercentage != 75)
      {
        if (!this.game.EditObj.DoubleSize & (double) this.game.RealScreenWidth >= (double) num25 * 1.25 * (double) num24 & (double) this.game.RealScreenHeight >= 960.0 * (double) num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 7/8 of your real resolution.", ref this.OwnBitmap, num3, num4);
          this.B17bId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "7/8 RESOLUTION (125% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage == 125)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active your screen resolution will appear to be 7/8 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17bId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "7/8 RESOLUTION (125% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage != 125 & (double) this.game.RealScreenWidth >= (double) num25 * 1.25 * (double) num24 & (double) this.game.RealScreenHeight >= 960.0 * (double) num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 7/8 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17bId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "7/8 RESOLUTION (125% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        num4 += num5;
        if (!this.game.EditObj.DoubleSize & (double) this.game.RealScreenWidth >= (double) num25 * 1.5 * (double) num24 & (double) this.game.RealScreenHeight >= 1152.0 * (double) num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 3/4 of your real resolution.", ref this.OwnBitmap, num3, num4);
          this.B17cId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "3/4 RESOLUTION (150% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage == 150)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active your screen resolution will appear to be 3/4 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17cId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "3/4 RESOLUTION (150% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage != 150 & (double) this.game.RealScreenWidth >= (double) num25 * 1.5 * (double) num24 & (double) this.game.RealScreenHeight >= 1152.0 * (double) num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 3/4 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17cId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "3/4 RESOLUTION (150% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        if (this.B17cId > 0)
          num4 += num5;
        if (!this.game.EditObj.DoubleSize & (double) this.game.RealScreenWidth >= (double) num25 * 1.75 * (double) num24 & (double) this.game.RealScreenHeight >= 1344.0 * (double) num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 5/8 of your real resolution.", ref this.OwnBitmap, num3, num4);
          this.B17dId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "5/8 RESOLUTION (175% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage == 175)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active your screen resolution will appear to be 5/8 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17dId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "5/8 RESOLUTION (175% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage != 175 & (double) this.game.RealScreenWidth >= (double) num25 * 1.75 * (double) num24 & (double) this.game.RealScreenHeight >= 1344.0 * (double) num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 5/8 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17dId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "5/8 RESOLUTION (175% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        if (this.B17dId > 0)
          num4 += num5;
        if (!this.game.EditObj.DoubleSize & this.game.RealScreenWidth >= num25 * 2 * num24 & this.game.RealScreenHeight >= 1536 * num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 1/2 of your real resolution.", ref this.OwnBitmap, num3, num4);
          this.B17Id = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "1/2 RESOLUTION (200% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage == 200)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active your screen resolution will appear to be 1/2 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17Id = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "1/2 RESOLUTION (200% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage != 200 & this.game.RealScreenWidth >= num25 * 2 * num24 & this.game.RealScreenHeight >= 1536 * num24)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be 1/2 of your real resolution. ", ref this.OwnBitmap, num3, num4);
          this.B17Id = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
          DrawMod.DrawTextColouredMarc(ref g, "1/2 RESOLUTION (200% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
        }
        else
        {
          int num26 = this.game.SuperAdminRights ? 1 : 0;
        }
        if (this.B17Id > 0)
          num4 += num5;
      }
      if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage == 75)
      {
        tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active your screen resolution will appear to be larger than your real resolution. Will result in some loss of quality and readability.", ref this.OwnBitmap, num3, num4);
        this.B17eId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
      }
      else
      {
        tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be larger than your real resolution. Will result in some loss of quality and readability.", ref this.OwnBitmap, num3, num4);
        this.B17eId = this.AddSubPart(ref tsubpart1, num3, num4, 35, 35, 1);
      }
      DrawMod.DrawTextColouredMarc(ref g, "5/4 RESOLUTION (75% DPI)", this.game.MarcFont4, num3 + 50, num4 + 8, Color.White);
      int num27 = num4 + num5;
      if (this.game.EventRelatedObj.Helper_IsDebug())
      {
        if (this.game.EditObj.DoubleSize & this.game.EditObj.DoubleSizePercentage == 50)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "When option is active your screen resolution will appear to be larger than your real resolution. Will result in some loss of quality and readability.", ref this.OwnBitmap, num3, num27);
          this.B17fId = this.AddSubPart(ref tsubpart1, num3, num27, 35, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "When option is active your screen resolution will appear to be larger than your real resolution. Will result in some loss of quality and readability.", ref this.OwnBitmap, num3, num27);
          this.B17fId = this.AddSubPart(ref tsubpart1, num3, num27, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "2/1 RESOLUTION (50% DPI)", this.game.MarcFont4, num3 + 50, num27 + 8, Color.White);
        num11 = num27 + num5;
      }
      int num28;
      if (!((double) this.game.RealScreenWidth >= (double) num25 * 1.25 * (double) num24 & (double) this.game.RealScreenHeight >= 960.0 * (double) num24))
      {
        num28 = num7 + num5 + num5;
      }
      else
      {
        num28 = num7;
        num3 += num6 + 50;
      }
      if (this.game.HighGraphicsSpeedPossible)
      {
        if (!this.game.EditObj.highGfxSpeedOn)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "HIGHSPEED GFX: Presses the most speed out of Windows GDI(+) graphics possible. Advised to leave flagged unless you are experiencing problems. ", ref this.OwnBitmap, num3, num28);
          this.B20Id = this.AddSubPart(ref tsubpart1, num3, num28, 35, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "HIGHSPEED GFX: Presses the most speed out of Windows GDI(+) graphics possible. Advised to leave flagged unless you are experiencing problems. ", ref this.OwnBitmap, num3, num28);
          this.B20Id = this.AddSubPart(ref tsubpart1, num3, num28, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "Speed", this.game.MarcFont4, num3 + 35, num28 + 8, Color.White);
        if (!this.game.EditObj.skipGfxDetail)
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "SKIP GFX DETAILS: Flag to skip some aesthetical details to render the map faster. Only flag if things are to slow. ", ref this.OwnBitmap, num3 + 85, num28);
          this.b36id = this.AddSubPart(ref tsubpart1, num3 + 85, num28, 35, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "SKIP GFX DETAILS: Flag to skip some aesthetical details to render the map faster. Only flag if things are to slow. ", ref this.OwnBitmap, num3 + 85, num28);
          this.b36id = this.AddSubPart(ref tsubpart1, num3 + 85, num28, 35, 35, 1);
        }
        DrawMod.DrawTextColouredMarc(ref g, "Skip", this.game.MarcFont4, num3 + 85 + 35, num28 + 8, Color.White);
        if (!((double) this.game.RealScreenWidth >= (double) num25 * 1.25 * (double) num24 & (double) this.game.RealScreenHeight >= 960.0 * (double) num24))
        {
          int num29 = num28 + num5;
          if (!this.game.EditObj.mouseScreenLock)
          {
            tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "Mouse Lock locks your mouse to the Windows bounds. You might want to disable in certain multi-monitor or bordered-window play modes. ", ref this.OwnBitmap, num3, num29);
            this.b31id = this.AddSubPart(ref tsubpart1, num3, num29, 35, 35, 1);
          }
          else
          {
            tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "Mouse Lock locks your mouse to the Windows bounds. You might want to disable in certain multi-monitor or bordered-window play modes. ", ref this.OwnBitmap, num3, num29);
            this.b31id = this.AddSubPart(ref tsubpart1, num3, num29, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "Mouse Lock", this.game.MarcFont4, num3 + 50, num29 + 8, Color.White);
          num28 = num29 + num5;
        }
        else
        {
          if (!this.game.EditObj.mouseScreenLock)
          {
            tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, false, "Mouse Lock locks your mouse to the Windows bounds. You might want to disable in certain multi-monitor or bordered-window play modes. ", ref this.OwnBitmap, num3 + 160, num28);
            this.b31id = this.AddSubPart(ref tsubpart1, num3 + 160, num28, 35, 35, 1);
          }
          else
          {
            tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, true, "Mouse Lock locks your mouse to the Windows bounds. You might want to disable in certain multi-monitor or bordered-window play modes. ", ref this.OwnBitmap, num3 + 160, num28);
            this.b31id = this.AddSubPart(ref tsubpart1, num3 + 160, num28, 35, 35, 1);
          }
          DrawMod.DrawTextColouredMarc(ref g, "Mouse Lock", this.game.MarcFont4, num3 + 160 + 40, num28 + 8, Color.White);
          num28 += num5;
        }
      }
      if (!(this.game.Data.Product >= 6 & !this.formref.windowsTxtFormPlease))
        return;
      if (num3 < num6 + 50)
      {
        int num30 = num7;
        num3 += num6 + 50;
        num28 = num30 + num5;
      }
      this.OptionsListObj = new ListClass();
      DEVMODE1 lpDevMode1 = new DEVMODE1();
      DEVMODE1 lpDevMode2 = new DEVMODE1();
      this.resList = new SimpleList();
      Form1.EnumDisplaySettings(0, -1, ref lpDevMode2);
      lpDevMode1.dmSize = (short) Marshal.SizeOf((object) lpDevMode1);
      int iModeNum = 0;
      int num31 = -1;
      int tlistselect = -1;
      SimpleList simpleList = new SimpleList();
      bool flag = false;
      int num32 = num31 + 1;
      string tname1 = "Desktop (" + this.game.StartupScreenWidth.ToString() + "x" + this.game.StartupScreenHeight.ToString() + ")";
      if (this.detailnr == -1)
      {
        if (this.game.EditObj.overruleScreenResWidth < 1 && this.game.EditObj.overruleScreenResHeight < 1)
          this.detailnr = num32;
        if (this.game.StartupScreenWidth == lpDevMode2.dmPelsWidth & this.game.StartupScreenHeight == lpDevMode2.dmPelsHeight)
          this.detailnr = num32;
      }
      if (this.game.StartupScreenWidth == lpDevMode2.dmPelsWidth & this.game.StartupScreenHeight == lpDevMode2.dmPelsHeight)
      {
        tname1 += " (Current Res)";
        if (tlistselect == num32)
          flag = true;
      }
      simpleList.Add(this.game.StartupScreenWidth, 1, this.game.StartupScreenHeight, CheckExistence: false);
      this.OptionsListObj.add(tname1, num32);
      if (num32 == this.detailnr)
        tlistselect = num32;
      for (; Form1.EnumDisplaySettings(0, iModeNum, ref lpDevMode1); ++iModeNum)
      {
        if ((int) lpDevMode2.dmBitsPerPel == (int) lpDevMode1.dmBitsPerPel && lpDevMode1.dmPelsWidth >= 1280 & lpDevMode1.dmPelsHeight > 768 && simpleList.FindNr(lpDevMode1.dmPelsWidth, lpDevMode1.dmPelsHeight) == -1)
        {
          ++num32;
          if (this.detailnr == -1 && this.game.EditObj.overruleScreenResWidth == lpDevMode1.dmPelsWidth && this.game.EditObj.overruleScreenResHeight == lpDevMode1.dmPelsHeight)
            this.detailnr = num32;
          if (num32 == this.detailnr)
            tlistselect = num32;
          simpleList.Add(lpDevMode1.dmPelsWidth, 1, lpDevMode1.dmPelsHeight, CheckExistence: false);
          string tname2 = lpDevMode1.dmPelsWidth.ToString() + "x" + lpDevMode1.dmPelsHeight.ToString();
          if (lpDevMode1.dmPelsWidth == lpDevMode2.dmPelsWidth & lpDevMode1.dmPelsHeight == lpDevMode2.dmPelsHeight)
          {
            tname2 += " (Current Res)";
            if (tlistselect == num32)
              flag = true;
          }
          this.resList.Add(num32, 1, lpDevMode1.dmPelsWidth, lpDevMode1.dmPelsHeight, CheckExistence: false);
          this.OptionsListObj.add(tname2, num32);
        }
      }
      if (this.optionsListId > 0)
      {
        this.SubPartList[this.SubpartNr(this.optionsListId)].Refresh(this.OptionsListObj, tlistselect);
        this.SubPartFlag[this.SubpartNr(this.optionsListId)] = true;
      }
      else
      {
        tsubpart1 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, 5, 250, tlistselect, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: num3, bby: num28, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
        this.optionsListId = this.AddSubPart(ref tsubpart1, num3, num28, 250, 144, 0);
      }
      int num33 = num28 + 144 + 8;
      if (flag)
      {
        tsubpart1 = (SubPartClass) new TextButtonPartClass("CHANGE RESOLUTION", 240, "Resolution selected is the current resolution. So you cannot really change to it.", ref this.OwnBitmap, num3, num33, true, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.b29id = this.AddSubPart(ref tsubpart1, num3, num33, 240, 35, 0);
      }
      else
      {
        tsubpart1 = (SubPartClass) new TextButtonPartClass("CHANGE RESOLUTION", 240, "Select a desired screen resolution in the listbox and confirm by pressing this button. Resolution will be changed. DPI will reset to default.", ref this.OwnBitmap, num3, num33, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.b29id = this.AddSubPart(ref tsubpart1, num3, num33, 240, 35, 1);
      }
      DrawMod.DrawTextColouredMarc(ref g, "Switch Real Resolution", this.game.MarcFont4, num3 + 50, num33 + 8, Color.White);
      num11 = num33 + num5;
    }

    public override void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            return;
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    public override WindowReturnClass HandleMouseUp(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      OrderResult orderResult = new OrderResult();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (this.SubPartList[index].Scroller)
          {
            int num = this.SubPartID[index];
            if (num == this.slider1id)
            {
              this.game.EditObj.Volume = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = false;
              this.SubPartList[this.SubpartNr(this.slider2id)].Scroller = false;
              SoundMod.ChangeEventSoundBg(this.game.EditObj);
              return windowReturnClass;
            }
            if (num == this.slider2id)
            {
              this.game.EditObj.Volume2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = false;
              this.SubPartList[this.SubpartNr(this.slider1id)].Scroller = false;
              SoundMod.ChangeEventSound(this.game.EditObj);
              return windowReturnClass;
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          if (this.MouseData[mouseCounter] > 1000)
          {
            this.currentCat = this.MouseData[mouseCounter] - 1000;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[mouseCounter] == 999)
          {
            this.game.EditObj.SetViewMode2 = 0;
            windowReturnClass.AddCommand(1, 9);
            windowReturnClass.AddCommand(7, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      int mouseCounter1 = this.MouseCounter;
      for (int index = 0; index <= mouseCounter1; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 1000)
          {
            this.currentCat = this.MouseData[index] - 1000;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[index] == 999)
          {
            this.game.EditObj.SetViewMode2 = 0;
            windowReturnClass.AddCommand(1, 9);
            windowReturnClass.AddCommand(7, 12);
            windowReturnClass.AddCommand(4, 67);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.optionsListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 <= -1)
                return windowReturnClass;
              this.detailnr = num2;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.slider1id)
            {
              this.game.EditObj.Volume = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = true;
              SoundMod.ChangeEventSoundBg(this.game.EditObj);
              return windowReturnClass;
            }
            if (num1 == this.slider2id)
            {
              this.game.EditObj.Volume2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index], b);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              this.SubPartList[index].Scroller = true;
              SoundMod.ChangeEventSound(this.game.EditObj);
              return windowReturnClass;
            }
            if (num1 == this.B1Id)
            {
              this.game.EditObj.SoundOn = !this.game.EditObj.SoundOn;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B19Id)
            {
              this.game.EditObj.AlternateMusic = !this.game.EditObj.AlternateMusic;
              SoundMod.STopEventBackground();
              SoundMod.RestartLastBackground(ref this.game.EditObj);
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B2Id)
            {
              this.game.EditObj.PrefShowFOW = !this.game.EditObj.PrefShowFOW;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B8Id)
            {
              this.game.EditObj.IntroSoundOn = !this.game.EditObj.IntroSoundOn;
              if (!this.game.EditObj.IntroSoundOn)
              {
                if (this.game.Data.Product == 7)
                {
                  SoundMod.STopEventBackground();
                  SoundMod.dssEnd(ref this.game.EditObj);
                }
                else
                  SoundMod.STopEventBackground();
              }
              else if (this.game.Data.Product == 7)
              {
                SoundMod.RestartLastBackground(ref this.game.EditObj);
                SoundMod.dssTimer(ref this.game.EditObj);
              }
              else
                SoundMod.RestartLastBackground(ref this.game.EditObj);
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B9Id)
            {
              this.game.EditObj.AutoSave = !this.game.EditObj.AutoSave;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B24Id)
            {
              this.game.EditObj.ShowLISRange = !this.game.EditObj.ShowLISRange;
              if (this.game.EditObj.ShowLISRange)
              {
                this.game.EditObj.ShowHQPower = false;
                this.game.EditObj.ShowAirRange = false;
              }
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B5Id)
            {
              this.game.EditObj.CombatNumbers = !this.game.EditObj.CombatNumbers;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B21Id)
            {
              if (this.game.EditObj.HideUnit == 2)
                this.game.EditObj.HideUnit = 1;
              else
                this.game.EditObj.HideUnit = 2;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.AddCommand(4, 2);
              windowReturnClass.AddCommand(4, 69);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B22Id)
            {
              this.game.EditObj.SpreadUnit = !this.game.EditObj.SpreadUnit;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.AddCommand(4, 2);
              windowReturnClass.AddCommand(4, 69);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B3Id)
            {
              this.game.EditObj.ShowUnderHQ = !this.game.EditObj.ShowUnderHQ;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B6Id)
            {
              this.game.EditObj.ShowSameHistorical = !this.game.EditObj.ShowSameHistorical;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B7Id)
            {
              this.game.EditObj.ShowMouseOver = !this.game.EditObj.ShowMouseOver;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b26id)
            {
              this.game.EditObj.AutoCombat = !this.game.EditObj.AutoCombat;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b27id)
            {
              this.game.EditObj.maximumInterfaceSpace = !this.game.EditObj.maximumInterfaceSpace;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b31id)
            {
              this.game.EditObj.mouseScreenLock = !this.game.EditObj.mouseScreenLock;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b28id)
            {
              this.game.EditObj.useLeftRightClickMode = !this.game.EditObj.useLeftRightClickMode;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b30id)
            {
              this.game.EditObj.dontShowAImoves = !this.game.EditObj.dontShowAImoves;
              this.game.Data.DontShowAIMove = this.game.EditObj.dontShowAImoves;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b32id)
            {
              this.game.EditObj.showAdvice = !this.game.EditObj.showAdvice;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b33id)
            {
              int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
              int setValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, 56, 2))) == 1 ? 0 : 1;
              this.game.Data.StringListObj[stringListById].SetData(0, 56, 2, setValue);
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b34id)
            {
              int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
              int setValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, 56, 2))) == 2 ? 0 : 2;
              this.game.Data.StringListObj[stringListById].SetData(0, 56, 2, setValue);
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b35id)
            {
              int stringListById = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0));
              int setValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, 56, 2))) == 0 ? 0 : 0;
              this.game.Data.StringListObj[stringListById].SetData(0, 56, 2, setValue);
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B10Id)
            {
              this.game.EditObj.ShowLabel = !this.game.EditObj.ShowLabel;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B11Id)
            {
              this.game.EditObj.HideAS = !this.game.EditObj.HideAS;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b36id)
            {
              this.game.EditObj.skipGfxDetail = !this.game.EditObj.skipGfxDetail;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B12Id)
            {
              this.game.EditObj.ShowHQPower = !this.game.EditObj.ShowHQPower;
              if (this.game.EditObj.ShowHQPower)
                this.game.EditObj.ShowLISRange = false;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B16Id)
            {
              this.game.EditObj.RegimeColoring = !this.game.EditObj.RegimeColoring;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B13Id)
            {
              this.game.EditObj.Screenshoton = !this.game.EditObj.Screenshoton;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B20Id)
            {
              this.game.EditObj.highGfxSpeedOn = !this.game.EditObj.highGfxSpeedOn;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B4Id)
            {
              this.game.EditObj.HexRasterOn = !this.game.EditObj.HexRasterOn;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B14Id)
            {
              this.game.EditObj.ShowAirRange = !this.game.EditObj.ShowAirRange;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B15Id)
            {
              this.game.EditObj.PrefMinimalistCounter = !this.game.EditObj.PrefMinimalistCounter;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 68);
              windowReturnClass.AddCommand(4, 9);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B18Id)
            {
              this.game.EditObj.allowMetrics = !this.game.EditObj.allowMetrics;
              this.game.EditObj.Save(this.game.AppPath + "editobj.txt");
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b29id)
            {
              if (this.detailnr == 0)
              {
                this.game.HandyFunctionsObj.SwitchResolution2(ref this.formref, this.game.StartupScreenWidth, this.game.StartupScreenHeight, true);
                windowReturnClass.AddCommand(3, 11);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (!Information.IsNothing((object) this.resList) & this.detailnr > -1)
              {
                int nr = this.resList.FindNr(this.detailnr);
                if (nr > -1)
                {
                  this.game.HandyFunctionsObj.SwitchResolution2(ref this.formref, this.resList.Data1[nr], this.resList.Data2[nr], false);
                  windowReturnClass.AddCommand(3, 11);
                  windowReturnClass.SetFlag(true);
                }
              }
              return windowReturnClass;
            }
            if (num1 == this.B17bId)
            {
              if (this.game.EditObj.DoubleSizePercentage == 125)
              {
                this.game.EditObj.DoubleSize = false;
                this.game.EditObj.DoubleSizePercentage = 100;
              }
              else
              {
                this.game.EditObj.DoubleSize = true;
                this.game.EditObj.DoubleSizePercentage = 125;
              }
              this.game.HandyFunctionsObj.SwitchResolution(ref this.formref);
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B17cId)
            {
              if (this.game.EditObj.DoubleSizePercentage == 150)
              {
                this.game.EditObj.DoubleSize = false;
                this.game.EditObj.DoubleSizePercentage = 100;
              }
              else
              {
                this.game.EditObj.DoubleSize = true;
                this.game.EditObj.DoubleSizePercentage = 150;
              }
              this.game.HandyFunctionsObj.SwitchResolution(ref this.formref);
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B17dId)
            {
              if (this.game.EditObj.DoubleSizePercentage == 175)
              {
                this.game.EditObj.DoubleSize = false;
                this.game.EditObj.DoubleSizePercentage = 100;
              }
              else
              {
                this.game.EditObj.DoubleSize = true;
                this.game.EditObj.DoubleSizePercentage = 175;
              }
              this.game.HandyFunctionsObj.SwitchResolution(ref this.formref);
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B17eId)
            {
              if (this.game.EditObj.DoubleSizePercentage == 75)
              {
                this.game.EditObj.DoubleSize = false;
                this.game.EditObj.DoubleSizePercentage = 100;
              }
              else
              {
                this.game.EditObj.DoubleSize = true;
                this.game.EditObj.DoubleSizePercentage = 75;
              }
              this.game.HandyFunctionsObj.SwitchResolution(ref this.formref);
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B17fId)
            {
              if (this.game.EditObj.DoubleSizePercentage == 50)
              {
                this.game.EditObj.DoubleSize = false;
                this.game.EditObj.DoubleSizePercentage = 100;
              }
              else
              {
                this.game.EditObj.DoubleSize = true;
                this.game.EditObj.DoubleSizePercentage = 50;
              }
              this.game.HandyFunctionsObj.SwitchResolution(ref this.formref);
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.B17Id)
            {
              if (this.game.EditObj.DoubleSizePercentage == 200)
              {
                this.game.EditObj.DoubleSize = false;
                this.game.EditObj.DoubleSizePercentage = 100;
              }
              else
              {
                this.game.EditObj.DoubleSize = true;
                this.game.EditObj.DoubleSizePercentage = 200;
              }
              this.game.HandyFunctionsObj.SwitchResolution(ref this.formref);
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.b25id)
            {
              if (Interaction.MsgBox((object) "Quitting... are you sure?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.game.Data = new DataClass();
                this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                this.game.EditObj.ShowInitialMenu = true;
                windowReturnClass.AddCommand(3, 12);
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.minId)
              {
                this.game.FormRef.WindowState = FormWindowState.Minimized;
                return windowReturnClass;
              }
              if (num1 == this.B23Id)
              {
                string str1;
                if (this.game.Data.Round == 0)
                {
                  string str2 = this.game.AppPath + "scenarios\\";
                  if (!Information.IsNothing((object) this.game.Data.ScenarioDir))
                  {
                    if (this.game.Data.ScenarioDir.Length > 1)
                      str1 = str2.Replace("scenarios", this.game.Data.ScenarioDir);
                    else if (this.game.ModScenarioDir.Length > 1)
                      str1 = str2.Replace("scenarios", this.game.ModScenarioDir);
                  }
                  else if (this.game.ModScenarioDir.Length > 1)
                    str1 = str2.Replace("scenarios", this.game.ModScenarioDir);
                }
                else
                  str1 = "savedgames";
                string str3 = this.game.Data.Round != 0 ? this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1", "Give save name...", this.game.AppPath_SAVEGAMES, false) : this.game.HandyFunctionsObj.SaveSomething("SE1 Scenario file (*.se1)|*.se1", "Give save name...", this.game.AppPath_SAVEGAMES, false);
                if (Strings.Len(str3) >= 2)
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  this.game.Data.serialize(str3);
                  this.game.HandyFunctionsObj.ZipFile(str3);
                  windowReturnClass.SetFlag(true);
                  this.game.FormRef.Cursor = Cursors.Default;
                }
              }
            }
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
