// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.DynamicData
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class DynamicData
  {
    public DynamicDataElement[] element;
    public int elementCounter;

    public DynamicData(string datastring)
    {
      this.element = new DynamicDataElement[1000];
      string[] strArray1 = new string[1000];
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
            ++this.elementCounter;
            strArray1[this.elementCounter] = str;
            datastring = Strings.Left(datastring, num2 - 1) + "" + Strings.Mid(datastring, num3 + Strings.Len("[/element]"));
            num1 = 1;
          }
        }
      }
      int elementCounter1 = this.elementCounter;
      for (int index = 0; index <= elementCounter1; ++index)
      {
        datastring = strArray1[index];
        this.element[index] = new DynamicDataElement();
        int num4 = 0;
        do
        {
          int num5 = 1;
          string str1;
          if (num4 == 0)
            str1 = "type";
          if (num4 == 1)
            str1 = this.element[index].type != DynamicType.PageBreak ? "fontname" : "image";
          if (num4 == 2)
            str1 = "fontsize";
          if (num4 == 3)
            str1 = "fontstyle";
          if (num4 == 4)
            str1 = "lineheight";
          if (num4 == 5)
            str1 = "color";
          if (num4 == 6)
            str1 = "eventpic";
          if (num4 == 7)
            str1 = "portraitpic";
          if (num4 == 8)
            str1 = "text";
          if (num4 == 9)
            str1 = "x";
          if (num4 == 10)
            str1 = "y";
          if (num4 == 11)
            str1 = "w";
          if (num4 == 12)
            str1 = "h";
          if (num4 == 13)
            str1 = "z";
          if (num4 == 14)
            str1 = "pos";
          if (num4 == 15)
            str1 = "optiontitle";
          if (num4 == 16)
            str1 = "optiontext";
          if (num4 == 17)
            str1 = "optionpp";
          if (num4 == 18)
            str1 = "optionevent";
          if (num4 == 19)
            str1 = "center";
          if (num4 >= 20)
            str1 = "optiontempvar";
          while (num5 == 1)
          {
            num5 = 0;
            int num6 = Strings.InStr(datastring, "[" + str1 + "]");
            if (num6 > 0)
            {
              int num7 = Strings.InStr(datastring, "[/" + str1 + "]");
              if (num7 > num6 & num7 > 0)
              {
                string str2 = Strings.Mid(datastring, num6 + Strings.Len("[" + str1 + "]"), num7 - (num6 + Strings.Len("[" + str1 + "]")));
                if (num4 == 0)
                {
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(str2)), "text", false) == 0)
                    this.element[index].type = DynamicType.TextField;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(str2)), "picture", false) == 0)
                    this.element[index].type = DynamicType.PictureField;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(str2)), "option", false) == 0)
                    this.element[index].type = DynamicType.OptionField;
                  if (Operators.CompareString(Strings.Trim(Strings.LCase(str2)), "pagebreak", false) == 0)
                    this.element[index].type = DynamicType.PageBreak;
                }
                if (num4 == 1)
                {
                  if (this.element[index].type == DynamicType.PageBreak)
                    this.element[index].image = str2;
                  else
                    this.element[index].fontName = str2;
                }
                if (num4 == 2)
                  this.element[index].fontSize = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 3)
                  this.element[index].fontStyle = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 4)
                  this.element[index].lineHeight = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 5)
                {
                  try
                  {
                    string[] strArray2 = str2.Split(',');
                    if (strArray2.GetUpperBound(0) >= 3)
                    {
                      this.element[index].color = Color.FromArgb((int) Math.Round(Conversion.Val(strArray2[3])), (int) Math.Round(Conversion.Val(strArray2[0])), (int) Math.Round(Conversion.Val(strArray2[1])), (int) Math.Round(Conversion.Val(strArray2[2])));
                      if (strArray2.GetUpperBound(0) >= 2)
                        this.element[index].color = Color.FromArgb((int) byte.MaxValue, (int) Math.Round(Conversion.Val(strArray2[0])), (int) Math.Round(Conversion.Val(strArray2[1])), (int) Math.Round(Conversion.Val(strArray2[2])));
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    this.element[index].color = Color.FromArgb(0, 0, 0, (int) byte.MaxValue);
                    ProjectData.ClearProjectError();
                  }
                }
                if (num4 == 6)
                  this.element[index].eventPicture = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 7)
                  this.element[index].historicalUnitPortrait = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 8)
                  this.element[index].texty = str2;
                if (num4 == 9)
                  this.element[index].x = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 10)
                  this.element[index].y = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 11)
                  this.element[index].w = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 12)
                  this.element[index].h = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 13)
                  this.element[index].z = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 14)
                {
                  try
                  {
                    string[] strArray3 = str2.Split(',');
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
                  this.element[index].optiontitle = str2;
                if (num4 == 16)
                  this.element[index].optiontext = str2;
                if (num4 == 17)
                  this.element[index].optionpp = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 18)
                  this.element[index].optionevent = (int) Math.Round(Conversion.Val(str2));
                if (num4 == 19 && Operators.CompareString(str2, "1", false) == 0)
                  this.element[index].center = true;
                if (num4 >= 20)
                {
                  try
                  {
                    string[] strArray4 = str2.Split(',');
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
                datastring = Strings.Left(datastring, num6 - 1) + "" + Strings.Mid(datastring, num7 + Strings.Len("[/" + str1 + "]"));
                num5 = 1;
              }
            }
          }
          ++num4;
        }
        while (num4 <= 30);
      }
      int elementCounter2 = this.elementCounter;
      for (int index1 = 0; index1 <= elementCounter2; ++index1)
      {
        int num8 = index1;
        int num9 = this.elementCounter - 1;
        for (int index2 = num8; index2 <= num9; ++index2)
        {
          if (this.element[index2 + 1].z < this.element[index2].z)
          {
            DynamicDataElement dynamicDataElement = this.element[index2];
            this.element[index2] = this.element[index2 + 1];
            this.element[index2 + 1] = dynamicDataElement;
          }
        }
      }
      int elementCounter3 = this.elementCounter;
      for (int index = 0; index <= elementCounter3; ++index)
      {
        if (this.element[index].type == DynamicType.TextField && this.element[index].fontSize > 0 & this.element[index].lineHeight < 1)
          this.element[index].lineHeight = (int) Math.Round(1.2 * (double) this.element[index].fontSize);
      }
    }
  }
}
