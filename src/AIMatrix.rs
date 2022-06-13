// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.AIMatrix
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;

namespace WindowsApplication1
{
  pub class AIMatrix
  {
    pub int[,] Value;
    pub Width: i32;
    pub Height: i32;
    pub Left: i32;
    pub Top: i32;
    pub DC2AIClass ai;

    pub AIMatrix()
    {
      this.Value = new int[1, 1];
      this.ai = (DC2AIClass) null;
      this.Width = DrawMod.TGame.Data.MapObj[0].MapWidth;
      this.Height = DrawMod.TGame.Data.MapObj[0].MapHeight;
      this.Top = 0;
      this.Left = 0;
      this.Value = new int[this.Width + 1, this.Height + 1];
    }

    pub AIMatrix(ref DC2AIClass tai)
    {
      this.Value = new int[1, 1];
      this.ai = tai;
      this.Width = tai.game.Data.MapObj[0].MapWidth;
      this.Height = tai.game.Data.MapObj[0].MapHeight;
      this.Top = 0;
      this.Left = 0;
      this.Value = new int[this.Width + 1, this.Height + 1];
    }

    pub AIMatrix(ref DC2AIClass tai, int twidth, int theight, int ttop, int tleft)
    {
      this.Value = new int[1, 1];
      this.ai = tai;
      this.Width = twidth;
      this.Height = theight;
      this.Left = tleft;
      this.Top = ttop;
      this.Value = new int[this.Width + 1, this.Height + 1];
    }

    pub AIMatrix Clone()
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
          aiMatrix.Value[index1, index2] = this.Value[index1, index2];
      }
      return aiMatrix;
    }

    pub void RemoveValuesByMask(AIMatrix mask, int SetValXToZero, int ignoreAbove = -1)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (mask.Value[index1, index2] == SetValXToZero && ignoreAbove == -1 | ignoreAbove > this.Value[index1, index2])
            this.Value[index1, index2] = 0;
        }
      }
    }

    pub void AddValueByMask(AIMatrix mask, int SetValXToY, int valueY)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (mask.Value[index1, index2] == SetValXToY)
            this.Value[index1, index2] = valueY;
        }
      }
    }

    pub void RemoveValuesBySuperFrontRule()
    {
      if (!this.ai.VAR_USE_SUPERFRONTS || this.ai.VAR_SUPERFRONT_HQLEVEL < 6)
        return;
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      SimpleList simpleList = SimpleList::new();
      int width1 = this.Width;
      for (int index1 = 0; index1 <= width1; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.ai.VAR_MATRIX_SUPERFRONT.Value[index1, index2] > 0)
          {
            int tid = this.ai.VAR_MATRIX_SUPERFRONT.Value[index1, index2];
            int nr = simpleList.FindNr(tid);
            if (nr > -1)
            {
              int[] weight = simpleList.Weight;
              int[] numArray = weight;
              int index3 = nr;
              int index4 = index3;
              int num = weight[index3] + 1;
              numArray[index4] = num;
            }
            else
              simpleList.Add(tid, 1);
          }
        }
      }
      int counter = simpleList.Counter;
      for (int index5 = 0; index5 <= counter; index5 += 1)
      {
        int width2 = this.Width;
        for (int index6 = 0; index6 <= width2; index6 += 1)
        {
          int height1 = this.Height;
          for (int index7 = 0; index7 <= height1; index7 += 1)
          {
            if (this.ai.VAR_MATRIX_SUPERFRONT.Value[index6, index7] == simpleList.Id[index5])
            {
              int num1 = this.Value[index6, index7];
              if (num1 > 0)
              {
                if (num1 == 32)
                  num1 = num1;
                int num2 = 0;
                int num3 = 0;
                int width3 = this.Width;
                for (int index8 = 0; index8 <= width3; index8 += 1)
                {
                  int height2 = this.Height;
                  for (int index9 = 0; index9 <= height2; index9 += 1)
                  {
                    if (this.Value[index8, index9] == num1)
                    {
                      if (this.ai.VAR_MATRIX_SUPERFRONT.Value[index8, index9] == simpleList.Id[index5])
                        num2 += 1;
                      else
                        num3 += 1;
                    }
                  }
                }
                if (num3 >= num2)
                {
                  int width4 = this.Width;
                  for (int index10 = 0; index10 <= width4; index10 += 1)
                  {
                    int height3 = this.Height;
                    for (int index11 = 0; index11 <= height3; index11 += 1)
                    {
                      if (this.Value[index10, index11] == num1 && this.ai.VAR_MATRIX_SUPERFRONT.Value[index10, index11] == simpleList.Id[index5])
                        this.Value[index10, index11] = 0;
                    }
                  }
                }
              }
            }
          }
        }
      }
    }

    pub void RemoveValuesByLandscapeAIBlock(int SetToVal)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[index1, index2].LandscapeType].AIBlock > 0)
            this.Value[index1, index2] = SetToVal;
        }
      }
    }

    pub void RemoveValuesByDoubleMask(
      AIMatrix mask,
      int SetValXToZero,
      AIMatrix mask2,
      int SetValXToZero2)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (mask.Value[index1, index2] == SetValXToZero && mask2.Value[index1, index2] == SetValXToZero2)
            this.Value[index1, index2] = 0;
        }
      }
    }

    pub int ReturnHighestValueInMatrix()
    {
      int num = -99999;
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] > num)
            num = this.Value[index1, index2];
        }
      }
      return num;
    }

    pub void RemoveValuesByNotMask(AIMatrix mask, int SetNotValXToZero)
    {
      if (this.ai.game.Data.MapObj[0].MapLoop)
      {
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            int realX = this.ai.GetRealX(tx, this.Left);
            int num = index1 + this.Top;
            int matrixX = this.ai.GetMatrixX(realX, mask.Left);
            int index2 = num - mask.Top;
            if (mask.Value[matrixX, index2] != SetNotValXToZero)
              this.Value[tx, index1] = 0;
          }
        }
      }
      else
      {
        int num1 = this.Left - mask.Left;
        int num2 = this.Top - mask.Top;
        int width = this.Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int height = this.Height;
          for (int index4 = 0; index4 <= height; index4 += 1)
          {
            if (mask.Value[index3 + num1, index4 + num2] != SetNotValXToZero)
              this.Value[index3, index4] = 0;
          }
        }
      }
    }

    pub void MultiplyAllValues(int number)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
          this.Value[index1, index2] = this.Value[index1, index2] * number;
      }
    }

    pub void DiminishAllPositiveValues(int number)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] > 0)
            this.Value[index1, index2] = Math.Max(0, this.Value[index1, index2] - number);
        }
      }
    }

    pub void SetAllValuesTo(int number)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
          this.Value[index1, index2] = number;
      }
    }

    pub void SetAllValuesToWithMask(int number, ref AIMatrix mask, int ifMaskValue)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (mask.Value[index1, index2] == ifMaskValue)
            this.Value[index1, index2] = number;
        }
      }
    }

    pub void SetAllValuesSubtractWith(int number)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          int[,] numArray1 = this.Value;
          int[,] numArray2 = numArray1;
          int index3 = index1;
          int index4 = index3;
          int index5 = index2;
          int index6 = index5;
          int num = numArray1[index3, index5] - number;
          numArray2[index4, index6] = num;
        }
      }
    }

    pub void SwitchValues(int number1, int number2)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] == number1)
            this.Value[index1, index2] = number2;
          else if (this.Value[index1, index2] == number2)
            this.Value[index1, index2] = number1;
        }
      }
    }

    pub void SetValueXToValueY(int number1, int number2)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] == number1)
            this.Value[index1, index2] = number2;
        }
      }
    }

    pub void SetAllValuesNotValueXTo(int number, int NotValueX)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] != NotValueX)
            this.Value[index1, index2] = number;
        }
      }
    }

    pub void RemoveUnconnectedHex(AIMatrix frontlines)
    {
      int width = frontlines.Width;
      int height = frontlines.Height;
      int num1 = width;
      int num2;
      for (int index1 = 0; index1 <= num1; index1 += 1)
      {
        int num3 = height;
        for (int index2 = 0; index2 <= num3; index2 += 1)
        {
          if (this.Value[index1, index2] > num2 & frontlines.Value[index1, index2] > 0)
            num2 = this.Value[index1, index2];
        }
      }
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai, width, height, 0, 0);
      int[] numArray = new int[num2 + 1];
      int num4 = width;
      for (int index3 = 0; index3 <= num4; index3 += 1)
      {
        int num5 = height;
        for (int index4 = 0; index4 <= num5; index4 += 1)
        {
          if (this.Value[index3, index4] > 0 & frontlines.Value[index3, index4] > 0 && !this.ai.game.Data.LandscapeTypeObj[this.ai.game.Data.MapObj[0].HexObj[index3, index4].LandscapeType].IsSea)
          {
            AIMatrix aiMatrix2 = new AIMatrix(ref this.ai, width, height, 0, 0);
            aiMatrix2.Value[index3, index4] = 1;
            bool flag = true;
            int num6 = 0;
            if (index3 == 31 & index4 == 14)
              index3 = index3;
            while (flag)
            {
              flag = false;
              num6 += 1;
              int num7 = width;
              for (int cx = 0; cx <= num7; cx += 1)
              {
                int num8 = height;
                for (int cy = 0; cy <= num8; cy += 1)
                {
                  if (aiMatrix2.Value[cx, cy] == num6)
                  {
                    int tfacing = 1;
                    do
                    {
                      Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                      if (coordinate.onmap && aiMatrix2.Value[coordinate.x, coordinate.y] == 0 & !this.ai.game.Data.LandscapeTypeObj[this.ai.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].LandscapeType].IsSea && frontlines.Value[coordinate.x, coordinate.y] > 0 & this.Value[coordinate.x, coordinate.y] == this.Value[index3, index4])
                      {
                        aiMatrix2.Value[coordinate.x, coordinate.y] = num6 + 1;
                        flag = true;
                      }
                      tfacing += 1;
                    }
                    while (tfacing <= 6);
                  }
                }
              }
            }
            int num9 = 0;
            int num10 = width;
            for (int index5 = 0; index5 <= num10; index5 += 1)
            {
              int num11 = height;
              for (int index6 = 0; index6 <= num11; index6 += 1)
              {
                if (aiMatrix2.Value[index5, index6] > 0)
                  num9 += 1;
              }
            }
            aiMatrix1.Value[index3, index4] = num9;
            if (num9 > numArray[this.Value[index3, index4]])
              numArray[this.Value[index3, index4]] = num9;
          }
        }
      }
      int num12 = width;
      for (int index7 = 0; index7 <= num12; index7 += 1)
      {
        int num13 = height;
        for (int index8 = 0; index8 <= num13; index8 += 1)
        {
          if (this.Value[index7, index8] > 0 & frontlines.Value[index7, index8] > 0 && aiMatrix1.Value[index7, index8] < numArray[this.Value[index7, index8]])
            this.Value[index7, index8] = 0;
        }
      }
    }

    pub void CopyValuesFrom(AIMatrix mat)
    {
      if (this.ai.game.Data.MapObj[0].MapLoop)
      {
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            int realX = this.ai.GetRealX(tx, this.Left);
            int num = index1 + this.Top;
            int matrixX = this.ai.GetMatrixX(realX, mat.Left);
            int index2 = num - mat.Top;
            this.Value[tx, index1] = mat.Value[matrixX, index2];
          }
        }
      }
      else
      {
        int num1 = this.Left - mat.Left;
        int num2 = this.Top - mat.Top;
        int width = this.Width;
        for (int index3 = 0; index3 <= width; index3 += 1)
        {
          int height = this.Height;
          for (int index4 = 0; index4 <= height; index4 += 1)
            this.Value[index3, index4] = mat.Value[index3 + num1, index4 + num2];
        }
      }
    }

    pub void SetAllValuesHigherThenXTo(int higherthen, int number)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] > higherthen)
            this.Value[index1, index2] = number;
        }
      }
    }

    pub void RemoveValueByPercentage(AIMatrix mult, int maxPercentRemove = 100)
    {
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          int[,] numArray1 = this.Value;
          int[,] numArray2 = numArray1;
          int index3 = index1;
          int index4 = index3;
          int index5 = index2;
          int index6 = index5;
          int num = numArray1[index3, index5] - (int) Math.Round((double) (this.Value[index1, index2] * Math.Min(maxPercentRemove, mult.Value[index1, index2])) / 100.0);
          numArray2[index4, index6] = num;
        }
      }
    }

    pub void AddValueByPercentage(AIMatrix mult, AIMatrix mult2, int divideBy = 10)
    {
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          int[,] numArray1 = this.Value;
          int[,] numArray2 = numArray1;
          int index3 = index1;
          int index4 = index3;
          int index5 = index2;
          int index6 = index5;
          int num = numArray1[index3, index5] + (int) Math.Round((double) (this.Value[index1, index2] * (mult.Value[index1, index2] + mult2.Value[index1, index2])) / 100.0);
          numArray2[index4, index6] = num;
        }
      }
    }

    pub void AddValue(AIMatrix addvalue, int multiply)
    {
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          int[,] numArray1 = this.Value;
          int[,] numArray2 = numArray1;
          int index3 = index1;
          int index4 = index3;
          int index5 = index2;
          int index6 = index5;
          int num = numArray1[index3, index5] + addvalue.Value[index1, index2] * multiply;
          numArray2[index4, index6] = num;
        }
      }
    }

    pub void AddValue(int addvalue)
    {
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          int[,] numArray1 = this.Value;
          int[,] numArray2 = numArray1;
          int index3 = index1;
          int index4 = index3;
          int index5 = index2;
          int index6 = index5;
          int num = numArray1[index3, index5] + addvalue;
          numArray2[index4, index6] = num;
        }
      }
    }

    pub void CopyToAreaSlot(ref DataClass data, int slot)
    {
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
          data.MapObj[0].HexObj[index1, index2].AreaCode[slot] = this.Value[index1, index2];
      }
    }

    pub void Percentify()
    {
      int width1 = this.Width;
      int num;
      for (int index1 = 0; index1 <= width1; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] > num)
            num = this.Value[index1, index2];
        }
      }
      int width2 = this.Width;
      for (int index3 = 0; index3 <= width2; index3 += 1)
      {
        int height = this.Height;
        for (int index4 = 0; index4 <= height; index4 += 1)
          this.Value[index3, index4] = this.Value[index3, index4] <= 0 ? 0 : (int) Math.Round((double) (100 * this.Value[index3, index4]) / (double) num);
      }
    }

    pub void RemoveSmallestEnclaves()
    {
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      AIMatrix aiMatrix2 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      AIMatrix ownerMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width1 = this.Width;
      int num1;
      for (int tx = 0; tx <= width1; tx += 1)
      {
        int height = this.Height;
        for (int index = 0; index <= height; index += 1)
        {
          ownerMatrix.Value[tx, index] = this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index + this.Top].Regime != -1 ? (this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index + this.Top].Regime != this.ai.GetGameDataTurn() ? 2 : 1) : 0;
          if (this.Value[tx, index] > num1)
            num1 = this.Value[tx, index];
        }
      }
      int[] numArray = new int[num1 + 1];
      int width2 = this.Width;
      int num2;
      for (int tx = 0; tx <= width2; tx += 1)
      {
        int height1 = this.Height;
        for (int index1 = 0; index1 <= height1; index1 += 1)
        {
          if (ownerMatrix.Value[tx, index1] == 1 & this.Value[tx, index1] > 0 & this.Value[tx, index1] < 1000000 & aiMatrix1.Value[tx, index1] == 0 && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock == 0)
          {
            aiMatrix1.Value[tx, index1] = 1;
            int MustHaveID = this.Value[tx, index1];
            num2 = 10;
            bool flag;
            if (!flag)
            {
              flag = true;
              num2 += 1;
            }
            AIMatrix aiMatrix3 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
            aiMatrix3.SetAllValuesTo(9999);
            aiMatrix3.Value[tx, index1] = 0;
            aiMatrix3.ExpandAsSimplifiedSupplyRouteMatrixByID(this.ai.VAR_SUPPLY_FRIENDLY_MOVETYPE, ref ownerMatrix, 1, MustHaveID, this);
            int width3 = this.Width;
            for (int index2 = 0; index2 <= width3; index2 += 1)
            {
              int height2 = this.Height;
              for (int index3 = 0; index3 <= height2; index3 += 1)
              {
                if (aiMatrix3.Value[index2, index3] < 9999 && aiMatrix1.Value[index2, index3] == 0 && this.Value[index2, index3] == MustHaveID)
                {
                  aiMatrix1.Value[index2, index3] = 1;
                  num2 += 10;
                }
              }
            }
            if (num2 > numArray[MustHaveID])
              numArray[MustHaveID] = num2;
            int width4 = this.Width;
            for (int index4 = 0; index4 <= width4; index4 += 1)
            {
              int height3 = this.Height;
              for (int index5 = 0; index5 <= height3; index5 += 1)
              {
                if (aiMatrix3.Value[index4, index5] < 9999 && this.Value[index4, index5] == MustHaveID & aiMatrix2.Value[index4, index5] < num2)
                  aiMatrix2.Value[index4, index5] = num2;
              }
            }
          }
        }
      }
      int width5 = this.Width;
      for (int tx = 0; tx <= width5; tx += 1)
      {
        int height = this.Height;
        for (int index6 = 0; index6 <= height; index6 += 1)
        {
          if (this.Value[tx, index6] > 0 & this.Value[tx, index6] < 1000000 && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index6 + this.Top].LandscapeType].AIBlock == 0)
          {
            int index7 = this.Value[tx, index6];
            if (index7 == 567)
              num2 = num2;
            if (numArray[index7] > aiMatrix2.Value[tx, index6])
              this.Value[tx, index6] = 0;
          }
        }
      }
    }

    pub void RemoveSmallestRegularFronts()
    {
      SimpleList simpleList = SimpleList::new();
      int width1 = this.Width;
      for (int index1 = 0; index1 <= width1; index1 += 1)
      {
        int height1 = this.Height;
        for (int index2 = 0; index2 <= height1; index2 += 1)
        {
          if (this.Value[index1, index2] > 0 & this.Value[index1, index2] < 1000000 && simpleList.FindNr(this.Value[index1, index2]) < 0)
          {
            int tweight = 0;
            int width2 = this.Width;
            for (int index3 = 0; index3 <= width2; index3 += 1)
            {
              int height2 = this.Height;
              for (int index4 = 0; index4 <= height2; index4 += 1)
              {
                if (this.Value[index3, index4] == this.Value[index1, index2])
                {
                  tweight += 1;
                  if (this.ai.game.Data.Product >= 6 && this.ai.game.Data.MapObj[0].HexObj[index3, index4].VP > 0)
                  {
                    int d = this.ai.game.Data.MapObj[0].HexObj[index3, index4].VP + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[index3, index4];
                    tweight += (int) Math.Round(Math.Sqrt((double) d));
                  }
                }
              }
            }
            simpleList.Add(this.Value[index1, index2], tweight);
          }
        }
      }
      int num1 = (int) Math.Round((double) (this.ai.VAR_FRONTLINE_MAX_LENGTH * this.ai.VAR_FRONTLINE_DEPTH) / 2.0);
      int counter = simpleList.Counter;
      for (int index5 = 0; index5 <= counter; index5 += 1)
      {
        if (simpleList.Weight[index5] < num1)
        {
          int num2 = 0;
          int width3 = this.Width;
          for (int cx = 0; cx <= width3; cx += 1)
          {
            int height = this.Height;
            for (int cy = 0; cy <= height; cy += 1)
            {
              if (this.Value[cx, cy] == simpleList.Id[index5])
              {
                int tfacing = 1;
                do
                {
                  Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate.onmap)
                  {
                    int tid = this.Value[coordinate.x, coordinate.y];
                    if (tid > 0)
                    {
                      int nr = simpleList.FindNr(tid);
                      if (nr > -1 & simpleList.Id[index5] != tid && simpleList.Weight[nr] >= num1 & tid < 100000)
                        num2 += 1;
                    }
                  }
                  tfacing += 1;
                }
                while (tfacing <= 6);
              }
            }
          }
          if (num2 >= 1)
          {
            int width4 = this.Width;
            for (int index6 = 0; index6 <= width4; index6 += 1)
            {
              int height = this.Height;
              for (int index7 = 0; index7 <= height; index7 += 1)
              {
                if (this.Value[index6, index7] == simpleList.Id[index5])
                  this.Value[index6, index7] = 0;
              }
            }
          }
        }
      }
    }

    pub RemoveSmallestRegularFrontsAroundEncircledEnemy: bool(
      ref AIMatrix tOwner,
      ref AIMatrix tEnemySupply)
    {
      bool flag = false;
      AIMatrix aiMatrix = new AIMatrix(ref this.ai);
      AIMatrix mask = new AIMatrix(ref this.ai);
      int width1 = this.Width;
      for (int index1 = 0; index1 <= width1; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          mask.Value[index1, index2] = 0;
          if (tEnemySupply.Value[index1, index2] >= 999 & tOwner.Value[index1, index2] == 2)
            mask.Value[index1, index2] = 1;
        }
      }
      int width2 = this.Width;
      for (int index3 = 0; index3 <= width2; index3 += 1)
      {
        int height = this.Height;
        for (int index4 = 0; index4 <= height; index4 += 1)
        {
          if (tOwner.Value[index3, index4] == 2 && tEnemySupply.Value[index3, index4] >= 999 & aiMatrix.Value[index3, index4] == 0)
          {
            int specificVal;
            specificVal += 1;
            aiMatrix.Value[index3, index4] = specificVal;
            aiMatrix.ExpandSpecificValueForSameRegimeWithinMask(specificVal, 12, ref mask);
          }
        }
      }
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      int width3 = this.Width;
      Coordinate coordinate1;
      for (int index5 = 0; index5 <= width3; index5 += 1)
      {
        int height1 = this.Height;
        for (int index6 = 0; index6 <= height1; index6 += 1)
        {
          if (this.Value[index5, index6] > 0 & this.Value[index5, index6] < 1000000 && simpleList1.FindNr(this.Value[index5, index6]) < 0)
          {
            int num1 = this.Value[index5, index6];
            int num2 = 0;
            SimpleList simpleList3 = SimpleList::new();
            int num3 = 0;
            int width4 = this.Width;
            for (int cx = 0; cx <= width4; cx += 1)
            {
              int height2 = this.Height;
              for (int cy = 0; cy <= height2; cy += 1)
              {
                if (this.Value[cx, cy] == this.Value[index5, index6])
                {
                  int tfacing = 1;
                  do
                  {
                    coordinate1 = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                    if (coordinate1.onmap && tOwner.Value[coordinate1.x, coordinate1.y] == 2)
                    {
                      if (aiMatrix.Value[coordinate1.x, coordinate1.y] > 0)
                      {
                        num2 += 1;
                        simpleList3.AddWeight(aiMatrix.Value[coordinate1.x, coordinate1.y], 1);
                      }
                      else
                        num3 += 1;
                    }
                    tfacing += 1;
                  }
                  while (tfacing <= 6);
                }
              }
            }
            if (!(num2 > 0 & num3 == 0) && num2 > 0 & num3 > 0)
              simpleList1.AddWeight(num1, 1);
            int counter = simpleList3.Counter;
            for (int index7 = 0; index7 <= counter; index7 += 1)
            {
              if (simpleList2.FindNr(simpleList3.Id[index7], num1) == -1)
                simpleList2.AddWeight(simpleList3.Id[index7], 1, num1, CheckExistence: false);
            }
          }
        }
      }
      int counter1 = simpleList1.Counter;
      for (int index8 = 0; index8 <= counter1; index8 += 1)
      {
        int num4 = simpleList1.Id[index8];
        int counter2 = simpleList2.Counter;
        for (int index9 = 0; index9 <= counter2; index9 += 1)
        {
          int num5 = simpleList2.Data1[index9];
          if (num4 == num5)
          {
            SimpleList simpleList4 = SimpleList::new();
            int counter3 = simpleList2.Counter;
            for (int index10 = 0; index10 <= counter3; index10 += 1)
            {
              if (simpleList2.Data1[index10] != num4)
              {
                int tid = simpleList2.Data1[index10];
                if (simpleList1.FindNr(tid) == -1)
                  simpleList4.AddWeight(tid, 1);
              }
            }
            if (simpleList4.Counter > -1)
            {
              int num6 = 0;
              do
              {
                bool[,] flagArray = new bool[this.Width + 1, this.Height + 1];
                int width5 = this.Width;
                for (int index11 = 0; index11 <= width5; index11 += 1)
                {
                  int height = this.Height;
                  for (int index12 = 0; index12 <= height; index12 += 1)
                    flagArray[index11, index12] = false;
                }
                int num7 = 0;
                int width6 = this.Width;
                for (int cx = 0; cx <= width6; cx += 1)
                {
                  int height = this.Height;
                  for (int cy = 0; cy <= height; cy += 1)
                  {
                    if (num4 == this.Value[cx, cy])
                    {
                      int num8 = 0;
                      int tfacing1 = 1;
                      do
                      {
                        coordinate1 = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing1);
                        if (coordinate1.onmap && tOwner.Value[coordinate1.x, coordinate1.y] == 2 && aiMatrix.Value[coordinate1.x, coordinate1.y] > 0)
                          num8 = 1;
                        tfacing1 += 1;
                      }
                      while (tfacing1 <= 6);
                      if (num8 == 1)
                      {
                        int tfacing2 = 1;
                        do
                        {
                          coordinate1 = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing2);
                          if (coordinate1.onmap && tOwner.Value[coordinate1.x, coordinate1.y] == 1 && this.Value[coordinate1.x, coordinate1.y] > 0 & this.Value[coordinate1.x, coordinate1.y] != num4 && simpleList1.FindNr(this.Value[coordinate1.x, coordinate1.y]) == -1 && simpleList2.FindData(this.Value[coordinate1.x, coordinate1.y], 1) > -1 & !flagArray[coordinate1.x, coordinate1.y])
                          {
                            flagArray[cx, cy] = true;
                            this.Value[cx, cy] = this.Value[coordinate1.x, coordinate1.y];
                            num7 = 1;
                            flag = true;
                          }
                          tfacing2 += 1;
                        }
                        while (tfacing2 <= 6);
                      }
                    }
                  }
                }
                if (num7 == 0)
                  num6 = 99;
                num6 += 1;
              }
              while (num6 <= 20);
              break;
            }
            break;
          }
        }
      }
      SimpleList simpleList5 = SimpleList::new();
      int width7 = this.Width;
      Coordinate coordinate2;
      for (int index13 = 0; index13 <= width7; index13 += 1)
      {
        int height3 = this.Height;
        for (int index14 = 0; index14 <= height3; index14 += 1)
        {
          if (this.Value[index13, index14] > 0 & this.Value[index13, index14] < 1000000 && simpleList5.FindNr(this.Value[index13, index14]) < 0)
          {
            int tweight = 0;
            int num9 = 0;
            int num10 = 0;
            int width8 = this.Width;
            for (int cx = 0; cx <= width8; cx += 1)
            {
              int height4 = this.Height;
              for (int cy = 0; cy <= height4; cy += 1)
              {
                if (this.Value[cx, cy] == this.Value[index13, index14])
                {
                  int num11 = 0;
                  int tfacing = 1;
                  do
                  {
                    coordinate2 = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                    if (coordinate2.onmap && tOwner.Value[coordinate2.x, coordinate2.y] == 2)
                    {
                      num9 += 1;
                      if (tEnemySupply.Value[coordinate2.x, coordinate2.y] >= 999)
                        num10 += 1;
                    }
                    tfacing += 1;
                  }
                  while (tfacing <= 6);
                  int num12 = num11 + 1;
                  if (this.ai.game.Data.Product >= 6 && this.ai.game.Data.MapObj[0].HexObj[cx, cy].VP > 0)
                  {
                    int d = this.ai.game.Data.MapObj[0].HexObj[cx, cy].VP + this.ai.game.Data.RegimeObj[this.ai.game.Data.Turn].AIVP[0].Value[cx, cy];
                    num12 += (int) Math.Round(Math.Sqrt((double) d));
                  }
                  tweight += num12;
                }
              }
            }
            if (num9 > 0 & num10 > 0)
              tweight = (int) Math.Round((double) tweight * 0.1 + (double) (int) Math.Round((double) tweight * 0.9 * (double) (num9 - num10) / (double) num9));
            if ((double) num10 <= (double) num9 * 0.75)
              tweight *= 3;
            simpleList5.Add(this.Value[index13, index14], tweight);
          }
        }
      }
      int num13 = (int) Math.Round((double) (this.ai.VAR_FRONTLINE_MAX_LENGTH * this.ai.VAR_FRONTLINE_DEPTH) / 2.0);
      int counter4 = simpleList5.Counter;
      for (int index15 = 0; index15 <= counter4; index15 += 1)
      {
        if (simpleList5.Weight[index15] < num13)
        {
          int num14 = 0;
          int width9 = this.Width;
          for (int cx = 0; cx <= width9; cx += 1)
          {
            int height = this.Height;
            for (int cy = 0; cy <= height; cy += 1)
            {
              if (this.Value[cx, cy] == simpleList5.Id[index15])
              {
                int tfacing = 1;
                do
                {
                  coordinate2 = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                  if (coordinate2.onmap)
                  {
                    int tid = this.Value[coordinate2.x, coordinate2.y];
                    if (tid > 0)
                    {
                      int nr = simpleList5.FindNr(tid);
                      if (nr > -1 & simpleList5.Id[index15] != tid && simpleList5.Weight[nr] >= simpleList5.Weight[index15] & simpleList5.Weight[nr] < num13 & tid < 100000)
                        num14 += 1;
                    }
                  }
                  tfacing += 1;
                }
                while (tfacing <= 6);
              }
            }
          }
          if (num14 >= 1)
          {
            flag = true;
            int width10 = this.Width;
            for (int index16 = 0; index16 <= width10; index16 += 1)
            {
              int height = this.Height;
              for (int index17 = 0; index17 <= height; index17 += 1)
              {
                if (this.Value[index16, index17] == simpleList5.Id[index15])
                  this.Value[index16, index17] = 0;
              }
            }
          }
        }
      }
      int num15 = 0;
      do
      {
        bool[,] flagArray = new bool[this.Width + 1, this.Height + 1];
        int width11 = this.Width;
        for (int index18 = 0; index18 <= width11; index18 += 1)
        {
          int height = this.Height;
          for (int index19 = 0; index19 <= height; index19 += 1)
            flagArray[index18, index19] = false;
        }
        int num16 = 0;
        int width12 = this.Width;
        for (int cx = 0; cx <= width12; cx += 1)
        {
          int height = this.Height;
          for (int cy = 0; cy <= height; cy += 1)
          {
            if (aiMatrix.Value[cx, cy] > 0)
            {
              int num17 = 0;
              int tfacing3 = 1;
              do
              {
                coordinate1 = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing3);
                if (coordinate1.onmap && tOwner.Value[coordinate1.x, coordinate1.y] == 1 && this.Value[coordinate1.x, coordinate1.y] < 1)
                {
                  num17 = 1;
                  break;
                }
                tfacing3 += 1;
              }
              while (tfacing3 <= 6);
              if (num17 == 1)
              {
                int tfacing4 = 1;
                do
                {
                  Coordinate coordinate3 = this.ai.game.HandyFunctionsObj.HexNeighbour(coordinate1.x, coordinate1.y, 0, tfacing4);
                  if (coordinate3.onmap && tOwner.Value[coordinate3.x, coordinate3.y] == 1 && this.Value[coordinate3.x, coordinate3.y] > 0 & this.Value[coordinate1.x, coordinate1.y] == 0 && simpleList1.FindNr(this.Value[coordinate3.x, coordinate3.y]) == -1 && simpleList2.FindData(this.Value[coordinate3.x, coordinate3.y], 1) > -1 & !flagArray[coordinate3.x, coordinate3.y])
                  {
                    flagArray[coordinate1.x, coordinate1.y] = true;
                    this.Value[coordinate1.x, coordinate1.y] = this.Value[coordinate3.x, coordinate3.y];
                    num16 = 1;
                    flag = true;
                    break;
                  }
                  tfacing4 += 1;
                }
                while (tfacing4 <= 6);
              }
            }
          }
        }
        if (num16 == 0)
          num15 = 99;
        num15 += 1;
      }
      while (num15 <= 20);
      return flag;
    }

    pub void RemoveExposedNonNeccFronts()
    {
      SimpleList simpleList1 = SimpleList::new();
      int width1 = this.Width;
      for (int index1 = 0; index1 <= width1; index1 += 1)
      {
        int height1 = this.Height;
        for (int index2 = 0; index2 <= height1; index2 += 1)
        {
          if (this.Value[index1, index2] > 0 & this.Value[index1, index2] < 1000000 && simpleList1.FindNr(this.Value[index1, index2]) < 0)
          {
            int tweight = 0;
            int width2 = this.Width;
            for (int index3 = 0; index3 <= width2; index3 += 1)
            {
              int height2 = this.Height;
              for (int index4 = 0; index4 <= height2; index4 += 1)
              {
                if (this.Value[index3, index4] == this.Value[index1, index2])
                  tweight += 1;
              }
            }
            simpleList1.Add(this.Value[index1, index2], tweight);
          }
        }
      }
      int frontlineMaxLength = this.ai.VAR_FRONTLINE_MAX_LENGTH;
      int counter = simpleList1.Counter;
      for (int index5 = 0; index5 <= counter; index5 += 1)
      {
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        int num5 = 9999;
        SimpleList simpleList2 = SimpleList::new();
        int width3 = this.Width;
        for (int cx = 0; cx <= width3; cx += 1)
        {
          int height = this.Height;
          for (int cy = 0; cy <= height; cy += 1)
          {
            if (this.Value[cx, cy] == simpleList1.Id[index5])
            {
              num3 += 1;
              num4 += this.ai.VAR_MATRIX_RETREAT.Value[cx, cy];
              if (this.ai.VAR_MATRIX_RETREAT.Value[cx, cy] < num5)
                num5 = this.ai.VAR_MATRIX_RETREAT.Value[cx, cy];
              int tfacing = 1;
              do
              {
                Coordinate coordinate = this.ai.game.HandyFunctionsObj.HexNeighbour(cx, cy, 0, tfacing);
                if (coordinate.onmap)
                {
                  int tid = this.Value[coordinate.x, coordinate.y];
                  if (tid > 0)
                  {
                    num1 += 1;
                    if (simpleList2.FindNr(tid) > -1)
                    {
                      int[] weight = simpleList2.Weight;
                      int[] numArray = weight;
                      int nr = simpleList2.FindNr(tid);
                      int index6 = nr;
                      int num6 = weight[nr] + 1;
                      numArray[index6] = num6;
                    }
                    else
                      simpleList2.Add(tid, 1);
                  }
                  else if (tid <= 0 && this.ai.game.Data.MapObj[0].HexObj[coordinate.x, coordinate.y].Regime == this.ai.game.Data.Turn)
                    num2 += 1;
                }
                tfacing += 1;
              }
              while (tfacing <= 6);
            }
          }
        }
        int num7 = num3 <= 0 ? 100 : (int) Math.Round((double) num4 / (double) num3);
        if (simpleList1.Weight[index5] < frontlineMaxLength | num7 >= 200 && num1 >= 1 & num2 <= 0 && num5 > 50)
        {
          int num8 = 0;
          if (simpleList2.Counter > -1)
          {
            simpleList2.ReverseSort();
            num8 = simpleList2.Id[0];
          }
          int width4 = this.Width;
          for (int index7 = 0; index7 <= width4; index7 += 1)
          {
            int height = this.Height;
            for (int index8 = 0; index8 <= height; index8 += 1)
            {
              if (this.Value[index7, index8] == simpleList1.Id[index5])
                this.Value[index7, index8] = num8;
            }
          }
        }
      }
    }

    pub AIMatrix AverageValuesForSameRegime(
      int range,
      AIMatrix owner,
      bool OnlyHigher0Hexes = false,
      int OnlyOwnerX = -1)
    {
      int num1 = -9999;
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] > 0 | !OnlyHigher0Hexes)
          {
            if (OnlyOwnerX == -1 | OnlyOwnerX == owner.Value[index1, index2])
            {
              int num2 = 0;
              int num3 = 0;
              int num4 = index1 - range;
              int num5 = index1 + range;
              for (int index3 = num4; index3 <= num5; index3 += 1)
              {
                int num6 = index2 - range;
                int num7 = index2 + range;
                for (int index4 = num6; index4 <= num7; index4 += 1)
                {
                  if (index3 <= this.Width & index3 >= 0 && index4 <= this.Height & index4 > 0 && owner.Value[index1, index2] == owner.Value[index3, index4] && this.Value[index3, index4] > 0 | !OnlyHigher0Hexes)
                  {
                    num3 += 1;
                    num2 += this.Value[index3, index4];
                    if (this.Value[index3, index4] > num1)
                      num1 = this.Value[index3, index4];
                  }
                }
              }
              if (num3 > 0)
              {
                if (num2 > 60)
                  num2 = num2;
                int num8 = (int) Math.Round(((double) num2 + (double) num3 * 0.25) / (double) num3);
                if (num8 > num1)
                  num8 = num1;
                aiMatrix.Value[index1, index2] = num8;
              }
              else
                aiMatrix.Value[index1, index2] = this.Value[index1, index2];
            }
            else
              aiMatrix.Value[index1, index2] = this.Value[index1, index2];
          }
        }
      }
      return aiMatrix;
    }

    pub AIMatrix AverageAndDivideValuesForSameRegime_NotForVP(
      int range,
      AIMatrix vp,
      AIMatrix owner,
      bool OnlyHigher0Hexes = false,
      int OnlyOwnerX = -1,
      int dividy = 1)
    {
      int num1 = -9999;
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] > 0 | !OnlyHigher0Hexes)
          {
            if (OnlyOwnerX == -1 | OnlyOwnerX == owner.Value[index1, index2])
            {
              if (vp.Value[index1, index2] < 1)
              {
                int num2 = 0;
                int num3 = 0;
                int num4 = index1 - range;
                int num5 = index1 + range;
                for (int index3 = num4; index3 <= num5; index3 += 1)
                {
                  int num6 = index2 - range;
                  int num7 = index2 + range;
                  for (int index4 = num6; index4 <= num7; index4 += 1)
                  {
                    if (index3 <= this.Width & index3 >= 0 && index4 <= this.Height & index4 > 0 && owner.Value[index1, index2] == owner.Value[index3, index4] && this.Value[index3, index4] > 0 | !OnlyHigher0Hexes)
                    {
                      num3 += 1;
                      num2 += this.Value[index3, index4];
                      if (this.Value[index3, index4] > num1)
                        num1 = this.Value[index3, index4];
                    }
                  }
                }
                if (num3 > 0)
                {
                  if (num2 > 1000)
                    num2 = num2;
                  int num8 = (int) Math.Round((double) num2 / (double) dividy);
                  if (num8 > num1)
                    num8 = num1;
                  if (num8 < this.Value[index1, index2])
                    num8 = this.Value[index1, index2];
                  aiMatrix.Value[index1, index2] = num8;
                }
                else
                  aiMatrix.Value[index1, index2] = this.Value[index1, index2];
              }
              else
                aiMatrix.Value[index1, index2] = this.Value[index1, index2];
            }
            else
              aiMatrix.Value[index1, index2] = this.Value[index1, index2];
          }
        }
      }
      return aiMatrix;
    }

    pub AIMatrix AverageAndDivideValuesForSameRegime(
      int range,
      AIMatrix owner,
      bool OnlyHigher0Hexes = false,
      int OnlyOwnerX = -1,
      int dividy = 1,
      int notAboveVP = -1,
      int ifRoadMultiply = -1)
    {
      int num1 = -9999;
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int num2 = 3;
      if (this.ai.VAR_ZONES_TYPE == 1)
        num2 = 4;
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] > 0 | !OnlyHigher0Hexes)
          {
            if (OnlyOwnerX == -1 | OnlyOwnerX == owner.Value[index1, index2])
            {
              int num3 = 0;
              int num4 = 0;
              if (range == 1)
              {
                int index3 = 0;
                do
                {
                  Coordinate coordinate = this.ai.TempHexNeighbour[index1, index2, index3];
                  if (coordinate.onmap && coordinate.x >= 0 & coordinate.x <= this.Width && coordinate.y >= 0 & coordinate.y <= this.Height && owner.Value[index1, index2] == owner.Value[coordinate.x, coordinate.y] && this.Value[coordinate.x, coordinate.y] > 0 | !OnlyHigher0Hexes)
                  {
                    num4 += 1;
                    if (ifRoadMultiply < 2)
                      num3 += this.Value[coordinate.x, coordinate.y];
                    else if (this.ai.game.Data.MapObj[0].HexObj[index1 + this.Left, index2 + this.Top].RoadType[index3] > -1)
                      num3 += this.Value[coordinate.x, coordinate.y] * ifRoadMultiply;
                    else
                      num3 += this.Value[coordinate.x, coordinate.y];
                    if (this.Value[coordinate.x, coordinate.y] > num1)
                      num1 = this.Value[coordinate.x, coordinate.y];
                  }
                  index3 += 1;
                }
                while (index3 <= 5);
              }
              else
              {
                int num5 = index1 - range;
                int num6 = index1 + range;
                for (int index4 = num5; index4 <= num6; index4 += 1)
                {
                  int num7 = index2 - range;
                  int num8 = index2 + range;
                  for (int index5 = num7; index5 <= num8; index5 += 1)
                  {
                    if (index4 <= this.Width & index4 >= 0 && index5 <= this.Height & index5 > 0 && owner.Value[index1, index2] == owner.Value[index4, index5] && this.Value[index4, index5] > 0 | !OnlyHigher0Hexes)
                    {
                      num4 += 1;
                      num3 += this.Value[index4, index5];
                      if (this.Value[index4, index5] > num1)
                        num1 = this.Value[index4, index5];
                    }
                  }
                }
              }
              if (num4 > 0)
              {
                if (num3 > 1000)
                  num3 = num3;
                int num9 = (int) Math.Round((double) num3 / (double) dividy);
                if (num9 > num1)
                  num9 = num1;
                if (num9 < this.Value[index1, index2])
                  num9 = this.Value[index1, index2];
                aiMatrix.Value[index1, index2] = num9;
              }
              else
                aiMatrix.Value[index1, index2] = this.Value[index1, index2];
            }
            else
              aiMatrix.Value[index1, index2] = this.Value[index1, index2];
          }
          else
            aiMatrix.Value[index1, index2] = this.Value[index1, index2];
        }
      }
      return aiMatrix;
    }

    pub AIMatrix AverageValuesForAnyRegime(int range, bool OnlyHigher0Hexes = false)
    {
      int num1 = -9999;
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width = this.Width;
      for (int x1 = 0; x1 <= width; x1 += 1)
      {
        int height = this.Height;
        for (int y1 = 0; y1 <= height; y1 += 1)
        {
          if (this.Value[x1, y1] > 0 | !OnlyHigher0Hexes && this.Value[x1, y1] > -1)
          {
            int num2 = 0;
            int num3 = 0;
            int num4 = x1 - range;
            int num5 = x1 + range;
            for (int index1 = num4; index1 <= num5; index1 += 1)
            {
              int num6 = y1 - range;
              int num7 = y1 + range;
              for (int index2 = num6; index2 <= num7; index2 += 1)
              {
                int x2 = index1;
                int y2 = index2;
                if (mapClass.MapLoop)
                {
                  if (x2 < 0)
                    x2 = mapClass.MapWidth + 1 - x2;
                  if (x2 > mapClass.MapWidth)
                    x2 -= mapClass.MapWidth + 1;
                }
                if (x2 <= this.Width & x2 >= 0 && y2 <= this.Height & y2 >= 0 && this.ai.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0, range) <= range && this.Value[x2, y2] > 0 | !OnlyHigher0Hexes && this.Value[x2, y2] > -1)
                {
                  num3 += 1;
                  num2 += this.Value[x2, y2];
                  if (this.Value[x2, y2] > num1)
                    num1 = this.Value[x2, y2];
                }
              }
            }
            if (num2 > 60 & this.Value[x1, y1] == 0)
              num2 = num2;
            int num8 = (int) Math.Round(((double) num2 + (double) num3 * 0.25) / (double) num3);
            if (num8 > num1)
              num8 = num1;
            aiMatrix.Value[x1, y1] = num8;
          }
        }
      }
      return aiMatrix;
    }

    pub AIMatrix AverageValuesWithWindDirection(
      int tsteps,
      ref AIMatrix windDirection,
      ref GameClass tgame,
      bool allowLowering,
      bool onlycorrectdir = false)
    {
      bool flag = false;
      MapClass mapClass = tgame.Data.MapObj[0];
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int num1 = tsteps;
      for (int index1 = 1; index1 <= num1; index1 += 1)
      {
        AIMatrix aiMatrix2 = this.Clone();
        int width = this.Width;
        for (int index2 = 0; index2 <= width; index2 += 1)
        {
          int height = this.Height;
          for (int index3 = 0; index3 <= height; index3 += 1)
          {
            if (aiMatrix2.Value[index2, index3] > 0 | !flag)
            {
              int num2 = aiMatrix2.Value[index2, index3] * 30;
              int num3 = 30;
              int num4 = windDirection.Value[index2, index3];
              int num5 = 1;
              do
              {
                Coordinate coordinate = tgame.DC2AIObj.TempHexNeighbour[index2, index3, num5 - 1];
                int x = coordinate.x;
                int y = coordinate.y;
                if (coordinate.onmap && aiMatrix2.Value[x, y] > aiMatrix2.Value[index2, index3] | allowLowering)
                {
                  int num6 = 8;
                  if (onlycorrectdir)
                    num6 = 0;
                  if (num5 + 3 == num4 | num5 - 3 == num4)
                    num6 = 20;
                  else if (!(num5 + 3 == num4 - 1 | num5 - 3 == num4 - 1) && !(num5 + 3 == num4 + 1 | num5 - 3 == num4 + 1))
                  {
                    num6 = 2;
                    if (onlycorrectdir)
                      num6 = 0;
                  }
                  if (num6 > 0)
                  {
                    num3 += num6;
                    num2 += aiMatrix2.Value[x, y] * num6;
                  }
                }
                num5 += 1;
              }
              while (num5 <= 6);
              int num7 = (int) Math.Round((double) num2 / (double) num3);
              if (allowLowering)
                aiMatrix1.Value[index2, index3] = num7;
              else if (num7 > aiMatrix1.Value[index2, index3])
                aiMatrix1.Value[index2, index3] = num7;
            }
          }
        }
      }
      return aiMatrix1;
    }

    pub AIMatrix AverageUniqueValuesForSameRegime(int range)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      AIMatrix aiMatrix = new AIMatrix(ref this.ai);
      int[] numArray1 = new int[100];
      int[] numArray2 = new int[100];
      int mapWidth = mapClass.MapWidth;
      for (int x1 = 0; x1 <= mapWidth; x1 += 1)
      {
        int mapHeight = mapClass.MapHeight;
        for (int y1 = 0; y1 <= mapHeight; y1 += 1)
        {
          if (this.Value[x1, y1] > 0)
          {
            int index1 = -1;
            int num1 = x1 - (range + 1);
            int num2 = x1 + (range + 1);
            for (int x2 = num1; x2 <= num2; x2 += 1)
            {
              int num3 = y1 - (range + 1);
              int num4 = y1 + (range + 1);
              for (int y2 = num3; y2 <= num4; y2 += 1)
              {
                if (x2 <= this.Width & x2 >= 0 && y2 <= this.Height & y2 > 0 && this.ai.game.HandyFunctionsObj.Distance(x1, y1, 0, x2, y2, 0, range) <= range && this.Value[x2, y2] > 0)
                {
                  int num5 = -1;
                  int num6 = index1;
                  for (int index2 = 0; index2 <= num6; index2 += 1)
                  {
                    if (numArray1[index2] == this.Value[x2, y2])
                      num5 = index2;
                  }
                  if (num5 == -1)
                  {
                    index1 += 1;
                    numArray1[index1] = this.Value[x2, y2];
                    num5 = index1;
                  }
                  int[] numArray3 = numArray2;
                  int[] numArray4 = numArray3;
                  int index3 = num5;
                  int index4 = index3;
                  int num7 = numArray3[index3] + 1;
                  numArray4[index4] = num7;
                }
              }
            }
            int num8 = -1;
            int num9 = 0;
            int num10 = index1;
            for (int index5 = 0; index5 <= num10; index5 += 1)
            {
              if (numArray2[index5] > num9)
              {
                num8 = numArray1[index5];
                num9 = numArray2[index5];
              }
            }
            if (num8 > -1)
              aiMatrix.Value[x1, y1] = num8;
          }
        }
      }
      return aiMatrix;
    }

    pub void ExpandValueForSameRegime(int maxy = 9999, int maxValueToBeMutated = -1)
    {
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        int num3;
        num3 += 1;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & numArray[tx, index1] == num1 & (maxValueToBeMutated == -1 | maxValueToBeMutated > this.Value[tx, index1]))
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 && mapClass.HexObj[tx, index1].Regime == mapClass.HexObj[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y].Regime)
                {
                  num2 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1];
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num1 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        if (num3 == maxy)
          num2 = 0;
      }
      while (num2 > 0);
    }

    pub void ExpandValueForAnyRegimeWithinMask(ref AIMatrix mask, int maxy = 9999)
    {
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        int num3;
        num3 += 1;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & mask.Value[tx, index1] > 0 & numArray[tx, index1] == num1)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 && mask.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > 0 && mapClass.HexObj[tx, index1].Regime > -1)
                {
                  num2 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1];
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num1 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        if (num3 == maxy)
          num2 = 0;
      }
      while (num2 > 0);
    }

    pub void AddValueForAnyRegimeWithinMask(ref AIMatrix mask, int maxy = 9999)
    {
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        int num3;
        num3 += 1;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & mask.Value[tx, index1] > 0 & numArray[tx, index1] == num1)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > this.Value[tx, index1] + 1 && mask.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > 0 && mapClass.HexObj[tx, index1].Regime > -1)
                {
                  num2 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1] + 1;
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num1 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        if (num3 == maxy)
          num2 = 0;
      }
      while (num2 > 0);
    }

    pub void ExpandValueForSameRegimeWithinMask(ref AIMatrix mask, int maxy = 9999)
    {
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        int num3;
        num3 += 1;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & mask.Value[tx, index1] > 0 & numArray[tx, index1] == num1)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 && mask.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > 0 && mapClass.HexObj[tx, index1].Regime == mapClass.HexObj[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y].Regime)
                {
                  num2 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1];
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num1 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        if (num3 == maxy)
          num2 = 0;
      }
      while (num2 > 0);
    }

    pub void ExpandValueForSameRegimeWithinDoubleMask(
      ref AIMatrix mask,
      ref AIMatrix maskSameValueNeeded,
      int maxy = 9999)
    {
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        int num3;
        num3 += 1;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & mask.Value[tx, index1] > 0 & numArray[tx, index1] == num1)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && maskSameValueNeeded.Value[tx, index1] == maskSameValueNeeded.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 && mask.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > 0 && mapClass.HexObj[tx, index1].Regime == mapClass.HexObj[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y].Regime)
                {
                  num2 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1];
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num1 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        if (num3 == maxy)
          num2 = 0;
      }
      while (num2 > 0);
    }

    pub void ExpandValueForAnyRegime(int maxy = 9999, int maxValueToBeMutated = -1)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int num2;
        num2 += 1;
        int width = this.Width;
        int num3;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & aiMatrix.Value[index1, index2] == num3 & (maxValueToBeMutated == -1 | maxValueToBeMutated > this.Value[index1, index2]))
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[index1, index2, index3].x, this.Left), this.ai.TempHexNeighbour[index1, index2, index3].y + this.Top].Regime != -1 && this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0)
                {
                  num1 += 1;
                  aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num3 + 1;
                  this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = this.Value[index1, index2];
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        num3 += 1;
        if (num2 >= maxy)
          num1 = 0;
      }
      while (num1 > 0);
    }

    pub void ExpandValueWithoutConditions(int maxy = 9999, int maxValueToBeMutated = -1)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int num2;
        num2 += 1;
        int width = this.Width;
        int num3;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & aiMatrix.Value[index1, index2] == num3 & (maxValueToBeMutated == -1 | maxValueToBeMutated > this.Value[index1, index2]))
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0)
                {
                  num1 += 1;
                  aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num3 + 1;
                  this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = this.Value[index1, index2] + 1;
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        num3 += 1;
        if (num2 >= maxy)
          num1 = 0;
      }
      while (num1 > 0);
    }

    pub void ExpandValueWithoutConditionsDimishWithOne(int maxy = 9999)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int num2;
        num2 += 1;
        int width = this.Width;
        int num3;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 1 & aiMatrix.Value[index1, index2] == num3)
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0)
                {
                  num1 += 1;
                  aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num3 + 1;
                  this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = this.Value[index1, index2] - 1;
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        num3 += 1;
        if (num2 >= maxy)
          num1 = 0;
      }
      while (num1 > 0);
    }

    pub void ExpandValueWithoutConditionsDimishWithOneAndOverwriteSmaller(int maxy = 9999)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int num2;
        num2 += 1;
        int width = this.Width;
        int num3;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 1 & aiMatrix.Value[index1, index2] == num3)
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && this.Value[index1, index2] - 1 > this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y])
                {
                  num1 += 1;
                  aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num3 + 1;
                  this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = this.Value[index1, index2] - 1;
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        num3 += 1;
        if (num2 >= maxy)
          num1 = 0;
      }
      while (num1 > 0);
    }

    pub int CountHexes(int minVal, int maxVal)
    {
      int num = 0;
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          if (this.Value[index1, index2] >= minVal & this.Value[index1, index2] <= maxVal)
            num += 1;
        }
      }
      return num;
    }

    pub void ExpandValueWithoutRegimesWithMaskAndMax(
      int onlyNumberToCopy,
      ref AIMatrix mask,
      int maskValueNeeded,
      int maxHexesToBeTaken)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = 0;
      int num2 = 999;
      int num3;
      do
      {
        num3 = 0;
        int num4;
        num4 += 1;
        int width = this.Width;
        int num5;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] == onlyNumberToCopy | onlyNumberToCopy == -1 & this.Value[index1, index2] > 0 && aiMatrix.Value[index1, index2] == num5 && mask.Value[index1, index2] == maskValueNeeded)
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0 && mask.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == maskValueNeeded)
                {
                  if (maxHexesToBeTaken == -1 | num1 < maxHexesToBeTaken)
                  {
                    num3 += 1;
                    num1 += 1;
                    aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num5 + 1;
                    this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = this.Value[index1, index2];
                  }
                  else
                    goto label_16;
                }
                index3 += 1;
              }
              while (index3 <= 5);
              continue;
label_16:
              return;
            }
          }
        }
        num5 += 1;
        if (num4 >= num2)
          num3 = 0;
      }
      while (num3 > 0);
    }

    pub void ExpandValueWithoutRegimesWithMaskAndMovementCost(
      int onlyNumberToCopy,
      ref AIMatrix mask,
      int maskValueNeeded,
      int maxHexesToBeTaken,
      ref AIMatrix moveTypeMatrix,
      ref AIMatrix moveCostMatrix,
      int max0changes,
      bool horizMoreExpansive)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = 0;
      int num2 = 999;
      int num3 = 0;
      do
      {
        int num4 = 0;
        int num5;
        num5 += 1;
        int width = this.Width;
        int num6;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] == onlyNumberToCopy | onlyNumberToCopy == -1 & this.Value[index1, index2] > 0 && aiMatrix.Value[index1, index2] == num6 && mask.Value[index1, index2] == maskValueNeeded)
            {
              int index3 = moveTypeMatrix.Value[index1, index2];
              int index4 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index4].onmap && this.ai.TempHexNeighbour[index1, index2, index4].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index4].y <= this.Height && this.Value[this.ai.TempHexNeighbour[index1, index2, index4].x, this.ai.TempHexNeighbour[index1, index2, index4].y] == 0 && mask.Value[this.ai.TempHexNeighbour[index1, index2, index4].x, this.ai.TempHexNeighbour[index1, index2, index4].y] == maskValueNeeded)
                {
                  if (maxHexesToBeTaken == -1 | num1 < maxHexesToBeTaken)
                  {
                    num4 += 1;
                    num1 += 1;
                    int index5 = moveTypeMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index4].x, this.ai.TempHexNeighbour[index1, index2, index4].y];
                    int num7 = moveCostMatrix.Value[index3, index5];
                    if (this.ai.game.Data.MapObj[0].HexObj[this.ai.TempHexNeighbour[index1, index2, index4].x, this.ai.TempHexNeighbour[index1, index2, index4].y].LandscapeType != this.ai.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType)
                      num7 *= 4;
                    if (this.ai.game.Data.MapObj[0].HexObj[index1, index2].RiverType[index4] > -1)
                      num7 *= 2;
                    if (horizMoreExpansive & !(index4 == 0 | index4 == 5))
                      num7 = (int) Math.Round((double) num7 * 1.33);
                    aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index4].x, this.ai.TempHexNeighbour[index1, index2, index4].y] = num6 + num7;
                    this.Value[this.ai.TempHexNeighbour[index1, index2, index4].x, this.ai.TempHexNeighbour[index1, index2, index4].y] = this.Value[index1, index2];
                  }
                  else
                    goto label_25;
                }
                index4 += 1;
              }
              while (index4 <= 5);
              continue;
label_25:
              return;
            }
          }
        }
        num6 += 1;
        if (num5 >= num2)
          num4 = 0;
        if (num4 == 0)
          num3 += 1;
        else
          num3 = 0;
      }
      while (num3 < max0changes);
    }

    pub void ExpandValueWithoutConditionsHighest(int maxy = 9999, int percenta = 100, int addVal = 0)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int num2;
        num2 += 1;
        int width = this.Width;
        int num3;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & aiMatrix.Value[index1, index2] == num3)
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0 & aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0)
                {
                  num1 += 1;
                  aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num3 + 1;
                  this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = (int) Math.Round((double) (this.Value[index1, index2] * percenta) / 100.0) + addVal;
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        num3 += 1;
        if (num2 >= maxy)
          num1 = 0;
      }
      while (num1 > 0);
    }

    pub void ExpandValueForAnyRegimeOverRoadOnly(float moddyOfValue = 1f)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int width = this.Width;
        int num2;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & aiMatrix.Value[index1, index2] == num2)
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[index1, index2, index3].x, this.Left), this.ai.TempHexNeighbour[index1, index2, index3].y + this.Top].Regime != -1 && this.ai.map.HexObj[index1 + this.Left, index2 + this.Top].RoadType[index3] > -1 && this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0 | DrawMod.TGame.Data.Product != 6 & this.Value[index1, index2] > this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y])
                {
                  num1 += 1;
                  aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num2 + 1;
                  this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = (int) Math.Round((double) ((float) this.Value[index1, index2] * moddyOfValue));
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        num2 += 1;
      }
      while (num1 > 0);
    }

    pub void ExpandValueForAnyRegimeOverRoadOnly_Dc4version(
      float moddyOfValue,
      ref AIMatrix enemyMoveLimit)
    {
      AIMatrix aiMatrix1 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      AIMatrix aiMatrix2 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      aiMatrix2.SetAllValuesTo(-99);
      AIMatrix aiMatrix3 = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int width = this.Width;
        int val2;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & aiMatrix1.Value[index1, index2] == val2)
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[index1, index2, index3].x, this.Left), this.ai.TempHexNeighbour[index1, index2, index3].y + this.Top].Regime != -1)
                {
                  int index4 = this.ai.map.HexObj[index1 + this.Left, index2 + this.Top].RoadType[index3];
                  if (index4 > -1 && this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] == 0 | this.Value[index1, index2] > this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y])
                  {
                    int num2 = this.ai.game.Data.RoadTypeObj[index4].MoveCostOverrule[(int) Math.Round((double) this.ai.game.Data.RuleVar[99])];
                    float num3 = !(num2 <= 2 | val2 <= 5 | aiMatrix2.Value[index1, index2] + 6 > val2) ? (!(num2 <= 5 | val2 <= 9 | aiMatrix2.Value[index1, index2] + 9 > val2) ? (num2 > 10 ? moddyOfValue * 0.6f : moddyOfValue * 0.7f) : moddyOfValue * 0.8f) : (aiMatrix3.Value[index1, index2] > 1 ? moddyOfValue * 0.9f : moddyOfValue);
                    if (DrawMod.TGame.Data.MapObj[0].HexObj[index1 + this.Left, index2 + this.Top].UnitCounter > -1 & !Information.IsNothing((object) enemyMoveLimit) && enemyMoveLimit.Value[index1, index2] > 0 & DrawMod.TGame.Data.MapObj[0].HexObj[index1 + this.Left, index2 + this.Top].Regime != DrawMod.TGame.Data.Turn)
                      num3 -= (float) ((double) num3 * 0.150000005960464 * (double) enemyMoveLimit.Value[index1, index2] / 100.0);
                    int num4 = Math.Max(this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y], (int) Math.Round((double) ((float) this.Value[index1, index2] * num3)));
                    if (num4 > this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y])
                    {
                      num1 += 1;
                      aiMatrix1.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = val2 + 1;
                      this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num4;
                      if (num2 <= 2)
                      {
                        aiMatrix2.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = Math.Max(aiMatrix2.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y], val2);
                        aiMatrix3.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num2;
                      }
                      else
                      {
                        aiMatrix2.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = Math.Max(aiMatrix2.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y], aiMatrix2.Value[index1, index2] - 1);
                        aiMatrix2.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = aiMatrix3.Value[index1, index2];
                      }
                    }
                  }
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        val2 += 1;
      }
      while (num1 > 0);
    }

    pub void ExpandValueForSpreadOut(
      ref AIMatrix supplyMatrix,
      float moddyOfValue = 1f,
      float extraModdyForOffRoad = 0.33f,
      AIMatrix moveLimit = null,
      int maxHex = 999)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1 = 0;
      int num2;
      do
      {
        num2 = 0;
        int width = this.Width;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & aiMatrix.Value[index1, index2] == num1)
            {
              int index3 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[index1, index2, index3].onmap && this.ai.TempHexNeighbour[index1, index2, index3].x <= this.Width & this.ai.TempHexNeighbour[index1, index2, index3].y <= this.Height && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[index1, index2, index3].x, this.Left), this.ai.TempHexNeighbour[index1, index2, index3].y + this.Top].Regime != -1 && this.Value[index1, index2] > this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y])
                {
                  if (this.ai.map.HexObj[index1 + this.Left, index2 + this.Top].RoadType[index3] > -1)
                  {
                    num2 += 1;
                    int num3 = (int) Math.Round((double) ((float) this.Value[index1, index2] * moddyOfValue));
                    if (supplyMatrix.Value[index1, index2] > 200 + this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                      num3 = (int) Math.Round((double) num3 * 0.5);
                    else if (supplyMatrix.Value[index1, index2] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                      num3 = (int) Math.Round((double) num3 * 0.85);
                    if (!Information.IsNothing((object) moveLimit))
                      num3 = (int) Math.Round((double) (num3 * moveLimit.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y]) / 100.0);
                    if (num3 > this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y])
                    {
                      aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num1 + 1;
                      this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num3;
                    }
                  }
                  else
                  {
                    num2 += 1;
                    int num4 = (int) Math.Round((double) ((float) this.Value[index1, index2] * moddyOfValue * extraModdyForOffRoad));
                    if (supplyMatrix.Value[index1, index2] > 200 + this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                      num4 = (int) Math.Round((double) num4 * 0.2);
                    else if (supplyMatrix.Value[index1, index2] > this.ai.VAR_SUPPLY_25PERCENT_RANGE)
                      num4 = (int) Math.Round((double) num4 * 0.5);
                    if (!Information.IsNothing((object) moveLimit))
                      num4 = (int) Math.Round((double) (num4 * moveLimit.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y]) / 100.0);
                    if (num4 > this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y])
                    {
                      aiMatrix.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num1 + 1;
                      this.Value[this.ai.TempHexNeighbour[index1, index2, index3].x, this.ai.TempHexNeighbour[index1, index2, index3].y] = num4;
                    }
                  }
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
        num1 += 1;
      }
      while (num1 < maxHex && num2 > 0);
    }

    pub void ExpandValueToSpecificRegime(int UseOwner, ref AIMatrix owner)
    {
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int num1;
      do
      {
        num1 = 0;
        int width = this.Width;
        int num2;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & aiMatrix.Value[tx, index1] == num2)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && owner.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == UseOwner && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[tx, index1, index2].x, this.Left), this.ai.TempHexNeighbour[tx, index1, index2].y + this.Top].Regime != -1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1)
                {
                  num1 += 1;
                  aiMatrix.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num2 + 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1];
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        num2 += 1;
      }
      while (num1 > 0);
    }

    pub void ExpandAsSimplifiedSupplyMatrix(
      int MoveType,
      ref AIMatrix ownerMatrix,
      int OWNER,
      AICoordinateMatrix camefromMatrix)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray1 = new int[this.Width + 1, this.Height + 1];
      int[,] numArray2 = new int[this.Width + 1, this.Height + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int x = 0; x <= width; x += 1)
        {
          int height = this.Height;
          for (int y = 0; y <= height; y += 1)
          {
            if (numArray1[x, y] == num1 && this.Value[x, y] < this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
            {
              int index = 0;
              do
              {
                if (this.ai.TempHexNeighbour[x, y, index].onmap)
                {
                  Coordinate coordinate = this.ai.TempHexNeighbour[x, y, index];
                  if (coordinate.x <= this.Width & coordinate.y <= this.Height)
                  {
                    bool flag1 = false;
                    if (ownerMatrix.Value[x, y] == ownerMatrix.Value[coordinate.x, coordinate.y])
                      flag1 = true;
                    else if (ownerMatrix.Value[x, y] == 0 & ownerMatrix.Value[coordinate.x, coordinate.y] == OWNER)
                      flag1 = this.ai.game.HandyFunctionsObj.IsHexPort(coordinate.x, coordinate.y, 0);
                    else if (ownerMatrix.Value[x, y] == OWNER & ownerMatrix.Value[coordinate.x, coordinate.y] == 0)
                      flag1 = this.ai.game.HandyFunctionsObj.IsHexPort(x, y, 0);
                    if (this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].AIBlock > 0)
                      flag1 = false;
                    if (flag1)
                    {
                      int num3 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[coordinate.x, coordinate.y].LandscapeType].MoveCost[MoveType];
                      if (mapClass.HexObj[x, y].RoadType[index] > -1)
                      {
                        if (this.ai.game.Data.RoadTypeObj[mapClass.HexObj[x, y].RoadType[index]].MoveCostOverrule[MoveType] < num3)
                          num3 = this.ai.game.Data.RoadTypeObj[mapClass.HexObj[x, y].RoadType[index]].MoveCostOverrule[MoveType];
                      }
                      else
                        num3 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[coordinate.x, coordinate.y].LandscapeType].MoveCost[MoveType];
                      if (mapClass.HexObj[x, y].RiverType[index] > -1 & !mapClass.HexObj[x, y].Bridge[index])
                        num3 += this.ai.game.Data.RiverTypeObj[mapClass.HexObj[x, y].RiverType[index]].MovePenalty[MoveType];
                      int num4 = 0;
                      bool flag2 = false;
                      if (mapClass.HexObj[x, y].Location > -1)
                        num4 = this.ai.game.Data.LocTypeObj[this.ai.game.Data.LocObj[mapClass.HexObj[x, y].Location].Type].Logistical;
                      if (mapClass.HexObj[x, y].Location2 > -1)
                      {
                        int type = this.ai.game.Data.LocObj[mapClass.HexObj[x, y].Location2].Type;
                        if (this.ai.game.Data.LocTypeObj[type].Logistical > num4)
                          num4 = this.ai.game.Data.LocTypeObj[type].Logistical;
                      }
                      if (num4 < numArray2[x, y])
                        num4 = numArray2[x, y];
                      else if (numArray2[x, y] > 0)
                        flag2 = true;
                      int num5;
                      int num6;
                      if (num4 > num3)
                      {
                        num5 = num4 - num3;
                        num6 = 0;
                      }
                      else
                      {
                        num6 = num3 - num4;
                        num5 = 0;
                      }
                      if (flag2)
                        num6 += 1;
                      if (this.Value[x, y] + num6 - num5 < this.Value[coordinate.x, coordinate.y] - numArray2[coordinate.x, coordinate.y] & this.Value[coordinate.x, coordinate.y] != 0)
                      {
                        num2 += 1;
                        this.Value[coordinate.x, coordinate.y] = this.Value[x, y] + num6;
                        numArray1[coordinate.x, coordinate.y] = num1 + 1;
                        numArray2[coordinate.x, coordinate.y] = num5;
                        if (!Information.IsNothing((object) camefromMatrix))
                        {
                          camefromMatrix.Value[coordinate.x, coordinate.y].x = x;
                          camefromMatrix.Value[coordinate.x, coordinate.y].y = y;
                          camefromMatrix.Value[coordinate.x, coordinate.y].onmap = true;
                        }
                      }
                    }
                  }
                }
                index += 1;
              }
              while (index <= 5);
            }
          }
        }
      }
      while (num2 > 0);
    }

    pub void ExpandAsSimplifiedSupplyRouteMatrix_SuperSpeed(
      int MoveType,
      ref AIMatrix ownerMatrix,
      int OWNER,
      bool IgnoreOwner = false,
      bool NoNeutral = false,
      bool useRoads = true,
      int maxSteps = 9999)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray1 = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int[,] numArray2 = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int num1 = DrawMod.TGame.Data.Product < 7 ? this.ai.VAR_SUPPLY_MAXIMUM_RANGE * 2 : this.ai.VAR_SUPPLY_MAXIMUM_RANGE;
      CoordList coordList = CoordList::new();
      int width = this.Width;
      for (int x = 0; x <= width; x += 1)
      {
        int height = this.Height;
        for (int y = 0; y <= height; y += 1)
        {
          if (this.Value[x, y] < num1)
            coordList.AddCoord(x, y, 0);
        }
      }
      for (int index1 = 0; index1 <= coordList.counter; index1 += 1)
      {
        int x = coordList.coord[index1].x;
        int y = coordList.coord[index1].y;
        if (this.Value[x, y] < num1)
        {
          int index2 = 0;
          do
          {
            if (this.ai.TempHexNeighbour[x, y, index2].onmap)
            {
              Coordinate coordinate = this.ai.TempHexNeighbour[x, y, index2];
              if (coordinate.x <= this.Width & coordinate.y <= this.Height)
              {
                bool flag = ownerMatrix.Value[x, y] == ownerMatrix.Value[coordinate.x, coordinate.y] | IgnoreOwner && ownerMatrix.Value[coordinate.x, coordinate.y] != 0;
                if (numArray2[x, y] >= maxSteps)
                  flag = false;
                if (this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].AIBlock > 0)
                  flag = false;
                if (flag)
                {
                  int num2;
                  if (mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RoadType[index2] > -1 & !(!useRoads & ownerMatrix.Value[x, y] != 1 & !IgnoreOwner))
                  {
                    num2 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].MoveCost[MoveType];
                    if (this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RoadType[index2]].MoveCostOverrule[MoveType] < num2)
                      num2 = this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RoadType[index2]].MoveCostOverrule[MoveType];
                  }
                  else
                  {
                    num2 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].MoveCost[MoveType];
                    if (mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RiverType[index2] > -1 & !mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].Bridge[index2])
                      num2 += this.ai.game.Data.RiverTypeObj[mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RiverType[index2]].MovePenalty[MoveType];
                  }
                  if (this.Value[x, y] + num2 < this.Value[coordinate.x, coordinate.y])
                  {
                    this.Value[coordinate.x, coordinate.y] = this.Value[x, y] + num2;
                    coordList.AddCoord(coordinate.x, coordinate.y, 0);
                    numArray2[coordinate.x, coordinate.y] = numArray2[x, y] + 1;
                  }
                }
              }
            }
            index2 += 1;
          }
          while (index2 <= 5);
        }
      }
    }

    pub void ExpandAsSimplifiedSupplyRouteMatrix(
      int MoveType,
      ref AIMatrix ownerMatrix,
      int OWNER,
      bool IgnoreOwner = false,
      bool NoNeutral = false,
      bool useRoads = true,
      int extraForEnemy = 0,
      bool NeverRoads = false,
      float nonRoadCostMod = 1f,
      int riverCostExtraAp = 0,
      AIMatrix enemyDist = null)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      bool[,] flagArray = new bool[this.Width + 1, this.Height + 1];
      int num1 = DrawMod.TGame.Data.Product < 7 ? this.ai.VAR_SUPPLY_MAXIMUM_RANGE * 2 : this.ai.VAR_SUPPLY_MAXIMUM_RANGE;
      if (extraForEnemy > 0)
        num1 *= 3;
      if (riverCostExtraAp > 0)
        num1 = 5000;
      CoordList coordList = CoordList::new();
      int width = this.Width;
      for (int x = 0; x <= width; x += 1)
      {
        int height = this.Height;
        for (int y = 0; y <= height; y += 1)
        {
          if (this.Value[x, y] < num1)
            coordList.AddCoord(x, y, 0);
        }
      }
      for (int index1 = 0; index1 <= coordList.counter; index1 += 1)
      {
        int x = coordList.coord[index1].x;
        int y = coordList.coord[index1].y;
        if (this.Value[x, y] < num1)
        {
          int index2 = 0;
          do
          {
            if (this.ai.TempHexNeighbour[x, y, index2].onmap)
            {
              Coordinate coordinate = this.ai.TempHexNeighbour[x, y, index2];
              if (coordinate.x <= this.Width & coordinate.y <= this.Height)
              {
                bool flag = false;
                if ((ownerMatrix.Value[x, y] == ownerMatrix.Value[coordinate.x, coordinate.y] | IgnoreOwner) & ownerMatrix.Value[coordinate.x, coordinate.y] != 0)
                  flag = true;
                else if (ownerMatrix.Value[x, y] == 0 & (IgnoreOwner | ownerMatrix.Value[coordinate.x, coordinate.y] == OWNER) & !NoNeutral)
                  flag = this.ai.game.HandyFunctionsObj.IsHexPort(this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top, 0);
                else if ((IgnoreOwner | ownerMatrix.Value[x, y] == OWNER) & ownerMatrix.Value[coordinate.x, coordinate.y] == 0 & !NoNeutral)
                  flag = this.ai.game.HandyFunctionsObj.IsHexPort(this.ai.GetRealX(x, this.Left), y + this.Top, 0);
                if (this.ai.game.Data.LandscapeTypeObj[this.ai.game.Data.MapObj[0].HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].AIBlock > 0)
                  flag = false;
                if (riverCostExtraAp > 0 && this.Value[coordinate.x, coordinate.y] >= 9999)
                  flag = false;
                if (flag)
                {
                  int num2;
                  if (!NeverRoads & mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RoadType[index2] > -1 & !(!useRoads & ownerMatrix.Value[x, y] != 1))
                  {
                    num2 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].MoveCost[MoveType];
                    if ((double) nonRoadCostMod != 1.0)
                      num2 = (int) Math.Round((double) ((float) num2 * nonRoadCostMod));
                    if (this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RoadType[index2]].MoveCostOverrule[MoveType] < num2)
                      num2 = this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RoadType[index2]].MoveCostOverrule[MoveType];
                  }
                  else
                  {
                    num2 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].MoveCost[MoveType];
                    if ((double) nonRoadCostMod != 1.0)
                      num2 = (int) Math.Round((double) ((float) num2 * nonRoadCostMod));
                  }
                  if (mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RiverType[index2] > -1 & !mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].Bridge[index2] && !NeverRoads)
                    num2 += this.ai.game.Data.RiverTypeObj[mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RiverType[index2]].MovePenalty[MoveType];
                  if (riverCostExtraAp > 0)
                  {
                    if (coordinate.x == 6 & coordinate.y == 5)
                      ;
                    if (mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RiverType[index2] > -1)
                    {
                      if (this.ai.game.Data.RiverTypeObj[mapClass.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].RiverType[index2]].TempDefenseBonus > 50)
                        num2 += riverCostExtraAp;
                      else
                        num2 = num2;
                    }
                  }
                  int num3 = 0;
                  if (ownerMatrix.Value[coordinate.x, coordinate.y] != OWNER)
                  {
                    num2 += extraForEnemy;
                    if (!NeverRoads && mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].UnitCounter > -1)
                      num2 += extraForEnemy * Math.Min(3, mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].UnitCounter + 1);
                  }
                  else if (!Information.IsNothing((object) enemyDist))
                  {
                    if (enemyDist.Value[coordinate.x, coordinate.y] == 1)
                      num2 += 40;
                    if (enemyDist.Value[coordinate.x, coordinate.y] == 2)
                      num2 += 20;
                    if (enemyDist.Value[coordinate.x, coordinate.y] == 3)
                      num2 += 10;
                  }
                  if (this.Value[x, y] + num2 - num3 < this.Value[coordinate.x, coordinate.y] - numArray[coordinate.x, coordinate.y])
                  {
                    this.Value[coordinate.x, coordinate.y] = this.Value[x, y] + num2;
                    coordList.AddCoord(coordinate.x, coordinate.y, 0);
                    numArray[coordinate.x, coordinate.y] = num3;
                    flagArray[coordinate.x, coordinate.y] = false;
                  }
                }
              }
            }
            index2 += 1;
          }
          while (index2 <= 5);
        }
      }
    }

    pub void ExpandAsSupplyIdealRouteMatrix(
      int MoveType,
      int enemyMoveType,
      ref AIMatrix ownerMatrix,
      int OWNER,
      AIMatrix EnemySupply,
      AIMatrix troops,
      bool blockSea = false)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray1 = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int[,] numArray2 = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] < this.ai.VAR_SUPPLY_MAXIMUM_RANGE * 2 & numArray1[tx, index1] == num1)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap)
                {
                  Coordinate coordinate = this.ai.TempHexNeighbour[tx, index1, index2];
                  if (coordinate.x <= this.Width & coordinate.y <= this.Height)
                  {
                    int num3 = 0;
                    if (coordinate.x == 24 & coordinate.y == 15)
                      tx = tx;
                    bool flag;
                    if (ownerMatrix.Value[tx, index1] == ownerMatrix.Value[coordinate.x, coordinate.y])
                    {
                      flag = true;
                      if (ownerMatrix.Value[coordinate.x, coordinate.y] == 2)
                      {
                        flag = true;
                        if (EnemySupply.Value[coordinate.x, coordinate.y] < this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
                        {
                          num3 = 25;
                          if (troops.Value[coordinate.x, coordinate.y] > 30)
                            num3 += 30;
                          else if (troops.Value[coordinate.x, coordinate.y] > 10)
                            num3 += 20;
                          else if (troops.Value[coordinate.x, coordinate.y] > 0)
                            num3 += 10;
                        }
                        else
                          num3 = 5;
                      }
                      if (ownerMatrix.Value[coordinate.x, coordinate.y] == 0 && blockSea)
                        flag = false;
                    }
                    else if (ownerMatrix.Value[tx, index1] == 0 & ownerMatrix.Value[coordinate.x, coordinate.y] == OWNER)
                    {
                      flag = this.ai.game.HandyFunctionsObj.IsHexPort(this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top, 0);
                      if (!blockSea)
                        flag = false;
                    }
                    else if (ownerMatrix.Value[tx, index1] == OWNER & ownerMatrix.Value[coordinate.x, coordinate.y] == 0)
                    {
                      flag = this.ai.game.HandyFunctionsObj.IsHexPort(this.ai.GetRealX(tx, this.Left), index1 + this.Top, 0);
                      if (!blockSea)
                        flag = false;
                    }
                    else
                    {
                      flag = true;
                      if (ownerMatrix.Value[coordinate.x, coordinate.y] == 2)
                      {
                        flag = true;
                        if (EnemySupply.Value[coordinate.x, coordinate.y] < this.ai.VAR_SUPPLY_MAXIMUM_RANGE)
                        {
                          num3 = 25;
                          if (troops.Value[coordinate.x, coordinate.y] > 30)
                            num3 += 30;
                          else if (troops.Value[coordinate.x, coordinate.y] > 10)
                            num3 += 20;
                          else if (troops.Value[coordinate.x, coordinate.y] > 0)
                            num3 += 10;
                        }
                        else
                          num3 = 5;
                      }
                      else if (ownerMatrix.Value[coordinate.x, coordinate.y] == 0 && blockSea)
                        flag = false;
                    }
                    if (flag)
                    {
                      int num4 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].MoveCost[MoveType];
                      if (ownerMatrix.Value[coordinate.x, coordinate.y] == 2)
                      {
                        if (mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2] > -1 && this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2]].MoveCostOverrule[enemyMoveType] < num4)
                          num4 = this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2]].MoveCostOverrule[enemyMoveType];
                      }
                      else if (mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2] > -1 && this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2]].MoveCostOverrule[MoveType] < num4)
                        num4 = this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2]].MoveCostOverrule[MoveType];
                      if (mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RiverType[index2] > -1 & !mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].Bridge[index2])
                        num4 += this.ai.game.Data.RiverTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RiverType[index2]].MovePenalty[MoveType];
                      int num5 = num4 + num3;
                      int num6 = 0;
                      if (this.Value[tx, index1] + num5 - num6 < this.Value[coordinate.x, coordinate.y] - numArray2[coordinate.x, coordinate.y])
                      {
                        num2 += 1;
                        this.Value[coordinate.x, coordinate.y] = this.Value[tx, index1] + num5;
                        numArray1[coordinate.x, coordinate.y] = num1 + 1;
                        numArray2[coordinate.x, coordinate.y] = num6;
                      }
                    }
                  }
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
      }
      while (num2 > 0);
    }

    pub void ExpandAsSimplifiedSupplyRouteMatrixByID(
      int MoveType,
      ref AIMatrix ownerMatrix,
      int OWNER,
      int MustHaveID,
      AIMatrix id)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray1 = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int[,] numArray2 = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (id.Value[tx, index1] == MustHaveID && this.Value[tx, index1] < 9999 & numArray1[tx, index1] == num1)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap)
                {
                  Coordinate coordinate = this.ai.TempHexNeighbour[tx, index1, index2];
                  if (coordinate.x <= this.Width & coordinate.y <= this.Height && id.Value[coordinate.x, coordinate.y] == MustHaveID)
                  {
                    bool flag = false;
                    if (ownerMatrix.Value[tx, index1] == ownerMatrix.Value[coordinate.x, coordinate.y])
                      flag = true;
                    else if (ownerMatrix.Value[tx, index1] == 0 & ownerMatrix.Value[coordinate.x, coordinate.y] == OWNER)
                      flag = this.ai.game.HandyFunctionsObj.IsHexPort(this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top, 0);
                    else if (ownerMatrix.Value[tx, index1] == OWNER & ownerMatrix.Value[coordinate.x, coordinate.y] == 0)
                      flag = this.ai.game.HandyFunctionsObj.IsHexPort(this.ai.GetRealX(tx, this.Left), index1 + this.Top, 0);
                    if (this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].AIBlock > 0)
                      flag = false;
                    if (flag)
                    {
                      int num3;
                      if (mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2] > -1)
                      {
                        if (this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2]].MoveCostOverrule[MoveType] < num3)
                          num3 = this.ai.game.Data.RoadTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RoadType[index2]].MoveCostOverrule[MoveType];
                      }
                      else
                        num3 = this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].LandscapeType].MoveCost[MoveType];
                      if (mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RiverType[index2] > -1 & !mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].Bridge[index2])
                        num3 += this.ai.game.Data.RiverTypeObj[mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].RiverType[index2]].MovePenalty[MoveType];
                      int num4 = 0;
                      if (this.Value[tx, index1] + num3 - num4 < this.Value[coordinate.x, coordinate.y] - numArray2[coordinate.x, coordinate.y])
                      {
                        num2 += 1;
                        this.Value[coordinate.x, coordinate.y] = this.Value[tx, index1] + num3;
                        numArray1[coordinate.x, coordinate.y] = num1 + 1;
                        numArray2[coordinate.x, coordinate.y] = num4;
                      }
                    }
                  }
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
      }
      while (num2 > 0);
    }

    pub void ExpandUniquesValuesForAnyRegime(int MaxSteps = 9999, bool allowSea = false, int valueMustBeBelow = -1)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & numArray[tx, index1] == num1 & (valueMustBeBelow == -1 | this.Value[tx, index1] < valueMustBeBelow))
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height & this.ai.TempHexNeighbour[tx, index1, index2].x >= 0 & this.ai.TempHexNeighbour[tx, index1, index2].y >= 0 && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 & (valueMustBeBelow == -1 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] < valueMustBeBelow))
                {
                  bool flag = false;
                  if (!this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].IsSea | allowSea)
                    flag = true;
                  if (flag)
                  {
                    num2 += 1;
                    this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1];
                    numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num1 + 1;
                  }
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1);
    }

    pub void ExpandUniquesValuesForSameRegime(
      int MaxSteps = 9999,
      int areaSlotMustBeSame2 = -1,
      int valueMustBeBelow = -1)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[mapClass.MapWidth + 1, mapClass.MapHeight + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] > 0 & numArray[tx, index1] == num1 & (valueMustBeBelow == -1 | this.Value[tx, index1] < valueMustBeBelow))
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height & this.ai.TempHexNeighbour[tx, index1, index2].x >= 0 & this.ai.TempHexNeighbour[tx, index1, index2].y >= 0 && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 & (valueMustBeBelow == -1 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] < valueMustBeBelow) && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1)
                {
                  bool flag = false;
                  if (areaSlotMustBeSame2 == -1)
                    flag = true;
                  if (areaSlotMustBeSame2 > -1 && this.ai.VAR_MATRIX_SUPERFRONT.Value[tx, index1] == this.ai.VAR_MATRIX_SUPERFRONT.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y])
                    flag = true;
                  if (flag && mapClass.HexObj[tx, index1].Regime == mapClass.HexObj[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y].Regime)
                  {
                    num2 += 1;
                    this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1];
                    numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num1 + 1;
                  }
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1);
    }

    pub void ExpandAllNonZeroValuesForAnyRegime(int MaxSteps)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      if (this.ai.TempHexNeighbour.GetUpperBound(0) < this.ai.game.Data.MapObj[0].MapWidth | this.ai.TempHexNeighbour.GetUpperBound(1) < this.ai.game.Data.MapObj[0].MapHeight)
        this.ai.SetTempHexNeighbours();
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & numArray[index1, index2] == num1)
            {
              int index3 = 0;
              do
              {
                Coordinate coordinate = this.ai.TempHexNeighbour[index1, index2, index3];
                if (coordinate.onmap && coordinate.x <= this.Width & coordinate.y <= this.Height && this.Value[coordinate.x, coordinate.y] < 1)
                {
                  bool flag = true;
                  if (mapClass.HexObj[coordinate.x, coordinate.y].MaxRecon > 0)
                  {
                    if (mapClass.HexObj[index1, index2].Regime != mapClass.HexObj[coordinate.x, coordinate.y].Regime)
                      flag = false;
                  }
                  else if (mapClass.HexObj[coordinate.x, coordinate.y].get_LastLT(DrawMod.TGame.Data.Turn) > -1 && DrawMod.TGame.Data.LandscapeTypeObj[mapClass.HexObj[coordinate.x, coordinate.y].get_LastLT(DrawMod.TGame.Data.Turn)].IsSea)
                    flag = false;
                  if (flag)
                  {
                    num2 += 1;
                    this.Value[coordinate.x, coordinate.y] = this.Value[index1, index2];
                    numArray[coordinate.x, coordinate.y] = num1 + 1;
                  }
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1 + 1);
    }

    pub void ExpandAllNonZeroValuesForAnyRegime(int MaxSteps, AIMatrix specialMask)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] > 0 & numArray[index1, index2] == num1)
            {
              int index3 = 0;
              do
              {
                Coordinate coordinate = this.ai.TempHexNeighbour[index1, index2, index3];
                if (coordinate.onmap && coordinate.x <= this.Width & coordinate.y <= this.Height && this.Value[coordinate.x, coordinate.y] < 1)
                {
                  bool flag = true;
                  if (mapClass.HexObj[coordinate.x, coordinate.y].MaxRecon > 0)
                  {
                    if (mapClass.HexObj[index1, index2].Regime != mapClass.HexObj[coordinate.x, coordinate.y].Regime)
                      flag = false;
                  }
                  else if (mapClass.HexObj[coordinate.x, coordinate.y].get_LastLT(DrawMod.TGame.Data.Turn) > -1 && DrawMod.TGame.Data.LandscapeTypeObj[mapClass.HexObj[coordinate.x, coordinate.y].get_LastLT(DrawMod.TGame.Data.Turn)].IsSea)
                    flag = false;
                  if (specialMask.Value[coordinate.x, coordinate.y] == 0)
                    flag = false;
                  else if (specialMask.Value[coordinate.x, coordinate.y] != specialMask.Value[index1, index2])
                    flag = false;
                  if (flag)
                  {
                    num2 += 1;
                    this.Value[coordinate.x, coordinate.y] = this.Value[index1, index2];
                    numArray[coordinate.x, coordinate.y] = num1 + 1;
                  }
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1 + 1);
    }

    pub void ExpandSpecificValueForAnyRegime(int specificVal, int MaxSteps)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] == specificVal & numArray[index1, index2] == num1)
            {
              int index3 = 0;
              do
              {
                Coordinate coordinate = this.ai.TempHexNeighbour[index1, index2, index3];
                if (coordinate.onmap && coordinate.x <= this.Width & coordinate.y <= this.Height && this.Value[coordinate.x, coordinate.y] != specificVal && mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].Regime > -1)
                {
                  num2 += 1;
                  this.Value[coordinate.x, coordinate.y] = this.Value[index1, index2];
                  numArray[coordinate.x, coordinate.y] = num1 + 1;
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1 + 1);
    }

    pub void ExpandSpecificValueForAnyRegimeMasked(
      int specificVal,
      int MaxSteps,
      AIMatrix matrixMustBeBelow1)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int index1 = 0; index1 <= width; index1 += 1)
        {
          int height = this.Height;
          for (int index2 = 0; index2 <= height; index2 += 1)
          {
            if (this.Value[index1, index2] == specificVal & numArray[index1, index2] == num1)
            {
              int index3 = 0;
              do
              {
                Coordinate coordinate = this.ai.TempHexNeighbour[index1, index2, index3];
                if (coordinate.onmap && coordinate.x <= this.Width & coordinate.y <= this.Height && this.Value[coordinate.x, coordinate.y] != specificVal & matrixMustBeBelow1.Value[coordinate.x, coordinate.y] < 1 && mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].Regime > -1)
                {
                  num2 += 1;
                  this.Value[coordinate.x, coordinate.y] = this.Value[index1, index2];
                  numArray[coordinate.x, coordinate.y] = num1 + 1;
                }
                index3 += 1;
              }
              while (index3 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1 + 1);
    }

    pub void ExpandSpecificValueForSameRegime(int specificVal, int MaxSteps)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      if (this.ai.TempHexNeighbour.GetUpperBound(0) < this.ai.game.Data.MapObj[0].MapWidth | this.ai.TempHexNeighbour.GetUpperBound(1) < this.ai.game.Data.MapObj[0].MapHeight)
        this.ai.SetTempHexNeighbours();
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] == specificVal & numArray[tx, index1] == num1)
            {
              int index2 = 0;
              do
              {
                Coordinate coordinate = this.ai.TempHexNeighbour[tx, index1, index2];
                if (coordinate.onmap && coordinate.x <= this.Width & coordinate.y <= this.Height && this.Value[coordinate.x, coordinate.y] != specificVal && this.ai.game.Data.MapObj[0].HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].Regime == this.ai.game.Data.MapObj[0].HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].Regime && mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].Regime > -1)
                {
                  num2 += 1;
                  this.Value[coordinate.x, coordinate.y] = this.Value[tx, index1];
                  numArray[coordinate.x, coordinate.y] = num1 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1 + 1);
    }

    pub void ExpandSpecificValueForSameRegimeWithinMask(
      int specificVal,
      int MaxSteps,
      ref AIMatrix mask)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1 = -1;
      int num2;
      do
      {
        num2 = 0;
        num1 += 1;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (this.Value[tx, index1] == specificVal & numArray[tx, index1] == num1 & mask.Value[tx, index1] > 0)
            {
              int index2 = 0;
              do
              {
                Coordinate coordinate = this.ai.TempHexNeighbour[tx, index1, index2];
                if (coordinate.onmap && coordinate.x <= this.Width & coordinate.y <= this.Height && this.Value[coordinate.x, coordinate.y] != specificVal & mask.Value[coordinate.x, coordinate.y] > 0 && this.ai.game.Data.MapObj[0].HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].Regime == this.ai.game.Data.MapObj[0].HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].Regime && mapClass.HexObj[this.ai.GetRealX(coordinate.x, this.Left), coordinate.y + this.Top].Regime > -1)
                {
                  num2 += 1;
                  this.Value[coordinate.x, coordinate.y] = this.Value[tx, index1];
                  numArray[coordinate.x, coordinate.y] = num1 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
      }
      while (num2 > 0 & MaxSteps > num1 + 1);
    }

    pub void ExpandAndAddValueForSameRegime(int MaxValue)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1;
      int num2;
      do
      {
        num1 = 0;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (numArray[tx, index1] == num2 && this.Value[tx, index1] > 0 & this.Value[tx, index1] < MaxValue)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > this.Value[tx, index1] + 1 && mapClass.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].Regime == mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[tx, index1, index2].x, this.Left), this.ai.TempHexNeighbour[tx, index1, index2].y + this.Top].Regime)
                {
                  num1 += 1;
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num2 + 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1] + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        num2 += 1;
      }
      while (num1 > 0 & num2 < MaxValue);
    }

    pub void ExpandAndAddValueForSameOwner_FAST(int MaxValue, ref AIMatrix tOwnerMat)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      CoordList coordList = CoordList::new();
      int width = this.Width;
      for (int x = 0; x <= width; x += 1)
      {
        int height = this.Height;
        for (int y = 0; y <= height; y += 1)
        {
          if (this.ai.game.Data.Turn == mapClass.HexObj[x, y].Regime & this.Value[x, y] > 0)
            coordList.AddCoord(x, y, 0);
        }
      }
      for (int index1 = 0; index1 <= coordList.counter; index1 += 1)
      {
        int x = coordList.coord[index1].x;
        int y = coordList.coord[index1].y;
        if (this.ai.game.Data.Turn == mapClass.HexObj[x, y].Regime & this.Value[x, y] > 0 & this.Value[x, y] < MaxValue)
        {
          int index2 = 0;
          do
          {
            if (this.ai.TempHexNeighbour[x, y, index2].onmap && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y] > this.Value[x, y] + 1 && tOwnerMat.Value[x, y] == tOwnerMat.Value[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y])
            {
              coordList.AddCoord(this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y, 0);
              this.Value[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y] = this.Value[x, y] + 1;
            }
            index2 += 1;
          }
          while (index2 <= 5);
        }
      }
    }

    pub void ExpandAndAddValueForSameOwner(int MaxValue, ref AIMatrix tOwnerMat)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1;
      int num2;
      do
      {
        num1 = 0;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (numArray[tx, index1] == num2 && this.Value[tx, index1] > 0 & this.Value[tx, index1] < MaxValue)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > this.Value[tx, index1] + 1 && tOwnerMat.Value[tx, index1] == tOwnerMat.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y])
                {
                  num1 += 1;
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num2 + 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1] + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        num2 += 1;
      }
      while (num1 > 0 & num2 < MaxValue);
    }

    pub void SetLandscapeValues(ref SimpleList LTSL, int multiplier)
    {
      int[] numArray = new int[this.ai.game.Data.LandscapeTypeCounter + 2 + 1];
      int landscapeTypeCounter = this.ai.game.Data.LandscapeTypeCounter;
      for (int tid = 0; tid <= landscapeTypeCounter; tid += 1)
      {
        int index;
        numArray[index] = LTSL.FindNr(tid);
      }
      int width = this.Width;
      for (int index1 = 0; index1 <= width; index1 += 1)
      {
        int height = this.Height;
        for (int index2 = 0; index2 <= height; index2 += 1)
        {
          int landscapeType = this.ai.game.Data.MapObj[0].HexObj[index1, index2].LandscapeType;
          int index3 = numArray[landscapeType];
          this.Value[index1, index2] = LTSL.Weight[index3] * multiplier;
        }
      }
    }

    pub void ExpandAndAddValueForLandscapeTypeAndSameRegime(ref SimpleList LTSL, int MaxValue)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[] numArray = new int[this.ai.game.Data.LandscapeTypeCounter + 1];
      int landscapeTypeCounter = this.ai.game.Data.LandscapeTypeCounter;
      for (int tid = 0; tid <= landscapeTypeCounter; tid += 1)
      {
        int nr = LTSL.FindNr(tid);
        numArray[tid] = nr <= -1 ? 9999 : LTSL.Weight[nr];
      }
      CoordList coordList = CoordList::new();
      int width = this.Width;
      for (int x = 0; x <= width; x += 1)
      {
        int height = this.Height;
        for (int y = 0; y <= height; y += 1)
        {
          if (this.ai.game.Data.Turn == mapClass.HexObj[x, y].Regime & this.Value[x, y] > 0)
            coordList.AddCoord(x, y, 0);
        }
      }
      for (int index1 = 0; index1 <= coordList.counter; index1 += 1)
      {
        int x = coordList.coord[index1].x;
        int y = coordList.coord[index1].y;
        if (this.ai.game.Data.Turn == mapClass.HexObj[x, y].Regime & this.Value[x, y] > 0 & this.Value[x, y] < MaxValue)
        {
          int index2 = 0;
          do
          {
            if (this.ai.TempHexNeighbour[x, y, index2].onmap && this.ai.TempHexNeighbour[x, y, index2].x <= this.Width & this.ai.TempHexNeighbour[x, y, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(x, this.Left), y + this.Top].LandscapeType].AIBlock < 1)
            {
              int landscapeType = this.ai.game.Data.MapObj[0].HexObj[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y].LandscapeType;
              int num = numArray[landscapeType];
              if (this.ai.game.Data.MapObj[0].HexObj[x, y].RoadType[index2] > -1)
                num = 1;
              if (this.Value[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y] > this.Value[x, y] + num && this.ai.game.Data.Turn == mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[x, y, index2].x, this.Left), this.ai.TempHexNeighbour[x, y, index2].y + this.Top].Regime)
              {
                coordList.AddCoord(this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y, 0);
                this.Value[this.ai.TempHexNeighbour[x, y, index2].x, this.ai.TempHexNeighbour[x, y, index2].y] = this.Value[x, y] + num;
              }
            }
            index2 += 1;
          }
          while (index2 <= 5);
        }
      }
    }

    pub void ExpandAndAddValueForAnyRegime(int MaxValue, bool blockSea = false)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1;
      int num2;
      do
      {
        num1 = 0;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (numArray[tx, index1] == num2 && this.Value[tx, index1] > 0 & this.Value[tx, index1] < MaxValue)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 & (!blockSea | !this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].IsSea) && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] > this.Value[tx, index1] + 1 && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[tx, index1, index2].x, this.Left), this.ai.TempHexNeighbour[tx, index1, index2].y + this.Top].Regime > -1)
                {
                  num1 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1] + 1;
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num2 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        num2 += 1;
      }
      while (num1 > 0 & num2 < MaxValue);
    }

    pub void ExpandAndRemoveValueForAnyRegime(int MaxValue, bool anyhex = false)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1;
      int num2;
      do
      {
        num1 = 0;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (numArray[tx, index1] == num2 && this.Value[tx, index1] > 0)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 | anyhex && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] < this.Value[tx, index1] - 1 && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[tx, index1, index2].x, this.Left), this.ai.TempHexNeighbour[tx, index1, index2].y + this.Top].Regime > -1 | anyhex)
                {
                  num1 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = this.Value[tx, index1] - 1;
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num2 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        num2 += 1;
      }
      while (num1 > 0 & num2 < MaxValue);
    }

    pub void ExpandAndRemovePercentageForAnyRegime(int MaxValue, float moddy, bool anyhex = false)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      int[,] numArray = new int[this.Width + 1, this.Height + 1];
      int num1;
      int num2;
      do
      {
        num1 = 0;
        int width = this.Width;
        for (int tx = 0; tx <= width; tx += 1)
        {
          int height = this.Height;
          for (int index1 = 0; index1 <= height; index1 += 1)
          {
            if (numArray[tx, index1] == num2 && this.Value[tx, index1] > 0)
            {
              int index2 = 0;
              do
              {
                if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.ai.game.Data.LandscapeTypeObj[this.ai.map.HexObj[this.ai.GetRealX(tx, this.Left), index1 + this.Top].LandscapeType].AIBlock < 1 | anyhex && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0 | this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] < this.Value[tx, index1] - 1 && mapClass.HexObj[this.ai.GetRealX(this.ai.TempHexNeighbour[tx, index1, index2].x, this.Left), this.ai.TempHexNeighbour[tx, index1, index2].y + this.Top].Regime > -1 | anyhex)
                {
                  num1 += 1;
                  this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = (int) Math.Round((double) ((float) this.Value[tx, index1] * moddy));
                  numArray[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = num2 + 1;
                }
                index2 += 1;
              }
              while (index2 <= 5);
            }
          }
        }
        num2 += 1;
      }
      while (num1 > 0 & num2 < MaxValue);
    }

    pub AIMatrix DetectAndMakeEdgeMatrix(bool AlsoForInaccesible)
    {
      MapClass mapClass = this.ai.game.Data.MapObj[0];
      AIMatrix aiMatrix = new AIMatrix(ref this.ai, this.Width, this.Height, this.Top, this.Left);
      int width = this.Width;
      for (int tx = 0; tx <= width; tx += 1)
      {
        int height = this.Height;
        for (int index1 = 0; index1 <= height; index1 += 1)
        {
          if (this.Value[tx, index1] > 0 && this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[tx, index1].LandscapeType].AIBlock < 1)
          {
            if (tx == 23 & index1 == 55)
              tx = tx;
            int index2 = 0;
            do
            {
              if (this.ai.TempHexNeighbour[tx, index1, index2].onmap && this.ai.TempHexNeighbour[tx, index1, index2].x <= this.Width & this.ai.TempHexNeighbour[tx, index1, index2].y <= this.Height && this.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] == 0)
              {
                if (!AlsoForInaccesible)
                {
                  if (!this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.TempHexNeighbour[this.ai.GetRealX(tx, this.Left), this.Top + index1, index2].x, this.ai.TempHexNeighbour[this.ai.GetRealX(tx, this.Left), this.Top + index1, index2].y].LandscapeType].IsSea && this.ai.game.Data.LandscapeTypeObj[mapClass.HexObj[this.ai.TempHexNeighbour[this.ai.GetRealX(tx, this.Left), this.Top + index1, index2].x, this.ai.TempHexNeighbour[this.ai.GetRealX(tx, this.Left), this.Top + index1, index2].y].LandscapeType].AIBlock < 1)
                    aiMatrix.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = 1;
                }
                else
                  aiMatrix.Value[this.ai.TempHexNeighbour[tx, index1, index2].x, this.ai.TempHexNeighbour[tx, index1, index2].y] = 1;
              }
              index2 += 1;
            }
            while (index2 <= 5);
          }
        }
      }
      return aiMatrix;
    }
  }
}
