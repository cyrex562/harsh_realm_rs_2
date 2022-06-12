// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.UDSData
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class UDSData
  {
    public UDSElement[] element;
    public int elementCounter;

    public UDSData(string datastring, bool allGray)
    {
      this.element = new UDSElement[1000];
      string[] strArray1 = new string[10000];
      this.elementCounter = -1;
      int num1 = 1;
      while (num1 == 1)
      {
        num1 = 0;
        int num2 = Strings.InStr(datastring, "[element]");
        if (num2 > 0)
        {
          int num3 = Strings.InStr(datastring, "[/element]");
          if (num3 > num2 & num3 > 0)
          {
            string str = Strings.Mid(datastring, num2 + Strings.Len("[element]"), num3 - (num2 + Strings.Len("[element]")));
            if (this.elementCounter < 999)
            {
              ++this.elementCounter;
              strArray1[this.elementCounter] = str;
            }
            datastring = Strings.Left(datastring, num2 - 1) + "" + Strings.Mid(datastring, num3 + Strings.Len("[/element]"));
            num1 = 1;
          }
        }
      }
      int elementCounter1 = this.elementCounter;
      for (int index = 0; index <= elementCounter1; ++index)
      {
        datastring = strArray1[index];
        this.element[index] = new UDSElement();
        int num4 = 0;
        do
        {
          int num5 = 1;
          string str;
          if (num4 == 0)
            str = "type";
          if (num4 == 1)
            str = this.element[index].type != UDSType.PageBreak ? "fontname" : "image";
          if (num4 == 2)
            str = "fontsize";
          if (num4 == 3)
            str = "fontstyle";
          if (num4 == 4)
            str = "lineheight";
          if (num4 == 5)
            str = "color";
          if (num4 == 6)
            str = "eventpic";
          if (num4 == 7)
            str = "portraitpic";
          if (num4 == 8)
            str = "text";
          if (num4 == 9)
            str = "x";
          if (num4 == 10)
            str = "y";
          if (num4 == 11)
            str = "w";
          if (num4 == 12)
            str = "h";
          if (num4 == 13)
            str = "z";
          if (num4 == 14)
            str = "pos";
          if (num4 == 15)
            str = "optiontitle";
          if (num4 == 16)
            str = "optiontext";
          if (num4 == 17)
            str = "optionpp";
          if (num4 == 18)
            str = "optionevent";
          if (num4 >= 19 & num4 <= 29)
            str = "optiontempvar";
          if (num4 == 30)
            str = "event";
          if (num4 == 31)
            str = "mouseover";
          if (num4 == 32)
            str = "key";
          if (num4 == 33)
            str = "value";
          if (num4 == 34)
            str = "grayed";
          if (num4 == 35)
            str = "group";
          if (num4 == 36)
            str = "flagged";
          if (num4 == 37)
            str = "smallgfx";
          if (num4 == 38)
            str = "minvalue";
          if (num4 == 39)
            str = "maxvalue";
          if (num4 == 40)
            str = "temppic";
          if (num4 == 41)
            str = "rotation";
          if (num4 == 42)
            str = "center";
          if (num4 == 43)
            str = "subtype";
          if (num4 == 44)
            str = "ox";
          if (num4 == 45)
            str = "oy";
          if (num4 == 46)
            str = "ow";
          if (num4 == 47)
            str = "oh";
          while (num5 == 1)
          {
            num5 = 0;
            int num6 = Strings.InStr(datastring, "[" + str + "]");
            if (num6 > 0)
            {
              int num7 = Strings.InStr(datastring, "[/" + str + "]");
              if (num7 > num6 & num7 > 0)
              {
                string InputStr = Strings.Mid(datastring, num6 + Strings.Len("[" + str + "]"), num7 - (num6 + Strings.Len("[" + str + "]")));
                if (num4 == 0)
                {
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "text", false) == 0)
                    this.element[index].type = UDSType.TextField;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "picture", false) == 0)
                    this.element[index].type = UDSType.PictureField;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "option", false) == 0)
                    this.element[index].type = UDSType.OptionField;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "pagebreak", false) == 0)
                    this.element[index].type = UDSType.PageBreak;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "button", false) == 0)
                    this.element[index].type = UDSType.Button;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "flag", false) == 0)
                    this.element[index].type = UDSType.Flag;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "hidden", false) == 0)
                    this.element[index].type = UDSType.Hidden;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "layout", false) == 0)
                    this.element[index].type = UDSType.Layout;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "slider", false) == 0)
                    this.element[index].type = UDSType.Slider;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "wav", false) == 0)
                    this.element[index].type = UDSType.Wav;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "table", false) == 0)
                    this.element[index].type = UDSType.Table;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "line", false) == 0)
                    this.element[index].type = UDSType.Line;
                }
                if (this.element[index].type == UDSType.Table & num4 == 12)
                  InputStr = ((int) Math.Round(Conversion.Val(InputStr)) - 40).ToString();
                if (num4 == 1)
                {
                  if (this.element[index].type == UDSType.PageBreak)
                    this.element[index].image = InputStr;
                  else
                    this.element[index].fontName = InputStr;
                }
                if (num4 == 2)
                  this.element[index].fontSize = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 3)
                  this.element[index].fontStyle = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 4)
                  this.element[index].lineHeight = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 5)
                {
                  try
                  {
                    string[] strArray2 = InputStr.Split(',');
                    if (strArray2.GetUpperBound(0) >= 3)
                      this.element[index].color = Color.FromArgb((int) Math.Round(Conversion.Val(strArray2[3])), (int) Math.Round(Conversion.Val(strArray2[0])), (int) Math.Round(Conversion.Val(strArray2[1])), (int) Math.Round(Conversion.Val(strArray2[2])));
                    else if (strArray2.GetUpperBound(0) >= 2)
                      this.element[index].color = Color.FromArgb((int) byte.MaxValue, (int) Math.Round(Conversion.Val(strArray2[0])), (int) Math.Round(Conversion.Val(strArray2[1])), (int) Math.Round(Conversion.Val(strArray2[2])));
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    this.element[index].color = Color.FromArgb(0, 0, 0, (int) byte.MaxValue);
                    ProjectData.ClearProjectError();
                  }
                }
                if (num4 == 6)
                  this.element[index].eventPicture = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 7)
                  this.element[index].historicalUnitPortrait = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 8)
                {
                  this.element[index].texty = InputStr;
                  if (this.element[index].type == UDSType.Button && Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "exit", false) == 0 | Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "cancel", false) == 0 | Operators.CompareString(Strings.Trim(Strings.LCase(InputStr)), "back", false) == 0)
                    this.element[index].hidden = true;
                }
                if (num4 == 9)
                  this.element[index].x = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 10)
                  this.element[index].y = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 11)
                  this.element[index].w = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 12)
                  this.element[index].h = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 13)
                  this.element[index].z = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 14)
                {
                  try
                  {
                    string[] strArray3 = InputStr.Split(',');
                    if (strArray3.GetUpperBound(0) >= 4)
                    {
                      this.element[index].x = (int) Math.Round(Conversion.Val(strArray3[0]));
                      this.element[index].y = (int) Math.Round(Conversion.Val(strArray3[1]));
                      this.element[index].w = (int) Math.Round(Conversion.Val(strArray3[2]));
                      this.element[index].h = (int) Math.Round(Conversion.Val(strArray3[3]));
                      this.element[index].z = (int) Math.Round(Conversion.Val(strArray3[4]));
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                  }
                }
                if (num4 == 15)
                  this.element[index].optiontitle = InputStr;
                if (num4 == 16)
                  this.element[index].optiontext = InputStr;
                if (num4 == 17)
                  this.element[index].optionpp = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 18)
                  this.element[index].optionevent = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 >= 19 & num4 <= 29)
                {
                  try
                  {
                    string[] strArray4 = InputStr.Split(',');
                    if (strArray4.GetUpperBound(0) >= 1)
                    {
                      this.element[index].optiontempvarOn[(int) Math.Round(Conversion.Val(strArray4[0]))] = true;
                      this.element[index].optiontempvar[(int) Math.Round(Conversion.Val(strArray4[0]))] = (int) Math.Round(Conversion.Val(strArray4[1]));
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                  }
                }
                if (num4 == 30)
                  this.element[index].eventNr = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 31)
                  this.element[index].mouseOver = InputStr;
                if (num4 == 32)
                  this.element[index].key = InputStr;
                if (num4 == 33)
                  this.element[index].value = InputStr;
                if (num4 == 34)
                  this.element[index].grayed = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 35)
                  this.element[index].group = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 36)
                  this.element[index].flagged = Conversion.Val(InputStr) == 1.0;
                if (num4 == 37)
                  this.element[index].smallgfx = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 38)
                  this.element[index].minvalue = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 39)
                  this.element[index].maxvalue = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 40)
                  this.element[index].tempPicture = InputStr;
                if (num4 == 41)
                  this.element[index].rotation = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 42)
                  this.element[index].center = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 43)
                  this.element[index].subtype = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 44)
                  this.element[index].ox = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 45)
                  this.element[index].oy = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 46)
                  this.element[index].ow = (int) Math.Round(Conversion.Val(InputStr));
                if (num4 == 47)
                  this.element[index].oh = (int) Math.Round(Conversion.Val(InputStr));
                datastring = Strings.Left(datastring, num6 - 1) + "" + Strings.Mid(datastring, num7 + Strings.Len("[/" + str + "]"));
                num5 = 1;
              }
            }
          }
          ++num4;
        }
        while (num4 <= 47);
      }
      int num8 = this.elementCounter - 1;
      for (int index1 = 0; index1 <= num8; ++index1)
      {
        if (this.element[index1].type == UDSType.Layout)
        {
          int num9 = index1 + 1;
          int elementCounter2 = this.elementCounter;
          for (int index2 = num9; index2 <= elementCounter2; ++index2)
          {
            if (this.element[index2].type != UDSType.Hidden & this.element[index2].type != UDSType.Layout)
            {
              UDSElement[] element1 = this.element;
              UDSElement[] udsElementArray1 = element1;
              int index3 = index2;
              int index4 = index3;
              udsElementArray1[index4].x = element1[index3].x + this.element[index1].w;
              UDSElement[] element2 = this.element;
              UDSElement[] udsElementArray2 = element2;
              int index5 = index2;
              int index6 = index5;
              udsElementArray2[index6].y = element2[index5].y + this.element[index1].h;
              if (this.element[index2].type == UDSType.Line)
              {
                UDSElement[] element3 = this.element;
                UDSElement[] udsElementArray3 = element3;
                int index7 = index2;
                int index8 = index7;
                udsElementArray3[index8].w = element3[index7].w + this.element[index1].w;
                UDSElement[] element4 = this.element;
                UDSElement[] udsElementArray4 = element4;
                int index9 = index2;
                int index10 = index9;
                udsElementArray4[index10].h = element4[index9].h + this.element[index1].h;
              }
            }
          }
        }
      }
      int elementCounter3 = this.elementCounter;
      for (int index11 = 0; index11 <= elementCounter3; ++index11)
      {
        int num10 = index11;
        int num11 = this.elementCounter - 1;
        for (int index12 = num10; index12 <= num11; ++index12)
        {
          if (this.element[index12 + 1].z < this.element[index12].z)
          {
            UDSElement udsElement = this.element[index12];
            this.element[index12] = this.element[index12 + 1];
            this.element[index12 + 1] = udsElement;
          }
        }
      }
      int elementCounter4 = this.elementCounter;
      for (int index = 0; index <= elementCounter4; ++index)
      {
        if (allGray)
          this.element[index].grayed = 1;
        if (this.element[index].type == UDSType.Slider && this.element[index].h < 1)
          this.element[index].h = 40;
        if (this.element[index].type == UDSType.PictureField)
        {
          if (this.element[index].eventPicture >= 2000000)
          {
            this.element[index].customBitmapFunction3 = this.element[index].eventPicture - 2000000;
            this.element[index].eventPicture = -1;
          }
          else if (this.element[index].eventPicture >= 1000000)
          {
            this.element[index].customBitmapFunction2 = this.element[index].eventPicture - 1000000;
            this.element[index].eventPicture = -1;
          }
          else if (this.element[index].eventPicture >= 100000)
          {
            this.element[index].customBitmapFunction = this.element[index].eventPicture - 100000;
            this.element[index].eventPicture = -1;
          }
          else if (this.element[index].eventPicture > 10000)
          {
            this.element[index].bitmapSlot = this.element[index].eventPicture - 10000;
            this.element[index].eventPicture = -1;
            if (this.element[index].w == 0 & this.element[index].h == 0)
            {
              this.element[index].w = BitmapStore.GetWidth(this.element[index].bitmapSlot);
              this.element[index].h = BitmapStore.Getheight(this.element[index].bitmapSlot);
            }
            else if (this.element[index].w == 0)
              this.element[index].w = (int) Math.Round((double) BitmapStore.GetWidth(this.element[index].bitmapSlot) * ((double) this.element[index].h / (double) BitmapStore.Getheight(this.element[index].bitmapSlot)));
            else if (this.element[index].h == 0)
              this.element[index].h = (int) Math.Round((double) BitmapStore.Getheight(this.element[index].bitmapSlot) * ((double) this.element[index].w / (double) BitmapStore.GetWidth(this.element[index].bitmapSlot)));
          }
          else if (this.element[index].eventPicture > -1)
          {
            if (this.element[index].w == 0 & this.element[index].h == 0)
            {
              this.element[index].w = BitmapStore.GetWidth(DrawMod.TGame.Data.EventPicNr[this.element[index].eventPicture]);
              this.element[index].h = BitmapStore.Getheight(DrawMod.TGame.Data.EventPicNr[this.element[index].eventPicture]);
            }
            else if (this.element[index].w == 0)
              this.element[index].w = (int) Math.Round((double) (BitmapStore.GetWidth(DrawMod.TGame.Data.EventPicNr[this.element[index].eventPicture]) * this.element[index].h) / (double) BitmapStore.Getheight(DrawMod.TGame.Data.EventPicNr[this.element[index].eventPicture]));
            else if (this.element[index].h == 0)
              this.element[index].h = (int) Math.Round((double) (BitmapStore.Getheight(DrawMod.TGame.Data.EventPicNr[this.element[index].eventPicture]) * this.element[index].w) / (double) BitmapStore.GetWidth(DrawMod.TGame.Data.EventPicNr[this.element[index].eventPicture]));
          }
        }
        if (this.element[index].type == UDSType.Flag && this.element[index].w == 0 & this.element[index].h == 0)
        {
          this.element[index].w = 35;
          this.element[index].h = 35;
        }
        if (this.element[index].type == UDSType.Table)
        {
          this.AddChildButtonForTable("<<", index, 1, this.element[index].x, this.element[index].y + this.element[index].h + 5, 50, 30);
          this.AddChildButtonForTable("<", index, 2, this.element[index].x + 60, this.element[index].y + this.element[index].h + 5, 50, 30);
          this.AddChildTextForTable("Page 1/" + this.GetTablePages(index).ToString(), index, 5, this.element[index].x + 120, this.element[index].y + this.element[index].h + 5, this.element[index].w - 240, 30);
          this.AddChildButtonForTable(">", index, 3, this.element[index].x + this.element[index].w - 110, this.element[index].y + this.element[index].h + 5, 50, 30);
          this.AddChildButtonForTable(">>", index, 4, this.element[index].x + this.element[index].w - 50, this.element[index].y + this.element[index].h + 5, 50, 30);
          this.element[index].rowsPerPage = this.GetRowsPerPage(index);
          this.element[index].topRow = 0;
          this.element[index].totalRows = this.GetTotalRows(index);
          index = index;
        }
      }
      int elementCounter5 = this.elementCounter;
      for (int index = 0; index <= elementCounter5; ++index)
      {
        if (this.element[index].type == UDSType.Slider & this.element[index].group > 0)
        {
          ++this.elementCounter;
          int elementCounter6 = this.elementCounter;
          this.element[elementCounter6] = new UDSElement();
          this.element[elementCounter6].type = UDSType.Flag;
          this.element[elementCounter6].key = "SysAutoLock_" + index.ToString();
          this.element[elementCounter6].value = Conversions.ToString(0);
          this.element[elementCounter6].group = 0;
          this.element[elementCounter6].x = this.element[index].x + this.element[index].w + 10;
          this.element[elementCounter6].y = this.element[index].y + 5;
          this.element[elementCounter6].w = 35;
          this.element[elementCounter6].h = 35;
          this.element[index].rotation = elementCounter6;
          this.element[elementCounter6].mouseOver = "Flag to lock the Slider";
        }
      }
    }

    public void AddChildButtonForTable(
      string texty,
      int tparentSlot,
      int tChildType,
      int tx,
      int ty,
      int tw,
      int th)
    {
      ++this.elementCounter;
      int elementCounter = this.elementCounter;
      this.element[elementCounter] = new UDSElement();
      this.element[elementCounter].type = UDSType.Button;
      this.element[elementCounter].x = tx;
      this.element[elementCounter].y = ty;
      this.element[elementCounter].w = tw;
      this.element[elementCounter].h = th;
      this.element[elementCounter].texty = texty;
      this.element[elementCounter].fontName = this.element[tparentSlot].fontName;
      this.element[elementCounter].fontStyle = this.element[tparentSlot].fontStyle;
      this.element[elementCounter].fontSize = this.element[tparentSlot].fontSize;
      this.element[elementCounter].parentElement = tparentSlot;
      this.element[elementCounter].childType = tChildType;
      this.element[elementCounter].childData = this.GetRowsPerPage(tparentSlot);
      if (tChildType == 1)
        this.element[elementCounter].grayed = 1;
      if (tChildType == 2)
        this.element[elementCounter].grayed = 1;
      if (tChildType == 3 && 0 > this.GetTotalRows(tparentSlot) - this.GetRowsPerPage(tparentSlot) - 1)
        this.element[elementCounter].grayed = 1;
      if (tChildType != 4 || 0 <= this.GetTotalRows(tparentSlot) - this.GetRowsPerPage(tparentSlot) - 1)
        return;
      this.element[elementCounter].grayed = 1;
    }

    public void AddChildTextForTable(
      string texty,
      int tparentSlot,
      int tChildType,
      int tx,
      int ty,
      int tw,
      int th)
    {
      ++this.elementCounter;
      int elementCounter = this.elementCounter;
      this.element[elementCounter] = new UDSElement();
      this.element[elementCounter].type = UDSType.TextField;
      this.element[elementCounter].x = tx;
      this.element[elementCounter].y = ty;
      this.element[elementCounter].w = tw;
      this.element[elementCounter].h = th;
      this.element[elementCounter].center = 1;
      this.element[elementCounter].texty = texty;
      this.element[elementCounter].fontName = this.element[tparentSlot].fontName;
      this.element[elementCounter].fontStyle = this.element[tparentSlot].fontStyle;
      this.element[elementCounter].fontSize = this.element[tparentSlot].fontSize;
      this.element[elementCounter].parentElement = tparentSlot;
      this.element[elementCounter].childType = tChildType;
      this.element[elementCounter].lineHeight = 24;
      this.element[elementCounter].color = Color.Black;
    }

    public int GetTablePages(int slot)
    {
      StringListClass stringListClass = DrawMod.TGame.Data.StringListObj[(int) Math.Round(Conversion.Val(this.element[slot].texty))];
      int num1 = stringListClass.Length + 1;
      int num2 = (int) Math.Round(Math.Floor((double) this.element[slot].h / (double) this.element[slot].lineHeight)) - 1;
      return (int) Math.Round(Math.Floor((double) Math.Max(0, stringListClass.Length - 1) / (double) num2)) + 1;
    }

    public int GetRowsPerPage(int slot)
    {
      int num = DrawMod.TGame.Data.StringListObj[(int) Math.Round(Conversion.Val(this.element[slot].texty))].Length + 1;
      return (int) Math.Round(Math.Floor((double) this.element[slot].h / (double) this.element[slot].lineHeight)) - 1;
    }

    public int GetTotalRows(int slot) => DrawMod.TGame.Data.StringListObj[(int) Math.Round(Conversion.Val(this.element[slot].texty))].Length + 1;
  }
}
