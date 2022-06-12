// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.QuickUnitInfoSubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class QuickUnitInfoSubPartClass : SubPartClass
  {
    private object OwnBitmapNr;
    private int unr;
    private GameClass game;
    private bool shownothing;

    public QuickUnitInfoSubPartClass(int tunr, GameClass tgame, bool tShowNothing = false)
      : base(96, 200)
    {
      this.unr = tunr;
      this.game = tgame;
      this.shownothing = tShowNothing;
    }

    public override void DescriptInfo(int x, int y)
    {
      if (x == -1 | y == -1 || this.game.Data.Round == 0 || this.unr == -1)
        return;
      this.Descript = "";
      if (y > 5 & y < 28)
      {
        if (this.game.Data.UnitObj[this.unr].IsHQ)
          this.Descript = "Headquarter supply stock available for troops. Total supply including stock of troops in hq is " + Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Supply)) + ". Click to ditch supply pts";
        else
          this.Descript = "Supply stocks the unit has with it. Can max be " + Conversion.Str((object) this.game.HandyFunctionsObj.UnitSupplyStore(this.unr));
      }
      if (y > 28 & y < 51)
        this.Descript = "Amount of supply that arrived at the unit at start of turn.";
      if (y > 51 & y < 74)
        this.Descript = "Amount of supply the unit had requested at start of turn.";
      if (y > 74 & y < 97)
        this.Descript = "Amount of supply that was sent to unit, but destroyed due to anti-supply pts";
      if (this.game.Data.UnitObj[this.unr].IsHQ)
      {
        if (y > 97 & y < 120)
          this.Descript = "Real total supply points in HQ.";
        if (y > 120 & y < 143)
          this.Descript = "The total amount of supply points subordinates requested in supply points at start of turn.";
        if (y > 143 & y < 166)
          this.Descript = "The total amount of supply points sent out to subordinates at start of turn.";
        if (!(y > 166 & y < 189 & (double) this.game.Data.RuleVar[322] == 0.0))
          return;
        this.Descript = "The desired supply reserve points for this HQ. Click on it to set it.";
      }
      else
      {
        if (!this.game.HandyFunctionsObj.DoesUnitUseFuel(this.unr))
          return;
        if (y > 97 & y < 120)
          this.Descript = "Fuel used in movement (and moving into attack hex)";
        if (y > 120 & y < 143)
          this.Descript = "Fuel used in offensive combat";
        if (!(y > 143 & y < 166))
          return;
        this.Descript = "Fuel used in defensive combat";
      }
    }

    public override Bitmap Paint()
    {
      SizeF sizeF = new SizeF();
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.shownothing)
      {
        DrawMod.Clear(ref objgraphics, 101, 101, 101);
        return this.OwnBitmap;
      }
      int num = 40;
      int width = 56;
      string str1;
      if (this.game.Data.UnitObj[this.unr].IsHQ)
      {
        str1 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetRealHQSupplyPts(this.unr)));
      }
      else
      {
        string str2 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Supply));
        if (this.game.HandyFunctionsObj.UnitSupplyUse(this.unr) > 0)
        {
          double Number = Math.Round((double) this.game.Data.UnitObj[this.unr].Supply / (double) this.game.HandyFunctionsObj.UnitSupplyUse(this.unr), 1);
          if (Number > 99.0)
            Number = 99.0;
          str1 = str2 + " (" + Strings.Trim(Conversion.Str((object) Number)) + ")";
        }
        else
          str1 = str2 + " (>99)";
      }
      ref Graphics local1 = ref objgraphics;
      Rectangle rectangle1 = new Rectangle(0, 5, num, 23);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(num, 5, width, 23);
      Rectangle rect2_1 = rectangle2;
      string txt2_1 = str1;
      DrawMod.MakeFullBoxVic(ref local1, rect1_1, "STK", rect2_1, txt2_1, 1);
      string str3 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyIn));
      ref Graphics local2 = ref objgraphics;
      rectangle2 = new Rectangle(0, 28, num, 23);
      Rectangle rect1_2 = rectangle2;
      rectangle1 = new Rectangle(num, 28, width, 23);
      Rectangle rect2_2 = rectangle1;
      string txt2_2 = str3;
      DrawMod.MakeFullBoxVic(ref local2, rect1_2, "IN", rect2_2, txt2_2, 1);
      string str4 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyInReq));
      ref Graphics local3 = ref objgraphics;
      rectangle2 = new Rectangle(0, 51, num, 23);
      Rectangle rect1_3 = rectangle2;
      rectangle1 = new Rectangle(num, 51, width, 23);
      Rectangle rect2_3 = rectangle1;
      string txt2_3 = str4;
      DrawMod.MakeFullBoxVic(ref local3, rect1_3, "REQ", rect2_3, txt2_3, 1);
      string str5 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyLost));
      ref Graphics local4 = ref objgraphics;
      rectangle2 = new Rectangle(0, 74, num, 23);
      Rectangle rect1_4 = rectangle2;
      rectangle1 = new Rectangle(num, 74, width, 23);
      Rectangle rect2_4 = rectangle1;
      string txt2_4 = str5;
      DrawMod.MakeFullBoxVic(ref local4, rect1_4, "DES", rect2_4, txt2_4, 1);
      if (this.game.Data.UnitObj[this.unr].IsHQ)
      {
        string str6 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Supply));
        ref Graphics local5 = ref objgraphics;
        rectangle2 = new Rectangle(0, 97, num, 23);
        Rectangle rect1_5 = rectangle2;
        rectangle1 = new Rectangle(num, 97, width, 23);
        Rectangle rect2_5 = rectangle1;
        string txt2_5 = str6;
        DrawMod.MakeFullBoxVic(ref local5, rect1_5, "RST", rect2_5, txt2_5, 1);
        string str7 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyReq));
        ref Graphics local6 = ref objgraphics;
        rectangle2 = new Rectangle(0, 120, num, 23);
        Rectangle rect1_6 = rectangle2;
        rectangle1 = new Rectangle(num, 120, width, 23);
        Rectangle rect2_6 = rectangle1;
        string txt2_6 = str7;
        DrawMod.MakeFullBoxVic(ref local6, rect1_6, "ORQ", rect2_6, txt2_6, 1);
        string str8 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyOut));
        ref Graphics local7 = ref objgraphics;
        rectangle2 = new Rectangle(0, 143, num, 23);
        Rectangle rect1_7 = rectangle2;
        rectangle1 = new Rectangle(num, 143, width, 23);
        Rectangle rect2_7 = rectangle1;
        string txt2_7 = str8;
        DrawMod.MakeFullBoxVic(ref local7, rect1_7, "OUT", rect2_7, txt2_7, 1);
        string str9 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Reserve));
        if ((double) this.game.Data.RuleVar[322] == 0.0)
        {
          ref Graphics local8 = ref objgraphics;
          rectangle2 = new Rectangle(0, 166, num, 23);
          Rectangle rect1_8 = rectangle2;
          rectangle1 = new Rectangle(num, 166, width, 23);
          Rectangle rect2_8 = rectangle1;
          string txt2_8 = str9;
          DrawMod.MakeFullBoxVic(ref local8, rect1_8, "RES", rect2_8, txt2_8, 1);
        }
      }
      else if (this.game.HandyFunctionsObj.DoesUnitUseFuel(this.unr))
      {
        string str10 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].FuelUsedMove));
        ref Graphics local9 = ref objgraphics;
        rectangle2 = new Rectangle(0, 97, num, 23);
        Rectangle rect1_9 = rectangle2;
        rectangle1 = new Rectangle(num, 97, width, 23);
        Rectangle rect2_9 = rectangle1;
        string txt2_9 = str10;
        DrawMod.MakeFullBoxVic(ref local9, rect1_9, "FMV", rect2_9, txt2_9, 1);
        string str11 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].FuelUsedAtt));
        ref Graphics local10 = ref objgraphics;
        rectangle2 = new Rectangle(0, 120, num, 23);
        Rectangle rect1_10 = rectangle2;
        rectangle1 = new Rectangle(num, 120, width, 23);
        Rectangle rect2_10 = rectangle1;
        string txt2_10 = str11;
        DrawMod.MakeFullBoxVic(ref local10, rect1_10, "FAT", rect2_10, txt2_10, 1);
        string str12 = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].FuelUsedDef));
        ref Graphics local11 = ref objgraphics;
        rectangle2 = new Rectangle(0, 143, num, 23);
        Rectangle rect1_11 = rectangle2;
        rectangle1 = new Rectangle(num, 143, width, 23);
        Rectangle rect2_11 = rectangle1;
        string txt2_11 = str12;
        DrawMod.MakeFullBoxVic(ref local11, rect1_11, "FDF", rect2_11, txt2_11, 1);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    public override Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      ref Graphics local1 = ref Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
      ref Bitmap local2 = ref bitmap;
      DrawMod.Draw(ref local1, ref local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
