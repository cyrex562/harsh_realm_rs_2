// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SpecialWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SpecialWindowClass2 : WindowClass
  {
    private int okId;
    private int useWidth;
    private int useHeight;

    public SpecialWindowClass2(ref GameClass tGame, int tUseWidth, int tUseHeight)
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
      int id1 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      string libName = "SE_Data";
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 210, 0, 0));
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 190, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 187, 0, 0));
      int stringListById3 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 169, 0, 0));
      int stringListById4 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID(libName, 168, 0, 0));
      if (this.okId > 0)
      {
        this.RemoveSubPart(this.okId);
        this.okId = 0;
      }
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, -1);
      Graphics g1 = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawRepeatingBackground(g1, DrawMod.TGame.BACKGROUND3MARC, 0, 0, this.useWidth, this.useHeight);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      SimpleList simpleList1 = new SimpleList();
      simpleList1.Add(201, 0, 202, CheckExistence: false);
      simpleList1.Add(202, 0, 203, CheckExistence: false);
      simpleList1.Add(202, 0, 204, CheckExistence: false);
      simpleList1.Add(203, 0, 205, CheckExistence: false);
      simpleList1.Add(203, 0, 207, CheckExistence: false);
      simpleList1.Add(203, 0, 220, CheckExistence: false);
      simpleList1.Add(204, 0, 220, CheckExistence: false);
      simpleList1.Add(204, 0, 206, CheckExistence: false);
      simpleList1.Add(204, 0, 208, CheckExistence: false);
      simpleList1.Add(204, 0, 209, CheckExistence: false);
      simpleList1.Add(207, 0, 210, CheckExistence: false);
      simpleList1.Add(207, 0, 211, CheckExistence: false);
      simpleList1.Add(208, 0, 211, CheckExistence: false);
      simpleList1.Add(208, 0, 212, CheckExistence: false);
      simpleList1.Add(209, 0, 213, CheckExistence: false);
      simpleList1.Add(209, 0, 214, CheckExistence: false);
      simpleList1.Add(210, 0, 215, CheckExistence: false);
      simpleList1.Add(211, 0, 215, CheckExistence: false);
      simpleList1.Add(211, 0, 216, CheckExistence: false);
      simpleList1.Add(212, 0, 217, CheckExistence: false);
      simpleList1.Add(213, 0, 218, CheckExistence: false);
      simpleList1.Add(209, 0, 214, CheckExistence: false);
      simpleList1.Add(217, 0, 219, CheckExistence: false);
      int[] numArray1 = new int[21];
      int[] numArray2 = new int[21];
      int[] numArray3 = new int[21];
      int index1 = 1;
      do
      {
        int num1;
        int num2;
        int num3;
        if (index1 == 1)
        {
          num1 = 201;
          num2 = 2;
          num3 = 1;
        }
        if (index1 == 2)
        {
          num1 = 202;
          num2 = 3;
          num3 = 1;
        }
        if (index1 == 3)
        {
          num1 = 205;
          num2 = 1;
          num3 = 2;
        }
        if (index1 == 4)
        {
          num1 = 203;
          num2 = 2;
          num3 = 2;
        }
        if (index1 == 5)
        {
          num1 = 204;
          num2 = 3;
          num3 = 2;
        }
        if (index1 == 6)
        {
          num1 = 206;
          num2 = 4;
          num3 = 2;
        }
        if (index1 == 7)
        {
          num1 = 207;
          num2 = 1;
          num3 = 3;
        }
        if (index1 == 8)
        {
          num1 = 220;
          num2 = 2;
          num3 = 3;
        }
        if (index1 == 9)
        {
          num1 = 208;
          num2 = 3;
          num3 = 3;
        }
        if (index1 == 10)
        {
          num1 = 209;
          num2 = 4;
          num3 = 3;
        }
        if (index1 == 11)
        {
          num1 = 210;
          num2 = 1;
          num3 = 4;
        }
        if (index1 == 12)
        {
          num1 = 211;
          num2 = 2;
          num3 = 4;
        }
        if (index1 == 13)
        {
          num1 = 212;
          num2 = 3;
          num3 = 4;
        }
        if (index1 == 14)
        {
          num1 = 213;
          num2 = 4;
          num3 = 4;
        }
        if (index1 == 15)
        {
          num1 = 214;
          num2 = 5;
          num3 = 4;
        }
        if (index1 == 16)
        {
          num1 = 215;
          num2 = 1;
          num3 = 5;
        }
        if (index1 == 17)
        {
          num1 = 216;
          num2 = 2;
          num3 = 5;
        }
        if (index1 == 18)
        {
          num1 = 217;
          num2 = 3;
          num3 = 5;
        }
        if (index1 == 19)
        {
          num1 = 218;
          num2 = 4;
          num3 = 5;
        }
        if (index1 == 20)
        {
          num1 = 219;
          num2 = 3;
          num3 = 6;
        }
        numArray3[index1] = num1;
        numArray1[index1] = num2;
        numArray2[index1] = num3;
        ++index1;
      }
      while (index1 <= 20);
      int counter1 = simpleList1.Counter;
      for (int index2 = 0; index2 <= counter1; ++index2)
      {
        int num4 = simpleList1.Id[index2];
        int num5 = simpleList1.Data1[index2];
        int index3 = -1;
        int index4 = -1;
        int index5 = 1;
        do
        {
          if (num4 == numArray3[index5])
            index3 = index5;
          if (num5 == numArray3[index5])
            index4 = index5;
          ++index5;
        }
        while (index5 <= 20);
        Rectangle groupRect1 = this.GetGroupRect(numArray1[index3], numArray2[index3]);
        Rectangle groupRect2 = this.GetGroupRect(numArray1[index4], numArray2[index4]);
        if (groupRect1.Y < groupRect2.Y)
        {
          DrawMod.drawLine(ref g1, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X + (int) Math.Round((double) groupRect2.Width / 2.0), groupRect2.Y, 108, 108, 108, 180, 3);
          DrawMod.drawLine(ref g1, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X + (int) Math.Round((double) groupRect2.Width / 2.0), groupRect2.Y, 208, 228, 228, 180);
        }
        if (groupRect1.X < groupRect2.X & groupRect1.Y == groupRect2.Y)
        {
          DrawMod.drawLine(ref g1, groupRect1.X + groupRect1.Width, groupRect1.Y + (int) Math.Round((double) groupRect1.Height / 2.0), groupRect2.X, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 108, 108, 108, 180, 3);
          DrawMod.drawLine(ref g1, groupRect1.X + groupRect1.Width, groupRect1.Y + (int) Math.Round((double) groupRect1.Height / 2.0), groupRect2.X, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 208, 228, 228, 180);
        }
        if (groupRect1.X > groupRect2.X & groupRect1.Y == groupRect2.Y)
        {
          DrawMod.drawLine(ref g1, groupRect1.X, groupRect1.Y + (int) Math.Round((double) groupRect1.Height / 2.0), groupRect2.X + groupRect2.Width, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 108, 108, 108, 180, 3);
          DrawMod.drawLine(ref g1, groupRect1.X, groupRect1.Y + (int) Math.Round((double) groupRect1.Height / 2.0), groupRect2.X + groupRect2.Width, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 208, 228, 228, 180);
        }
      }
      int index6 = 1;
      do
      {
        int num6 = numArray3[index6];
        Rectangle groupRect = this.GetGroupRect(numArray1[index6], numArray2[index6]);
        if (this.game.EventRelatedObj.Helper_AirEnabled())
        {
          if (num6 == 206)
            groupRect.Width *= 2;
          if (num6 == 202)
            groupRect.Width = (int) Math.Round((double) groupRect.Width * 1.5);
        }
        else if (num6 == 206)
          groupRect.Width = (int) Math.Round((double) groupRect.Width * 1.5);
        string data1 = this.game.Data.StringListObj[stringListById1].GetData(0, num6, 1);
        bool flag1 = false;
        bool flag2 = false;
        int index7 = (int) Math.Round(Conversion.Val((object) this.game.Data.StringListObj[stringListById2].FindRow2(0, num6, 1, id1)));
        if (index7 > -1)
        {
          int num7 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index7, 2]));
          if (num7 >= 2)
            flag1 = true;
          else if (num7 >= 1)
            flag2 = true;
        }
        string str1 = "";
        string ttext1;
        Color c1;
        if (flag2)
        {
          ttext1 = "This Tech Group is open to discoveries. Once you have fully researched 3 Techs from this group you'll open up all the Tech Groups connected to " + data1 + ".";
          c1 = Color.LightGray;
          DrawMod.DrawBlockGradient2(ref g1, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, Color.FromArgb(100, 100, 120, 100), Color.FromArgb(50, 50, 60, 50));
        }
        else if (flag1)
        {
          ttext1 = "You have fully researched 3 or more Techs from this group. You have fully mastered it and have access to all connected Tech Groups.";
          c1 = Color.White;
          DrawMod.DrawBlockGradient2(ref g1, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, Color.FromArgb(100, 0, 150, 0), Color.FromArgb(50, 0, 75, 0));
        }
        else
        {
          ttext1 = "This Tech Group is still out of reach for making discoveries. You need to fully research 3 or more Techs in a Tech Group connecting to " + data1 + ".";
          c1 = Color.Gray;
          DrawMod.DrawBlockGradient2(ref g1, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, this.game.MarcCol1, this.game.MarcCol2);
        }
        int num8 = (int) Math.Round((double) (groupRect.Height - 33) / 5.0);
        int num9 = 28;
        Rectangle trect1;
        Rectangle trect2;
        if (num8 < 16)
        {
          DrawMod.DrawTextColouredMarcCenter(ref g1, data1, this.game.MarcFont5, groupRect.X + (int) Math.Round((double) groupRect.Width / 2.0), groupRect.Y + 3, c1);
          num9 = 18;
          trect1 = new Rectangle(groupRect.X, groupRect.Y, groupRect.Width, 18);
          trect2 = trect1;
          this.AddMouse(ref trect2, data1, ttext1);
        }
        else
        {
          DrawMod.DrawTextColouredMarcCenter(ref g1, data1, this.game.MarcFont4, groupRect.X + (int) Math.Round((double) groupRect.Width / 2.0), groupRect.Y + 5, c1);
          trect2 = new Rectangle(groupRect.X, groupRect.Y, groupRect.Width, 28);
          trect1 = trect2;
          this.AddMouse(ref trect1, data1, ttext1);
        }
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g1, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, -1, -1);
        SimpleList simpleList2 = new SimpleList();
        int length = this.game.Data.StringListObj[stringListById1].Length;
        for (int index8 = 0; index8 <= length; ++index8)
        {
          int num10 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index8, 10]));
          if (num10 == num6)
          {
            int tid = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index8, 0]));
            if (tid != num10)
              simpleList2.Add(tid, 1);
          }
        }
        int num11 = groupRect.X + 10;
        int num12 = groupRect.Y + num9;
        int width = (int) Math.Round((double) groupRect.Width / 2.0 - 20.0);
        if (this.game.EventRelatedObj.Helper_AirEnabled())
        {
          if (num6 == 206)
            width = (int) Math.Round((double) groupRect.Width / 4.0 - 20.0);
          if (num6 == 202)
            width = (int) Math.Round((double) groupRect.Width / 3.0 - 20.0);
        }
        else if (num6 == 206)
          width = (int) Math.Round((double) groupRect.Width / 3.0 - 20.0);
        int num13 = num11 + width + 20;
        int num14 = num12;
        int num15 = num13 + width + 20;
        int num16 = num12;
        int num17 = num15 + width + 20;
        int num18 = num12;
        int height = (int) Math.Round((double) (groupRect.Height - (num9 + 5)) / 5.0);
        int num19 = 5;
        if (num6 != 206 & !(this.game.EventRelatedObj.Helper_AirEnabled() & num6 == 202))
        {
          num19 = (int) Math.Round(Math.Floor((double) simpleList2.Counter / 2.0)) + 1;
          if (num19 < 5)
          {
            num12 += (int) Math.Round((double) (height * (5 - num19)) / 2.0);
            num14 += (int) Math.Round((double) (height * (5 - num19)) / 2.0);
          }
        }
        int counter2 = simpleList2.Counter;
        for (int index9 = 0; index9 <= counter2; ++index9)
        {
          int row = this.game.Data.StringListObj[stringListById1].FindRow(0, simpleList2.Id[index9]);
          string str2 = this.game.Data.StringListObj[stringListById1].Data[row, 1];
          int x;
          int num20;
          if (index9 < num19)
          {
            x = num11;
            num20 = num12;
            num12 += height;
          }
          else if (index9 < num19 * 2 | num6 != 206 & !(this.game.EventRelatedObj.Helper_AirEnabled() & num6 == 202))
          {
            x = num13;
            num20 = num14;
            num14 += height;
          }
          else if (index9 < num19 * 3 | num6 != 206)
          {
            x = num15;
            num20 = num16;
            num16 += height;
          }
          else
          {
            x = num17;
            num20 = num18;
            num18 += height;
          }
          int num21 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[row, 2]));
          int index10 = (int) Math.Round(Conversion.Val((object) this.game.Data.StringListObj[stringListById2].FindRow2(0, simpleList2.Id[index9], 1, id1)));
          int num22 = 0;
          if (index10 > -1)
            num22 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index10, 2]));
          string str3 = this.game.Data.StringListObj[stringListById1].Data[row, 9];
          int num23 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[row, 3]));
          int num24 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[row, 4]));
          string str4 = this.game.Data.StringListObj[stringListById1].Data[row, 7];
          string str5 = str4.ToLower();
          string str6 = "";
          int num25 = 1;
          int idValue;
          do
          {
            if (Strings.InStr(str5, "tech.") > 0)
            {
              int Start = Strings.InStr(str5, "tech.");
              int num26 = Strings.InStr(Start, str5, ">");
              idValue = (int) Math.Round(Conversion.Val(Strings.Mid(str5, Start + 5, num26 - (Start + 5))));
              if (idValue > 0)
              {
                string data2 = this.game.Data.StringListObj[stringListById1].GetData(0, idValue, 1);
                str6 = str6 + "• " + data2 + "\r\n";
              }
              str5 = str5.Replace("tech." + idValue.ToString(), "used." + idValue.ToString());
            }
            ++num25;
          }
          while (num25 <= 4);
          str1 = "";
          int r;
          int g2;
          int b;
          int a;
          Color c2;
          string str7;
          if (num22 >= 100)
          {
            r = 0;
            g2 = 150;
            b = 0;
            a = 128;
            c2 = Color.White;
            str7 = "You have fully researched " + str2 + ".";
          }
          else if (index10 > -1)
          {
            r = 110;
            g2 = 110;
            b = 0;
            a = 128;
            c2 = Color.Yellow;
            if (num22 > 0)
              str7 = "You have discovered " + str2 + ". But not fully researched. Research Level is at " + num22.ToString() + ".";
            else
              str7 = "You have discovered " + str2 + ". But research on it has not yet started.";
            if (num21 == 2)
              str7 += "\r\nKeep in mind this is a Linear research field and effects gradual. Arriving at level 100 will be extremely difficult.";
            if (num22 <= 0)
              ;
          }
          else if (!flag2 & !flag1)
          {
            r = 0;
            g2 = 0;
            b = 0;
            a = 128;
            c2 = Color.FromArgb((int) byte.MaxValue, 140, 140, 140);
            str7 = "You have not yet discovered " + str2 + ". Discovery is currently impossible.";
          }
          else
          {
            bool flag3 = true;
            if (str4.Length > 1)
            {
              EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
              int id2 = this.game.Data.StringListObj[stringListById4].ID;
              int id3 = this.game.Data.StringListObj[stringListById3].ID;
              string logicString = str4;
              Random random = (Random) null;
              ref Random local = ref random;
              if (eventRelatedObj.CheckLogicStringStart(id2, id3, logicString, 0, ref local) < 1)
                flag3 = false;
            }
            if (flag3)
            {
              r = 100;
              g2 = 100;
              b = 100;
              a = 128;
              c2 = Color.LightGray;
              str7 = "You have not yet discovered " + str2 + ". Discovery is possible.";
            }
            else
            {
              r = 0;
              g2 = 0;
              b = 0;
              a = 128;
              c2 = Color.FromArgb((int) byte.MaxValue, 140, 140, 140);
              str7 = "You have not yet discovered " + str2 + ". Discovery is currently impossible because of a 'requisite condition' missing.";
            }
          }
          string tstring = "";
          Color color;
          if (index10 == -1 | num22 == 0 & index10 > -1)
          {
            switch (num23)
            {
              case 1:
                str7 += "\r\n\r\nYou need the Economic Council to discover this Tech.";
                tstring = "Ec";
                color = Color.DarkBlue;
                break;
              case 2:
                str7 += "\r\n\r\nYou need the Military Research Council to discover this Tech.";
                tstring = "Mi";
                color = Color.DarkOliveGreen;
                break;
              case 33:
                str7 += "\r\n\r\nYou need the Applied Science Council to discover this Tech.";
                tstring = "Ap";
                color = Color.DarkSlateGray;
                break;
              case 61:
                str7 += "\r\n\r\nYou need the Military Research Council or Airforce Research Department to discover this Tech.";
                tstring = "Air";
                color = Color.FromArgb((int) byte.MaxValue, 140, 160, 180);
                break;
            }
          }
          string str8 = str2;
          int num27 = 1;
          int num28 = 0;
          idValue = 0;
          if (num22 > 0 & num22 < 100)
            idValue = 20;
          if (index10 == -1)
            idValue = 20;
          if (num22 == 0)
            idValue = 20;
          while (num27 > 0)
          {
            num27 = 0;
            sizeF = g1.MeasureString(str8, this.game.MarcFont5);
            if ((double) sizeF.Width > (double) (width - idValue))
            {
              num27 = 1;
              num28 = 1;
              str8 = Strings.Left(str8, str8.Length - 1);
            }
          }
          if (num28 == 1)
            str8 += ".";
          if (num22 > 0 & num22 < 100)
            str8 = str8 + " - " + num22.ToString();
          string ttext2 = str7 + "\r\n\r\n" + str3;
          if (str6.Length > 0)
            ttext2 = ttext2 + "\r\n\r\nThis Tech has the following prerequisites:\r\n" + str6;
          DrawMod.DrawBlock(ref g1, x - 2, num20 - 2, Math.Max(14, width - 4 + 5), Math.Max(14, height - 4), r, g2, b, a);
          DrawMod.DrawTextColouredMarc(ref g1, str8, this.game.MarcFont5, x, num20 - 1, c2);
          if (tstring.Length > 0)
          {
            DrawMod.DrawBlock(ref g1, (int) Math.Round((double) x + (double) sizeF.Width + 3.0), num20 - 1, 20, Math.Max(12, height - 6), (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredMarcCenter(ref g1, tstring, this.game.MarcFont5, (int) Math.Round((double) x + (double) sizeF.Width + 13.0), num20 - 1, c2);
          }
          trect2 = new Rectangle(x - 4, num20 - 4, width, height);
          trect1 = trect2;
          this.AddMouse(ref trect1, str2 + " (#" + simpleList2.Id[index9].ToString() + ")", ttext2);
        }
        ++index6;
      }
      while (index6 <= 20);
      g1.Dispose();
    }

    public Rectangle GetGroupRect(int tgroupX, int tgroupY)
    {
      int num1 = 50;
      int num2 = 104;
      int num3 = this.useHeight - 768;
      int num4 = (int) Math.Round(238.0 + Math.Floor((double) (this.useWidth - 1280) / 5.0));
      int num5 = (int) Math.Round(108.0 + Math.Floor((double) num3 / 6.0));
      int x = (tgroupX - 1) * num4 + num1;
      int y = (tgroupY - 1) * num5 + num2;
      int num6 = num4 - 8;
      int height = (int) Math.Round((double) (num5 - 18) - Math.Floor((double) num3 / 18.0));
      int width = (int) Math.Round((double) num6 - Math.Floor((double) num3 / 15.0));
      return new Rectangle(x, y, width, height);
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
