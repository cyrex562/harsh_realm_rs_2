// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SpecialWindowClass3
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class SpecialWindowClass3 : WindowClass
  {
    private int okId;
    private int useWidth;
    private int useHeight;

    public SpecialWindowClass3(ref GameClass tGame, int tUseWidth, int tUseHeight)
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
      SizeF sizeF1 = new SizeF();
      int id1 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      string libName = "SE_Data";
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 225, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 228, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 169, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 168, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 143, 0, 0));
      int stringListById6 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(DrawMod.TGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID(libName, 190, 0, 0));
      if (this.okId > 0)
      {
        this.RemoveSubPart(this.okId);
        this.okId = 0;
      }
      int idValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData(0, id1, 2)));
      int cultureGroupId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue1, 1)));
      this.game.Data.StringListObj[stringListById3].SetData(0, "REGIMEID", 1, id1);
      this.game.Data.StringListObj[stringListById3].SetData(0, "ROUND", 1, this.game.Data.Round);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawRepeatingBackground(g, DrawMod.TGame.BACKGROUND3MARC, 0, 0, this.useWidth, this.useHeight);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      string text;
      sizeF1 = g.MeasureString(text, this.game.MarcFont4);
      SimpleList simpleList1 = new SimpleList();
      simpleList1.Add(1, 0, 2, CheckExistence: false);
      simpleList1.Add(1, 0, 3, CheckExistence: false);
      simpleList1.Add(1, 0, 22, CheckExistence: false);
      simpleList1.Add(1, 0, 11, CheckExistence: false);
      simpleList1.Add(1, 0, 41, CheckExistence: false);
      simpleList1.Add(1, 0, 5, CheckExistence: false);
      simpleList1.Add(1, 0, 13, CheckExistence: false);
      simpleList1.Add(2, 0, 73, CheckExistence: false);
      simpleList1.Add(73, 0, 72, CheckExistence: false);
      simpleList1.Add(2, 0, 4, CheckExistence: false);
      simpleList1.Add(4, 0, 81, CheckExistence: false);
      simpleList1.Add(22, 0, 21, CheckExistence: false);
      simpleList1.Add(22, 0, 23, CheckExistence: false);
      simpleList1.Add(23, 0, 61, CheckExistence: false);
      simpleList1.Add(61, 0, 62, CheckExistence: false);
      simpleList1.Add(62, 0, 63, CheckExistence: false);
      simpleList1.Add(63, 0, 64, CheckExistence: false);
      simpleList1.Add(11, 0, 31, CheckExistence: false);
      simpleList1.Add(31, 0, 32, CheckExistence: false);
      simpleList1.Add(32, 0, 34, CheckExistence: false);
      simpleList1.Add(32, 0, 91, CheckExistence: false);
      simpleList1.Add(32, 0, 33, CheckExistence: false);
      simpleList1.Add(33, 0, 51, CheckExistence: false);
      simpleList1.Add(91, 0, 92, CheckExistence: false);
      simpleList1.Add(33, 0, 35, CheckExistence: false);
      simpleList1.Add(33, 0, 36, CheckExistence: false);
      simpleList1.Add(51, 0, 52, CheckExistence: false);
      simpleList1.Add(51, 0, 71, CheckExistence: false);
      simpleList1.Add(41, 0, 12, CheckExistence: false);
      if (this.game.EventRelatedObj.Helper_AirEnabled())
      {
        simpleList1.Add(1, 0, 101, CheckExistence: false);
        simpleList1.Add(1, 0, 111, CheckExistence: false);
        simpleList1.Add(1, 0, 121, CheckExistence: false);
        simpleList1.Add(101, 0, 102, CheckExistence: false);
        simpleList1.Add(102, 0, 103, CheckExistence: false);
        simpleList1.Add(103, 0, 105, CheckExistence: false);
        simpleList1.Add(105, 0, 107, CheckExistence: false);
        simpleList1.Add(103, 0, 104, CheckExistence: false);
        simpleList1.Add(105, 0, 106, CheckExistence: false);
        simpleList1.Add(107, 0, 108, CheckExistence: false);
        simpleList1.Add(111, 0, 112, CheckExistence: false);
        simpleList1.Add(112, 0, 113, CheckExistence: false);
        simpleList1.Add(121, 0, 122, CheckExistence: false);
        simpleList1.Add(122, 0, 123, CheckExistence: false);
        simpleList1.Add(21, 0, 132, CheckExistence: false);
        simpleList1.Add(62, 0, 131, CheckExistence: false);
        simpleList1.Add(3, 0, 133, CheckExistence: false);
      }
      int[] numArray1 = new int[56];
      int[] numArray2 = new int[56];
      int[] numArray3 = new int[56];
      int index1 = 1;
      do
      {
        int num1;
        int num2;
        int num3;
        if (index1 == 1)
        {
          num1 = 1;
          num2 = 1;
          num3 = 1;
        }
        if (index1 == 2)
        {
          num1 = 2;
          num2 = 2;
          num3 = 1;
        }
        if (index1 == 3)
        {
          num1 = 73;
          num2 = 3;
          num3 = 1;
        }
        if (index1 == 4)
        {
          num1 = 72;
          num2 = 4;
          num3 = 1;
        }
        if (index1 == 5)
        {
          num1 = 3;
          num2 = 2;
          num3 = 2;
        }
        if (index1 == 6)
        {
          num1 = 4;
          num2 = 3;
          num3 = 2;
        }
        if (index1 == 7)
        {
          num1 = 81;
          num2 = 4;
          num3 = 2;
        }
        if (index1 == 8)
        {
          num1 = 22;
          num2 = 2;
          num3 = 3;
        }
        if (index1 == 9)
        {
          num1 = 21;
          num2 = 3;
          num3 = 3;
        }
        if (index1 == 10)
        {
          num1 = 23;
          num2 = 3;
          num3 = 4;
        }
        if (index1 == 11)
        {
          num1 = 61;
          num2 = 4;
          num3 = 4;
        }
        if (index1 == 12)
        {
          num1 = 62;
          num2 = 5;
          num3 = 4;
        }
        if (index1 == 13)
        {
          num1 = 63;
          num2 = 6;
          num3 = 4;
        }
        if (index1 == 14)
        {
          num1 = 64;
          num2 = 7;
          num3 = 4;
        }
        if (index1 == 15)
        {
          num1 = 34;
          num2 = 5;
          num3 = 5;
        }
        if (index1 == 16)
        {
          num1 = 11;
          num2 = 2;
          num3 = 6;
        }
        if (index1 == 17)
        {
          num1 = 31;
          num2 = 3;
          num3 = 6;
        }
        if (index1 == 18)
        {
          num1 = 32;
          num2 = 4;
          num3 = 6;
        }
        if (index1 == 19)
        {
          num1 = 91;
          num2 = 5;
          num3 = 6;
        }
        if (index1 == 20)
        {
          num1 = 92;
          num2 = 6;
          num3 = 6;
        }
        if (index1 == 21)
        {
          num1 = 33;
          num2 = 5;
          num3 = 7;
        }
        if (index1 == 22)
        {
          num1 = 35;
          num2 = 6;
          num3 = 7;
        }
        if (index1 == 23)
        {
          num1 = 41;
          num2 = 2;
          num3 = 8;
        }
        if (index1 == 24)
        {
          num1 = 12;
          num2 = 3;
          num3 = 8;
        }
        if (index1 == 25)
        {
          num1 = 36;
          num2 = 6;
          num3 = 8;
        }
        if (index1 == 26)
        {
          num1 = 5;
          num2 = 2;
          num3 = 9;
        }
        if (index1 == 27)
        {
          num1 = 51;
          num2 = 6;
          num3 = 9;
        }
        if (index1 == 28)
        {
          num1 = 52;
          num2 = 7;
          num3 = 9;
        }
        if (index1 == 29)
        {
          num1 = 13;
          num2 = 2;
          num3 = 10;
        }
        if (index1 == 30)
        {
          num1 = 71;
          num2 = 7;
          num3 = 10;
        }
        if (this.game.EventRelatedObj.Helper_AirEnabled())
        {
          if (index1 == 26)
          {
            num1 = 5;
            num2 = 2;
            num3 = 4;
          }
          if (index1 == 29)
          {
            num1 = 13;
            num2 = 2;
            num3 = 5;
          }
          if (index1 == 23)
          {
            num1 = 41;
            num2 = 2;
            num3 = 7;
          }
          if (index1 == 24)
          {
            num1 = 12;
            num2 = 3;
            num3 = 7;
          }
          if (index1 == 31)
          {
            num1 = 101;
            num2 = 2;
            num3 = 10;
          }
          if (index1 == 32)
          {
            num1 = 102;
            num2 = 3;
            num3 = 10;
          }
          if (index1 == 33)
          {
            num1 = 103;
            num2 = 4;
            num3 = 10;
          }
          if (index1 == 34)
          {
            num1 = 105;
            num2 = 5;
            num3 = 10;
          }
          if (index1 == 35)
          {
            num1 = 107;
            num2 = 6;
            num3 = 10;
          }
          if (index1 == 36)
          {
            num1 = 104;
            num2 = 4;
            num3 = 11;
          }
          if (index1 == 37)
          {
            num1 = 106;
            num2 = 5;
            num3 = 11;
          }
          if (index1 == 38)
          {
            num1 = 108;
            num2 = 6;
            num3 = 11;
          }
          if (index1 == 39)
          {
            num1 = 111;
            num2 = 2;
            num3 = 9;
          }
          if (index1 == 40)
          {
            num1 = 112;
            num2 = 3;
            num3 = 9;
          }
          if (index1 == 41)
          {
            num1 = 113;
            num2 = 4;
            num3 = 9;
          }
          if (index1 == 42)
          {
            num1 = 121;
            num2 = 2;
            num3 = 8;
          }
          if (index1 == 43)
          {
            num1 = 122;
            num2 = 3;
            num3 = 8;
          }
          if (index1 == 44)
          {
            num1 = 123;
            num2 = 4;
            num3 = 8;
          }
          if (index1 == 45)
          {
            num1 = 131;
            num2 = 6;
            num3 = 3;
          }
          if (index1 == 46)
          {
            num1 = 132;
            num2 = 4;
            num3 = 3;
          }
          if (index1 == 47)
          {
            num1 = 133;
            num2 = 3;
            num3 = 2;
          }
          if (index1 == 2)
          {
            num1 = 2;
            num2 = 3;
            num3 = 1;
          }
          if (index1 == 3)
          {
            num1 = 73;
            num2 = 4;
            num3 = 1;
          }
          if (index1 == 4)
          {
            num1 = 72;
            num2 = 5;
            num3 = 1;
          }
          if (index1 == 6)
          {
            num1 = 4;
            num2 = 4;
            num3 = 2;
          }
          if (index1 == 7)
          {
            num1 = 81;
            num2 = 5;
            num3 = 2;
          }
        }
        numArray3[index1] = num1;
        numArray1[index1] = num2;
        numArray2[index1] = num3;
        ++index1;
      }
      while (index1 <= 47);
      int counter = simpleList1.Counter;
      for (int index2 = 0; index2 <= counter; ++index2)
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
        while (index5 <= 47);
        Rectangle groupRect1 = this.GetGroupRect(numArray1[index3], numArray2[index3]);
        Rectangle groupRect2 = this.GetGroupRect(numArray1[index4], numArray2[index4]);
        if (num4 == 1 & !(num5 == 2 | num5 == 3))
        {
          DrawMod.drawLine(ref g, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 108, 108, 108, 180, 3);
          DrawMod.drawLine(ref g, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 208, 228, 228, 180);
        }
        else if (numArray2[index4] == 11)
        {
          DrawMod.drawLine(ref g, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X + (int) Math.Round((double) groupRect2.Width / 2.0), groupRect2.Y, 108, 108, 108, 180, 3);
          DrawMod.drawLine(ref g, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X + (int) Math.Round((double) groupRect2.Width / 2.0), groupRect2.Y, 208, 228, 228, 180);
        }
        else if (numArray1[index4] == numArray1[index3])
        {
          DrawMod.drawLine(ref g, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X + (int) Math.Round((double) groupRect2.Width / 2.0), groupRect2.Y, 108, 108, 108, 180, 3);
          DrawMod.drawLine(ref g, groupRect1.X + (int) Math.Round((double) groupRect1.Width / 2.0), groupRect1.Y + groupRect1.Height, groupRect2.X + (int) Math.Round((double) groupRect2.Width / 2.0), groupRect2.Y, 208, 228, 228, 180);
        }
        else
        {
          DrawMod.drawLine(ref g, groupRect1.X + groupRect1.Width, groupRect1.Y + (int) Math.Round((double) groupRect1.Height / 2.0), groupRect2.X, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 108, 108, 108, 180, 3);
          DrawMod.drawLine(ref g, groupRect1.X + groupRect1.Width, groupRect1.Y + (int) Math.Round((double) groupRect1.Height / 2.0), groupRect2.X, groupRect2.Y + (int) Math.Round((double) groupRect2.Height / 2.0), 208, 228, 228, 180);
        }
      }
      int index6 = 1;
      do
      {
        int idValue2 = numArray3[index6];
        int tgroupX = numArray1[index6];
        int tgroupY = numArray2[index6];
        if (idValue2 > 0)
        {
          Rectangle groupRect = this.GetGroupRect(tgroupX, tgroupY);
          if (idValue2 == 206)
            groupRect.Width = (int) Math.Round((double) groupRect.Width * 1.5);
          string data1 = this.game.Data.StringListObj[stringListById1].GetData(0, idValue2, 1);
          string data2 = this.game.Data.StringListObj[stringListById1].GetData(0, idValue2, 6);
          bool flag1 = false;
          bool flag2 = false;
          int num6 = 0;
          int num7 = 0;
          SimpleList simpleList2 = new SimpleList();
          string str1 = "";
          string str2 = "";
          int length = this.game.Data.StringListObj[stringListById2].Length;
          for (int index7 = 0; index7 <= length; ++index7)
          {
            if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index7, 1])) == idValue2 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index7, 2])) == id1)
            {
              int num8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index7, 4]));
              int num9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].Data[index7, 5]));
              if (num9 < 1 & num8 < 1)
                flag1 = true;
              if (num9 < 1 & num8 > 0)
              {
                flag1 = true;
                ++num6;
              }
              if (num9 > 0 & num8 > 0)
              {
                flag1 = true;
                ++num7;
                simpleList2.Add(num9, num9);
                string str3 = this.game.Data.StringListObj[stringListById2].Data[index7, 3];
                str1 = str1 + "• " + str3 + "\r\n";
              }
            }
          }
          if (!flag1)
          {
            EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
            int id2 = this.game.Data.StringListObj[stringListById4].ID;
            int id3 = this.game.Data.StringListObj[stringListById3].ID;
            string logicString = data2;
            Random random = (Random) null;
            ref Random local = ref random;
            int num10 = eventRelatedObj.CheckLogicStringStart(id2, id3, logicString, 0, ref local);
            flag2 = true;
            if (num10 < 1)
              flag2 = false;
          }
          string ttext;
          Color c;
          int num11;
          if (flag2)
          {
            ttext = "This Model Type could be discovered";
            c = Color.LightGray;
            DrawMod.DrawBlockGradient2(ref g, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, Color.FromArgb(100, 50, 60, 50), Color.FromArgb(50, 20, 30, 20));
          }
          else if (flag1 & simpleList2.Counter > -1)
          {
            ttext = "This Model Type is already discovered and you have designed Models.";
            c = Color.White;
            DrawMod.DrawBlockGradient2(ref g, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, Color.FromArgb(100, 0, 150, 0), Color.FromArgb(50, 0, 75, 0));
          }
          else if (flag1 & simpleList2.Counter == -1)
          {
            ttext = "This Model Type is already discovered, but you did not complete design of any Model yet.";
            c = Color.LightGray;
            DrawMod.DrawBlockGradient2(ref g, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, Color.FromArgb(100, 50, 135, 50), Color.FromArgb(50, 25, 67, 25));
            if (num6 > 0)
              data1 += "*";
          }
          else
          {
            ttext = "This Model Type cannot be discovered yet.";
            c = Color.Gray;
            DrawMod.DrawBlockGradient2(ref g, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, this.game.MarcCol1, this.game.MarcCol2);
            string str4 = this.game.Data.StringListObj[stringListById1].GetData(0, idValue2, 6).ToLower();
            int num12 = 1;
            do
            {
              if (Strings.InStr(str4, "tech.") > 0)
              {
                int Start = Strings.InStr(str4, "tech.");
                int num13 = Strings.InStr(Start, str4, ">");
                num11 = (int) Math.Round(Conversion.Val(Strings.Mid(str4, Start + 5, num13 - (Start + 5))));
                if (num11 > 0)
                {
                  string data3 = this.game.Data.StringListObj[stringListById7].GetData(0, num11, 1);
                  str2 = str2 + "• " + data3 + "\r\n";
                }
                str4 = str4.Replace("tech." + num11.ToString(), "used." + num11.ToString());
              }
              ++num12;
            }
            while (num12 <= 4);
          }
          if (str2.Length > 0)
            ttext = ttext + "\r\n\r\nYou need to have mastered the following Techs:\r\n" + str2;
          if (str1.Length > 0)
            ttext = ttext + "\r\n\r\nYou have the following Models:\r\n" + str1;
          int num14 = (int) Math.Round((double) (groupRect.Height - 19) / 3.0);
          int num15 = 28;
          Rectangle trect1;
          Rectangle trect2;
          if (simpleList2.Counter == -1)
          {
            if (groupRect.Width < 180)
            {
              DrawMod.DrawTextColouredMarcCenter(ref g, data1, this.game.MarcFont5, groupRect.X + (int) Math.Round((double) groupRect.Width / 2.0), groupRect.Y - 6 + (int) Math.Round((double) groupRect.Height / 2.0), c);
              trect1 = new Rectangle(groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height);
              trect2 = trect1;
              this.AddMouse(ref trect2, data1, ttext);
            }
            else
            {
              DrawMod.DrawTextColouredMarcCenter(ref g, data1, this.game.MarcFont4, groupRect.X + (int) Math.Round((double) groupRect.Width / 2.0), groupRect.Y - 9 + (int) Math.Round((double) groupRect.Height / 2.0), c);
              trect2 = new Rectangle(groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height);
              trect1 = trect2;
              this.AddMouse(ref trect1, data1, ttext);
            }
          }
          else if (groupRect.Width < 200)
          {
            DrawMod.DrawTextColouredMarcCenter(ref g, data1, this.game.MarcFont5, groupRect.X + (int) Math.Round((double) groupRect.Width / 2.0), groupRect.Y + 3, c);
            num15 = 18;
            trect2 = new Rectangle(groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height);
            trect1 = trect2;
            this.AddMouse(ref trect1, data1, ttext);
          }
          else
          {
            DrawMod.DrawTextColouredMarcCenter(ref g, data1, this.game.MarcFont4, groupRect.X + (int) Math.Round((double) groupRect.Width / 2.0), groupRect.Y + 5, c);
            trect2 = new Rectangle(groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height);
            trect1 = trect2;
            this.AddMouse(ref trect1, data1, ttext);
          }
          if (simpleList2.Counter > -1)
          {
            SizeF sizeF2 = groupRect.Width >= 180 ? g.MeasureString(num7.ToString() + "x", this.game.MarcFont3) : g.MeasureString(num7.ToString() + "x", this.game.MarcFont4);
            simpleList2.ReverseSort();
            int num16 = 1 + simpleList2.Counter;
            int num17 = groupRect.Height - num15;
            int index8 = 0;
            num11 = this.game.HandyFunctionsObj.GetSFTypeByID(simpleList2.Id[index8]);
            Bitmap objBitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(num11, false, cultureGroupId, this.game.Data.Turn, -1);
            float num18 = (float) objBitmap.Width / (float) objBitmap.Height;
            int h = num17;
            int w = (int) Math.Round((double) (num18 * (float) num17));
            int x = groupRect.X + (int) Math.Round((double) groupRect.Width / 2.0 - (double) w / 2.0) + (int) Math.Round((double) (sizeF2.Width / 2f));
            int y = groupRect.Y - 5 + num15;
            DrawMod.DrawScaled(ref g, ref objBitmap, x, y, w, h, true);
            objBitmap.Dispose();
            if (groupRect.Width < 180)
              DrawMod.DrawTextColouredMarcCenter(ref g, num7.ToString() + "x", this.game.MarcFont4, x - (int) Math.Round((double) (sizeF2.Width / 2f)), y + 1 + (int) Math.Round((double) h / 2.0) - (int) Math.Round((double) (sizeF2.Height / 2f)), c);
            else
              DrawMod.DrawTextColouredMarcCenter(ref g, num7.ToString() + "x", this.game.MarcFont3, x - (int) Math.Round((double) (sizeF2.Width / 2f)), y + 1 + (int) Math.Round((double) h / 2.0) - (int) Math.Round((double) (sizeF2.Height / 2f)), c);
          }
          DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref g, groupRect.X, groupRect.Y, groupRect.Width, groupRect.Height, -1, -1);
        }
        ++index6;
      }
      while (index6 <= 47);
      g.Dispose();
    }

    public Rectangle GetGroupRect(int tgroupX, int tgroupY)
    {
      int num1 = 50;
      int num2 = 104;
      int num3 = this.useHeight - 768;
      int num4 = (int) Math.Round(170.0 + Math.Floor((double) (this.useWidth - 1280) / 7.0));
      int num5 = (int) Math.Round(62.0 + Math.Floor((double) num3 / 12.0));
      int x = (tgroupX - 1) * num4 + num1;
      int y = (tgroupY - 1) * num5 + num2;
      int num6 = num4 - 8;
      int height = num5 - 18;
      int width = (int) Math.Round((double) num6 - Math.Floor((double) num3 / 24.0));
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
