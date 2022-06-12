// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PlayExtraWindowClass
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
  public class PlayExtraWindowClass : WindowClass
  {
    private int UnitHeaderId;
    private int UnitsfId;
    private int OfficerId;
    private int QuickInfoId;
    private int StatsId;
    private int ReportId;
    private int DisbandId;
    private int SfButtonId;
    private int DisbandTroopsId;
    private int DisbandItemsId;
    private int ItemsButtonId;
    private int CurrentView;
    private int NewSFId;
    private int SOA1Id;
    private int SOA2Id;
    private int SOA3Id;
    private int SOA4Id;
    private int SOATextId;
    private int SOB1Id;
    private int SOB2Id;
    private int SOB3Id;
    private int SOB4Id;
    private int SOBTextid;
    private int OptionsListId;
    private ATListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int AttackPercentId;
    private int DefendPercentID;
    private int ReplacementID;
    private int RequestSupID;
    private ATListClass ListObj;
    private int CancelButtonId;
    private int CancelTextId;
    private int OrderTextId;
    private int AsId;
    private int OrderText2Id;
    private int OrderText3Id;
    private int OrderText4Id;
    private int ClearId;
    private int ClearTextId;
    private int OrderUpId;
    private int OrderDownId;
    private int OrderOkId;
    private int OrderOkTextId;
    private int OrderOk2Id;
    private int DitchId;
    private int ReserveId;
    private int OrderOk2TextId;
    private int ExtraId;
    private int SliderButtonId;
    private int AcapId;
    private int DefId;
    private int SupplyId;
    private int InterceptId;
    private int detail1;
    private int detail2;
    private int detail2a;
    private int detailSkill;
    private int detail2b;
    private int detail1b;
    private SubPartClass listy;

    public PlayExtraWindowClass(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, tGame.ScreenWidth, 210, 99, screenbitmap: screenbitmap, sx: sx, sy: sy)
    {
      this.CurrentView = 1;
      if (this.game.EditObj.SetViewMode > 0)
      {
        this.CurrentView = this.game.EditObj.SetViewMode;
        this.game.EditObj.SetViewMode = 0;
      }
      this.detail1 = -1;
      this.detail2 = -1;
      this.detail2a = -1;
      if (this.game.SelectX > -1 & this.game.SelectY > -1 & this.game.EditObj.UnitSelected == -1 && this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter > -1)
        this.game.EditObj.UnitSelected = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitList[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.SelectX, this.game.SelectY].UnitCounter];
      this.dostuff();
    }

    public override void HandleToolTip(int x, int y)
    {
      if (!this.formref.RightMousePressed)
        return;
      this.game.EditObj.TipTitle = "UNIT WINDOW";
      this.game.EditObj.TipText = "You can inspect your units here.";
    }

    public override string WindowDescription(int x, int y)
    {
      string str = "";
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
          return this.MouseText[index];
      }
      int num = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      return str;
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff_backup()
    {
      if (this.UnitHeaderId > 0)
        this.RemoveSubPart(this.UnitHeaderId);
      if (this.UnitsfId > 0)
        this.RemoveSubPart(this.UnitsfId);
      if (this.SfButtonId > 0)
        this.RemoveSubPart(this.SfButtonId);
      if (this.ItemsButtonId > 0)
        this.RemoveSubPart(this.ItemsButtonId);
      if (this.StatsId > 0)
        this.RemoveSubPart(this.StatsId);
      if (this.ReportId > 0)
        this.RemoveSubPart(this.ReportId);
      if (this.NewSFId > 0)
        this.RemoveSubPart(this.NewSFId);
      if (this.SOA1Id > 0)
        this.RemoveSubPart(this.SOA1Id);
      if (this.SOA2Id > 0)
        this.RemoveSubPart(this.SOA2Id);
      if (this.SOA3Id > 0)
        this.RemoveSubPart(this.SOA3Id);
      if (this.SOA4Id > 0)
        this.RemoveSubPart(this.SOA4Id);
      if (this.SOB1Id > 0)
        this.RemoveSubPart(this.SOB1Id);
      if (this.SOB2Id > 0)
        this.RemoveSubPart(this.SOB2Id);
      if (this.SOB3Id > 0)
        this.RemoveSubPart(this.SOB3Id);
      if (this.SOB4Id > 0)
        this.RemoveSubPart(this.SOB4Id);
      if (this.SOATextId > 0)
        this.RemoveSubPart(this.SOATextId);
      if (this.AsId > 0)
        this.RemoveSubPart(this.AsId);
      if (this.SOBTextid > 0)
        this.RemoveSubPart(this.SOBTextid);
      if (this.DisbandId > 0)
        this.RemoveSubPart(this.DisbandId);
      if (this.ReplacementID > 0)
        this.RemoveSubPart(this.ReplacementID);
      if (this.DefendPercentID > 0)
        this.RemoveSubPart(this.DefendPercentID);
      if (this.RequestSupID > 0)
        this.RemoveSubPart(this.RequestSupID);
      if (this.OfficerId > 0)
        this.RemoveSubPart(this.OfficerId);
      if (this.QuickInfoId > 0)
        this.RemoveSubPart(this.QuickInfoId);
      if (this.CancelButtonId > 0)
        this.RemoveSubPart(this.CancelButtonId);
      if (this.CancelTextId > 0)
        this.RemoveSubPart(this.CancelTextId);
      if (this.OrderTextId > 0)
        this.RemoveSubPart(this.OrderTextId);
      if (this.OrderText2Id > 0)
        this.RemoveSubPart(this.OrderText2Id);
      if (this.OrderText3Id > 0)
        this.RemoveSubPart(this.OrderText3Id);
      if (this.ClearId > 0)
        this.RemoveSubPart(this.ClearId);
      if (this.ClearTextId > 0)
        this.RemoveSubPart(this.ClearTextId);
      if (this.OrderUpId > 0)
        this.RemoveSubPart(this.OrderUpId);
      if (this.OrderDownId > 0)
        this.RemoveSubPart(this.OrderDownId);
      if (this.OrderOkId > 0)
        this.RemoveSubPart(this.OrderOkId);
      if (this.OrderOkTextId > 0)
        this.RemoveSubPart(this.OrderOkTextId);
      if (this.OrderOk2Id > 0)
        this.RemoveSubPart(this.OrderOk2Id);
      if (this.OrderOk2TextId > 0)
        this.RemoveSubPart(this.OrderOk2TextId);
      if (this.ExtraId > 0)
        this.RemoveSubPart(this.ExtraId);
      if (this.SliderButtonId > 0)
        this.RemoveSubPart(this.SliderButtonId);
      if (this.DisbandTroopsId > 0)
        this.RemoveSubPart(this.DisbandTroopsId);
      if (this.DisbandItemsId > 0)
        this.RemoveSubPart(this.DisbandItemsId);
      if (this.AcapId > 0)
        this.RemoveSubPart(this.AcapId);
      if (this.DefId > 0)
        this.RemoveSubPart(this.DefId);
      if (this.SupplyId > 0)
        this.RemoveSubPart(this.SupplyId);
      if (this.InterceptId > 0)
        this.RemoveSubPart(this.InterceptId);
      if (this.game.EditObj.UnitSelected > -1)
      {
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerCounter <= 6 && this.OptionsListId > 0)
        {
          this.RemoveSubPart(this.OptionsListId);
          this.OptionsListId = 0;
        }
      }
      else if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      this.detail1b = 0;
      this.detail2b = 0;
      this.NewBackGroundAndClearAll(this.game.ScreenWidth, 200, -1);
      Graphics.FromImage((Image) this.OwnBitmap);
      int num = 0;
      if (this.game.EditObj.OrderType < 1)
        num = 1;
      if (this.game.EditObj.OrderType == 1)
        num = 1;
      if (this.game.EditObj.OrderType == 9 & this.game.EditObj.OrderTarget == -1)
        num = 1;
      if (this.game.EditObj.OrderType == 18 & this.game.EditObj.OrderTarget == -1)
        num = 1;
      if (this.game.EditObj.OrderType == 18 & this.game.EditObj.TargetX == -1)
        num = 1;
      if (this.game.EditObj.OrderType == 3)
        num = 1;
      if (this.game.EditObj.OrderType == 19)
        num = 1;
      if (this.game.EditObj.OrderType == 14)
        num = 1;
      if (this.game.EditObj.OrderType == 15)
        num = 1;
      if (this.game.EditObj.OrderType == 2)
        num = 1;
      if (this.game.EditObj.OrderType == 12)
        num = 1;
      if (this.game.EditObj.OrderType == 11)
        num = 1;
      if (this.game.EditObj.OrderType == 13)
        num = 1;
      if (this.game.EditObj.OrderType == 21)
        num = 1;
      if (this.game.EditObj.OrderType == 20)
        num = 1;
      if (this.game.EditObj.OrderType == 37)
        num = 1;
      if (this.game.EditObj.OrderType == 36)
        num = 1;
      if (this.game.EditObj.OrderType == 35)
        num = 1;
      if (this.game.EditObj.OrderType == 39)
        num = 1;
      if (this.game.EditObj.OrderType == 40)
        num = 1;
      if (this.game.EditObj.HideUnit != 0)
        return;
      num = 0;
    }

    public void dostuff()
    {
      if (this.UnitHeaderId > 0)
        this.RemoveSubPart(this.UnitHeaderId);
      if (this.UnitsfId > 0)
        this.RemoveSubPart(this.UnitsfId);
      if (this.SfButtonId > 0)
        this.RemoveSubPart(this.SfButtonId);
      if (this.ItemsButtonId > 0)
        this.RemoveSubPart(this.ItemsButtonId);
      if (this.StatsId > 0)
        this.RemoveSubPart(this.StatsId);
      if (this.ReportId > 0)
        this.RemoveSubPart(this.ReportId);
      if (this.NewSFId > 0)
        this.RemoveSubPart(this.NewSFId);
      if (this.SOA1Id > 0)
        this.RemoveSubPart(this.SOA1Id);
      if (this.SOA2Id > 0)
        this.RemoveSubPart(this.SOA2Id);
      if (this.SOA3Id > 0)
        this.RemoveSubPart(this.SOA3Id);
      if (this.SOA4Id > 0)
        this.RemoveSubPart(this.SOA4Id);
      if (this.SOB1Id > 0)
        this.RemoveSubPart(this.SOB1Id);
      if (this.SOB2Id > 0)
        this.RemoveSubPart(this.SOB2Id);
      if (this.SOB3Id > 0)
        this.RemoveSubPart(this.SOB3Id);
      if (this.SOB4Id > 0)
        this.RemoveSubPart(this.SOB4Id);
      if (this.SOATextId > 0)
        this.RemoveSubPart(this.SOATextId);
      if (this.AsId > 0)
        this.RemoveSubPart(this.AsId);
      if (this.SOBTextid > 0)
        this.RemoveSubPart(this.SOBTextid);
      if (this.DisbandId > 0)
        this.RemoveSubPart(this.DisbandId);
      if (this.ReplacementID > 0)
        this.RemoveSubPart(this.ReplacementID);
      if (this.DefendPercentID > 0)
        this.RemoveSubPart(this.DefendPercentID);
      if (this.RequestSupID > 0)
        this.RemoveSubPart(this.RequestSupID);
      if (this.OfficerId > 0)
        this.RemoveSubPart(this.OfficerId);
      if (this.QuickInfoId > 0)
        this.RemoveSubPart(this.QuickInfoId);
      if (this.CancelButtonId > 0)
        this.RemoveSubPart(this.CancelButtonId);
      if (this.CancelTextId > 0)
        this.RemoveSubPart(this.CancelTextId);
      if (this.OrderTextId > 0)
        this.RemoveSubPart(this.OrderTextId);
      if (this.OrderText2Id > 0)
        this.RemoveSubPart(this.OrderText2Id);
      if (this.OrderText3Id > 0)
        this.RemoveSubPart(this.OrderText3Id);
      if (this.ClearId > 0)
        this.RemoveSubPart(this.ClearId);
      if (this.ClearTextId > 0)
        this.RemoveSubPart(this.ClearTextId);
      if (this.OrderUpId > 0)
        this.RemoveSubPart(this.OrderUpId);
      if (this.OrderDownId > 0)
        this.RemoveSubPart(this.OrderDownId);
      if (this.OrderOkId > 0)
        this.RemoveSubPart(this.OrderOkId);
      if (this.OrderOkTextId > 0)
        this.RemoveSubPart(this.OrderOkTextId);
      if (this.OrderOk2Id > 0)
        this.RemoveSubPart(this.OrderOk2Id);
      if (this.OrderOk2TextId > 0)
        this.RemoveSubPart(this.OrderOk2TextId);
      if (this.ExtraId > 0)
        this.RemoveSubPart(this.ExtraId);
      if (this.SliderButtonId > 0)
        this.RemoveSubPart(this.SliderButtonId);
      if (this.DitchId > 0)
        this.RemoveSubPart(this.DitchId);
      if (this.ReserveId > 0)
        this.RemoveSubPart(this.ReserveId);
      if (this.DisbandTroopsId > 0)
        this.RemoveSubPart(this.DisbandTroopsId);
      if (this.DisbandItemsId > 0)
        this.RemoveSubPart(this.DisbandItemsId);
      if (this.AcapId > 0)
        this.RemoveSubPart(this.AcapId);
      if (this.DefId > 0)
        this.RemoveSubPart(this.DefId);
      if (this.SupplyId > 0)
        this.RemoveSubPart(this.SupplyId);
      if (this.InterceptId > 0)
        this.RemoveSubPart(this.InterceptId);
      if (this.game.EditObj.UnitSelected > -1)
      {
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerCounter <= 6 && this.OptionsListId > 0)
        {
          this.RemoveSubPart(this.OptionsListId);
          this.OptionsListId = 0;
        }
      }
      else if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      this.detail1b = 0;
      this.detail2b = 0;
      this.NewBackGroundAndClearAll(this.game.ScreenWidth, 210, -1);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int num1 = 0;
      if (this.game.EditObj.OrderType < 1)
        num1 = 1;
      if (this.game.EditObj.OrderType == 1)
        num1 = 1;
      if (this.game.EditObj.OrderType == 9 & this.game.EditObj.OrderTarget == -1)
        num1 = 1;
      if (this.game.EditObj.OrderType == 18 & this.game.EditObj.OrderTarget == -1)
        num1 = 1;
      if (this.game.EditObj.OrderType == 18 & this.game.EditObj.TargetX == -1)
        num1 = 1;
      if (this.game.EditObj.OrderType == 3)
        num1 = 1;
      if (this.game.EditObj.OrderType == 19)
        num1 = 1;
      if (this.game.EditObj.OrderType == 14)
        num1 = 1;
      if (this.game.EditObj.OrderType == 15)
        num1 = 1;
      if (this.game.EditObj.OrderType == 2)
        num1 = 1;
      if (this.game.EditObj.OrderType == 12)
        num1 = 1;
      if (this.game.EditObj.OrderType == 11)
        num1 = 1;
      if (this.game.EditObj.OrderType == 13)
        num1 = 1;
      if (this.game.EditObj.OrderType == 21)
        num1 = 1;
      if (this.game.EditObj.OrderType == 20)
        num1 = 1;
      if (this.game.EditObj.OrderType == 37)
        num1 = 1;
      if (this.game.EditObj.OrderType == 36)
        num1 = 1;
      if (this.game.EditObj.OrderType == 35)
        num1 = 1;
      if (this.game.EditObj.OrderType == 39)
        num1 = 1;
      if (this.game.EditObj.OrderType == 40)
        num1 = 1;
      if (this.game.EditObj.HideUnit == 0)
        num1 = 0;
      this.ClearMouse();
      int h = 200;
      int x1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      int num2 = 10;
      DrawMod.DrawBlock(ref Expression, 0, 0, this.game.ScreenWidth, num2, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
      int num3 = 0;
      Rectangle trect1;
      Rectangle trect2;
      if (num1 == 1 && this.game.EditObj.UnitSelected > -1 & this.game.EditObj.UnitSelected <= this.game.Data.UnitCounter && this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.EditObj.UnitSelected, this.game.Data.Turn) > 0)
      {
        int num4 = x1 + 50;
        DrawMod.DrawBlock(ref Expression, num4 + 295, num2, 48, h, (int) this.game.VicColor4.R, (int) this.game.VicColor4.G, (int) this.game.VicColor4.B, (int) this.game.VicColor4.A);
        DrawMod.drawLine(ref Expression, 0, num2, num4 + 295, num2, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref Expression, num4 + 295 + 48, num2, this.game.ScreenWidth, num2, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref Expression, num4 + 295, num2, num4 + 295, num2 + h, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        DrawMod.drawLine(ref Expression, num4 + 343, num2, num4 + 343, num2 + h, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
        Color c2_1 = Color.FromArgb(0, 100, 100, 100);
        Color c1_1 = Color.FromArgb(100, 100, 100, 100);
        if (this.game.EditObj.SetViewMode2 == 0)
        {
          c2_1 = Color.FromArgb(60, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B);
          c1_1 = Color.FromArgb(150, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B);
        }
        DrawMod.DrawBlockGradient2(ref Expression, num4 + 294 + 8, 42, 35, 40, c1_1, c2_1);
        DrawMod.DrawTextVic(ref Expression, "SFs", this.game.VicFont5, num4 + 294 + 5 + 10, 56, this.game.VicColor1, this.game.VicColor1Shade);
        trect1 = new Rectangle(num4 + 294 + 8, 42, 35, 40);
        this.AddMouse(ref trect1, "", "View subformations", 1);
        Color c2_2 = Color.FromArgb(0, 100, 100, 100);
        Color c1_2 = Color.FromArgb(100, 100, 100, 100);
        if (this.game.EditObj.SetViewMode2 == 1)
        {
          c2_2 = Color.FromArgb(60, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B);
          c1_2 = Color.FromArgb(150, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B);
        }
        DrawMod.DrawBlockGradient2(ref Expression, num4 + 294 + 8, 89, 35, 40, c1_2, c2_2);
        DrawMod.DrawTextVic(ref Expression, "LOG", this.game.VicFont5, num4 + 294 + 3 + 10, 105, this.game.VicColor1, this.game.VicColor1Shade);
        trect1 = new Rectangle(num4 + 294 + 8, 89, 35, 40);
        Rectangle trect3 = trect1;
        this.AddMouse(ref trect3, "", "View logistical statistics", 2);
        Color c2_3 = Color.FromArgb(0, 100, 100, 100);
        Color c1_3 = Color.FromArgb(100, 100, 100, 100);
        if (this.game.EditObj.SetViewMode2 == 2)
        {
          c2_3 = Color.FromArgb(60, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B);
          c1_3 = Color.FromArgb(150, (int) this.game.viccolor7.R, (int) this.game.viccolor7.G, (int) this.game.viccolor7.B);
        }
        DrawMod.DrawBlockGradient2(ref Expression, num4 + 294 + 8, 138, 35, 40, c1_3, c2_3);
        DrawMod.DrawTextVic(ref Expression, "ANL", this.game.VicFont5, num4 + 294 + 3 + 10, 154, this.game.VicColor1, this.game.VicColor1Shade);
        trect1 = new Rectangle(num4 + 294 + 8, 138, 35, 40);
        trect2 = trect1;
        this.AddMouse(ref trect2, "", "View unit analysis statistics", 3);
        x1 = num4 - 50;
        SubPartClass tsubpart = (SubPartClass) new UnitHeaderPartClass(this.game.EditObj.UnitSelected, this.game);
        this.UnitHeaderId = this.AddSubPart(ref tsubpart, x1, num2 + 0, 280, 200, 0);
        num3 = 1;
      }
      if (num3 == 0)
        DrawMod.drawLine(ref Expression, 0, num2, this.game.ScreenWidth, num2, (int) this.game.VicColor6.R, (int) this.game.VicColor6.G, (int) this.game.VicColor6.B, (int) this.game.VicColor6.A);
      Coordinate coordinate = new Coordinate();
      if (this.game.EditObj.UnitSelected > -1)
      {
        if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
          coordinate.x = 3;
        else
          coordinate = this.game.HandyFunctionsObj.GetReconMinusHide(this.game.EditObj.UnitSelected, this.game.Data.Turn);
      }
      else
        coordinate.x = 3;
      string tname;
      Bitmap bitmap;
      if (num1 == 1 && this.game.EditObj.UnitSelected > -1 & this.game.EditObj.UnitSelected <= this.game.Data.UnitCounter && this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.EditObj.UnitSelected, this.game.Data.Turn) > 0 & coordinate.x >= 2)
      {
        int num5 = x1 - 691;
        int num6 = num2 + 35;
        if (this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime | this.game.Data.Round == 0 | !this.game.Data.FOWOn)
        {
          Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitPeople(this.game.EditObj.UnitSelected));
          int regime = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime;
          tname = Strings.Trim(Conversion.Str((object) (100 - this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent))) + "%";
          SubPartClass tsubpart1 = (SubPartClass) new TextPartClass("", this.game.GameFont2, 49, 23, true, 0, "Retreat Percentage. Unit retreats if this % of losses has been suffered. 25%=retreat quickly, 100%=to death");
          this.DefId = this.AddSubPart(ref tsubpart1, num5 + 975, num6 + 91, 49, 23, 0);
          ref Graphics local1 = ref Expression;
          trect1 = new Rectangle(num5 + 975, num6 + 77, 49, 14);
          Rectangle rect1_1 = trect1;
          trect2 = new Rectangle(num5 + 975, num6 + 77 + 14, 49, 23);
          Rectangle rect2_1 = trect2;
          string txt2_1 = tname;
          DrawMod.MakeFullBoxVic2(ref local1, rect1_1, "LOSS", rect2_1, txt2_1);
          if (this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
          {
            tname = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop != 100 ? Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop)) : "Don't";
            SubPartClass tsubpart2 = (SubPartClass) new TextPartClass("", this.game.GameFont2, 49, 23, true, 0, "Intercepts only if readiness is greater than specified. You can put on don't, which forbids intercept.");
            this.InterceptId = this.AddSubPart(ref tsubpart2, num5 + 975, num6 + 3 + 28 + 23, 49, 23, 0);
            ref Graphics local2 = ref Expression;
            trect1 = new Rectangle(num5 + 975, num6 + 3 + 14 + 23, 49, 14);
            Rectangle rect1_2 = trect1;
            trect2 = new Rectangle(num5 + 975, num6 + 3 + 28 + 23, 49, 23);
            Rectangle rect2_2 = trect2;
            string txt2_2 = tname;
            DrawMod.MakeFullBoxVic2(ref local2, rect1_2, "INTC", rect2_2, txt2_2);
          }
          if (this.game.Data.ASOn & this.game.HandyFunctionsObj.GetUnitAS(this.game.EditObj.UnitSelected) > 0)
          {
            tname = !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODoAS ? "No" : "Yes";
            SubPartClass tsubpart3 = (SubPartClass) new TextPartClass("", this.game.GameFont2, 49, 23, true, 0, "Wheter or not the unit will do Anti Supply damage on enemy hexes.");
            this.AsId = this.AddSubPart(ref tsubpart3, num5 + 981, num6 + 16, 49, 23, 0);
            ref Graphics local3 = ref Expression;
            trect1 = new Rectangle(num5 + 975, num6 + 2, 49, 14);
            Rectangle rect1_3 = trect1;
            trect2 = new Rectangle(num5 + 975, num6 + 2 + 14, 49, 23);
            Rectangle rect2_3 = trect2;
            string txt2_3 = tname;
            DrawMod.MakeFullBoxVic2(ref local3, rect1_3, "DOAS", rect2_3, txt2_3);
          }
        }
        if (this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime | this.game.Data.Round == 0 | !this.game.Data.FOWOn | this.game.Data.Turn == this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime].UberRegime && this.game.Data.Turn > -1)
        {
          tname = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent)) + "%";
          SubPartClass tsubpart = (SubPartClass) new TextPartClass("", this.game.GameFont2, 49, 23, true, 0, "Supply Rationing. The % of supply requested that will be alloted by superior hq.");
          this.SupplyId = this.AddSubPart(ref tsubpart, num5 + 975, num6 + 4 + 56 + 69, 49, 23, 0);
          ref Graphics local = ref Expression;
          trect1 = new Rectangle(num5 + 975, num6 + 4 + 42 + 69, 49, 14);
          Rectangle rect1 = trect1;
          trect2 = new Rectangle(num5 + 975, num6 + 4 + 56 + 69, 49, 23);
          Rectangle rect2 = trect2;
          string txt2 = tname;
          DrawMod.MakeFullBoxVic2(ref local, rect1, "SUPP", rect2, txt2);
        }
        int num7 = num5 + 691;
        int num8 = num6 - 35;
        int tlistselect;
        SubPartClass tsubpart4;
        if (this.game.EditObj.SetViewMode2 == 0)
        {
          num7 += 50;
          int num9 = 0;
          if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount + this.game.Data.UnitObj[this.game.EditObj.UnitSelected].PassengerCounter > 6)
            num9 = 1;
          int index = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
          if (index > -1)
          {
            if (this.game.Data.HistoricalUnitObj[index].CommanderSpriteID > -1)
              num9 = 1;
            else
              index = -1;
          }
          if (num9 == 1)
          {
            this.OptionsListObj = new ATListClass();
            tlistselect = -1;
            int num10 = -1;
            int sfCount = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount;
            for (int tdata = 0; tdata <= sfCount; ++tdata)
            {
              int sf = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFList[tdata];
              int type = this.game.Data.SFObj[sf].Type;
              int qty = this.game.Data.SFObj[sf].Qty;
              if (this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio > 0)
                qty *= this.game.Data.SFTypeObj[this.game.Data.SFObj[sf].Type].Ratio;
              ++num10;
              if (this.detail1 == sf)
                tlistselect = num10;
              tname = Strings.Trim(Conversion.Str((object) qty)) + "x " + this.game.Data.SFTypeObj[type].Name;
              if (this.game.Data.SFObj[sf].MoveType > -1)
                tname = tname + " (" + this.game.Data.TempString[this.game.Data.SFObj[sf].MoveType] + ")";
              string tvalue = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Ap));
              string tvalue2 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Rdn));
              string tvalue3 = Strings.Trim(Conversion.Str((object) this.game.Data.SFObj[sf].Xp));
              string tvalue4 = Strings.Left(this.game.Data.PeopleObj[this.game.Data.SFObj[sf].People].Name, 3);
              this.OptionsListObj.add(tname, tdata, tvalue, tvalue2, tvalue3, tvalue4);
            }
            if (this.OptionsListId > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect);
              this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
            }
            else if (index > -1)
            {
              tsubpart4 = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 9, 310, tlistselect, this.game, tHeader: "Subformations                     AP    RDN   XP    PPL", tHeaderCenter: false, tShowPair: true, tValueWidth: 130, tbackbitmap: (ref this.OwnBitmap), bbx: (num7 + 665), bby: (num8 + 5));
              this.OptionsListId = this.AddSubPart(ref tsubpart4, num7 + 665, num8 + 5, 310, 192, 0);
            }
            else
            {
              tsubpart4 = (SubPartClass) new ATListSubPartClass(this.OptionsListObj, 9, 590, tlistselect, this.game, tHeader: "Subformations", tShowPair: true, tValueWidth: 300, tbackbitmap: (ref this.OwnBitmap), bbx: (num7 + 355), bby: (num8 + 5));
              this.OptionsListId = this.AddSubPart(ref tsubpart4, num7 + 355, num8 + 5, 590, 192, 0);
            }
            if (index > -1)
            {
              tsubpart4 = (SubPartClass) new OfficerPartClass(this.game.EditObj.UnitSelected, this.game);
              this.OfficerId = this.AddSubPart(ref tsubpart4, num7 + 355, num8 + 5, 300, 200, 0);
            }
          }
          else
          {
            SubPartClass tsubpart5 = (SubPartClass) new UnitSFPartClass(this.game.EditObj.UnitSelected, this.game);
            this.UnitsfId = this.AddSubPart(ref tsubpart5, num7 + 350, num8 + 0, 620, 200, 0);
          }
        }
        int unitSelected = this.game.EditObj.UnitSelected;
        if (this.game.EditObj.SetViewMode2 == 1)
        {
          if (this.OptionsListId > 0)
          {
            this.RemoveSubPart(this.OptionsListId);
            this.OptionsListId = 0;
          }
          if (!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[unitSelected].Regime))
          {
            int x2 = num7 + 360 + 50;
            int width = 80;
            if (this.game.Data.UnitObj[unitSelected].IsHQ)
            {
              string str1 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].LandCap));
              ref Graphics local4 = ref Expression;
              trect1 = new Rectangle(x2, 25, width, 14);
              Rectangle rect1_4 = trect1;
              trect2 = new Rectangle(x2, 39, width, 23);
              Rectangle rect2_4 = trect2;
              string txt2_4 = str1;
              DrawMod.MakeFullBoxVic2(ref local4, rect1_4, "LAND CAP", rect2_4, txt2_4);
              string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].NavyCap));
              ref Graphics local5 = ref Expression;
              trect1 = new Rectangle(x2, 70, width, 14);
              Rectangle rect1_5 = trect1;
              trect2 = new Rectangle(x2, 84, width, 23);
              Rectangle rect2_5 = trect2;
              string txt2_5 = str2;
              DrawMod.MakeFullBoxVic2(ref local5, rect1_5, "NAVY CAP", rect2_5, txt2_5);
              string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].AirCap));
              ref Graphics local6 = ref Expression;
              trect1 = new Rectangle(x2, 115, width, 14);
              Rectangle rect1_6 = trect1;
              trect2 = new Rectangle(x2, 129, width, 23);
              Rectangle rect2_6 = trect2;
              string txt2_6 = str3;
              DrawMod.MakeFullBoxVic2(ref local6, rect1_6, "RAIL CAP", rect2_6, txt2_6);
              x2 += 100;
            }
            string str4 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].Supply));
            string str5;
            if (this.game.HandyFunctionsObj.UnitSupplyUse(unitSelected) > 0)
            {
              float Number = (float) Math.Round((double) ((float) this.game.Data.UnitObj[unitSelected].Supply / (float) this.game.HandyFunctionsObj.UnitSupplyUse(unitSelected)), 1);
              if ((double) Number > 99.0)
                Number = 99f;
              str5 = Strings.Trim(Conversion.Str((object) Number));
            }
            else
              str5 = ">99";
            ref Graphics local7 = ref Expression;
            trect1 = new Rectangle(x2, 25, width, 14);
            Rectangle rect1_7 = trect1;
            trect2 = new Rectangle(x2, 39, width, 23);
            Rectangle rect2_7 = trect2;
            string txt2_7 = str4;
            DrawMod.MakeFullBoxVic2(ref local7, rect1_7, "SUPPLY STOCK", rect2_7, txt2_7);
            string str6 = str5;
            ref Graphics local8 = ref Expression;
            trect1 = new Rectangle(x2, 70, width, 14);
            Rectangle rect1_8 = trect1;
            trect2 = new Rectangle(x2, 84, width, 23);
            Rectangle rect2_8 = trect2;
            string txt2_8 = str6;
            DrawMod.MakeFullBoxVic2(ref local8, rect1_8, "ROUNDS LEFT", rect2_8, txt2_8);
            int x3 = x2 + 100;
            string str7 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].SupplyInReq));
            ref Graphics local9 = ref Expression;
            trect1 = new Rectangle(x3, 25, width, 14);
            Rectangle rect1_9 = trect1;
            trect2 = new Rectangle(x3, 39, width, 23);
            Rectangle rect2_9 = trect2;
            string txt2_9 = str7;
            DrawMod.MakeFullBoxVic2(ref local9, rect1_9, "REQUEST IN", rect2_9, txt2_9);
            string str8 = Strings.Trim(Conversion.Str((object) (this.game.Data.UnitObj[unitSelected].SupplyIn + this.game.Data.UnitObj[unitSelected].SupplyLost)));
            ref Graphics local10 = ref Expression;
            trect1 = new Rectangle(x3, 70, width, 14);
            Rectangle rect1_10 = trect1;
            trect2 = new Rectangle(x3, 84, width, 23);
            Rectangle rect2_10 = trect2;
            string txt2_10 = str8;
            DrawMod.MakeFullBoxVic2(ref local10, rect1_10, "SUPPLY SEND", rect2_10, txt2_10);
            string str9 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].SupplyLost));
            ref Graphics local11 = ref Expression;
            trect1 = new Rectangle(x3, 115, width, 14);
            Rectangle rect1_11 = trect1;
            trect2 = new Rectangle(x3, 129, width, 23);
            Rectangle rect2_11 = trect2;
            string txt2_11 = str9;
            DrawMod.MakeFullBoxVic2(ref local11, rect1_11, "DESTROYED", rect2_11, txt2_11);
            tname = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].SupplyIn));
            ref Graphics local12 = ref Expression;
            trect1 = new Rectangle(x3, 160, width, 14);
            Rectangle rect1_12 = trect1;
            trect2 = new Rectangle(x3, 174, width, 23);
            Rectangle rect2_12 = trect2;
            string txt2_12 = tname;
            DrawMod.MakeFullBoxVic2(ref local12, rect1_12, "SUPPLY IN", rect2_12, txt2_12);
            if (this.game.Data.UnitObj[unitSelected].IsHQ)
            {
              x3 += 100;
              string str10 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetRealHQSupplyPts(unitSelected)));
              ref Graphics local13 = ref Expression;
              trect1 = new Rectangle(x3, 25, width, 14);
              Rectangle rect1_13 = trect1;
              trect2 = new Rectangle(x3, 39, width, 23);
              Rectangle rect2_13 = trect2;
              string txt2_13 = str10;
              DrawMod.MakeFullBoxVic2(ref local13, rect1_13, "EXCESS SUP", rect2_13, txt2_13);
              string str11 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].SupplyReq));
              ref Graphics local14 = ref Expression;
              trect1 = new Rectangle(x3, 70, width, 14);
              Rectangle rect1_14 = trect1;
              trect2 = new Rectangle(x3, 84, width, 23);
              Rectangle rect2_14 = trect2;
              string txt2_14 = str11;
              DrawMod.MakeFullBoxVic2(ref local14, rect1_14, "REQUEST OUT", rect2_14, txt2_14);
              string str12 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].SupplyOut));
              ref Graphics local15 = ref Expression;
              trect1 = new Rectangle(x3, 115, width, 14);
              Rectangle rect1_15 = trect1;
              trect2 = new Rectangle(x3, 129, width, 23);
              Rectangle rect2_15 = trect2;
              string txt2_15 = str12;
              DrawMod.MakeFullBoxVic2(ref local15, rect1_15, "SUPPLY OUT", rect2_15, txt2_15);
              tname = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].Reserve));
              ref Graphics local16 = ref Expression;
              trect1 = new Rectangle(x3, 160, width, 14);
              Rectangle rect1_16 = trect1;
              trect2 = new Rectangle(x3, 174, width, 23);
              Rectangle rect2_16 = trect2;
              string txt2_16 = tname;
              DrawMod.MakeFullBoxVic2(ref local16, rect1_16, "RESERVE", rect2_16, txt2_16);
            }
            if (this.game.HandyFunctionsObj.DoesUnitUseFuel(unitSelected))
            {
              x3 += 100;
              string str13 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].FuelUsedMove));
              ref Graphics local17 = ref Expression;
              trect1 = new Rectangle(x3, 25, width, 14);
              Rectangle rect1_17 = trect1;
              trect2 = new Rectangle(x3, 39, width, 23);
              Rectangle rect2_17 = trect2;
              string txt2_17 = str13;
              DrawMod.MakeFullBoxVic2(ref local17, rect1_17, "FUEL MOVING", rect2_17, txt2_17);
              string str14 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].FuelUsedAtt));
              ref Graphics local18 = ref Expression;
              trect1 = new Rectangle(x3, 70, width, 14);
              Rectangle rect1_18 = trect1;
              trect2 = new Rectangle(x3, 84, width, 23);
              Rectangle rect2_18 = trect2;
              string txt2_18 = str14;
              DrawMod.MakeFullBoxVic2(ref local18, rect1_18, "FUEL ATTACK", rect2_18, txt2_18);
              tname = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[unitSelected].FuelUsedDef));
              ref Graphics local19 = ref Expression;
              trect1 = new Rectangle(x3, 115, width, 14);
              Rectangle rect1_19 = trect1;
              trect2 = new Rectangle(x3, 129, width, 23);
              Rectangle rect2_19 = trect2;
              string txt2_19 = tname;
              DrawMod.MakeFullBoxVic2(ref local19, rect1_19, "FUEL DEFENSE", rect2_19, txt2_19);
            }
            if (this.game.Data.UnitObj[unitSelected].IsHQ & this.game.Data.UnitObj[unitSelected].Regime == this.game.Data.Turn)
            {
              int num11 = x3 + 100;
              tsubpart4 = (SubPartClass) new TextButtonPartClass("DITCH", 100, "Allows you to ditch a specific ammount of supply points", ref this.OwnBitmap, num11, 25);
              this.DitchId = this.AddSubPart(ref tsubpart4, num11, 25, 100, 32, 1);
              tsubpart4 = (SubPartClass) new TextButtonPartClass("RESERVE", 100, "Set the reserve supply point ammount the HQ should try to build up", ref this.OwnBitmap, num11, 70);
              this.ReserveId = this.AddSubPart(ref tsubpart4, num11, 70, 100, 32, 1);
            }
          }
        }
        if (this.game.EditObj.SetViewMode2 == 2)
        {
          if (this.OptionsListId > 0)
          {
            this.RemoveSubPart(this.OptionsListId);
            this.OptionsListId = 0;
          }
          if (!this.game.Data.FOWOn | this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, this.game.Data.UnitObj[unitSelected].Regime))
          {
            int bbx = num7 + 360 + 50;
            this.ListObj = new ATListClass();
            int[] numArray1 = new int[100];
            int[] numArray2 = new int[100];
            this.ListObj.add("MOVETYPE", -1, "WGT", "CARRY");
            int sfCount = this.game.Data.UnitObj[unitSelected].SFCount;
            for (int index1 = 0; index1 <= sfCount; ++index1)
            {
              int sf = this.game.Data.UnitObj[unitSelected].SFList[index1];
              int type = this.game.Data.SFObj[sf].Type;
              int[] numArray3 = numArray1;
              int[] numArray4 = numArray3;
              int moveType1 = this.game.Data.SFTypeObj[type].MoveType;
              int index2 = moveType1;
              int num12 = numArray3[moveType1] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].Weight;
              numArray4[index2] = num12;
              int[] numArray5 = numArray2;
              int[] numArray6 = numArray5;
              int moveType2 = this.game.Data.SFTypeObj[type].MoveType;
              int index3 = moveType2;
              int num13 = numArray5[moveType2] + this.game.Data.SFObj[sf].Qty * this.game.Data.SFTypeObj[type].CarryCap;
              numArray6[index3] = num13;
            }
            int index = 0;
            int num14;
            do
            {
              if (numArray1[index] > 0)
              {
                ++num14;
                this.ListObj.add(Strings.Left(this.game.Data.TempString[index], 9), -1, Strings.Trim(Conversion.Str((object) numArray1[index])), Strings.Trim(Conversion.Str((object) numArray2[index])));
              }
              ++index;
            }
            while (index <= 99);
            if (this.game.Data.UnitObj[unitSelected].IsHQ)
            {
              int integer = Conversions.ToInteger(this.game.HandyFunctionsObj.GetUnitExcessWeight(unitSelected));
              if (integer > 0)
              {
                ++num14;
                this.ListObj.add("Excess Sup", -1, Strings.Trim(Strings.Trim(Conversion.Str((object) integer))), "0");
              }
            }
            if (num14 > 0)
            {
              if (num14 > 4)
                ;
              this.listy = (SubPartClass) new ATListSubPartClass(this.ListObj, 6, 200, tlistselect, this.game, tHeader: "Move Types", tHighlight: false, tShowPair: true, tValueWidth: 100, tbackbitmap: (ref this.OwnBitmap), bbx: bbx, bby: 25);
              ref Graphics local20 = ref Expression;
              bitmap = this.listy.Paint();
              ref Bitmap local21 = ref bitmap;
              int x4 = bbx;
              DrawMod.DrawSimple(ref local20, ref local21, x4, 25);
            }
            int x5 = bbx + 215;
            int width1 = 80;
            int unitCarryCap1 = this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected, 0);
            string str15 = Strings.Trim(Conversion.Str((object) (this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected, 0) - this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected, 0, true)))) + " / " + Strings.Trim(Conversion.Str((object) unitCarryCap1));
            ref Graphics local22 = ref Expression;
            trect1 = new Rectangle(x5, 25, width1, 14);
            Rectangle rect1_20 = trect1;
            trect2 = new Rectangle(x5, 39, width1, 23);
            Rectangle rect2_20 = trect2;
            string txt2_20 = str15;
            DrawMod.MakeFullBoxVic2(ref local22, rect1_20, "LAND CARRIED", rect2_20, txt2_20);
            int unitCarryCap2 = this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected, 1);
            string str16 = Strings.Trim(Conversion.Str((object) (this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected, 1) - this.game.HandyFunctionsObj.GetUnitCarryCap(unitSelected, 1, true)))) + " / " + Strings.Trim(Conversion.Str((object) unitCarryCap2));
            ref Graphics local23 = ref Expression;
            trect1 = new Rectangle(x5, 70, width1, 14);
            Rectangle rect1_21 = trect1;
            trect2 = new Rectangle(x5, 84, width1, 23);
            Rectangle rect2_21 = trect2;
            string txt2_21 = str16;
            DrawMod.MakeFullBoxVic2(ref local23, rect1_21, "NAVY CARRIED", rect2_21, txt2_21);
            int airCarryCapPts = this.game.HandyFunctionsObj.GetAirCarryCapPts(unitSelected);
            string str17 = Strings.Trim(Conversion.Str((object) Conversions.ToInteger(Operators.SubtractObject(this.game.HandyFunctionsObj.GetUnitNonSeaWeight(unitSelected, true), this.game.HandyFunctionsObj.GetUnitNonSeaWeight(unitSelected, false))))) + " / " + Strings.Trim(Conversion.Str((object) airCarryCapPts));
            ref Graphics local24 = ref Expression;
            trect1 = new Rectangle(x5, 115, width1, 14);
            Rectangle rect1_22 = trect1;
            trect2 = new Rectangle(x5, 129, width1, 23);
            Rectangle rect2_22 = trect2;
            string txt2_22 = str17;
            DrawMod.MakeFullBoxVic2(ref local24, rect1_22, "AIRCARRIER", rect2_22, txt2_22);
            int x6 = x5 + 100;
            int width2 = 80;
            string str18 = Strings.Trim(Conversion.Str(Operators.AddObject(this.game.HandyFunctionsObj.GetUnitNonSeaWeight(unitSelected, true), this.game.HandyFunctionsObj.GetUnitExcessWeight(unitSelected))));
            ref Graphics local25 = ref Expression;
            trect1 = new Rectangle(x6, 25, width2, 14);
            Rectangle rect1_23 = trect1;
            trect2 = new Rectangle(x6, 39, width2, 23);
            Rectangle rect2_23 = trect2;
            string txt2_23 = str18;
            DrawMod.MakeFullBoxVic2(ref local25, rect1_23, "WEIGHT", rect2_23, txt2_23);
            tname = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetUnitStackPts(unitSelected)));
            ref Graphics local26 = ref Expression;
            trect1 = new Rectangle(x6, 70, width2, 14);
            Rectangle rect1_24 = trect1;
            trect2 = new Rectangle(x6, 84, width2, 23);
            Rectangle rect2_24 = trect2;
            string txt2_24 = tname;
            DrawMod.MakeFullBoxVic2(ref local26, rect1_24, "STACK", rect2_24, txt2_24);
            if (!this.game.Data.UnitObj[unitSelected].IsHQ)
            {
              int x7 = x6 + 100;
              int width3 = 80;
              int hq = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
              int num15 = this.game.HandyFunctionsObj.GetStaffPercent(hq, true);
              int num16 = this.game.HandyFunctionsObj.GetStaffPercent(hq, true);
              int num17 = this.game.HandyFunctionsObj.GetStaffPercent(hq);
              int num18 = this.game.HandyFunctionsObj.GetStaffPercent(hq);
              if (num15 > 100)
                num15 = 100;
              if (num16 > 100)
                num16 = 100;
              if (num17 > 100)
                num17 = 100;
              if (num18 > 100)
                num18 = 100;
              int Number1 = (int) Math.Round((double) (int) Math.Round((double) num15 * (double) this.game.HandyFunctionsObj.GetStaffCombatMod(hq) * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0)) + (double) num17 * (double) this.game.Data.RuleVar[140] * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0));
              int Number2 = (int) Math.Round((double) (int) Math.Round((double) num16 * (double) this.game.HandyFunctionsObj.GetStaffMoraleMod(hq) * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0)) + (double) num18 * (double) this.game.Data.RuleVar[141] * ((double) this.game.HandyFunctionsObj.Gethqpow(this.game.EditObj.UnitSelected) / 100.0));
              string str19 = Strings.Trim(Conversion.Str((object) Number1)) + "%";
              ref Graphics local27 = ref Expression;
              trect1 = new Rectangle(x7, 25, width3, 14);
              Rectangle rect1_25 = trect1;
              trect2 = new Rectangle(x7, 39, width3, 23);
              Rectangle rect2_25 = trect2;
              string txt2_25 = str19;
              DrawMod.MakeFullBoxVic2(ref local27, rect1_25, "STF.COMBAT", rect2_25, txt2_25);
              tname = Strings.Trim(Conversion.Str((object) Number2)) + "%";
              ref Graphics local28 = ref Expression;
              trect1 = new Rectangle(x7, 70, width3, 14);
              Rectangle rect1_26 = trect1;
              trect2 = new Rectangle(x7, 84, width3, 23);
              Rectangle rect2_26 = trect2;
              string txt2_26 = tname;
              DrawMod.MakeFullBoxVic2(ref local28, rect1_26, "STF.MORALE", rect2_26, txt2_26);
            }
          }
        }
      }
      if (false)
      {
        int selectX = this.game.SelectX;
        int selectY = this.game.SelectY;
        Expression = Graphics.FromImage((Image) this.OwnBitmap);
        int landscapeType = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[selectX, selectY].LandscapeType;
        int spriteNr = this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[selectX, selectY].SpriteNr;
        int num19 = (int) Math.Round((double) this.game.ScreenWidth / 2.0 - 174.0);
        int y1 = 55;
        if (this.game.Data.Round > 0 && this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[selectX, selectY].get_SeeNow(this.game.Data.Turn) < 1)
        {
          DrawMod.DrawBlock(ref Expression, num19, y1, 384, 144, 0, 0, 0, (int) byte.MaxValue);
          string tstring = tname + "Shrouded (" + Conversion.Str((object) selectX) + "," + Conversion.Str((object) selectY) + ")";
          DrawMod.DrawText(ref Expression, tstring, new Font("Times New Roman", 12f, FontStyle.Bold, GraphicsUnit.Pixel), 10, 35);
        }
        if (landscapeType > -1 & spriteNr > -1)
        {
          int nr1 = this.game.Data.LandscapeTypeObj[landscapeType].BasicPicID[spriteNr];
          ref Graphics local29 = ref Expression;
          bitmap = BitmapStore.GetBitmap(nr1);
          ref Bitmap local30 = ref bitmap;
          int x8 = num19;
          int y2 = y1;
          DrawMod.DrawScaled(ref local29, ref local30, x8, y2, 384, 144);
          if (this.game.Data.MapObj[0].HexObj[selectX, selectY].Location > -1 && this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[selectX, selectY].Location].Type].PictureLT > -1)
          {
            int nr2 = this.game.Data.LandscapeTypeObj[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[selectX, selectY].Location].Type].PictureLT].BasicPicID[this.game.Data.LocTypeObj[this.game.Data.LocObj[this.game.Data.MapObj[0].HexObj[selectX, selectY].Location].Type].PictureSprite];
            ref Graphics local31 = ref Expression;
            bitmap = BitmapStore.GetBitmap(nr2);
            ref Bitmap local32 = ref bitmap;
            int x9 = num19;
            int y3 = y1;
            DrawMod.DrawScaled(ref local31, ref local32, x9, y3, 384, 144);
          }
        }
        DrawMod.DrawRectangle(ref Expression, num19, y1, 384, 144, (int) this.game.VicColor3.R, (int) this.game.VicColor3.G, (int) this.game.VicColor3.B, (int) this.game.VicColor3.A);
        string str = !(this.game.Data.ShrowdOn & this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[selectX, selectY].get_SeeNow(this.game.Data.Turn) == 0) ? (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[selectX, selectY].Regime != -1 ? this.game.Data.RegimeObj[this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[selectX, selectY].Regime].Name : "Neutral") : "Unknown";
        int y = 15;
        ref Graphics local = ref Expression;
        trect1 = new Rectangle(num19, y, 384, 14);
        Rectangle rect1 = trect1;
        trect2 = new Rectangle(num19, y + 14, 384, 23);
        Rectangle rect2 = trect2;
        string txt2 = str;
        DrawMod.MakeFullBoxVic2(ref local, rect1, "HEX OWNER", rect2, txt2);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public void PopUpRefresh()
    {
      this.game.EditObj.HandCard = -1;
      this.DoRefresh();
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.EditObj.BattleTimerActive)
        return windowReturnClass;
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] == 1)
          {
            this.game.EditObj.SetViewMode2 = 0;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[index] == 2)
          {
            this.game.EditObj.SetViewMode2 = 1;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[index] == 3)
          {
            this.game.EditObj.SetViewMode2 = 2;
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
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
            if (num1 == this.OfficerId)
            {
              int num2 = x - this.SubPartX[index1];
              int num3 = y - this.SubPartY[index1];
              if (num2 > 140 & num2 < 340 & num3 > 18 & num3 < 36 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
              {
                string str = Interaction.InputBox("Give New Name for commander", "Rename", this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName);
                if (Strings.Len(str) > 33)
                  str = Strings.Left(str, 33);
                if (Operators.CompareString(Strings.Trim(str), "", false) != 0)
                  this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical].CommanderName = str;
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime, this.game.Data.Turn) | !this.game.Data.FOWOn | this.game.Data.Round == 0)
              {
                int index2;
                int index3;
                if (num2 > 50 & num3 > 107 & num2 < 350 & num3 < 177)
                {
                  this.game.EditObj.PopupValue = 4;
                  this.game.EditObj.HandCard = this.game.Data.HistoricalUnitObj[index2].HandCard[index3];
                  windowReturnClass.AddCommand(5, 10);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num2 > 50 & num3 > 7 & num2 < 138 & num3 < 103)
                {
                  this.game.EditObj.PopupValue = 4;
                  this.game.EditObj.HandCard = this.game.Data.HistoricalUnitObj[index2].HandCard[index3];
                  windowReturnClass.AddCommand(5, 10);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn)
                {
                  int historical = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Historical;
                  if (historical > -1)
                  {
                    int num4 = Math.Min(3, this.game.Data.HistoricalUnitObj[historical].HandCardCounter);
                    for (int index4 = 0; index4 <= num4; ++index4)
                    {
                      if (num2 > 140 + index4 * 45 & num3 > 45 & num2 < 185 + index4 * 45 & num3 < 105)
                      {
                        this.game.EditObj.PopupValue = 2;
                        this.game.EditObj.HandCard = this.game.Data.HistoricalUnitObj[historical].HandCard[index4];
                        windowReturnClass.AddCommand(5, 10);
                        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                        windowReturnClass.SetFlag(true);
                        return windowReturnClass;
                      }
                    }
                  }
                }
              }
            }
            else if (num1 == this.UnitHeaderId)
            {
              if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
              {
                int num5 = x - this.SubPartX[index1];
                int num6 = y - this.SubPartY[index1];
                if (num5 > 125 & num5 < 277 & num6 > 70 & num6 < 88)
                {
                  string str = Interaction.InputBox("Give New Name for Unit", "Rename", this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Name);
                  if (Strings.Len(str) > 25)
                    str = Strings.Left(str, 25);
                  if (Operators.CompareString(Strings.Trim(str), "", false) != 0)
                    this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Name = str;
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num5 > 125 & num5 < 277 & num6 > 90 & num6 < 108 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime == this.game.Data.Turn | this.game.Data.Round == 0)
                {
                  int hq = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].HQ;
                  if (hq > -1 & this.game.EditObj.OrderType == 0)
                  {
                    if (this.game.Data.UnitObj[hq].X > -1 & this.game.Data.UnitObj[hq].Y > -1)
                    {
                      this.game.SelectX = this.game.Data.UnitObj[hq].X;
                      this.game.SelectY = this.game.Data.UnitObj[hq].Y;
                      this.game.EditObj.UnitSelected = hq;
                    }
                    else
                    {
                      this.game.SelectX = this.game.Data.UnitObj[this.game.Data.UnitObj[hq].OnBoard].X;
                      this.game.SelectY = this.game.Data.UnitObj[this.game.Data.UnitObj[hq].OnBoard].Y;
                      this.game.EditObj.UnitSelected = this.game.Data.UnitObj[hq].OnBoard;
                    }
                    this.game.HandyFunctionsObj.SetcornerXY2();
                    this.game.EditObj.TempCoordList = new CoordList();
                    windowReturnClass.AddCommand(4, 12);
                    windowReturnClass.AddCommand(4, 18);
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                if (num5 > 44 & num5 < 122 & num6 > 60 & num6 < 138 && this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
                {
                  ColorDialog colorDialog = new ColorDialog();
                  colorDialog.Color = Color.FromArgb((int) byte.MaxValue, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Red, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Green, this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Blue);
                  if (colorDialog.ShowDialog() == DialogResult.OK)
                  {
                    this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Blue = (int) colorDialog.Color.B;
                    UnitClass unitClass1 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                    Color color = colorDialog.Color;
                    int g = (int) color.G;
                    unitClass1.Green = g;
                    UnitClass unitClass2 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected];
                    color = colorDialog.Color;
                    int r = (int) color.R;
                    unitClass2.Red = r;
                  }
                  this.dostuff();
                  windowReturnClass.AddCommand(4, 12);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
            }
            else
            {
              if (num1 == this.OptionsListId)
              {
                int num7 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                if (num7 > -1 & this.game.EditObj.OrderType == 0)
                {
                  this.game.EditObj.SFSelected = num7;
                  if (this.game.Data.Round > 0)
                  {
                    this.game.EditObj.PopupValue = 6;
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass.AddCommand(5, 10);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else
                  this.SubPartFlag[index1] = true;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.UnitsfId)
              {
                int sfSelected = this.game.EditObj.SFSelected;
                this.game.EditObj.SFSelected = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                if (this.game.EditObj.SFSelected > -1 & this.game.EditObj.OrderType == 0)
                {
                  windowReturnClass.AddCommand(4, 44);
                  if (sfSelected == this.game.EditObj.SFSelected & this.game.Data.Round > 0)
                  {
                    this.game.EditObj.PopupValue = 6;
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass.AddCommand(5, 10);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  if (this.game.EditObj.SFSelected <= this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SFCount & this.game.Data.Round > 0)
                  {
                    this.game.EditObj.PopupValue = 6;
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass.AddCommand(5, 10);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
              else
              {
                if (num1 == this.OptionsList2Id)
                {
                  int num8 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                  if (b != 1)
                    this.detail2 = -1;
                  if (this.CurrentView == 2)
                  {
                    if (num8 > -1)
                      this.detail2 = num8;
                    this.dostuff();
                  }
                  this.SubPartFlag[index1] = true;
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (num1 == this.DefendPercentID)
                {
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODefendPercent = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1], b);
                  this.SubPartFlag[index1] = true;
                  windowReturnClass.SetFlag(true);
                }
                else if (num1 == this.RequestSupID)
                {
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOSupReqPercent = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1], b);
                  this.SubPartFlag[index1] = true;
                  windowReturnClass.SetFlag(true);
                }
                else if (num1 == this.SOB1Id)
                {
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1], b);
                  this.SubPartFlag[index1] = true;
                  windowReturnClass.SetFlag(true);
                }
                else if (num1 == this.AsId)
                {
                  this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODoAS = !this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SODoAS;
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                }
                else if (num1 == this.DefId)
                {
                  int unitSelected = this.game.EditObj.UnitSelected;
                  if (this.game.Data.UnitObj[unitSelected].SODefendPercent == 0)
                    this.game.Data.UnitObj[unitSelected].SODefendPercent = 25;
                  else if (this.game.Data.UnitObj[unitSelected].SODefendPercent == 25)
                    this.game.Data.UnitObj[unitSelected].SODefendPercent = 50;
                  else if (this.game.Data.UnitObj[unitSelected].SODefendPercent == 50)
                    this.game.Data.UnitObj[unitSelected].SODefendPercent = 75;
                  else
                    this.game.Data.UnitObj[unitSelected].SODefendPercent = 0;
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                }
                else if (num1 == this.DitchId)
                {
                  string str = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give amount of supply points to ditch", "Shadow Empire : Planetary Conquest")));
                  if (Operators.CompareString(Strings.Trim(str), "", false) != 0)
                  {
                    int num9 = Conversions.ToInteger(str);
                    if (num9 < 1)
                      num9 = 0;
                    if (num9 > this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Supply)
                      num9 = this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Supply;
                    UnitClass[] unitObj = this.game.Data.UnitObj;
                    UnitClass[] unitClassArray = unitObj;
                    int unitSelected = this.game.EditObj.UnitSelected;
                    int index5 = unitSelected;
                    unitClassArray[index5].Supply = unitObj[unitSelected].Supply - num9;
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else if (num1 == this.ReserveId)
                {
                  string str = Conversions.ToString(Conversion.Val(Interaction.InputBox("Give desired reserve in supply points", "Shadow Empire : Planetary Conquest")));
                  if (Operators.CompareString(Strings.Trim(str), "", false) != 0)
                  {
                    int num10 = Conversions.ToInteger(str);
                    if (num10 < 1)
                      num10 = 0;
                    if (num10 > 99999)
                      num10 = 99999;
                    this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Reserve = num10;
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else if (num1 == this.SupplyId)
                {
                  int unitSelected = this.game.EditObj.UnitSelected;
                  if (this.game.Data.UnitObj[unitSelected].SOSupReqPercent == 50)
                    this.game.Data.UnitObj[unitSelected].SOSupReqPercent = 75;
                  else if (this.game.Data.UnitObj[unitSelected].SOSupReqPercent == 75)
                    this.game.Data.UnitObj[unitSelected].SOSupReqPercent = 100;
                  else
                    this.game.Data.UnitObj[unitSelected].SOSupReqPercent = 50;
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                }
                else if (num1 == this.ReplacementID)
                {
                  if (this.game.Data.Round == 0 | this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime)
                  {
                    if (!this.game.Data.UnitObj[this.game.EditObj.UnitSelected].IsHQ)
                    {
                      if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 0)
                        this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 25;
                      else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 25)
                        this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 50;
                      else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 50)
                        this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 75;
                      else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 75)
                        this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 100;
                      else
                        this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 0;
                    }
                    else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 0)
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 25;
                    else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 25)
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 50;
                    else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 50)
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 75;
                    else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent == 75)
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 100;
                    else
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOReplacementPercent = 0;
                  }
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                }
                else if (num1 == this.InterceptId)
                {
                  if (this.game.Data.Round == 0 | this.game.Data.Turn == this.game.Data.UnitObj[this.game.EditObj.UnitSelected].Regime && this.game.HandyFunctionsObj.HasUnitAirSF(this.game.EditObj.UnitSelected))
                  {
                    if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 25)
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 100;
                    else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 50)
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 25;
                    else if (this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop == 75)
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 50;
                    else
                      this.game.Data.UnitObj[this.game.EditObj.UnitSelected].SOInterceptRdnStop = 75;
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                  }
                }
                else if (num1 == this.ClearId)
                {
                  if (this.game.EditObj.OrderType == 3)
                  {
                    if (this.game.ProcessingObj.SetUnitHq(this.game.EditObj.OrderUnit, -1).OK)
                    {
                      this.game.EditObj.OrderType = 0;
                      windowReturnClass.AddCommand(4, 12);
                      windowReturnClass.AddCommand(4, 44);
                      windowReturnClass.AddCommand(4, 29);
                      this.game.SelectX = this.game.EditObj.OrderX;
                      this.game.SelectY = this.game.EditObj.OrderY;
                      this.game.EditObj.UnitSelected = this.game.EditObj.OrderUnit;
                    }
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                  }
                }
                else if (num1 == this.OrderOk2Id)
                {
                  int orderType1 = this.game.EditObj.OrderType;
                }
                else if (num1 == this.OrderOkId)
                {
                  int orderType2 = this.game.EditObj.OrderType;
                }
                else if (num1 == this.SliderButtonId)
                {
                  if (this.game.EditObj.OrderType == 5)
                  {
                    this.game.EditObj.orderInt = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
                    this.SubPartFlag[index1] = true;
                    windowReturnClass.SetFlag(true);
                  }
                }
                else if (num1 == this.OrderUpId)
                {
                  int orderType3 = this.game.EditObj.OrderType;
                }
                else if (num1 == this.OrderDownId)
                {
                  int orderType4 = this.game.EditObj.OrderType;
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
