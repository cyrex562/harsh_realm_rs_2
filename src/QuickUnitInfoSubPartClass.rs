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
  pub class QuickUnitInfoSubPartClass : SubPartClass
  {
     object OwnBitmapNr;
     int unr;
     GameClass game;
     bool shownothing;

    pub QuickUnitInfoSubPartClass(int tunr, GameClass tgame, bool tShowNothing = false)
      : base(96, 200)
    {
      this.unr = tunr;
      this.game = tgame;
      this.shownothing = tShowNothing;
    }

    pub void DescriptInfo(int x, int y)
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

    pub Bitmap Paint()
    {
      SizeF sizeF = SizeF::new();
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.shownothing)
      {
        DrawMod.Clear( objgraphics, 101, 101, 101);
        return this.OwnBitmap;
      }
      let mut num: i32 = 40;
      let mut width: i32 = 56;
      string str1;
      if (this.game.Data.UnitObj[this.unr].IsHQ)
      {
        str1 = Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetRealHQSupplyPts(this.unr)));
      }
      else
      {
        str2: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Supply));
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
       Graphics local1 =  objgraphics;
      Rectangle rectangle1 = new Rectangle(0, 5, num, 23);
      Rectangle rect1_1 = rectangle1;
      Rectangle rectangle2 = new Rectangle(num, 5, width, 23);
      Rectangle rect2_1 = rectangle2;
      txt2_1: String = str1;
      DrawMod.MakeFullBoxVic( local1, rect1_1, "STK", rect2_1, txt2_1, 1);
      str3: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyIn));
       Graphics local2 =  objgraphics;
      rectangle2 = new Rectangle(0, 28, num, 23);
      Rectangle rect1_2 = rectangle2;
      rectangle1 = new Rectangle(num, 28, width, 23);
      Rectangle rect2_2 = rectangle1;
      txt2_2: String = str3;
      DrawMod.MakeFullBoxVic( local2, rect1_2, "IN", rect2_2, txt2_2, 1);
      str4: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyInReq));
       Graphics local3 =  objgraphics;
      rectangle2 = new Rectangle(0, 51, num, 23);
      Rectangle rect1_3 = rectangle2;
      rectangle1 = new Rectangle(num, 51, width, 23);
      Rectangle rect2_3 = rectangle1;
      txt2_3: String = str4;
      DrawMod.MakeFullBoxVic( local3, rect1_3, "REQ", rect2_3, txt2_3, 1);
      str5: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyLost));
       Graphics local4 =  objgraphics;
      rectangle2 = new Rectangle(0, 74, num, 23);
      Rectangle rect1_4 = rectangle2;
      rectangle1 = new Rectangle(num, 74, width, 23);
      Rectangle rect2_4 = rectangle1;
      txt2_4: String = str5;
      DrawMod.MakeFullBoxVic( local4, rect1_4, "DES", rect2_4, txt2_4, 1);
      if (this.game.Data.UnitObj[this.unr].IsHQ)
      {
        str6: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Supply));
         Graphics local5 =  objgraphics;
        rectangle2 = new Rectangle(0, 97, num, 23);
        Rectangle rect1_5 = rectangle2;
        rectangle1 = new Rectangle(num, 97, width, 23);
        Rectangle rect2_5 = rectangle1;
        txt2_5: String = str6;
        DrawMod.MakeFullBoxVic( local5, rect1_5, "RST", rect2_5, txt2_5, 1);
        str7: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyReq));
         Graphics local6 =  objgraphics;
        rectangle2 = new Rectangle(0, 120, num, 23);
        Rectangle rect1_6 = rectangle2;
        rectangle1 = new Rectangle(num, 120, width, 23);
        Rectangle rect2_6 = rectangle1;
        txt2_6: String = str7;
        DrawMod.MakeFullBoxVic( local6, rect1_6, "ORQ", rect2_6, txt2_6, 1);
        str8: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].SupplyOut));
         Graphics local7 =  objgraphics;
        rectangle2 = new Rectangle(0, 143, num, 23);
        Rectangle rect1_7 = rectangle2;
        rectangle1 = new Rectangle(num, 143, width, 23);
        Rectangle rect2_7 = rectangle1;
        txt2_7: String = str8;
        DrawMod.MakeFullBoxVic( local7, rect1_7, "OUT", rect2_7, txt2_7, 1);
        str9: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].Reserve));
        if ((double) this.game.Data.RuleVar[322] == 0.0)
        {
           Graphics local8 =  objgraphics;
          rectangle2 = new Rectangle(0, 166, num, 23);
          Rectangle rect1_8 = rectangle2;
          rectangle1 = new Rectangle(num, 166, width, 23);
          Rectangle rect2_8 = rectangle1;
          txt2_8: String = str9;
          DrawMod.MakeFullBoxVic( local8, rect1_8, "RES", rect2_8, txt2_8, 1);
        }
      }
      else if (this.game.HandyFunctionsObj.DoesUnitUseFuel(this.unr))
      {
        str10: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].FuelUsedMove));
         Graphics local9 =  objgraphics;
        rectangle2 = new Rectangle(0, 97, num, 23);
        Rectangle rect1_9 = rectangle2;
        rectangle1 = new Rectangle(num, 97, width, 23);
        Rectangle rect2_9 = rectangle1;
        txt2_9: String = str10;
        DrawMod.MakeFullBoxVic( local9, rect1_9, "FMV", rect2_9, txt2_9, 1);
        str11: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].FuelUsedAtt));
         Graphics local10 =  objgraphics;
        rectangle2 = new Rectangle(0, 120, num, 23);
        Rectangle rect1_10 = rectangle2;
        rectangle1 = new Rectangle(num, 120, width, 23);
        Rectangle rect2_10 = rectangle1;
        txt2_10: String = str11;
        DrawMod.MakeFullBoxVic( local10, rect1_10, "FAT", rect2_10, txt2_10, 1);
        str12: String = Strings.Trim(Conversion.Str((object) this.game.Data.UnitObj[this.unr].FuelUsedDef));
         Graphics local11 =  objgraphics;
        rectangle2 = new Rectangle(0, 143, num, 23);
        Rectangle rect1_11 = rectangle2;
        rectangle1 = new Rectangle(num, 143, width, 23);
        Rectangle rect2_11 = rectangle1;
        txt2_11: String = str12;
        DrawMod.MakeFullBoxVic( local11, rect1_11, "FDF", rect2_11, txt2_11, 1);
      }
      if (!Information.IsNothing((object) objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
       Graphics local1 =  Expression;
      Bitmap bitmap = BitmapStore.GetBitmap(Conversions.ToInteger(this.OwnBitmapNr));
       Bitmap local2 =  bitmap;
      DrawMod.Draw( local1,  local2, 0, 0, 0.3f, 0.3f, 0.3f, 1f);
      if (!Information.IsNothing((object) Expression))
        Expression.Dispose();
      return this.OwnBitmap;
    }
  }
}
