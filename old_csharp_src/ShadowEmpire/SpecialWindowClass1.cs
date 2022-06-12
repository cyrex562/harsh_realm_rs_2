// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SpecialWindowClass1
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SpecialWindowClass1 : WindowClass
  {
    private int okId;
    private int useWidth;
    private int useHeight;

    public SpecialWindowClass1(ref GameClass tGame, int tUseWidth, int tUseHeight)
      : base(ref tGame, tUseWidth, tUseHeight, 8)
    {
      this.useWidth = tUseWidth;
      this.useHeight = tUseHeight;
      this.dostuff();
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

    public void dostuff(bool crmAlreadySet = false)
    {
      SizeF sizeF = new SizeF();
      int id = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      string libName = "SE_Data";
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 387, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 388, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 258, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 277, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 402, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 188, 0, 0));
      int stringListById8 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Present", 81, 0, 0));
      if (this.okId > 0)
      {
        this.RemoveSubPart(this.okId);
        this.okId = 0;
      }
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawRepeatingBackground(g, DrawMod.TGame.BACKGROUND3MARC, 0, 0, this.useWidth, this.useHeight);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      int num1 = 50;
      int num2 = 88;
      int num3 = (int) Math.Round((double) (this.useHeight - 768) / 9.0) - 1;
      if (num3 < 0)
        num3 = 0;
      int num4 = (int) Math.Round((double) (this.useWidth - 310) / 6.0);
      if (num4 < 160)
        num4 = 160;
      int Length = (int) Math.Round((double) num4 / 8.0) - 1;
      if (Length < 19)
        Length = 10;
      int num5 = 1;
      do
      {
        int num6 = num1;
        int num7 = num2 + (num5 - 1) * (72 + num3);
        DrawMod.DrawBlockGradient2(ref g, num6, num7, this.useWidth - 100, 70 + num3, this.game.MarcCol1, this.game.MarcCol2);
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, num6, num7, this.useWidth - 100, 70 + num3, -1, -1);
        string str1 = "";
        if (num5 == 1)
          str1 = "Democracy";
        if (num5 == 2)
          str1 = "Autocracy";
        if (num5 == 3)
          str1 = "Meritocracy";
        if (num5 == 4)
          str1 = "Enforcement";
        if (num5 == 5)
          str1 = "Commerce";
        if (num5 == 6)
          str1 = "Government";
        if (num5 == 7)
          str1 = "Fist";
        if (num5 == 8)
          str1 = "Mind";
        if (num5 == 9)
          str1 = "Heart";
        int num8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, id, 1, str1, 2)));
        string data1 = this.game.Data.StringListObj[stringListById4].GetData(0, str1, 4);
        int tCardId = this.game.Data.FindEventPic((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, str1, 5))), data1);
        int num9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, str1, 6)));
        ref Graphics local1 = ref g;
        Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[tCardId]);
        ref Bitmap local2 = ref bitmap1;
        Rectangle trect = new Rectangle(num9 * 32, 0, 32, 32);
        Rectangle srcrect = trect;
        Rectangle rectangle = new Rectangle(num6 + 20, num7 + 20 + (int) Math.Round((double) num3 / 2.0), 32, 32);
        Rectangle destrect = rectangle;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        DrawMod.DrawTextColouredMarc(ref g, num8.ToString(), this.game.MarcFont3, num6 + 58, num7 + 25 + (int) Math.Round((double) num3 / 2.0), Color.White);
        DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont4, num6 + 88, num7 + 26 + (int) Math.Round((double) num3 / 2.0), Color.White);
        int num10 = num7 + 7;
        int num11 = 1;
        do
        {
          int num12 = num1 + 200 + (num11 - 1) * num4;
          int idValue2 = 40 + (num11 - 1) * 10;
          int num13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData2(5, str1.ToLower(), 20, idValue2, 0)));
          if (num13 > 0)
          {
            bool flag1 = false;
            if (this.game.Data.StringListObj[stringListById3].FindRow2(0, id, 1, num13) > -1)
              flag1 = true;
            string str2 = this.game.Data.StringListObj[stringListById2].GetData(0, num13, 3);
            string currentName = str2;
            int num14 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, num13, 21)));
            if (str2.Length > Length + 1)
              str2 = Strings.Left(str2, Length) + ".";
            bool flag2 = false;
            int num15 = 0;
            if (num8 >= idValue2 & !flag1)
            {
              flag2 = true;
              num15 = num8 - idValue2 + 1;
            }
            bool flag3 = false;
            int num16 = 0;
            if (flag1)
              flag2 = false;
            if (num8 <= num14)
            {
              flag3 = true;
              num16 = num14 - num8 + 1;
            }
            if (!flag1)
              flag3 = false;
            if (flag1)
            {
              if (flag3)
                DrawMod.DrawBlockGradient2(ref g, num12, num10, num4 - 5, 55 + num3, Color.FromArgb(100, 100, 70, 0), Color.FromArgb(50, 50, 30, 0));
              else
                DrawMod.DrawBlockGradient2(ref g, num12, num10, num4 - 5, 55 + num3, Color.FromArgb(100, 0, 150, 0), Color.FromArgb(50, 0, 75, 0));
            }
            else if (!flag1)
            {
              if (flag2)
                DrawMod.DrawBlockGradient2(ref g, num12, num10, num4 - 5, 55 + num3, Color.FromArgb(100, 100, 120, 100), Color.FromArgb(50, 50, 60, 50));
              else
                DrawMod.DrawBlockGradient2(ref g, num12, num10, num4 - 5, 55 + num3, Color.FromArgb(100, 0, 0, 0), Color.FromArgb(50, 0, 0, 0));
            }
            string data2 = this.game.Data.StringListObj[stringListById2].GetData(0, num13, 22);
            int num17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, num13, 23)));
            bool flag4 = true;
            int num18 = num17;
            int num19 = 0;
            if (data2.Length > 1)
            {
              int num20 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, id, 1, data2, 2)));
              num19 = num20;
              if (num20 < num17)
                flag4 = false;
            }
            else
              flag4 = false;
            int num21 = num12 + 8;
            int length1 = this.game.Data.StringListObj[stringListById5].Length;
            string str3;
            for (int index = 0; index <= length1; ++index)
            {
              if (Strings.InStr(this.game.Data.StringListObj[stringListById5].Data[index, 6], "REGIMEFEAT." + num13.ToString()) > 0)
              {
                tCardId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[index, 0]));
                int num22 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[index, 5]));
                int num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].Data[index, 14]));
                string ttitle = "Stratagem: " + this.game.Data.StringListObj[stringListById5].Data[index, 1];
                str3 = "";
                string str4;
                if (num22 > 0 | num23 > 0)
                {
                  if (num22 == 0 | num23 == 0)
                  {
                    int idValue = Math.Max(num22, num23);
                    str4 = "You need the Organisation '" + this.game.Data.StringListObj[stringListById7].GetData(0, idValue, 1) + "' to generate these Stratagems.\r\n\r\n";
                  }
                  else
                    str4 = "You need the Organisation '" + this.game.Data.StringListObj[stringListById7].GetData(0, num22, 1) + "' or '" + this.game.Data.StringListObj[stringListById7].GetData(0, num23, 1) + "' to generate these Stratagems.\r\n\r\n";
                }
                else
                  str4 = "No Organisation is needed to generate these Stratagems.\r\n\r\n";
                string ttext = str4 + this.game.Data.StringListObj[stringListById5].Data[index, 4];
                int x1 = num21;
                int y1 = (int) Math.Round((double) (num10 + 19) + (double) num3 * 0.33);
                int width = (int) Math.Round(20.0 + (double) num3 * 0.44);
                int height = (int) Math.Round(30.0 + (double) num3 * 0.66);
                ref Graphics local3 = ref g;
                Bitmap bitmap2 = this.game.CustomBitmapObj.DrawActionCardSe1(this.game.Data.Turn, -1, size: 2, tCardId: tCardId);
                ref Bitmap local4 = ref bitmap2;
                int x2 = x1;
                int y2 = y1;
                int w = width;
                int h = height;
                DrawMod.DrawScaled(ref local3, ref local4, x2, y2, w, h, true);
                rectangle = new Rectangle(x1, y1, width, height);
                trect = rectangle;
                this.AddMouse(ref trect, ttitle, ttext);
                num21 += width + 2;
              }
            }
            int length2 = this.game.Data.StringListObj[stringListById6].Length;
            for (int index = 0; index <= length2; ++index)
            {
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].Data[index, 1])) == num13)
              {
                tCardId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].Data[index, 10]));
                string ttitle = "Unit Feat: " + this.game.Data.StringListObj[stringListById6].Data[index, 2];
                string ttext = this.game.Data.StringListObj[stringListById6].Data[index, 12];
                Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.Data.EventPicNr[tCardId]);
                int x = num21 - 4;
                int y = (int) Math.Round((double) (num10 + 10) + (double) num3 * 0.5);
                int num24 = (int) Math.Round(40.0 + (double) num3 * 0.5);
                int num25 = (int) Math.Round(40.0 + (double) num3 * 0.5);
                DrawMod.DrawScaled(ref g, ref bitmap3, x, y, num24, num25, true);
                rectangle = new Rectangle(x, y, num24, num25);
                trect = rectangle;
                this.AddMouse(ref trect, ttitle, ttext);
              }
            }
            if (flag1)
              DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont8c, num12 + 8, (int) Math.Round((double) (num10 + 4) + (double) num3 / 8.0), Color.White);
            else if (!flag1)
              DrawMod.DrawTextColouredMarc(ref g, str2, this.game.MarcFont8c, num12 + 8, (int) Math.Round((double) (num10 + 4) + (double) num3 / 8.0), Color.LightGray);
            DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, num12, num10, num4 - 5, 55 + num3, -1, -1);
            tCardId = this.game.Data.StringListObj[stringListById8].FindRow(0, "{regimefeat}" + currentName);
            if (tCardId > -1)
            {
              string str5 = this.game.Data.StringListObj[stringListById8].Data[tCardId, 2] + "\r\n\r\n" + this.game.Data.StringListObj[stringListById8].Data[tCardId, 5];
              str3 = "";
              string str6;
              if (flag1)
              {
                if (flag3)
                  str6 = "Your nation has this Regime Feat. You have a " + num16.ToString() + "% chance every turn to lose this Regime Feat because your profile is equal or below " + str1 + "-" + num14.ToString() + ".";
                else
                  str6 = "Your nation has this Regime Feat. You cannot lose it unless your Profile drops to " + str1 + "-" + num14.ToString() + " or lower.";
              }
              else if (flag2)
              {
                if (flag4)
                  str6 = "Your nation does not have this Regime Feat. You have a " + num15.ToString() + "% chance every turn to gain it. Has been the highest Profile in group for " + num19.ToString() + " Rounds.";
                else
                  str6 = "Your nation does not have this Regime Feat. You still have 0% chance every turn to gain it because the Profile has only been the highest Profile in group for " + num19.ToString() + " Rounds. It needs to have been the highest for " + num18.ToString() + " Rounds.";
              }
              else
                str6 = "Your nation does not have this Regime Feat. You need a Profile of at least " + str1 + "-" + idValue2.ToString() + " to have a chance to gain it.";
              string ttext = this.game.HandyFunctionsObj.CustomMouseOverLookups(str6 + "\r\n\r\n" + str5, currentName);
              rectangle = new Rectangle(num12, num10, num4 - 5, 55 + num3);
              trect = rectangle;
              this.AddMouse(ref trect, "Regime Feat: " + currentName, ttext);
            }
            if (flag2)
            {
              if (flag4)
              {
                DrawMod.DrawTextColouredMarcCenter(ref g, num15.ToString() + "%", this.game.MarcFont4, num12 + num4 - 24, num10 + 36 + num3, Color.FromArgb((int) byte.MaxValue, 150, 200, 150));
              }
              else
              {
                tCardId = num18 - num19;
                if (tCardId < 0)
                  tCardId = 0;
                DrawMod.DrawTextColouredMarcCenter(ref g, tCardId.ToString() + " Rd", this.game.MarcFont4, num12 + num4 - 36, num10 + 36 + num3, Color.FromArgb((int) byte.MaxValue, 200, 150, 150));
              }
            }
            if (flag3)
              DrawMod.DrawTextColouredMarcCenter(ref g, num16.ToString() + "%", this.game.MarcFont4, num12 + num4 - 24, num10 + 36 + num3, Color.FromArgb((int) byte.MaxValue, 200, 150, 150));
          }
          ++num11;
        }
        while (num11 <= 6);
        ++num5;
      }
      while (num5 <= 9);
      g.Dispose();
      g = (Graphics) null;
    }

    public override WindowReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if (nr == 27 | nr == 32)
        {
          if (nr > 0 & this.okId > 0)
          {
            windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okId)] + 1, this.SubPartY[this.SubpartNr(this.okId)] + 1, 1);
            windowReturnClass.SetFlag(true);
          }
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
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      WindowReturnClass windowReturnClass2 = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && this.SubPartID[index] == this.okId)
          {
            windowReturnClass1.AddCommand(6, 0);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
        windowReturnClass1.SetFlag(false);
        return windowReturnClass1;
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }
  }
}
