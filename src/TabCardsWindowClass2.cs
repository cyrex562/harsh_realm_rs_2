// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabCardsWindowClass2
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
  public class TabCardsWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private int w;
    private int h;
    private int detailnr;
    private int hovernr;
    private int lastActualCard;
    private int currentCat;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int pageId;
    private int miniId;
    private int tSelectX;
    private int tSelectY;
    private int tSelectMap;
    private int tCornerX;
    private int tCornerY;
    private int categoryCount;
    private string[] categoryName;
    private int[] categorySelectMode;
    private int maxMiniSelectValue;
    private int miniSelectX;
    private int miniSelectY;
    private int miniSelectValue;
    private int miniUnitSelect;
    private int miniSelectLeader;
    private int miniCatSelectValue;
    private bool[,] cardPlayable;
    private string[,] cardWhyNot;
    private bool donePrepareCardPlayable;
    private AIMatrix zones;
    private string[] zoneName;
    private bool[] zoneVisible;
    private int[] zoneRegimeId;
    private int mouseOverWhichTab;
    private int viewMode;
    private string rememberExtraS;
    private int pageNr;
    private int nextId;
    private int prevId;
    private int next2Id;
    private int prev2Id;
    private int sizeId;
    private int scrapId;
    private int buyScrapId;
    private int buyScrapId2;
    private bool first;
    private bool scrapMode;
    private int scrapMouseOver;
    private int cardSize;

    public TabCardsWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.categoryName = new string[20];
      this.categorySelectMode = new int[20];
      this.cardPlayable = new bool[1, 1];
      this.cardWhyNot = new string[1, 1];
      this.zoneName = new string[1];
      this.zoneVisible = new bool[1];
      this.zoneRegimeId = new int[1];
      this.scrapMode = false;
      this.scrapMouseOver = 0;
      this.w = trect.Width;
      this.h = trect.Height;
      this.detailnr = -1;
      this.lastActualCard = -1;
      this.hovernr = -1;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.viewMode = 1;
      this.cardSize = 2;
      if (this.w < 1200)
        this.cardSize = 1;
      this.first = true;
      this.game.DC2AIObj.SetTempHexNeighbours();
      this.zones = new AIMatrix(ref tGame.DC2AIObj);
      int mapWidth = tGame.Data.MapObj[0].MapWidth;
      int mapHeight = tGame.Data.MapObj[0].MapHeight;
      DataClass data = tGame.Data;
      string str = "Zones";
      ref string local = ref str;
      int libVar = data.FindLibVar(ref local, "SE_Data");
      int num1 = mapWidth;
      for (int index1 = 0; index1 <= num1; ++index1)
      {
        int num2 = mapHeight;
        for (int index2 = 0; index2 <= num2; ++index2)
          this.zones.Value[index1, index2] = tGame.Data.MapObj[0].HexObj[index1, index2].GetHexLibVarValue(libVar);
      }
      this.currentCat = 1;
      this.categoryCount = 9;
      this.categoryName[1] = "Majors";
      this.categorySelectMode[1] = 1;
      this.categoryName[2] = "Minors";
      this.categorySelectMode[2] = 1;
      this.categoryName[3] = "Covert Ops";
      this.categorySelectMode[3] = 2;
      this.categoryName[4] = "Nation";
      this.categorySelectMode[4] = 0;
      this.categoryName[5] = "Tariffs";
      this.categorySelectMode[5] = 1;
      this.categoryName[6] = "HQs";
      this.categorySelectMode[6] = 3;
      this.categoryName[7] = "Zones";
      this.categorySelectMode[7] = 2;
      this.categoryName[8] = "Leaders";
      this.categorySelectMode[8] = 4;
      this.categoryName[9] = "Units";
      this.categorySelectMode[9] = 5;
      this.miniSelectValue = -1;
      this.miniSelectLeader = -1;
      this.game.EditObj.MiniMap = new Bitmap(10, 10);
      this.miniSelectX = this.game.SelectX;
      this.miniSelectY = this.game.SelectY;
      this.miniUnitSelect = this.game.EditObj.UnitSelected;
      this.miniCatSelectValue = -1;
      if (this.game.EditObj.se1_CardsCategory > 0)
      {
        this.currentCat = this.game.EditObj.se1_CardsCategory;
        this.pageNr = this.game.EditObj.se1_CardsPage;
        if (this.categorySelectMode[this.currentCat] == 4)
        {
          this.miniSelectLeader = this.game.EditObj.se1_CardsTarget;
          this.miniSelectValue = (int) Math.Round(Conversion.Val((object) this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0))].FindRow(0, this.miniSelectLeader)));
          if (this.miniSelectValue < 0)
            this.miniSelectLeader = -1;
        }
        if (this.categorySelectMode[this.currentCat] == 3)
        {
          this.miniUnitSelect = this.game.EditObj.se1_CardsTarget;
          if (this.miniUnitSelect > this.game.Data.UnitCounter | this.miniUnitSelect < 1)
            this.miniUnitSelect = -1;
          else if (this.game.Data.UnitObj[this.miniUnitSelect].Historical == -1)
            this.miniUnitSelect = -1;
        }
        if (this.categorySelectMode[this.currentCat] == 5)
        {
          this.miniUnitSelect = this.game.EditObj.se1_CardsTarget;
          if (this.miniUnitSelect > this.game.Data.UnitCounter | this.miniUnitSelect < 1)
            this.miniUnitSelect = -1;
          else if (this.game.Data.UnitObj[this.miniUnitSelect].Historical == -1)
            this.miniUnitSelect = -1;
        }
        if (this.categorySelectMode[this.currentCat] == 1)
        {
          this.miniSelectValue = this.game.EditObj.se1_CardsTarget;
          if (this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0))].FindRow(0, this.miniSelectValue) < 0)
            this.miniSelectValue = -1;
          bool flag = false;
          if (this.game.EditObj.se1_CardsSelectX > -1 & this.game.EditObj.se1_CardsSelectY > -1 & this.game.EditObj.se1_CardsSelectX <= this.game.Data.MapObj[0].MapWidth & this.game.EditObj.se1_CardsSelectY <= this.game.Data.MapObj[0].MapHeight)
          {
            if (this.game.Data.MapObj[0].HexObj[this.game.EditObj.se1_CardsSelectX, this.game.EditObj.se1_CardsSelectY].Regime > -1)
            {
              if (this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[this.game.EditObj.se1_CardsSelectX, this.game.EditObj.se1_CardsSelectY].Regime].id != this.miniSelectValue)
                flag = true;
            }
            else
              flag = true;
          }
          if (this.miniSelectValue > 0 & flag)
          {
            int num3 = -1;
            int num4 = -1;
            int num5 = 0;
            do
            {
              int num6 = mapWidth;
              for (int index3 = 0; index3 <= num6; ++index3)
              {
                int num7 = mapHeight;
                for (int index4 = 0; index4 <= num7; ++index4)
                {
                  if (this.game.Data.MapObj[0].HexObj[index3, index4].Regime > -1 && num5 == 1 | this.game.Data.MapObj[0].HexObj[index3, index4].MaxRecon > 0 && this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[index3, index4].Regime].id == this.miniSelectValue & num3 == -1)
                  {
                    num3 = index3;
                    num4 = index4;
                  }
                }
              }
              ++num5;
            }
            while (num5 <= 1);
            if (num3 > -1)
            {
              this.game.EditObj.se1_CardsSelectX = num3;
              this.game.EditObj.se1_CardsSelectY = num4;
            }
            else
              this.miniSelectValue = -1;
          }
        }
        if (this.categorySelectMode[this.currentCat] == 2)
        {
          this.miniSelectValue = this.game.EditObj.se1_CardsTarget;
          if (this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0))].FindRow(0, this.miniSelectValue) < 0)
            this.miniSelectValue = -1;
          bool flag = false;
          if (this.game.EditObj.se1_CardsSelectX > -1 & this.game.EditObj.se1_CardsSelectY > -1 && this.zones.Value[this.game.EditObj.se1_CardsSelectX, this.game.EditObj.se1_CardsSelectY] != this.miniSelectValue)
            flag = true;
          if (this.miniSelectValue > 0 & flag)
          {
            int num8 = -1;
            int num9 = -1;
            int num10 = 0;
            do
            {
              int num11 = mapWidth;
              for (int index5 = 0; index5 <= num11; ++index5)
              {
                int num12 = mapHeight;
                for (int index6 = 0; index6 <= num12; ++index6)
                {
                  if (num10 == 1 | this.game.Data.MapObj[0].HexObj[index5, index6].MaxRecon > 0 && this.zones.Value[index5, index6] == this.miniSelectValue & num8 == -1)
                  {
                    num8 = index5;
                    num9 = index6;
                  }
                }
              }
              ++num10;
            }
            while (num10 <= 1);
            if (num8 > -1)
            {
              this.game.EditObj.se1_CardsSelectX = num8;
              this.game.EditObj.se1_CardsSelectY = num9;
            }
            else
              this.miniSelectValue = -1;
          }
        }
        if (this.game.EditObj.se1_CardsCard > -1)
        {
          int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter;
          for (int index = 0; index <= actionCardCounter; ++index)
          {
            if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index]].TempVar0 == this.game.EditObj.se1_CardsCard)
            {
              this.detailnr = index;
              break;
            }
          }
        }
        if (this.game.EditObj.se1_CardsSmallCards > 0)
          this.cardSize = this.game.EditObj.se1_CardsSmallCards;
        if (this.game.EditObj.se1_CardsViewMode > 0)
          this.viewMode = this.game.EditObj.se1_CardsViewMode;
        this.miniSelectX = this.game.EditObj.se1_CardsSelectX;
        this.miniSelectY = this.game.EditObj.se1_CardsSelectY;
      }
      if (this.miniSelectX < 0 | this.miniSelectY < 0)
      {
        this.miniSelectX = this.game.SelectX;
        this.miniSelectY = this.game.SelectY;
      }
      this.prepareTempValue4();
      this.donePrepareCardPlayable = false;
      this.dostuff();
    }

    public void CopyToEditObj()
    {
      this.game.EditObj.se1_CardsCategory = this.currentCat;
      if (this.categorySelectMode[this.currentCat] == 4)
        this.game.EditObj.se1_CardsTarget = this.miniSelectLeader;
      else if (this.categorySelectMode[this.currentCat] == 3)
        this.game.EditObj.se1_CardsTarget = this.miniUnitSelect;
      else if (this.categorySelectMode[this.currentCat] == 5)
        this.game.EditObj.se1_CardsTarget = this.miniUnitSelect;
      else if (this.categorySelectMode[this.currentCat] == 1)
        this.game.EditObj.se1_CardsTarget = this.miniSelectValue;
      else if (this.categorySelectMode[this.currentCat] == 2)
        this.game.EditObj.se1_CardsTarget = this.miniSelectValue;
      this.game.EditObj.se1_CardsPage = this.pageNr;
      if (this.detailnr > -1)
        this.game.EditObj.se1_CardsCard = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].TempVar0;
      else
        this.game.EditObj.se1_CardsCard = -1;
      this.game.EditObj.se1_CardsSmallCards = this.cardSize;
      this.game.EditObj.se1_CardsViewMode = this.viewMode;
      this.game.EditObj.se1_CardsSelectX = this.miniSelectX;
      this.game.EditObj.se1_CardsSelectY = this.miniSelectY;
    }

    public void prepareTempValue4()
    {
      this.game.HandyFunctionsObj.RedimTempValue4(-1);
      this.game.HandyFunctionsObj.RedimTempValue3(-1);
      this.game.EditObj.TempAI = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.game.EditObj.TempAI2 = new int[this.game.Data.MapObj[0].MapWidth + 1, this.game.Data.MapObj[0].MapHeight + 1];
      this.maxMiniSelectValue = -1;
      bool[] flagArray = new bool[this.game.Data.RegimeCounter + 1];
      if (this.categorySelectMode[this.currentCat] == 1)
      {
        int mapWidth = this.game.Data.MapObj[0].MapWidth;
        for (int index1 = 0; index1 <= mapWidth; ++index1)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index2 = 0; index2 <= mapHeight; ++index2)
          {
            int regime = this.game.Data.MapObj[0].HexObj[index1, index2].Regime;
            if (regime > -1)
            {
              flagArray[regime] = true;
              this.game.EditObj.TempValue4[0].Value[index1, index2] = this.game.Data.RegimeObj[regime].id;
              if (index1 == this.miniSelectX & index2 == this.miniSelectY)
                this.miniSelectValue = this.game.Data.RegimeObj[regime].id;
            }
          }
        }
      }
      AIMatrix specialMask = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
      if (this.categorySelectMode[this.currentCat] == 2)
      {
        int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
        for (int index3 = 0; index3 <= mapWidth1; ++index3)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index4 = 0; index4 <= mapHeight; ++index4)
          {
            int num = this.zones.Value[index3, index4];
            if (num > 0 & (this.game.Data.MapObj[0].HexObj[index3, index4].MaxRecon > 0 | !this.game.Data.ShrowdOn))
            {
              this.game.EditObj.TempValue4[0].Value[index3, index4] = num;
              if (index3 == this.miniSelectX & index4 == this.miniSelectY)
                this.miniSelectValue = num;
              if (num > this.maxMiniSelectValue)
                this.maxMiniSelectValue = num;
            }
            specialMask.Value[index3, index4] = 0;
            if (this.game.Data.MapObj[0].HexObj[index3, index4].MaxRecon > 0 | !this.game.Data.ShrowdOn)
            {
              if ((this.game.Data.MapObj[0].HexObj[index3, index4].MaxRecon > 0 | !this.game.Data.ShrowdOn) & this.game.Data.MapObj[0].HexObj[index3, index4].Regime > -1)
                specialMask.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].Regime + 2;
              else if (this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn) > 0)
                specialMask.Value[index3, index4] = this.game.Data.MapObj[0].HexObj[index3, index4].get_LastReg(this.game.Data.Turn) + 2;
            }
          }
        }
        if (this.game.Data.UnitCounter > this.maxMiniSelectValue)
          this.maxMiniSelectValue = this.game.Data.UnitCounter;
        if (this.maxMiniSelectValue > 0)
        {
          int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0));
          if (this.maxMiniSelectValue < this.game.Data.StringListObj[stringListById1].GetHighestValue(0))
            this.maxMiniSelectValue = this.game.Data.StringListObj[stringListById1].GetHighestValue(0);
          this.zoneName = new string[this.maxMiniSelectValue + 1];
          this.zoneRegimeId = new int[this.maxMiniSelectValue + 1];
          this.zoneVisible = new bool[this.maxMiniSelectValue + 1];
          int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 288, 0, 0));
          int length = this.game.Data.StringListObj[stringListById1].Length;
          for (int index = 0; index <= length; ++index)
          {
            int idValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index, 0]));
            int num = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index, 8]));
            string str = this.game.Data.StringListObj[stringListById1].Data[index, 7];
            this.zoneName[idValue2] = str;
            this.zoneRegimeId[idValue2] = num;
            if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, idValue2, 2, "recon", 3))) > -1 | num == this.game.Data.RegimeObj[this.game.Data.Turn].id)
              this.zoneVisible[idValue2] = true;
          }
          int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
          for (int index5 = 0; index5 <= mapWidth2; ++index5)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index6 = 0; index6 <= mapHeight; ++index6)
            {
              int index7 = this.zones.Value[index5, index6];
              if (index7 > 0 & (this.game.Data.MapObj[0].HexObj[index5, index6].MaxRecon > 0 | !this.game.Data.ShrowdOn))
                this.zoneVisible[index7] = true;
            }
          }
        }
      }
      if (this.categorySelectMode[this.currentCat] == 1 | this.categorySelectMode[this.currentCat] == 2)
      {
        AIMatrix aiMatrix1 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
        AIMatrix aiMatrix2 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
        AIMatrix aiMatrix3 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
        AIMatrix aiMatrix4 = new AIMatrix(ref this.game.DC2AIObj, this.game.Data.MapObj[0].MapWidth, this.game.Data.MapObj[0].MapHeight, 0, 0);
        int mapWidth3 = this.game.Data.MapObj[0].MapWidth;
        for (int index8 = 0; index8 <= mapWidth3; ++index8)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index9 = 0; index9 <= mapHeight; ++index9)
          {
            this.game.EditObj.TempAI[index8, index9] = 0;
            aiMatrix4.Value[index8, index9] = this.game.Data.MapObj[0].HexObj[index8, index9].get_LastLT(this.game.Data.Turn);
            if (aiMatrix4.Value[index8, index9] < 0)
              aiMatrix4.Value[index8, index9] = 0;
            if (this.game.Data.MapObj[0].HexObj[index8, index9].MaxRecon > 0 | !this.game.Data.ShrowdOn)
            {
              aiMatrix1.Value[index8, index9] = (int) byte.MaxValue;
              aiMatrix2.Value[index8, index9] = this.game.EditObj.TempValue4[0].Value[index8, index9];
              if (aiMatrix2.Value[index8, index9] <= 0)
                aiMatrix2.Value[index8, index9] = 999999;
              aiMatrix3.Value[index8, index9] = this.game.Data.MapObj[0].HexObj[index8, index9].Regime + 2;
              aiMatrix4.Value[index8, index9] = this.game.Data.MapObj[0].HexObj[index8, index9].LandscapeType + 1;
            }
            else if (this.game.Data.MapObj[0].HexObj[index8, index9].get_LastReg(this.game.Data.Turn) > -1 && flagArray[this.game.Data.MapObj[0].HexObj[index8, index9].get_LastReg(this.game.Data.Turn)])
            {
              aiMatrix1.Value[index8, index9] = (int) byte.MaxValue;
              aiMatrix2.Value[index8, index9] = this.game.EditObj.TempValue4[0].Value[index8, index9];
              if (aiMatrix2.Value[index8, index9] <= 0 & this.categorySelectMode[this.currentCat] == 1)
                aiMatrix2.Value[index8, index9] = 999999;
              aiMatrix3.Value[index8, index9] = this.game.Data.MapObj[0].HexObj[index8, index9].get_LastReg(this.game.Data.Turn) + 2;
              aiMatrix4.Value[index8, index9] = this.game.Data.MapObj[0].HexObj[index8, index9].get_LastLT(this.game.Data.Turn) + 1;
            }
          }
        }
        if (this.categorySelectMode[this.currentCat] == 2)
          specialMask.ExpandAllNonZeroValuesForAnyRegime(15);
        aiMatrix1.ExpandAndRemovePercentageForAnyRegime((int) byte.MaxValue, 0.8f, true);
        if (this.categorySelectMode[this.currentCat] == 2)
          aiMatrix2.ExpandAllNonZeroValuesForAnyRegime(15, specialMask);
        else
          aiMatrix2.ExpandAllNonZeroValuesForAnyRegime(15);
        aiMatrix3.ExpandAllNonZeroValuesForAnyRegime(15);
        aiMatrix4.ExpandAllNonZeroValuesForAnyRegime(15);
        int mapWidth4 = this.game.Data.MapObj[0].MapWidth;
        for (int index10 = 0; index10 <= mapWidth4; ++index10)
        {
          int mapHeight = this.game.Data.MapObj[0].MapHeight;
          for (int index11 = 0; index11 <= mapHeight; ++index11)
          {
            if (this.game.Data.MapObj[0].HexObj[index10, index11].MaxRecon > 0 | !this.game.Data.ShrowdOn)
            {
              aiMatrix1.Value[index10, index11] = (int) byte.MaxValue;
              aiMatrix2.Value[index10, index11] = this.game.EditObj.TempValue4[0].Value[index10, index11];
              aiMatrix3.Value[index10, index11] = this.game.Data.MapObj[0].HexObj[index10, index11].Regime + 2;
              aiMatrix4.Value[index10, index11] = this.game.Data.MapObj[0].HexObj[index10, index11].LandscapeType + 1;
            }
            else if (this.game.Data.MapObj[0].HexObj[index10, index11].get_LastReg(this.game.Data.Turn) > 0)
            {
              aiMatrix1.Value[index10, index11] = (int) byte.MaxValue;
              if (this.categorySelectMode[this.currentCat] == 1)
                aiMatrix2.Value[index10, index11] = this.game.EditObj.TempValue4[0].Value[index10, index11];
              aiMatrix3.Value[index10, index11] = this.game.Data.MapObj[0].HexObj[index10, index11].get_LastReg(this.game.Data.Turn) + 2;
              aiMatrix4.Value[index10, index11] = this.game.Data.MapObj[0].HexObj[index10, index11].get_LastLT(this.game.Data.Turn) + 1;
            }
            else if (aiMatrix1.Value[index10, index11] < 20)
            {
              aiMatrix1.Value[index10, index11] = 0;
              aiMatrix2.Value[index10, index11] = 0;
              aiMatrix3.Value[index10, index11] = 0;
              aiMatrix4.Value[index10, index11] = 0;
            }
            if (aiMatrix2.Value[index10, index11] == 999999)
              aiMatrix2.Value[index10, index11] = 0;
            if (this.categorySelectMode[this.currentCat] == 1)
            {
              this.game.EditObj.TempValue4[0].Value[index10, index11] = 0;
              if (aiMatrix3.Value[index10, index11] > 1)
                this.game.EditObj.TempValue4[0].Value[index10, index11] = this.game.Data.RegimeObj[aiMatrix3.Value[index10, index11] - 2].id;
            }
            else
              this.game.EditObj.TempValue4[0].Value[index10, index11] = aiMatrix2.Value[index10, index11];
            this.game.EditObj.TempValue3[0].Value[index10, index11] = aiMatrix1.Value[index10, index11];
            this.game.EditObj.TempAI[index10, index11] = aiMatrix3.Value[index10, index11] - 2;
            this.game.EditObj.TempAI2[index10, index11] = aiMatrix4.Value[index10, index11] - 1;
          }
        }
      }
      int regimeCounter = this.game.Data.RegimeCounter;
      for (int index = 0; index <= regimeCounter; ++index)
      {
        if (this.game.Data.RegimeObj[index].id > this.maxMiniSelectValue)
        {
          this.maxMiniSelectValue = this.game.Data.RegimeObj[index].id;
          this.zoneName = (string[]) Utils.CopyArray((Array) this.zoneName, (Array) new string[this.maxMiniSelectValue + 1]);
          this.zoneRegimeId = (int[]) Utils.CopyArray((Array) this.zoneRegimeId, (Array) new int[this.maxMiniSelectValue + 1]);
          this.zoneVisible = (bool[]) Utils.CopyArray((Array) this.zoneVisible, (Array) new bool[this.maxMiniSelectValue + 1]);
        }
      }
    }

    public void prepareCardPlayable(SimpleList SL)
    {
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 277, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 184, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 188, 0, 0));
      if (this.donePrepareCardPlayable)
        return;
      if (this.game.Data.UnitCounter > this.maxMiniSelectValue)
        this.maxMiniSelectValue = this.game.Data.UnitCounter;
      if (this.game.Data.StringListObj[stringListById1].Length + 10 > this.maxMiniSelectValue)
        this.maxMiniSelectValue = this.game.Data.StringListObj[stringListById1].Length + 10;
      this.cardPlayable = new bool[SL.Counter + 1, this.maxMiniSelectValue + 1];
      this.cardWhyNot = new string[SL.Counter + 1, this.maxMiniSelectValue + 1];
      int counter = SL.Counter;
      for (int index1 = 0; index1 <= counter; ++index1)
      {
        int cardinhandnr = SL.Data1[index1];
        int index2 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[cardinhandnr];
        if (this.game.Data.ActionCardObj[index2].AreaSlot > -1)
        {
          int index3;
          if (Strings.InStr(this.game.Data.ActionCardObj[index2].Title, "Zoo") > 0)
            index3 = index3;
          this.game.EditObj.DoCardSlot = cardinhandnr;
          this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, cardinhandnr);
          if (this.categorySelectMode[this.currentCat] == 1)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index4 = 0; index4 <= mapWidth; ++index4)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index5 = 0; index5 <= mapHeight; ++index5)
              {
                index3 = this.game.Data.MapObj[0].HexObj[index4, index5].Regime;
                if (index3 > -1)
                {
                  int id = this.game.Data.RegimeObj[index3].id;
                  if (this.game.Data.MapObj[0].HexObj[index4, index5].AreaCode[0] > 0)
                    this.cardPlayable[index1, id] = true;
                  else
                    this.cardWhyNot[index1, id] = this.game.EditObj.TempString2[0].Value[index4, index5];
                }
              }
            }
          }
          if (this.categorySelectMode[this.currentCat] == 2)
          {
            int mapWidth = this.game.Data.MapObj[0].MapWidth;
            for (int index6 = 0; index6 <= mapWidth; ++index6)
            {
              int mapHeight = this.game.Data.MapObj[0].MapHeight;
              for (int index7 = 0; index7 <= mapHeight; ++index7)
              {
                index3 = this.zones.Value[index6, index7];
                if (index3 > -1)
                {
                  if (this.game.Data.MapObj[0].HexObj[index6, index7].AreaCode[0] > 0)
                    this.cardPlayable[index1, index3] = true;
                  else
                    this.cardWhyNot[index1, index3] = this.game.EditObj.TempString2[0].Value[index6, index7];
                }
              }
            }
          }
        }
        else if (this.game.Data.ActionCardObj[index2].UnitSelect)
        {
          this.game.EditObj.DoCardSlot = cardinhandnr;
          this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, cardinhandnr);
          if (this.categorySelectMode[this.currentCat] == 3)
          {
            int unitCounter = this.game.Data.UnitCounter;
            for (int index8 = 0; index8 <= unitCounter; ++index8)
            {
              if (this.game.Data.UnitObj[index8].TempUnitSelectable)
                this.cardPlayable[index1, index8] = true;
              else
                this.cardWhyNot[index1, index8] = "These cards can only be played on HQ units";
            }
          }
          if (this.categorySelectMode[this.currentCat] == 5)
          {
            int unitCounter = this.game.Data.UnitCounter;
            for (int index9 = 0; index9 <= unitCounter; ++index9)
            {
              if (this.game.Data.UnitObj[index9].TempUnitSelectable)
                this.cardPlayable[index1, index9] = true;
              else
                this.cardWhyNot[index1, index9] = "These cards can only be played on non-HQ units";
            }
          }
        }
        else if (this.categorySelectMode[this.currentCat] == 4)
        {
          this.game.EditObj.DoCardSlot = cardinhandnr;
          this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, cardinhandnr);
          int length = this.game.Data.StringListObj[stringListById1].Length;
          for (int index10 = 0; index10 <= length; ++index10)
          {
            if (this.game.EditObj.tempOtherTest[index10] == 1)
            {
              this.cardPlayable[index1, index10] = true;
            }
            else
            {
              if (this.game.Data.ActionCardObj[index2].TempVar0 == 522)
                index1 = index1;
              this.cardWhyNot[index1, index10] = this.game.EditObj.tempOtherTestText[index10];
              this.cardPlayable[index1, index10] = false;
            }
            if (this.categorySelectMode[this.currentCat] == 4)
            {
              int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 277, 0, 0));
              int idValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, this.game.Data.ActionCardObj[index2].TempVar0, 5)));
              int jobSpecificId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData2(1, idValue1, 2, this.game.Data.RegimeObj[this.game.Data.Turn].id, 0)));
              int num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue1, 2)));
              if (jobSpecificId < 1)
              {
                int idValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, this.game.Data.ActionCardObj[index2].TempVar0, 14)));
                jobSpecificId = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData2(1, idValue2, 2, this.game.Data.RegimeObj[this.game.Data.Turn].id, 0)));
                num1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById3].GetData(0, idValue2, 2)));
              }
              int idValue2_1 = -1;
              if (jobSpecificId > 0)
              {
                switch (num1)
                {
                  case 1:
                    idValue2_1 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 5, jobSpecificId, -1);
                    break;
                  case 2:
                    idValue2_1 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 9, jobSpecificId, -1);
                    break;
                }
              }
              if (idValue2_1 < 1)
                idValue2_1 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 8, 0, -1);
              if (idValue2_1 == (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index10, 0])))
              {
                int num2 = 0;
                if (this.game.Data.StringListObj[stringListById4].Width >= 19)
                  num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, this.game.Data.ActionCardObj[index2].TempVar0, 19)));
                if (num2 < 1)
                {
                  this.cardWhyNot[index1, index10] = "A Leader cannot execute a Stratagem on self";
                  this.cardPlayable[index1, index10] = false;
                }
              }
              else
              {
                int num3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(6, 6, 7, idValue2_1, 0)));
                if (num3 > 0 && num3 == (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].Data[index10, 0])))
                {
                  int num4 = 0;
                  if (this.game.Data.StringListObj[stringListById4].Width >= 19)
                    num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById4].GetData(0, this.game.Data.ActionCardObj[index2].TempVar0, 19)));
                  if (num4 < 1)
                  {
                    this.cardWhyNot[index1, index10] = "A Leader cannot execute a Stratagem on its own Advisor";
                    this.cardPlayable[index1, index10] = false;
                  }
                }
              }
            }
          }
        }
        else
        {
          this.game.EditObj.DoCardSlot = cardinhandnr;
          this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, cardinhandnr);
          if (this.game.EditObj.tempOtherTest.GetUpperBound(0) > 0)
          {
            if (this.game.EditObj.tempOtherTest[1] == 1)
            {
              this.cardPlayable[index1, 1] = true;
            }
            else
            {
              this.cardWhyNot[index1, 1] = this.game.EditObj.tempOtherTestText[1];
              this.cardPlayable[index1, 1] = false;
            }
          }
          else
            this.cardPlayable[index1, 1] = true;
        }
      }
      this.donePrepareCardPlayable = true;
    }

    public override void DoRefresh()
    {
      if (this.detailnr <= -1 || this.lastActualCard == -1)
        return;
      if (this.detailnr > this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter)
        this.detailnr = -1;
      else if (this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr] != this.lastActualCard)
      {
        this.detailnr = -1;
        if (this.game.EditObj.se1_CardsCard > -1)
        {
          int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter;
          for (int index = 0; index <= actionCardCounter; ++index)
          {
            if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index]].TempVar0 == this.game.EditObj.se1_CardsCard)
            {
              this.detailnr = index;
              break;
            }
          }
        }
        if (this.detailnr == -1)
          this.game.EditObj.se1_CardsCard = -1;
      }
      this.lastActualCard = -1;
      this.dostuff();
    }

    public void dostuff()
    {
      int num1 = this.game.EventRelatedObj.CheckStringlistID("SE_IO", 158, 0, 0);
      this.game.HandyFunctionsObj.GetStringListByID(num1);
      int stringListById1 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
      int stringListById2 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 277, 0, 0));
      int stringListById3 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 278, 0, 0));
      int stringListById4 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 279, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 169, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 168, 0, 0));
      int stringListById5 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 184, 0, 0));
      int stringListById6 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 188, 0, 0));
      int stringListById7 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0));
      int stringListById8 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 169, 0, 0));
      int stringListById9 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 168, 0, 0));
      int stringListById10 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 203, 0, 0));
      this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 199, 0, 0));
      int stringListById11 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0));
      int stringListById12 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 275, 0, 0));
      int stringListById13 = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      int num2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 156, 0, 0))].GetData(0, 58, 2)));
      if (this.Info1Id > 0)
      {
        this.RemoveSubPart(this.Info1Id);
        this.Info1Id = 0;
      }
      if (this.sizeId > 0)
      {
        this.RemoveSubPart(this.sizeId);
        this.sizeId = 0;
      }
      if (this.scrapId > 0)
      {
        this.RemoveSubPart(this.scrapId);
        this.scrapId = 0;
      }
      if (this.buyScrapId > 0)
      {
        this.RemoveSubPart(this.buyScrapId);
        this.buyScrapId = 0;
      }
      if (this.buyScrapId2 > 0)
      {
        this.RemoveSubPart(this.buyScrapId2);
        this.buyScrapId2 = 0;
      }
      if (this.nextId > 0)
      {
        this.RemoveSubPart(this.nextId);
        this.nextId = 0;
      }
      if (this.prevId > 0)
      {
        this.RemoveSubPart(this.prevId);
        this.prevId = 0;
      }
      if (this.next2Id > 0)
      {
        this.RemoveSubPart(this.next2Id);
        this.next2Id = 0;
      }
      if (this.prev2Id > 0)
      {
        this.RemoveSubPart(this.prev2Id);
        this.prev2Id = 0;
      }
      if (this.info2id > 0)
      {
        this.RemoveSubPart(this.info2id);
        this.info2id = 0;
      }
      if (this.pageId > 0)
      {
        this.RemoveSubPart(this.pageId);
        this.pageId = 0;
      }
      if (this.miniId > 0)
      {
        this.RemoveSubPart(this.miniId);
        this.miniId = 0;
      }
      this.tSelectX = this.game.SelectX;
      this.tSelectY = this.game.SelectY;
      this.tCornerX = this.game.CornerX;
      this.tCornerY = this.game.CornerY;
      this.game.EditObj.AreaX = -1;
      this.game.EditObj.AreaY = -1;
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Graphics g = Graphics.FromImage((Image) this.OwnBitmap);
      Rectangle trect1 = DrawMod.DrawBackTab(g, this.w, this.h, "STRAT.", 5);
      this.AddMouse(ref trect1, "CLOSE TAB", "Click here to close this tab. [ESC/F6]", 9999999);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      SimpleList simpleList1 = new SimpleList();
      int[] numArray1 = new int[20];
      int actionCardCounter1 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter;
      for (int index1 = 0; index1 <= actionCardCounter1; ++index1)
      {
        int num3 = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].ColorScheme * 1000 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1];
        if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].Category > 0 && this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].quickButton < 2 && this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].Category < 99)
        {
          int[] numArray2 = numArray1;
          int[] numArray3 = numArray2;
          int category = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].Category;
          int index2 = category;
          int num4 = numArray2[category] + 1;
          numArray3[index2] = num4;
        }
      }
      if (this.first & this.currentCat > 0 && numArray1[this.currentCat] < 1)
      {
        this.currentCat = 0;
        this.miniSelectValue = -1;
      }
      if (this.currentCat < 1)
      {
        int categoryCount = this.categoryCount;
        for (int index = 1; index <= categoryCount; ++index)
        {
          if (numArray1[index] > 0)
          {
            this.currentCat = index;
            this.prepareTempValue4();
            break;
          }
        }
      }
      if (this.currentCat < 1)
        this.currentCat = 1;
      if (numArray1[this.currentCat] < 1)
        this.viewMode = 1;
      this.first = false;
      this.game.EditObj.se1_CardsCategory = this.currentCat;
      int x1_1 = 30;
      int y1_1 = 42;
      int w1 = 512;
      int h1 = 512;
      if (this.w > 910)
        w1 += this.w - 910;
      if (this.h > 602)
        h1 += this.h - 602;
      int tx1 = this.game.ScreenWidth >= 1400 ? x1_1 + (int) Math.Round((double) w1 / 2.0) - 200 : x1_1 + (int) Math.Round((double) w1 / 2.0) - 100;
      int ty1 = -5;
      bool active1 = false;
      if (this.viewMode == 1)
        active1 = true;
      string sText1 = "STRATAGEMS";
      if (!active1)
        ty1 -= 6;
      trect1 = this.DrawOneTab(g, true, active1, tx1, ty1, "", sText1, -1, 4, tMousingOverNow: (this.mouseOverWhichTab == 1));
      this.AddMouse(ref trect1, "", "View the Stratagems available", 1);
      int tx2 = tx1 + 200;
      bool active2 = false;
      int ty2 = -5;
      if (this.viewMode == 2)
        active2 = true;
      string sText2 = "TARGET";
      if (!active2)
        ty2 -= 6;
      trect1 = this.DrawOneTab(g, true, active2, tx2, ty2, "", sText2, -1, 16, grayedOut: (numArray1[this.currentCat] == 0 | this.categorySelectMode[this.currentCat] == 0), tMousingOverNow: (this.mouseOverWhichTab == 2));
      if (!(numArray1[this.currentCat] == 0 | this.categorySelectMode[this.currentCat] == 0))
        this.AddMouse(ref trect1, "", "Select or change the Target of the Stratagem", 2);
      bool tselected = true;
      if (this.cardSize == 2)
        tselected = false;
      int num5 = this.w - 200;
      int num6 = 0;
      SubPartClass tsubpart1 = (SubPartClass) new MarcRadioPartClass(0, tselected, "Click to change size of the Stratagems", ref this.BackBitmap, num5, num6);
      this.sizeId = this.AddSubPart(ref tsubpart1, num5, num6, 35, 35, 1);
      DrawMod.DrawTextColouredConsole(ref g, "Small Stratagems", this.game.MarcFont4, num5 + 40, num6 + 8, this.game.seColWhite);
      int num7 = this.w - 340;
      int num8 = 0;
      if ((int) Math.Round(Conversion.Val(this.game.Data.Designer)) >= 94)
      {
        SubPartClass tsubpart2 = (SubPartClass) new MarcRadioPartClass(0, this.scrapMode, "Click to switch on/off Scrap Mode. This mode allows you to Scrap Stratagems to earn Scrap Points. ", ref this.BackBitmap, num7, num8);
        this.scrapId = this.AddSubPart(ref tsubpart2, num7, num8, 35, 35, 1);
        DrawMod.DrawTextColouredConsole(ref g, "Scrap Mode", this.game.MarcFont4, num7 + 40, num8 + 8, this.game.seColWhite);
      }
      Rectangle trect2;
      Rectangle trect3;
      if (this.viewMode == 1)
      {
        DrawMod.DrawBlockGradient2(ref g, x1_1, y1_1, w1, h1, Color.FromArgb(50, 0, 0, 0), Color.FromArgb(150, 0, 0, 0));
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref g, x1_1 - 3, y1_1 - 3, w1 + 6, h1 + 6, 10, 10, 10);
        int x1_2 = this.w - 335;
        int y1_2 = 42;
        int w2 = 300;
        int h2 = 512;
        if (this.h > 602)
          h2 += this.h - 602;
        DrawMod.DrawBlockGradient2(ref g, x1_2, y1_2, w2, h2, Color.FromArgb(50, 0, 0, 0), Color.FromArgb(150, 0, 0, 0));
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref g, x1_2 - 3, y1_2 - 3, w2 + 6, h2 + 6, 10, 10, 10);
        DrawMod.drawLineDot(ref g, 176, 43, 176, this.h - 80, Color.White);
        int categoryCount = this.categoryCount;
        for (int index = 1; index <= categoryCount; ++index)
        {
          int num9 = numArray1[index];
          if (num9 > 6)
            num9 = 6;
          if (num9 > 0 & this.currentCat < 1)
            this.currentCat = index;
          if (index == this.currentCat)
            DrawMod.DrawBlockGradient(ref g, 36, 43 + 50 * (index - 1), 140, 50, Color.FromArgb(0, 0, 0, 0), Color.FromArgb(96, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
          trect2 = new Rectangle(36, 43 + 50 * (index - 1), 140, 50);
          trect3 = trect2;
          this.AddMouse(ref trect3, "Stratagem Category " + this.categoryName[index], "Click to see all stratagems in this category", 100000 + index);
          int num10 = 50 * index;
          Color color = this.game.seColWhite;
          if (index != this.currentCat)
            color = this.game.seColGray;
          if (numArray1[index] < 1)
          {
            Color c = DrawMod.LightenColor(color, -50);
            DrawMod.DrawTextColouredMarcCenter(ref g, this.categoryName[index], this.game.MarcFont4, 106, num10 + 10, c);
          }
          else
          {
            DrawMod.DrawTextColouredMarcCenter(ref g, this.categoryName[index], this.game.MarcFont4, 106, num10 - 1, color);
            DrawMod.DrawTextColouredMarcCenter(ref g, "( " + numArray1[index].ToString() + " )", this.game.MarcFont5, 106, num10 + 24, color);
          }
          DrawMod.drawLineDot(ref g, 56, 43 + 50 * index, 176, 43 + 50 * index, Color.White);
        }
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      Rectangle rectangle3;
      if (this.viewMode == 2 & (this.categorySelectMode[this.currentCat] == 1 | this.categorySelectMode[this.currentCat] == 2))
      {
        int x1_3 = this.w - 335;
        int y1_3 = 42;
        int w3 = 300;
        int h3 = 512;
        if (this.h > 602)
          h3 += this.h - 602;
        DrawMod.DrawBlockGradient2(ref g, x1_3, y1_3, w3, h3, Color.FromArgb(50, 0, 0, 0), Color.FromArgb(150, 0, 0, 0));
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref g, x1_3 - 3, y1_3 - 3, w3 + 6, h3 + 6, 10, 10, 10);
        int num11 = 221;
        int num12 = 42;
        int num13 = 321;
        int num14 = 240;
        if (this.w > 910)
          num13 += this.w - 910;
        if (this.h > 602)
          num14 += this.h - 602;
        rectangle1 = new Rectangle(num11, num12, num13, num14);
        DrawMod.DrawBlockGradient2(ref g, num11, num12, num13, num14, Color.FromArgb(50, 0, 0, 0), Color.FromArgb(150, 0, 0, 0));
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref g, num11 - 3, num12 - 3, num13 + 6, num14 + 6, 10, 10, 10);
        int y1 = num12 + num14 + 30;
        int height1 = 240;
        rectangle2 = new Rectangle(num11, y1, num13, height1);
        int x = 30;
        int y2 = 38;
        int width = 155;
        int height2 = 512;
        if (this.h > 602)
          height2 += this.h - 602;
        rectangle3 = new Rectangle(x, y2, width, height2);
      }
      Rectangle rectangle4;
      if (this.viewMode == 2 & (this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5 | this.categorySelectMode[this.currentCat] == 4))
      {
        int x1_4 = this.w - 335;
        int y1_4 = 42;
        int w4 = 300;
        int h4 = 512;
        if (this.h > 602)
          h4 += this.h - 602;
        DrawMod.DrawBlockGradient2(ref g, x1_4, y1_4, w4, h4, Color.FromArgb(50, 0, 0, 0), Color.FromArgb(150, 0, 0, 0));
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref g, x1_4 - 3, y1_4 - 3, w4 + 6, h4 + 6, 10, 10, 10);
        int x1 = 221;
        int y3 = 42;
        int width1 = 321;
        int height3 = 240;
        if (this.w > 910)
          width1 += this.w - 910;
        if (this.h > 602)
          height3 += this.h - 602;
        rectangle3 = new Rectangle(x1, y3, width1, height3);
        int y4 = y3 + height3 + 30;
        int height4 = 240;
        rectangle2 = new Rectangle(x1, y4, width1, height4);
        int x2 = 30;
        int y5 = 38;
        int width2 = 155;
        int height5 = 512;
        if (this.h > 602)
          height5 += this.h - 602;
        rectangle4 = new Rectangle(x2, y5, width2, height5);
      }
      this.game.Data.StringListObj[stringListById8].SetData(0, "ZONEID", 1, 0);
      this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCHARID", 1, 0);
      int id1 = this.game.Data.RegimeObj[this.game.Data.Turn].id;
      this.game.Data.StringListObj[stringListById8].SetData(0, "REGIMEID", 1, id1, true);
      this.game.Data.StringListObj[stringListById8].SetData(0, "SOURCEAI", 1, 0, true);
      this.game.Data.StringListObj[stringListById8].SetData(0, "REGID", 1, id1, true);
      this.game.Data.StringListObj[stringListById8].SetData(0, "SOURCEREGIMEID", 1, id1, true);
      this.game.Data.StringListObj[stringListById8].SetData(0, "SOURCEREGIMESLOT", 1, this.game.Data.Turn, true);
      this.game.Data.StringListObj[stringListById8].SetData(0, "ROUND", 1, this.game.Data.Round, true);
      if (this.categorySelectMode[this.currentCat] == 1)
      {
        this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
        this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, -1, true);
        if (this.miniSelectValue > -1)
        {
          this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEID", 1, this.miniSelectValue, true);
          int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(this.miniSelectValue);
          if (regimeById == -1)
          {
            this.miniSelectValue = -1;
          }
          else
          {
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMESLOT", 1, regimeById, true);
            int num15 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.miniSelectValue, 2)));
            int setValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData(0, num15, 1)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTURE", 1, setValue1, true);
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTUREID", 1, num15, true);
            int setValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.miniSelectValue, 13)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEAIID", 1, setValue2, true);
            int num16 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regimeById];
            int num17 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.miniSelectValue, 1)));
            if (num16 == 0 & num17 == 2 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, this.game.Data.RegimeObj[regimeById].id, 2, "dipClear", 3))) < 1)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
            else if (num16 == 0)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 1, true);
            else
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
          }
        }
      }
      else if (this.categorySelectMode[this.currentCat] == 2)
      {
        this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
        this.game.Data.StringListObj[stringListById8].SetData(0, "ZONEID", 1, this.miniSelectValue, true);
        this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, -1, true);
        if (this.miniSelectValue > -1)
        {
          int num18 = this.zoneRegimeId[this.miniSelectValue];
          this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEID", 1, num18, true);
          int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(num18);
          if (regimeById == -1)
          {
            this.miniSelectValue = -1;
          }
          else
          {
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMESLOT", 1, regimeById, true);
            int num19 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num18, 2)));
            int setValue3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData(0, num19, 1)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTURE", 1, setValue3, true);
            int setValue4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num18, 1)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETMAJOR", 1, setValue4, true);
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTUREID", 1, num19, true);
            int setValue5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num18, 13)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEAIID", 1, setValue5, true);
            int num20 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regimeById];
            int num21 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num18, 1)));
            if (num20 == 0 & num21 == 2 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, this.game.Data.RegimeObj[regimeById].id, 2, "dipClear", 3))) < 1)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
            else if (num20 == 0)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 1, true);
            else
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
            int setValue6 = 0;
            if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
              setValue6 = 1;
            this.game.Data.StringListObj[stringListById8].SetData(0, "SOURCEAI", 1, setValue6, true);
            int setValue7 = 0;
            if (this.game.Data.RegimeObj[regimeById].AI)
              setValue7 = 1;
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETAI", 1, setValue7, true);
          }
        }
      }
      else if (this.categorySelectMode[this.currentCat] == 3)
      {
        this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, this.miniUnitSelect, true);
        if (this.miniUnitSelect > 0)
        {
          if (this.game.Data.UnitObj[this.miniUnitSelect].Historical > 0)
            this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.miniUnitSelect].Historical].ID, true);
          else
            this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
        }
        else
          this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
      }
      else if (this.categorySelectMode[this.currentCat] == 5)
      {
        this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, this.miniUnitSelect, true);
        if (this.miniUnitSelect > 0)
        {
          if (this.game.Data.UnitObj[this.miniUnitSelect].Historical > 0)
            this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.miniUnitSelect].Historical].ID, true);
          else
            this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
        }
        else
          this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
      }
      else if (this.categorySelectMode[this.currentCat] == 4)
      {
        this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCHARID", 1, this.miniSelectLeader, true);
        this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
        this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, -1, true);
      }
      this.game.Data.StringListObj[stringListById8].SetData(0, "CHARID", 1, 0, true);
      SimpleList simpleList2 = new SimpleList();
      int actionCardCounter2 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter;
      for (int tdata1 = 0; tdata1 <= actionCardCounter2; ++tdata1)
      {
        if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[tdata1]].Category == this.currentCat | this.currentCat < 1 && this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[tdata1]].quickButton < 2)
        {
          int tweight = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[tdata1]].ColorScheme * 100000 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[tdata1];
          simpleList2.Add(this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[tdata1]].TempVar0, tweight, tdata1, tdata5: this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[tdata1]].TempVar0, CheckExistence: false);
        }
      }
      simpleList2.Sort();
      SimpleList SL = new SimpleList();
      int index3 = -1;
      int num22 = 0;
      int num23 = -1;
      int[] numArray4 = new int[Math.Max(0, this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter) + 1];
      int counter1 = simpleList2.Counter;
      for (int index4 = 0; index4 <= counter1; ++index4)
      {
        if (simpleList2.Id[index4] == index3)
        {
          ++num22;
        }
        else
        {
          index3 = simpleList2.Id[index4];
          num22 = 1;
        }
        if (index3 == num23)
        {
          SL.AddWeight(index3, 1, simpleList2.Data1[index4], tdata5: simpleList2.Data5[index4]);
        }
        else
        {
          num23 = index3;
          SL.AddWeight(index3, 1, simpleList2.Data1[index4], tdata5: simpleList2.Data5[index4]);
        }
        int nr = SL.FindNr(index3);
        numArray4[simpleList2.Data1[index4]] = nr;
      }
      StringListClass stringListClass = this.game.Data.StringListObj[stringListById8].Clone();
      if (this.game.Data.UnitCounter > this.cardPlayable.GetUpperBound(1) & (this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5))
        this.donePrepareCardPlayable = false;
      if (this.categorySelectMode[this.currentCat] == 4 & this.miniSelectLeader > 0 && this.game.Data.StringListObj[stringListById7].FindRow(0, this.miniSelectLeader) == -1)
        this.donePrepareCardPlayable = false;
      if (!this.donePrepareCardPlayable)
        this.prepareTempValue4();
      this.prepareCardPlayable(SL);
      this.game.Data.StringListObj[stringListById8] = stringListClass;
      if (this.detailnr > this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter)
        this.detailnr = -1;
      if (this.hovernr > this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter)
        this.hovernr = -1;
      Bitmap bitmap;
      if (this.viewMode == 1)
      {
        int num24 = 186;
        int num25 = 43;
        int num26 = 359;
        int num27 = 459;
        if (this.w > 910)
          num26 += this.w - 910;
        if (this.h > 602)
          num27 += this.h - 602;
        int num28 = 115;
        int num29 = 157;
        if (this.cardSize == 2)
        {
          num28 = 200;
          num29 = 276;
        }
        int num30 = (int) Math.Round(Math.Floor((double) num26 / (double) num28));
        int num31 = (int) Math.Round(Math.Floor((double) num27 / (double) num29));
        int num32 = num30;
        int num33 = num31;
        int num34 = 1;
        int num35;
        int num36;
        int num37;
        int num38;
        do
        {
          num35 = num32;
          num36 = num33;
          if (this.pageNr < 1)
            this.pageNr = 1;
          num37 = num35 * num36;
          int d = SL.Counter + 1 - (this.pageNr - 1) * num37;
          if (d > num37)
            d = num37;
          if (d == 0)
          {
            num35 = 1;
            num36 = 1;
          }
          else
          {
            int num39 = (int) Math.Round(Math.Ceiling(Math.Sqrt((double) d)));
            if (num39 < num35)
              num35 = num39;
            if (num39 < num36)
              num36 = num39;
            if (num35 * num36 < d)
            {
              num35 = num32;
              num36 = num33;
            }
            while (num35 * (num36 - 1) >= d)
              --num36;
            if (d <= num35)
              num36 = 1;
          }
          num38 = (int) Math.Round(Math.Ceiling((double) (SL.Counter + 1) / (double) num37));
          if (this.pageNr > num38)
          {
            this.pageNr = num38;
            ++num34;
          }
          else
            break;
        }
        while (num34 <= 2);
        string tstring1 = "Page " + this.pageNr.ToString() + " of " + num38.ToString();
        DrawMod.DrawTextColouredConsoleCenter(ref g, tstring1, this.game.MarcFont4, num24 + (int) Math.Round((double) num26 / 2.0), num25 + num27 + 3, this.game.seColWhite);
        if (this.pageNr > 1)
        {
          SubPartClass tsubpart3 = (SubPartClass) new TextButtonPartClass("<", 50, "Previous Page", ref this.OwnBitmap, num24 + (int) Math.Round((double) num26 / 2.0) - 150, num25 + num27, theight: 30, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.prevId = this.AddSubPart(ref tsubpart3, num24 + (int) Math.Round((double) num26 / 2.0) - 100, num25 + num27, 50, 30, 1);
        }
        else
        {
          SubPartClass tsubpart4 = (SubPartClass) new TextButtonPartClass("<", 50, "Previous Page", ref this.OwnBitmap, num24 + (int) Math.Round((double) num26 / 2.0) - 150, num25 + num27, true, theight: 30, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.prev2Id = this.AddSubPart(ref tsubpart4, num24 + (int) Math.Round((double) num26 / 2.0) - 100, num25 + num27, 50, 30, 0);
        }
        if (this.pageNr < num38)
        {
          SubPartClass tsubpart5 = (SubPartClass) new TextButtonPartClass(">", 50, "Next Page", ref this.OwnBitmap, num24 + (int) Math.Round((double) num26 / 2.0) + 60, num25 + num27, theight: 30, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.nextId = this.AddSubPart(ref tsubpart5, num24 + (int) Math.Round((double) num26 / 2.0) + 60, num25 + num27, 50, 30, 1);
        }
        else
        {
          SubPartClass tsubpart6 = (SubPartClass) new TextButtonPartClass(">", 50, "Next Page", ref this.OwnBitmap, num24 + (int) Math.Round((double) num26 / 2.0) + 60, num25 + num27, true, theight: 30, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.next2Id = this.AddSubPart(ref tsubpart6, num24 + (int) Math.Round((double) num26 / 2.0) + 60, num25 + num27, 50, 30, 0);
        }
        index3 = num26 - num35 * num28;
        int num40 = num27 - num36 * num29;
        int num41 = 186 + (int) Math.Round((double) index3 / 2.0);
        int num42 = 43 + (int) Math.Round((double) num40 / 2.0) + 10;
        int num43 = num35 * num28;
        int num44 = num36 * num29;
        int num45 = num41;
        int y6 = num42;
        int x3 = num45 - num28;
        this.rememberExtraS = "";
        int counter2 = SL.Counter;
        for (int index5 = 0; index5 <= counter2; ++index5)
        {
          if (index5 >= (this.pageNr - 1) * num37 & index5 < this.pageNr * num37)
          {
            x3 += num28;
            if (x3 >= num41 + num43)
            {
              x3 = num41;
              y6 += num29;
            }
            if (y6 <= num42 + num44)
            {
              int regcardslot = SL.Data1[index5];
              int num46 = SL.Weight[index5];
              index3 = -1;
              bool flag = false;
              if (this.detailnr == -1)
                this.detailnr = regcardslot;
              if (this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5)
              {
                if (this.miniUnitSelect > 0 && this.cardPlayable[index5, this.miniUnitSelect])
                  flag = true;
              }
              else if (this.categorySelectMode[this.currentCat] == 4)
              {
                if (this.miniSelectValue > -1)
                {
                  int row = this.game.Data.StringListObj[stringListById7].FindRow(0, this.miniSelectValue);
                  if (row > -1 && this.cardPlayable[index5, row])
                    flag = true;
                }
              }
              else if (this.miniSelectX > -1 & this.miniSelectY > -1 & this.categorySelectMode[this.currentCat] > 0)
              {
                index3 = this.game.EditObj.TempValue4[0].Value[this.miniSelectX, this.miniSelectY];
                if (index3 > -1 & index3 < 9999)
                {
                  if (this.cardPlayable[index5, index3])
                    flag = true;
                }
                else
                  flag = false;
              }
              else
                flag = true;
              if (regcardslot == this.detailnr && !this.scrapMode)
              {
                if (this.cardSize == 2)
                {
                  ref Graphics local1 = ref g;
                  bitmap = BitmapStore.GetBitmap(this.game.SECARDOUTLINE);
                  ref Bitmap local2 = ref bitmap;
                  int x4 = x3 - 10;
                  int y7 = y6 - 10;
                  DrawMod.DrawScaled(ref local1, ref local2, x4, y7, 210, 286);
                }
                else
                {
                  ref Graphics local3 = ref g;
                  bitmap = BitmapStore.GetBitmap(this.game.SECARDOUTLINE);
                  ref Bitmap local4 = ref bitmap;
                  int x5 = x3 - 10;
                  int y8 = y6 - 10;
                  DrawMod.DrawSimple(ref local3, ref local4, x5, y8);
                }
              }
              if (this.cardSize == 2)
              {
                ref Graphics local5 = ref g;
                bitmap = this.game.CustomBitmapObj.DrawActionCardSe1(this.game.Data.Turn, this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]);
                ref Bitmap local6 = ref bitmap;
                int x6 = x3;
                int y9 = y6;
                DrawMod.DrawSimple(ref local5, ref local6, x6, y9);
              }
              else
              {
                ref Graphics local7 = ref g;
                bitmap = this.game.CustomBitmapObj.DrawActionCardSe1(this.game.Data.Turn, this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot], size: 2);
                ref Bitmap local8 = ref bitmap;
                int x7 = x3;
                int y10 = y6;
                DrawMod.DrawSimple(ref local7, ref local8, x7, y10);
              }
              int num47 = SL.Weight[index5];
              if (num47 > 1)
              {
                ref Graphics local9 = ref g;
                bitmap = BitmapStore.GetBitmap(this.game.SE1_MULTICARD);
                ref Bitmap local10 = ref bitmap;
                int x8 = x3 - 6;
                int y11 = y6 + num29 - 42;
                DrawMod.DrawSimple(ref local9, ref local10, x8, y11);
                string tstring2 = num47.ToString();
                if (num47 > 9)
                  tstring2 = "9+";
                DrawMod.DrawTextColouredConsoleCenter(ref g, tstring2, this.game.MarcFont3, x3 + 12, y6 + num29 - 32, this.game.seColWhite);
              }
              string str1 = "";
              int num48 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, SL.Id[index5], 13)));
              int idValue1 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, SL.Id[index5], 5)));
              int idValue2 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, SL.Id[index5], 14)));
              int num49 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, SL.Id[index5], 7)));
              int index6 = stringListById3;
              if (num49 == 1)
              {
                index3 = this.game.HandyFunctionsObj.GetRegimeByID(this.game.EditObj.TempValue4[0].Value[this.miniSelectX, this.miniSelectY]);
                if (index3 > -1 && !this.game.Data.RegimeObj[index3].AI & num48 == 1)
                  index6 = stringListById4;
              }
              string String2 = "[" + SL.Id[index5].ToString() + "]";
              int length1 = this.game.Data.StringListObj[index6].Length;
              for (int index7 = 0; index7 <= length1; ++index7)
              {
                if (Strings.InStr(this.game.Data.StringListObj[index6].Data[index7, 0], String2) > 0)
                {
                  string str2 = this.game.Data.StringListObj[index6].Data[index7, 6];
                  if (str2.Length > 1)
                    str1 = str1 + "• " + str2 + "\r\n";
                }
              }
              if (str1.Length > 1)
              {
                int num50 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(1, idValue1, 2, this.game.Data.RegimeObj[this.game.Data.Turn].id, 0)));
                int num51 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue1, 2)));
                if (num50 < 1)
                {
                  num50 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(1, idValue2, 2, this.game.Data.RegimeObj[this.game.Data.Turn].id, 0)));
                  num51 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue2, 2)));
                }
                int num52 = -1;
                if (num50 > 0)
                {
                  switch (num51)
                  {
                    case 1:
                      num52 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 5, num50, -1);
                      break;
                    case 2:
                      num52 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 9, num50, -1);
                      break;
                  }
                  if (this.categorySelectMode[this.currentCat] == 2 & num52 < 1)
                  {
                    int characterId = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 10, this.miniSelectValue, -1);
                    if (characterId > 0)
                      num52 = characterId;
                  }
                }
                else if (this.categorySelectMode[this.currentCat] == 2)
                {
                  int characterId = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 10, this.miniSelectValue, -1);
                  if (characterId > 0)
                    num52 = characterId;
                }
                if (num52 < 1)
                  num52 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 8, 0, -1);
                this.game.Data.StringListObj[stringListById8].SetData(0, "ORGID", 1, num50, true);
                if (num52 > 0)
                  this.game.Data.StringListObj[stringListById8].SetData(0, "CHARID", 1, num52, true);
                if (num52 > 0)
                {
                  string setValue = this.game.EventRelatedObj.Helper_GetCharacterJobTitle(num52) + " " + this.game.Data.StringListObj[stringListById7].GetData(0, num52, 4);
                  this.game.Data.StringListObj[stringListById8].SetData(0, "CHARNAME", 1, setValue, true);
                }
                int length2 = this.game.Data.StringListObj[stringListById8].Length;
                for (int index8 = 0; index8 <= length2; ++index8)
                {
                  string str3 = this.game.Data.StringListObj[stringListById8].Data[index8, 0];
                  string newValue = this.game.Data.StringListObj[stringListById8].Data[index8, 1];
                  if (Strings.InStr(str1, "<" + str3 + ">") > 0)
                    str1 = str1.Replace("<" + str3 + ">", newValue);
                }
                str1 = this.game.EventRelatedObj.Helper_Lookup(str1);
                if (str1.Length <= 1)
                  ;
              }
              if (this.hovernr == regcardslot)
                this.rememberExtraS = str1;
              else if (this.detailnr == regcardslot)
                this.rememberExtraS = str1;
              if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].MouseOver.Length > 1)
              {
                if (str1.Length > 1)
                  str1 = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].MouseOver + "\r\n\r\n" + "Effects when played:".ToUpper() + "\r\n" + str1;
                else
                  str1 = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].MouseOver;
              }
              if (Information.IsNothing((object) this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].MouseOver))
                this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].MouseOver = "";
              if (this.scrapMode)
              {
                int tdata2 = this.game.EventRelatedObj.CardScrapValue(regcardslot);
                if (this.cardSize == 2)
                {
                  DrawMod.DrawBlock(ref g, x3 + 42, y6 + 238, 130, 31, 0, 0, 0, (int) byte.MaxValue);
                  int num53 = 64;
                  if (this.scrapMouseOver == regcardslot)
                  {
                    ref Graphics local11 = ref g;
                    bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
                    ref Bitmap local12 = ref bitmap;
                    trect3 = new Rectangle(num53 * 42, 32, 42, 32);
                    Rectangle srcrect = trect3;
                    trect2 = new Rectangle(x3 + 40, y6 + 237, 42, 32);
                    Rectangle destrect = trect2;
                    DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
                    DrawMod.DrawTextColouredConsole(ref g, tdata2.ToString() + " Scrap Pts", this.game.MarcFont4, x3 + 80, y6 + 244, Color.White);
                  }
                  else
                  {
                    ref Graphics local13 = ref g;
                    bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
                    ref Bitmap local14 = ref bitmap;
                    trect3 = new Rectangle(num53 * 42, 0, 42, 32);
                    Rectangle srcrect = trect3;
                    trect2 = new Rectangle(x3 + 40, y6 + 237, 42, 32);
                    Rectangle destrect = trect2;
                    DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
                    DrawMod.DrawTextColouredConsole(ref g, tdata2.ToString() + " Scrap Pts", this.game.MarcFont4, x3 + 80, y6 + 244, Color.LightGray);
                  }
                  trect3 = new Rectangle(x3 + 42, y6 + 238, 130, 31);
                  trect2 = trect3;
                  this.AddMouse(ref trect2, "Scrap!", "Click to Scrap 1 Stratagem", regcardslot + 50100, tdata2);
                  if (this.scrapMouseOver == regcardslot)
                  {
                    DrawMod.DrawRectangle(ref g, x3 + 42, y6 + 238, 130, 31, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                    DrawMod.DrawRectangle(ref g, x3 + 42 - 1, y6 + 238 - 1, 132, 33, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 128);
                    DrawMod.DrawRectangle(ref g, x3 + 42 + 1, y6 + 238 + 1, 128, 29, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 128);
                  }
                }
                if (this.cardSize == 1)
                {
                  DrawMod.DrawBlock(ref g, x3 + 37 - 15, y6 + 119 - 13, 60, 32, 0, 0, 0, (int) byte.MaxValue);
                  int num54 = 64;
                  if (this.scrapMouseOver == regcardslot)
                  {
                    ref Graphics local15 = ref g;
                    bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
                    ref Bitmap local16 = ref bitmap;
                    trect3 = new Rectangle(num54 * 42, 32, 42, 32);
                    Rectangle srcrect = trect3;
                    trect2 = new Rectangle(x3 + 30 - 15, y6 + 119 - 13, 42, 32);
                    Rectangle destrect = trect2;
                    DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
                    DrawMod.DrawTextColouredConsole(ref g, tdata2.ToString() + " Pts", this.game.MarcFont5, x3 + 64 - 15, y6 + 130 - 13, Color.White);
                  }
                  else
                  {
                    ref Graphics local17 = ref g;
                    bitmap = BitmapStore.GetBitmap(this.game.SE1_ICONS);
                    ref Bitmap local18 = ref bitmap;
                    trect3 = new Rectangle(num54 * 42, 0, 42, 32);
                    Rectangle srcrect = trect3;
                    trect2 = new Rectangle(x3 + 30 - 15, y6 + 119 - 13, 42, 32);
                    Rectangle destrect = trect2;
                    DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
                    DrawMod.DrawTextColouredConsole(ref g, tdata2.ToString() + " Pts", this.game.MarcFont5, x3 + 64 - 15, y6 + 130 - 13, Color.LightGray);
                  }
                  trect3 = new Rectangle(x3 + 37 - 15, y6 + 119 - 13, 60, 32);
                  trect2 = trect3;
                  this.AddMouse(ref trect2, "Scrap!", "Click to Scrap 1 Stratagem", regcardslot + 50100, tdata2);
                  if (this.scrapMouseOver == regcardslot)
                  {
                    DrawMod.DrawRectangle(ref g, x3 + 37 - 15, y6 + 119 - 13, 60, 32, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                    DrawMod.DrawRectangle(ref g, x3 + 37 - 15 - 1, y6 + 119 - 13 - 1, 62, 34, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 128);
                    DrawMod.DrawRectangle(ref g, x3 + 37 - 15 + 1, y6 + 119 - 13 + 1, 58, 30, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 128);
                  }
                }
              }
              if (!this.scrapMode)
              {
                if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].MouseOver.Length > 0)
                {
                  trect3 = new Rectangle(x3, y6, num28 - 10, num29 - 10);
                  trect2 = trect3;
                  this.AddMouse(ref trect2, this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].Title, str1, regcardslot + 100);
                }
                else
                {
                  trect3 = new Rectangle(x3, y6, num28 - 10, num29 - 10);
                  trect2 = trect3;
                  this.AddMouse(ref trect2, this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[regcardslot]].Title, str1, regcardslot + 100);
                }
              }
            }
          }
        }
      }
      bool flag1 = true;
      if (this.viewMode == 2 && this.categorySelectMode[this.currentCat] == 1 | this.categorySelectMode[this.currentCat] == 2)
      {
        Rectangle trect4 = rectangle1;
        bool tTempZones = false;
        if (this.currentCat == 7 | this.currentCat == 3)
          tTempZones = true;
        SubPartClass tsubpart7 = (SubPartClass) new MiniMapPartClass(DrawMod.TGame, false, trect4.Width, trect4.Height, trealhex: true, tMapWidth: trect4.Width, tMapHeight: trect4.Height, ZoomLevel: 0, ttempValue4mustBe: this.miniSelectValue, tblockMapMove: true, tTempValue3usedForAlpha: true, tTempZones: tTempZones);
        this.miniId = this.AddSubPart(ref tsubpart7, trect4.X, trect4.Y, trect4.Width, trect4.Height, 0);
        if (this.categorySelectMode[this.currentCat] == 1)
          this.AddMouse(ref trect4, "", "Click to select a regime", 51);
        if (this.categorySelectMode[this.currentCat] == 2)
          this.AddMouse(ref trect4, "", "Click to select a zone", 51);
      }
      if (this.viewMode == 2)
      {
        int tlistselect1 = -1;
        this.OptionsListObj = new ListClass();
        this.OptionsList2Obj = new ListClass();
        int num55 = -1;
        int tlistsize1 = (int) Math.Round(Math.Floor((double) rectangle3.Height / 24.0)) - 1;
        int tlistsize2 = (int) Math.Round(Math.Floor((double) rectangle4.Height / 24.0)) - 1;
        string tstring = "";
        if (this.currentCat == 1)
          tstring = "Select Major Regime";
        if (this.currentCat == 2)
          tstring = "Select Minor Regime";
        if (this.currentCat == 3)
          tstring = "Select Zone";
        if (this.currentCat == 4)
          tstring = "Nothing to Select";
        if (this.currentCat == 5)
          tstring = "Select Regime";
        if (this.currentCat == 6)
          tstring = "Select OHQ";
        if (this.currentCat == 7)
          tstring = "Select Zone";
        if (this.currentCat == 8)
          tstring = "Select Leader";
        if (this.currentCat == 9)
          tstring = "Select Unit";
        bool[] flagArray1 = new bool[this.maxMiniSelectValue + 1];
        if (this.categorySelectMode[this.currentCat] == 1)
        {
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index9 = 0; index9 <= mapWidth; ++index9)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index10 = 0; index10 <= mapHeight; ++index10)
            {
              if (this.game.EditObj.TempValue4[0].Value[index9, index10] > 0)
                flagArray1[this.game.EditObj.TempValue4[0].Value[index9, index10]] = true;
            }
          }
        }
        bool[] flagArray2 = new bool[this.maxMiniSelectValue + 10 + 1];
        if (this.categorySelectMode[this.currentCat] == 2)
        {
          int mapWidth = this.game.Data.MapObj[0].MapWidth;
          for (int index11 = 0; index11 <= mapWidth; ++index11)
          {
            int mapHeight = this.game.Data.MapObj[0].MapHeight;
            for (int index12 = 0; index12 <= mapHeight; ++index12)
            {
              if (this.game.EditObj.TempValue4[0].Value[index11, index12] > 0)
                flagArray2[this.game.EditObj.TempValue4[0].Value[index11, index12]] = true;
            }
          }
        }
        if (tstring.Length > 1)
          DrawMod.DrawTextColouredConsole(ref g, tstring, this.game.MarcFont5, rectangle3.X, rectangle3.Y - 18, this.game.seColWhite);
        if (this.categorySelectMode[this.currentCat] == 1 && this.game.Data.RegimeCounter > -1)
        {
          int regimeCounter = this.game.Data.RegimeCounter;
          for (int tdata = 0; tdata <= regimeCounter; ++tdata)
          {
            if (!this.game.Data.RegimeObj[tdata].hideFromList & flagArray1[this.game.Data.RegimeObj[tdata].id] && !this.game.Data.RegimeObj[tdata].Sleep | !this.game.Data.RegimeObj[tdata].DipBlock)
            {
              bool flag2 = true;
              index3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.game.Data.RegimeObj[tdata].id, 1)));
              if (this.currentCat == 1 & index3 != 1)
                flag2 = false;
              if (this.currentCat == 2 & index3 != 2)
                flag2 = false;
              if (this.currentCat == 1 & this.game.Data.RegimeObj[tdata].Sleep)
                flag2 = false;
              if (flag2)
              {
                ++num55;
                if (this.miniSelectValue == this.game.Data.RegimeObj[tdata].id)
                  tlistselect1 = num55;
                string name = this.game.Data.RegimeObj[tdata].Name;
                int num56 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, this.game.Data.RegimeObj[tdata].id, 2, "recon", 3)));
                string tname;
                if (tdata == this.game.Data.Turn)
                  tname = "⍟ " + name;
                else if (num56 >= 2)
                {
                  switch ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.game.Data.RegimeObj[tdata].id, 1))))
                  {
                    case 1:
                      tname = "⌾ " + name;
                      break;
                    case 2:
                      int idValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.game.Data.RegimeObj[tdata].id, 2)));
                      tname = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData(0, idValue, 1))) != num2 ? "∘ " + name : "∞ " + name;
                      break;
                    case 3:
                      tname = "⊷ " + name;
                      break;
                    default:
                      tname = "  " + name;
                      break;
                  }
                }
                else
                {
                  switch ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.game.Data.RegimeObj[tdata].id, 1))))
                  {
                    case 1:
                      tname = "⌾ " + name;
                      break;
                    case 2:
                      tname = "∘ " + name;
                      break;
                    case 3:
                      tname = "⊷ " + name;
                      break;
                    default:
                      tname = "  " + name;
                      break;
                  }
                }
                this.OptionsListObj.add(tname, tdata);
              }
            }
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            SubPartClass tsubpart8 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, tlistsize1, rectangle3.Width, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle3.X, bby: rectangle3.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
            this.OptionsListId = this.AddSubPart(ref tsubpart8, rectangle3.X, rectangle3.Y, rectangle3.Width, (tlistsize1 + 1) * 24, 0);
          }
        }
        if (this.categorySelectMode[this.currentCat] == 2 && this.game.Data.RegimeCounter > -1)
        {
          int maxMiniSelectValue = this.maxMiniSelectValue;
          for (int tdata = 1; tdata <= maxMiniSelectValue; ++tdata)
          {
            if (this.zoneVisible[tdata] & flagArray2[tdata])
            {
              ++num55;
              if (this.miniSelectValue == tdata)
                tlistselect1 = num55;
              this.OptionsListObj.add(this.zoneName[tdata], tdata);
            }
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            SubPartClass tsubpart9 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, tlistsize1, rectangle3.Width, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle3.X, bby: rectangle3.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
            this.OptionsListId = this.AddSubPart(ref tsubpart9, rectangle3.X, rectangle3.Y, rectangle3.Width, (tlistsize1 + 1) * 24, 0);
          }
        }
        if (this.categorySelectMode[this.currentCat] == 3)
        {
          int num57 = num55 + 1;
          this.OptionsList2Obj.add("All", 0);
          if (this.miniCatSelectValue == -1)
            this.miniCatSelectValue = 0;
          if (0 == this.miniCatSelectValue)
            tlistselect1 = num57;
          if (this.game.Data.UnitCounter > -1)
          {
            int maxMiniSelectValue = this.maxMiniSelectValue;
            for (int tdata = 0; tdata <= maxMiniSelectValue; ++tdata)
            {
              if (tdata <= this.game.Data.UnitCounter && this.game.Data.UnitObj[tdata].IsHQ & this.game.Data.UnitObj[tdata].Regime == this.game.Data.Turn & this.game.Data.UnitObj[tdata].PreDef == -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tdata].Historical].Type == 8)
              {
                ++num57;
                if (this.miniCatSelectValue == tdata)
                  tlistselect1 = num57;
                this.OptionsList2Obj.add(this.game.Data.UnitObj[tdata].Name, tdata);
              }
            }
            if (this.OptionsList2Id > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect1);
              this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
            }
            else
            {
              SubPartClass tsubpart10 = (SubPartClass) new ListSubPartClass(this.OptionsList2Obj, tlistsize2, rectangle4.Width, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle4.X, bby: rectangle4.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
              this.OptionsList2Id = this.AddSubPart(ref tsubpart10, rectangle4.X, rectangle4.Y, rectangle4.Width, (tlistsize2 + 1) * 24, 0);
            }
          }
          num55 = -1;
          tlistselect1 = -1;
          if (this.game.Data.UnitCounter > -1)
          {
            int maxMiniSelectValue = this.maxMiniSelectValue;
            for (int tdata = 0; tdata <= maxMiniSelectValue; ++tdata)
            {
              if (tdata <= this.game.Data.UnitCounter && this.game.Data.UnitObj[tdata].TempUnitSelectable && this.game.Data.UnitObj[tdata].HQ == this.miniCatSelectValue | this.miniCatSelectValue == 0)
              {
                ++num55;
                if (this.miniUnitSelect == -1)
                  this.miniUnitSelect = tdata;
                if (this.miniUnitSelect == tdata)
                  tlistselect1 = num55;
                this.OptionsListObj.add(this.game.Data.UnitObj[tdata].Name, tdata);
              }
            }
            if (this.OptionsListId > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
              this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
            }
            else
            {
              SubPartClass tsubpart11 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, tlistsize1, rectangle3.Width, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle3.X, bby: rectangle3.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
              this.OptionsListId = this.AddSubPart(ref tsubpart11, rectangle3.X, rectangle3.Y, rectangle3.Width, (tlistsize1 + 1) * 24, 0);
            }
          }
        }
        if (this.categorySelectMode[this.currentCat] == 5)
        {
          int num58 = num55 + 1;
          this.OptionsList2Obj.add("All", 0);
          if (this.miniCatSelectValue == -1)
            this.miniCatSelectValue = 0;
          if (0 == this.miniCatSelectValue)
            tlistselect1 = num58;
          if (this.game.Data.UnitCounter > -1)
          {
            int maxMiniSelectValue = this.maxMiniSelectValue;
            for (int tdata = 0; tdata <= maxMiniSelectValue; ++tdata)
            {
              if (tdata <= this.game.Data.UnitCounter && this.game.Data.UnitObj[tdata].IsHQ & this.game.Data.UnitObj[tdata].Regime == this.game.Data.Turn & this.game.Data.UnitObj[tdata].PreDef == -1 && this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[tdata].Historical].Type == 5)
              {
                ++num58;
                if (this.miniCatSelectValue == tdata)
                  tlistselect1 = num58;
                this.OptionsList2Obj.add(this.game.Data.UnitObj[tdata].Name, tdata);
              }
            }
            if (this.OptionsList2Id > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect1);
              this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
            }
            else
            {
              SubPartClass tsubpart12 = (SubPartClass) new ListSubPartClass(this.OptionsList2Obj, tlistsize2, rectangle4.Width, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle4.X, bby: rectangle4.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
              this.OptionsList2Id = this.AddSubPart(ref tsubpart12, rectangle4.X, rectangle4.Y, rectangle4.Width, (tlistsize2 + 1) * 24, 0);
            }
          }
          num55 = -1;
          tlistselect1 = -1;
          if (this.game.Data.UnitCounter > -1)
          {
            int maxMiniSelectValue = this.maxMiniSelectValue;
            for (int tdata = 0; tdata <= maxMiniSelectValue; ++tdata)
            {
              if (tdata <= this.game.Data.UnitCounter && this.game.Data.UnitObj[tdata].TempUnitSelectable && this.game.Data.UnitObj[tdata].HQ == this.miniCatSelectValue | this.miniCatSelectValue == 0)
              {
                ++num55;
                if (this.miniUnitSelect == -1)
                  this.miniUnitSelect = tdata;
                if (this.miniUnitSelect == tdata)
                  tlistselect1 = num55;
                this.OptionsListObj.add(this.game.Data.UnitObj[tdata].Name, tdata);
              }
            }
            if (this.OptionsListId > 0)
            {
              this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
              this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
            }
            else
            {
              SubPartClass tsubpart13 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, tlistsize1, rectangle3.Width, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle3.X, bby: rectangle3.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
              this.OptionsListId = this.AddSubPart(ref tsubpart13, rectangle3.X, rectangle3.Y, rectangle3.Width, (tlistsize1 + 1) * 24, 0);
            }
          }
        }
        if (this.categorySelectMode[this.currentCat] == 4)
        {
          if (this.miniSelectLeader > -1 & this.miniSelectValue > -1 & this.miniCatSelectValue == -1)
            this.miniCatSelectValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[this.miniSelectValue, 6]));
          if (this.miniCatSelectValue == -1)
            this.miniCatSelectValue = 0;
          int num59 = num55 + 1;
          this.OptionsList2Obj.add("All", 0);
          if (0 == this.miniCatSelectValue)
            tlistselect1 = num59;
          int num60 = num59 + 1;
          this.OptionsList2Obj.add("Reserve Pool", 1);
          if (1 == this.miniCatSelectValue)
            tlistselect1 = num60;
          int num61 = num60 + 1;
          this.OptionsList2Obj.add("OHQ Commanders", 3);
          if (3 == this.miniCatSelectValue)
            tlistselect1 = num61;
          int num62 = num61 + 1;
          this.OptionsList2Obj.add("SHQ Commanders", 4);
          if (4 == this.miniCatSelectValue)
            tlistselect1 = num62;
          int num63 = num62 + 1;
          this.OptionsList2Obj.add("Directors", 5);
          if (5 == this.miniCatSelectValue)
            tlistselect1 = num63;
          int num64 = num63 + 1;
          this.OptionsList2Obj.add("Advisors", 6);
          if (6 == this.miniCatSelectValue)
            tlistselect1 = num64;
          int num65 = num64 + 1;
          this.OptionsList2Obj.add("Secretary", 8);
          if (8 == this.miniCatSelectValue)
            tlistselect1 = num65;
          int num66 = num65 + 1;
          this.OptionsList2Obj.add("Governors", 10);
          if (10 == this.miniCatSelectValue)
            tlistselect1 = num66;
          if (this.OptionsList2Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
          }
          else
          {
            SubPartClass tsubpart14 = (SubPartClass) new ListSubPartClass(this.OptionsList2Obj, tlistsize2, rectangle4.Width, tlistselect1, this.game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle4.X, bby: rectangle4.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 24);
            this.OptionsList2Id = this.AddSubPart(ref tsubpart14, rectangle4.X, rectangle4.Y, rectangle4.Width, (tlistsize2 + 1) * 24, 0);
          }
          int num67 = -1;
          int tlistselect2 = -1;
          int tlistsize3 = (int) Math.Round(Math.Floor((double) rectangle3.Height / 56.0)) - 1;
          int tValueWidth = rectangle3.Width - 200;
          index3 = rectangle3.Width - 400;
          if (index3 > 0)
            tValueWidth = (int) Math.Round((double) tValueWidth - (double) index3 / 3.0);
          if (this.detailnr > -1)
          {
            int length = this.game.Data.StringListObj[stringListById7].Length;
            for (int tdata = 0; tdata <= length; ++tdata)
            {
              if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tdata, 5])) == id1 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tdata, 6])) > 0 && ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tdata, 6])) == this.miniCatSelectValue | this.miniCatSelectValue == 0) & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tdata, 6])) < 11)
              {
                if (true)
                {
                  index3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[tdata, 0]));
                  string tname = rectangle3.Width < 500 ? this.game.Data.StringListObj[stringListById7].Data[tdata, 3] + "\r\n" + this.game.Data.StringListObj[stringListById7].Data[tdata, 4] : this.game.Data.StringListObj[stringListById7].Data[tdata, 3] + " " + this.game.Data.StringListObj[stringListById7].Data[tdata, 4];
                  string tvalue = rectangle3.Width < 400 ? this.game.EventRelatedObj.Helper_GetCharacterJobTitle(index3, shortJobSpecific: true) : this.game.EventRelatedObj.Helper_GetCharacterJobTitle(index3);
                  string tvalue2 = "Relation " + this.game.Data.StringListObj[stringListById7].Data[tdata, 20];
                  if (rectangle3.Width >= 550)
                    this.OptionsListObj.add(tname, tdata, tvalue, tvalue2, tbmp: ((Bitmap) this.game.CustomBitmapObj.DrawLeaderPortrait(index3, 40, 56).Clone()));
                  else
                    this.OptionsListObj.add(tname, tdata, tvalue, tbmp: ((Bitmap) this.game.CustomBitmapObj.DrawLeaderPortrait(index3, 40, 56).Clone()));
                }
              }
            }
          }
          this.OptionsListObj.Sort();
          int listCount = this.OptionsListObj.ListCount;
          for (int index13 = 0; index13 <= listCount; ++index13)
          {
            ++num67;
            if (this.miniSelectValue == -1)
            {
              this.miniSelectValue = this.OptionsListObj.ListData[index13];
              this.miniSelectLeader = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].Data[this.miniSelectValue, 0]));
            }
            if (this.OptionsListObj.ListData[index13] == this.miniSelectValue)
              tlistselect2 = num67;
          }
          if (this.OptionsListId > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect2);
            this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
          }
          else
          {
            SubPartClass tsubpart15 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, tlistsize3, rectangle3.Width, tlistselect2, this.game, tHeaderCenter: false, tShowPair: true, tValueWidth: tValueWidth, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: rectangle3.X, bby: rectangle3.Y, tMarcStyle: true, overruleFont: (ref this.game.MarcFont4), overruleItemSize: 56);
            this.OptionsListId = this.AddSubPart(ref tsubpart15, rectangle3.X, rectangle3.Y, rectangle3.Width, (tlistsize3 + 1) * 56, 0);
          }
        }
        if (this.categorySelectMode[this.currentCat] == 1)
        {
          this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
          this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, -1, true);
          if (this.miniSelectValue > -1)
          {
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEID", 1, this.miniSelectValue, true);
            int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(this.miniSelectValue);
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMESLOT", 1, regimeById, true);
            int num68 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.miniSelectValue, 2)));
            int setValue8 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData(0, num68, 1)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTURE", 1, setValue8, true);
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTUREID", 1, num68, true);
            int setValue9 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.miniSelectValue, 13)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEAIID", 1, setValue9, true);
            index3 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regimeById];
            int num69 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, this.miniSelectValue, 1)));
            if (index3 == 0 & num69 == 2 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, this.game.Data.RegimeObj[regimeById].id, 2, "dipClear", 3))) < 1)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
            else if (index3 == 0)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 1, true);
            else
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
            int setValue10 = 0;
            if (this.game.Data.RegimeObj[this.game.Data.Turn].AI)
              setValue10 = 1;
            this.game.Data.StringListObj[stringListById8].SetData(0, "SOURCEAI", 1, setValue10, true);
            int setValue11 = 0;
            if (this.game.Data.RegimeObj[regimeById].AI)
              setValue11 = 1;
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETAI", 1, setValue11, true);
          }
        }
        else if (this.categorySelectMode[this.currentCat] == 2)
        {
          this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
          this.game.Data.StringListObj[stringListById8].SetData(0, "ZONEID", 1, this.miniSelectValue, true);
          this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, -1, true);
          if (this.miniSelectValue > -1)
          {
            int num70 = this.zoneRegimeId[this.miniSelectValue];
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEID", 1, num70, true);
            int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(num70);
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMESLOT", 1, regimeById, true);
            int num71 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num70, 2)));
            int setValue12 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById13].GetData(0, num71, 1)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTURE", 1, setValue12, true);
            int setValue13 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num70, 1)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETMAJOR", 1, setValue13, true);
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCULTUREID", 1, num71, true);
            int setValue14 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num70, 13)));
            this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETREGIMEAIID", 1, setValue14, true);
            index3 = this.game.Data.RegimeObj[this.game.Data.Turn].RegimeRel[regimeById];
            int num72 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById11].GetData(0, num70, 1)));
            if (index3 == 0 & num72 == 2 & (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById12].GetData3(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, this.game.Data.RegimeObj[regimeById].id, 2, "dipClear", 3))) < 1)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
            else if (index3 == 0)
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 1, true);
            else
              this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETWAR", 1, 0, true);
          }
        }
        else if (this.categorySelectMode[this.currentCat] == 3)
        {
          this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, this.miniUnitSelect, true);
          if (this.miniUnitSelect > 0)
          {
            if (this.game.Data.UnitObj[this.miniUnitSelect].Historical > 0)
              this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.miniUnitSelect].Historical].ID, true);
            else
              this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
          }
          else
            this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
        }
        else if (this.categorySelectMode[this.currentCat] == 5)
        {
          this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, this.miniUnitSelect, true);
          if (this.miniUnitSelect > 0)
          {
            if (this.game.Data.UnitObj[this.miniUnitSelect].Historical > 0)
              this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.miniUnitSelect].Historical].ID, true);
            else
              this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
          }
          else
            this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
        }
        else if (this.categorySelectMode[this.currentCat] == 4)
        {
          this.game.Data.StringListObj[stringListById8].SetData(0, "TARGETCHARID", 1, this.miniSelectLeader, true);
          this.game.Data.StringListObj[stringListById8].SetData(0, "HISID", 1, -1, true);
          this.game.Data.StringListObj[stringListById8].SetData(0, "UNITID", 1, -1, true);
        }
      }
      if (this.categorySelectMode[this.currentCat] > 0)
      {
        if (this.categorySelectMode[this.currentCat] == 1)
          index3 = this.game.HandyFunctionsObj.GetRegimeByID(this.miniSelectValue);
        else if (this.categorySelectMode[this.currentCat] == 2)
          index3 = this.miniSelectValue;
        else if (this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5)
          index3 = this.miniUnitSelect;
        else if (this.categorySelectMode[this.currentCat] == 4)
          index3 = this.miniSelectLeader;
        int index14 = this.hovernr;
        if (index14 == -1)
          index14 = this.detailnr;
        int index15 = this.game.EditObj.TempValue4[0].Value[this.miniSelectX, this.miniSelectY];
        if (this.categorySelectMode[this.currentCat] == 1)
        {
          if (index14 > -1)
          {
            index14 = numArray4[index14];
            if (index15 > -1 & index15 < 9999 & index14 <= SL.Counter)
            {
              if (this.cardPlayable[index14, index15])
              {
                this.game.EventRelatedObj.Helper_Regime_Info_For_Cards(index3, "TARGET VALID", "", IO_ColNr.GreenDarker);
              }
              else
              {
                flag1 = false;
                this.game.EventRelatedObj.Helper_Regime_Info_For_Cards(index3, "NOT A VALID TARGET", this.cardWhyNot[index14, index15], IO_ColNr.Red);
              }
            }
            else
            {
              flag1 = false;
              this.game.EventRelatedObj.Helper_Regime_Info_For_Cards(index3, "NO TARGET", "", IO_ColNr.Red);
            }
          }
          else
            this.game.EventRelatedObj.Helper_Regime_Info_For_Cards(index3, "", "", IO_ColNr.Black);
        }
        if (this.categorySelectMode[this.currentCat] == 2)
        {
          if (index14 > -1)
          {
            index14 = numArray4[index14];
            if (index15 > -1 & index15 < 9999 & index14 <= SL.Counter)
            {
              if (this.cardPlayable[index14, index15])
              {
                this.game.EventRelatedObj.Helper_Zone_Info_For_Cards(index3, "TARGET VALID", "", IO_ColNr.GreenDarker);
              }
              else
              {
                flag1 = false;
                this.game.EventRelatedObj.Helper_Zone_Info_For_Cards(index3, "NOT A VALID TARGET", this.cardWhyNot[index14, index15], IO_ColNr.Red);
              }
            }
            else
            {
              flag1 = false;
              this.game.EventRelatedObj.Helper_Zone_Info_For_Cards(index3, "NO TARGET", "", IO_ColNr.Red);
            }
          }
          else
            this.game.EventRelatedObj.Helper_Zone_Info_For_Cards(index3, "", "", IO_ColNr.Black);
        }
        if (this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5)
        {
          int miniUnitSelect = this.miniUnitSelect;
          if (index14 > -1)
          {
            index14 = numArray4[index14];
            if (miniUnitSelect > -1 & index14 <= SL.Counter)
            {
              if (this.cardPlayable[index14, miniUnitSelect])
              {
                this.game.EventRelatedObj.Helper_Unit_Info_For_Cards(index3, "TARGET VALID", "", IO_ColNr.GreenDarker);
              }
              else
              {
                flag1 = false;
                this.game.EventRelatedObj.Helper_Unit_Info_For_Cards(index3, "NOT A VALID TARGET", this.cardWhyNot[index14, miniUnitSelect], IO_ColNr.Red);
              }
            }
            else
            {
              flag1 = false;
              this.game.EventRelatedObj.Helper_Unit_Info_For_Cards(index3, "NO TARGET", "", IO_ColNr.Red);
            }
          }
          else
            this.game.EventRelatedObj.Helper_Unit_Info_For_Cards(index3, "", "", IO_ColNr.Black);
        }
        if (this.categorySelectMode[this.currentCat] == 4)
        {
          int miniSelectLeader = this.miniSelectLeader;
          int row = this.game.Data.StringListObj[stringListById7].FindRow(0, miniSelectLeader);
          if (index14 > -1)
          {
            int index16 = numArray4[index14];
            if (miniSelectLeader > -1 & index16 <= SL.Counter)
            {
              if (this.cardPlayable[index16, row])
              {
                this.game.EventRelatedObj.Helper_Character_Info_For_Cards(index3, "TARGET VALID", "", IO_ColNr.GreenDarker);
              }
              else
              {
                flag1 = false;
                this.game.EventRelatedObj.Helper_Character_Info_For_Cards(index3, "NOT A VALID TARGET", this.cardWhyNot[index16, row], IO_ColNr.Red);
              }
            }
            else
            {
              flag1 = false;
              this.game.EventRelatedObj.Helper_Character_Info_For_Cards(index3, "NO TARGET", "", IO_ColNr.Red);
            }
          }
          else
            this.game.EventRelatedObj.Helper_Character_Info_For_Cards(index3, "", "", IO_ColNr.Black);
        }
      }
      else
      {
        int index17 = this.hovernr;
        if (index17 == -1)
          index17 = this.detailnr;
        if (index17 > -1)
        {
          int index18 = numArray4[index17];
          if (index18 <= SL.Counter)
          {
            if (!this.cardPlayable[index18, 1])
              flag1 = false;
          }
          else
            flag1 = false;
        }
      }
      if (this.viewMode == 2 && this.categorySelectMode[this.currentCat] > 0)
      {
        string tTexty1 = this.game.EventRelatedObj.CheckKey(num1, "FINALTEXT", 2, 0);
        int x9 = rectangle2.X;
        int y12 = rectangle2.Y;
        int width = rectangle2.Width;
        int height = rectangle2.Height;
        int num73 = (int) Math.Round((double) (rectangle2.Width - 324) / 2.0);
        UDSPartClass udsPartClass = new UDSPartClass(this.game, width, height, tTexty1, ref this.OwnBitmap, x9, y12, true, true, tAlwaysShowBackground: true);
        int num74 = udsPartClass.DoJustCheckHeight(true) + 30;
        int num75 = (int) Math.Round((double) (height - num74) / 2.0);
        udsPartClass.Dispose();
        if (rectangle2.Width > 564)
        {
          this.game.EventRelatedObj.ExecKey(num1, "FINALTEXT", "", "", "");
          if (this.categorySelectMode[this.currentCat] == 4 & this.miniSelectLeader > -1)
          {
            int eventByLib = this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 531, 0, 0);
            this.game.EventRelatedObj.Helper_AddPortraitUdsCode(this.miniSelectLeader, -120, 50 - num75, 100, 140, this.game.Data.RegimeObj[this.game.Data.Turn].id, 0, "CHARID", this.miniSelectLeader, eventByLib, mouseOverText: "Click for more information");
          }
          if ((this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5) & this.miniUnitSelect > 0 & this.miniUnitSelect <= this.game.Data.UnitCounter)
            this.game.EventRelatedObj.IO_AddUnitPic(-90, 80 - num75, 0, this.miniUnitSelect);
          if (this.categorySelectMode[this.currentCat] == 2 | this.categorySelectMode[this.currentCat] == 1 && this.miniSelectValue > 0)
          {
            int index19 = -1;
            if (this.categorySelectMode[this.currentCat] == 1)
              index19 = this.game.HandyFunctionsObj.GetRegimeByID(this.miniSelectValue);
            if (this.categorySelectMode[this.currentCat] == 2)
              index19 = this.game.HandyFunctionsObj.GetRegimeByID(this.zoneRegimeId[this.miniSelectValue]);
            int x10 = -120;
            int y13 = 20 - num75;
            int bannerSpriteNr = this.game.Data.RegimeObj[index19].BannerSpriteNr;
            this.game.EventRelatedObj.IO_AddEventPic(x10, y13, 124, this.game.Data.RegimeObj[index19].Red, this.game.Data.RegimeObj[index19].Green, this.game.Data.RegimeObj[index19].Blue, (int) byte.MaxValue, bannerSpriteNr + 10000);
            int bannerSpriteNr2 = this.game.Data.RegimeObj[index19].BannerSpriteNr2;
            if (bannerSpriteNr2 > 0)
              this.game.EventRelatedObj.IO_AddEventPic(x10, y13, 124, this.game.Data.RegimeObj[index19].Red2, this.game.Data.RegimeObj[index19].Green2, this.game.Data.RegimeObj[index19].Blue2, (int) byte.MaxValue, bannerSpriteNr2 + 10000);
            int symbolSpriteNr = this.game.Data.RegimeObj[index19].SymbolSpriteNr;
            if (symbolSpriteNr > 0)
              this.game.EventRelatedObj.IO_AddEventPic(x10 + 32, y13 + 55, 66, this.game.Data.RegimeObj[index19].Red3, this.game.Data.RegimeObj[index19].Green3, this.game.Data.RegimeObj[index19].Blue3, (int) byte.MaxValue, symbolSpriteNr + 10000);
            this.game.EventRelatedObj.IO_AddEventPic(x10, y13, 124, 220, -1, this.game.Data.RegimeObj[index19].Name + " banner", -1);
          }
          tTexty1 += this.game.EventRelatedObj.CheckKey(num1, "FINALTEXT", 2, 0);
        }
        string tTexty2 = "[element][type]layout[/type][w]" + num73.ToString() + "[/w][h]" + num75.ToString() + "[/h][/element]" + tTexty1;
        SubPartClass tsubpart16 = (SubPartClass) new UDSPartClass(this.game, width, height, tTexty2, ref this.OwnBitmap, x9, y12, true, tAlwaysShowBackground: true);
        this.pageId = this.AddSubPart(ref tsubpart16, x9, y12, width, height, 0);
      }
      int num76 = this.w - 335;
      int num77 = 54 + Math.Max(0, (int) Math.Round((double) (this.h - 154 - 544) / 2.0));
      int num78 = 300;
      int num79 = 285;
      int num80 = (int) Math.Round((double) num76 + (double) (num78 - 190) / 2.0 - 10.0);
      int num81 = num77 - 5;
      int num82 = 235;
      int num83 = num80 - 10;
      int num84 = num81 + 320;
      if (this.scrapMode)
      {
        int y14 = (int) Math.Round((double) this.h / 2.0 - 150.0);
        int num85 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, id1, 1, "scrapPoints", 2)));
        string tstring3 = "You are in";
        DrawMod.DrawTextColouredConsoleCenter(ref g, tstring3, this.game.MarcFont4, num76 + (int) Math.Round((double) num78 / 2.0), y14, this.game.seColWhite);
        int y15 = y14 + 20;
        string tstring4 = "Scrap Mode";
        DrawMod.DrawTextColouredConsoleCenter(ref g, tstring4, this.game.MarcFont3, num76 + (int) Math.Round((double) num78 / 2.0), y15, this.game.seColWhite);
        int y16 = y15 + 40;
        string tstring5 = "You currently have";
        DrawMod.DrawTextColouredConsoleCenter(ref g, tstring5, this.game.MarcFont4, num76 + (int) Math.Round((double) num78 / 2.0), y16, this.game.seColWhite);
        int y17 = y16 + 20;
        string tstring6 = num85.ToString() + " Scrap Points";
        DrawMod.DrawTextColouredConsoleCenter(ref g, tstring6, this.game.MarcFont2, num76 + (int) Math.Round((double) num78 / 2.0), y17, this.game.seColWhite);
        num77 = y17 + 40 + 20;
        int num86 = num77;
        int num87 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, id1, 1, "scrapPointCost", 2)));
        if (num87 < 15)
          num87 = 15;
        if (num85 >= num87)
        {
          SubPartClass tsubpart17 = (SubPartClass) new TextButtonPartClass("CRAFT STRATAGEM [" + num87.ToString() + "sp]", num82, "Click to craft a Scrap Stratagem for " + num87.ToString() + " Scrap Points.", ref this.OwnBitmap, num83, num86, theight: 60, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.buyScrapId = this.AddSubPart(ref tsubpart17, num83, num86, num82, 40, 1);
        }
        else
        {
          SubPartClass tsubpart18 = (SubPartClass) new TextButtonPartClass("CRAFT STRATAGEM [" + num87.ToString() + "sp]", num82, "Sorry, but you do not have the required " + num87.ToString() + " Scrap Points to craft a Scrap Stratagem. Scrap some more Stratagems to gain more Scrap Points!", ref this.OwnBitmap, num83, num86, true, theight: 60, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
          this.buyScrapId2 = this.AddSubPart(ref tsubpart18, num83, num86, num82, 40, 1);
        }
      }
      if (!this.scrapMode)
      {
        int num88 = num77 + 300;
        int num89 = num79 - 300;
        string str4 = "PP";
        bool flag3 = false;
        if (this.detailnr > -1)
        {
          if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].customCostType == 1)
          {
            if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById1].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "fp", 2))) >= this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].customCostQty)
              flag3 = true;
            str4 = "FP";
          }
          else if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].PPCost | this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].PPCost == 0)
            flag3 = true;
        }
        if (this.hovernr > -1)
        {
          int nr = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.hovernr];
          ref Graphics local19 = ref g;
          bitmap = this.game.CustomBitmapObj.DrawActionCardSe1(this.game.Data.Turn, nr);
          ref Bitmap local20 = ref bitmap;
          int x = num80 + 10;
          int y = num81 + 10;
          DrawMod.DrawSimple(ref local19, ref local20, x, y);
          string ttext;
          if (this.rememberExtraS.Length > 1)
          {
            if (this.game.Data.ActionCardObj[nr].MouseOver.Length > 1)
              ttext = this.game.Data.ActionCardObj[nr].MouseOver + "\r\n\r\n" + "Effect when played:".ToUpper() + "\r\n" + this.rememberExtraS;
            else
              ttext = "Effect when played:".ToUpper() + "\r\n" + this.rememberExtraS;
          }
          else
            ttext = this.game.Data.ActionCardObj[nr].MouseOver.Length <= 1 ? "No requirements to play Stratagem" : this.game.Data.ActionCardObj[nr].MouseOver;
          trect3 = new Rectangle(num80 + 10, num81 + 10, 190, 266);
          Rectangle trect5 = trect3;
          this.AddMouse(ref trect5, "REGIMECARD", ttext);
        }
        else if (this.detailnr > -1)
        {
          int nr = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr];
          ref Graphics local21 = ref g;
          bitmap = this.game.CustomBitmapObj.DrawActionCardSe1(this.game.Data.Turn, nr);
          ref Bitmap local22 = ref bitmap;
          int x = num80 + 10;
          int y = num81 + 10;
          DrawMod.DrawSimple(ref local21, ref local22, x, y);
          if (Information.IsNothing((object) this.game.Data.ActionCardObj[nr].MouseOver))
            this.game.Data.ActionCardObj[nr].MouseOver = "";
          if (Information.IsNothing((object) this.rememberExtraS))
            this.rememberExtraS = "";
          string ttext;
          if (this.rememberExtraS.Length > 1)
          {
            if (this.game.Data.ActionCardObj[nr].MouseOver.Length > 1)
              ttext = "Requirements:\r\n" + this.game.Data.ActionCardObj[nr].MouseOver + "\r\n\r\n" + "Effect when played:".ToUpper() + "\r\n" + this.rememberExtraS;
            else
              ttext = "Effect when played:".ToUpper() + "\r\n" + this.rememberExtraS;
          }
          else
            ttext = this.game.Data.ActionCardObj[nr].MouseOver.Length <= 1 ? "No requirements to play Stratagem" : "Requirements:\r\n" + this.game.Data.ActionCardObj[nr].MouseOver;
          trect3 = new Rectangle(num80 + 10, num81 + 10, 190, 266);
          Rectangle trect6 = trect3;
          this.AddMouse(ref trect6, "REGIMECARD", ttext);
        }
        int x11 = num80 - 35;
        int y18 = num81 + 290;
        int width = 275;
        bool flag4 = false;
        string tstring7 = "TARGET";
        string tstring8 = "xxxx";
        if (this.categorySelectMode[this.currentCat] == 0)
        {
          tstring7 = "TARGET REGIME";
          tstring8 = "Your own Regime";
        }
        if (this.categorySelectMode[this.currentCat] == 1)
        {
          tstring7 = "TARGET REGIME";
          if (this.miniSelectValue == -1)
          {
            tstring8 = "No Regime selected";
            flag4 = true;
          }
          else
            tstring8 = this.game.Data.RegimeObj[this.game.HandyFunctionsObj.GetRegimeByID(this.miniSelectValue)].Name;
        }
        if (this.categorySelectMode[this.currentCat] == 2)
        {
          tstring7 = "TARGET ZONE";
          if (this.miniSelectValue == -1)
          {
            tstring8 = "No Zone selected";
            flag4 = true;
          }
          else
            tstring8 = this.zoneName[this.miniSelectValue];
        }
        if (this.categorySelectMode[this.currentCat] == 3)
        {
          tstring7 = "TARGET OHQ";
          if (this.miniUnitSelect == -1)
          {
            tstring8 = "No OHQ selected";
            flag4 = true;
          }
          else
            tstring8 = this.game.Data.UnitObj[this.miniUnitSelect].Name;
        }
        if (this.categorySelectMode[this.currentCat] == 4)
        {
          tstring7 = "TARGET LEADER";
          if (this.miniSelectLeader == -1)
          {
            tstring8 = "No Leader selected";
            flag4 = true;
          }
          else
            tstring8 = this.game.Data.StringListObj[stringListById7].GetData(0, this.miniSelectLeader, 3) + " " + this.game.Data.StringListObj[stringListById7].GetData(0, this.miniSelectLeader, 4);
        }
        if (this.categorySelectMode[this.currentCat] == 5)
        {
          tstring7 = "TARGET UNIT";
          if (this.miniUnitSelect == -1)
          {
            tstring8 = "No Unit selected";
            flag4 = true;
          }
          else
            tstring8 = this.game.Data.UnitObj[this.miniUnitSelect].Name;
        }
        if (this.detailnr > -1)
        {
          DrawMod.DrawTextColouredConsoleCenter(ref g, tstring7, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y18, this.game.seColWhite);
          int y19 = y18 + 16;
          int num90;
          if (flag4)
          {
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring8, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y19, this.game.seColRed);
            num90 = y19 + 16;
          }
          else
          {
            if (this.h > 742 & this.categorySelectMode[this.currentCat] == 4)
            {
              ref Graphics local23 = ref g;
              bitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(this.miniSelectLeader, 50, 70, true);
              ref Bitmap local24 = ref bitmap;
              int x12 = x11 + (int) Math.Round((double) width / 2.0) - 25;
              int y20 = y19;
              DrawMod.DrawSimple(ref local23, ref local24, x12, y20);
              trect3 = new Rectangle(x11 + (int) Math.Round((double) width / 2.0) - 25, y19, 50, 70);
              Rectangle trect7 = trect3;
              this.AddMouse(ref trect7, "", "Click for more information", 11, this.miniSelectLeader);
              y19 += 70;
            }
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring8, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y19, this.game.seColWhite);
            num90 = y19 + 16;
          }
          y18 = num90 + 10;
        }
        string tstring9 = "EXECUTED BY";
        int num91 = -1;
        int index20 = this.hovernr;
        if (index20 == -1)
          index20 = this.detailnr;
        if (index20 > -1)
          num91 = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index20]].TempVar0;
        if (num91 > -1)
        {
          int num92 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, num91, 13)));
          int idValue3 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, num91, 5)));
          int idValue4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, num91, 14)));
          int num93 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById2].GetData(0, num91, 7)));
          int index21 = stringListById3;
          if (num93 == 1)
          {
            int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(this.game.EditObj.TempValue4[0].Value[this.miniSelectX, this.miniSelectY]);
            if (regimeById > -1 && !this.game.Data.RegimeObj[regimeById].AI & num92 == 1)
              index21 = stringListById4;
          }
          int num94 = -1;
          SimpleList simpleList3 = new SimpleList();
          bool flag5 = false;
          this.game.EventRelatedObj.fixedAvgRollOverule = true;
          string str5;
          if (flag1)
          {
            string String2 = "[" + num91.ToString() + "]";
            this.game.Data.StringListObj[stringListById8].SetData(0, "DIFF", 1, 0);
            int length = this.game.Data.StringListObj[index21].Length;
            for (int index22 = 0; index22 <= length; ++index22)
            {
              if (Strings.InStr(this.game.Data.StringListObj[index21].Data[index22, 0], String2) > 0)
              {
                string str6 = this.game.Data.StringListObj[index21].Data[index22, 1];
                string str7 = this.game.Data.StringListObj[index21].Data[index22, 2];
                if (str7.Length > 1)
                {
                  if ((uint) Strings.InStr(str7, "DIFF=") > 0U)
                  {
                    int num95 = 1;
                    Random random;
                    if (str6.Length > 1)
                    {
                      EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
                      int id2 = this.game.Data.StringListObj[stringListById9].ID;
                      int id3 = this.game.Data.StringListObj[stringListById8].ID;
                      string logicString = str6;
                      random = (Random) null;
                      ref Random local = ref random;
                      num95 = eventRelatedObj.CheckLogicStringStart(id2, id3, logicString, 0, ref local);
                    }
                    if (num95 > 0)
                    {
                      if (Strings.InStr(str7, "dth(") > 0)
                      {
                        flag5 = true;
                        int Start1 = Strings.InStr(str7, "dth(");
                        int Start2 = Strings.InStr(Start1, str7, ",");
                        int num96 = Strings.InStr(Start2, str7, ")");
                        str5 = !(Start2 < num96 & num96 > 0 & Start2 > 0) ? "Random Roll" : Strings.Mid(str7, Start1 + 4, Start2 - (Start1 + 4)) + "d" + Strings.Mid(str7, Start2 + 1, num96 - (Start2 + 1));
                      }
                      else
                      {
                        EventRelatedClass eventRelatedObj = this.game.EventRelatedObj;
                        int id4 = this.game.Data.StringListObj[stringListById9].ID;
                        int id5 = this.game.Data.StringListObj[stringListById8].ID;
                        string logicString = str7;
                        random = (Random) null;
                        ref Random local = ref random;
                        eventRelatedObj.ExecSetLogicWithReturnList(id4, id5, logicString, ref local);
                      }
                    }
                  }
                  string str8 = str7.ToLower().Replace(" ", "");
                  if (Strings.InStr(str8, "che(249,1,charid") > 0)
                  {
                    int Start = Strings.InStr(Strings.InStr(Strings.InStr(str8, "che(249,1,charid"), str8, "charid"), str8, ",");
                    int num97 = Strings.InStr(Start, str8, ")");
                    string InputStr = Strings.Mid(str8, Start + 1, num97 - Start - 1);
                    simpleList3.AddWeight((int) Math.Round(Conversion.Val(InputStr)), 1, 1);
                  }
                  if (Strings.InStr(str8, "che(249,1,targetcharid") > 0)
                  {
                    int Start = Strings.InStr(Strings.InStr(Strings.InStr(str8, "che(249,1,targetcharid"), str8, "targetcharid"), str8, ",");
                    int num98 = Strings.InStr(Start, str8, ")");
                    string InputStr = Strings.Mid(str8, Start + 1, num98 - Start - 1);
                    simpleList3.AddWeight((int) Math.Round(Conversion.Val(InputStr)), 1, 2);
                  }
                }
              }
            }
            num94 = Conversions.ToInteger(this.game.Data.StringListObj[stringListById8].GetData(0, "DIFF", 1));
            if (num94 > 999)
              num94 = 999;
          }
          this.game.EventRelatedObj.fixedAvgRollOverule = false;
          int num99 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(1, idValue3, 2, this.game.Data.RegimeObj[this.game.Data.Turn].id, 0)));
          int num100 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue3, 2)));
          if (num99 < 1)
          {
            num99 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById5].GetData2(1, idValue4, 2, this.game.Data.RegimeObj[this.game.Data.Turn].id, 0)));
            num100 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById6].GetData(0, idValue4, 2)));
          }
          int num101 = -1;
          if (num99 > 0)
          {
            switch (num100)
            {
              case 1:
                num101 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 5, num99, -1);
                break;
              case 2:
                num101 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 9, num99, -1);
                break;
            }
          }
          if (num93 == 2 & this.miniSelectValue > -1)
          {
            int characterId = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 10, this.miniSelectValue, -1);
            if (characterId > 0 & idValue3 < 1)
              num101 = characterId;
          }
          if (num101 < 1)
            num101 = this.game.EventRelatedObj.Helper_GetCharacterId(this.game.Data.RegimeObj[this.game.Data.Turn].id, 8, 0, -1);
          this.game.Data.StringListObj[stringListById8].SetData(0, "ORGID", 1, num99, true);
          if (num101 > 0)
            this.game.Data.StringListObj[stringListById8].SetData(0, "CHARID", 1, num101, true);
          string tstring10 = "Uknown";
          string tstring11 = "Unknown";
          if (num101 > 0)
          {
            tstring11 = this.game.EventRelatedObj.Helper_GetCharacterJobTitle(num101, shortJobSpecific: true);
            tstring10 = this.game.Data.StringListObj[stringListById7].GetData(0, num101, 3) + " " + this.game.Data.StringListObj[stringListById7].GetData(0, num101, 4);
            string setValue = tstring10;
            this.game.Data.StringListObj[stringListById8].SetData(0, "CHARNAME", 1, setValue, true);
          }
          if (this.detailnr > -1)
          {
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring9, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y18, this.game.seColWhite);
            int y21 = y18 + 16;
            if (this.h > 672)
            {
              ref Graphics local25 = ref g;
              bitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(num101, 50, 70, true);
              ref Bitmap local26 = ref bitmap;
              int x13 = x11 + (int) Math.Round((double) width / 2.0) - 25;
              int y22 = y21;
              DrawMod.DrawSimple(ref local25, ref local26, x13, y22);
              trect3 = new Rectangle(x11 + (int) Math.Round((double) width / 2.0) - 25, y21, 50, 70);
              Rectangle trect8 = trect3;
              this.AddMouse(ref trect8, "", "Click for more information", 11, num101);
              y21 += 70;
            }
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring10, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y21, this.game.seColWhite);
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring11, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y21 + 16, this.game.seColWhite);
            y18 = y21 + 42;
          }
          if (!flag1 & this.miniSelectValue < 0)
          {
            string tstring12 = "IMPOSSIBLE";
            string str9 = "";
            if (SL.FindNr(num91) > -1)
              str9 = this.cardWhyNot[SL.FindNr(num91), 1];
            if (Information.IsNothing((object) str9))
              str9 = "There is a reason this is impossible, but we cannot tell you.";
            if (Operators.CompareString(str9, "", false) == 0)
              str9 = "There is a reason this is impossible, but we cannot tell you.";
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring12, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y18, this.game.seColWhite);
            int y23 = y18 + 16;
            if (!Information.IsNothing((object) str9))
            {
              SizeF sizeF1 = new SizeF();
              StringFormat stringFormat = new StringFormat();
              SizeF sizeF2 = g.MeasureString(str9, this.game.MarcFont4, width - 20);
              DrawMod.DrawTextColouredConsoleMultiline(ref g, str9, this.game.MarcFont4, x11 + 10, y23, this.game.seColRed, width - 20, 80, true);
              y23 = (int) Math.Round((double) ((float) y23 + sizeF2.Height));
            }
            y18 = y23 + 10;
          }
          if (!flag1 & !flag4 & SL.FindNr(num91) > -1 & this.miniSelectValue > -1)
          {
            string tstring13 = "INVALID TARGET";
            string str10 = "";
            if (SL.FindNr(num91) > -1)
              str10 = this.cardWhyNot[SL.FindNr(num91), this.miniSelectValue];
            if (Information.IsNothing((object) str10))
              str10 = "Invalid Target";
            if (Operators.CompareString(str10, "", false) == 0)
              str10 = "Invalid Target";
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring13, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y18, this.game.seColWhite);
            int y24 = y18 + 16;
            if (!Information.IsNothing((object) str10))
            {
              SizeF sizeF3 = new SizeF();
              StringFormat stringFormat = new StringFormat();
              SizeF sizeF4 = g.MeasureString(str10, this.game.MarcFont4, width - 20);
              DrawMod.DrawTextColouredConsoleMultiline(ref g, str10, this.game.MarcFont4, x11 + 10, y24, this.game.seColRed, width - 20, 80, true);
              y24 = (int) Math.Round((double) ((float) y24 + sizeF4.Height));
            }
            y18 = y24 + 10;
          }
          if (flag1 & !flag4)
          {
            string tstring14 = "DIFFICULTY";
            string tstring15;
            if (flag4)
              tstring15 = "No target selected";
            else if (!flag1)
              tstring15 = "No valid target";
            else if (num94 > 0 | flag5)
            {
              tstring15 = num94.ToString();
              if (flag5 & num94 > 0)
                tstring15 = str5 + " +" + num94.ToString();
              else if (flag5 & num94 < 1)
                tstring15 = str5;
            }
            else
              tstring15 = "No Tests";
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring14, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y18, this.game.seColWhite);
            DrawMod.DrawTextColouredConsoleCenter(ref g, tstring15, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y18 + 16, this.game.seColWhite);
            y18 += 42;
            if (!flag4 & flag1 && simpleList3.Counter > -1)
            {
              bool flag6 = false;
              bool flag7 = false;
              int counter3 = simpleList3.Counter;
              for (int index23 = 0; index23 <= counter3; ++index23)
              {
                if (simpleList3.Data1[index23] == 2)
                  flag6 = true;
                else
                  flag7 = true;
              }
              string tstring16 = flag6 ? (!(flag6 & !flag7) ? "ROLLS (BOTH LEADERS)" : "ROLLS FOR TARGET LEADER") : "ROLLS";
              DrawMod.DrawTextColouredConsoleCenter(ref g, tstring16, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y18, this.game.seColWhite);
              int y25 = y18 + 16;
              int counter4 = simpleList3.Counter;
              for (int index24 = 0; index24 <= counter4; ++index24)
              {
                string data = this.game.Data.StringListObj[stringListById10].GetData(0, simpleList3.Id[index24], 1);
                int num102 = this.game.EventRelatedObj.Helper_SkillTotal(num101, simpleList3.Id[index24]);
                string tstring17 = num102 <= 0 ? (num102 != 0 ? data + " Skill Roll =  1d100 " + num102.ToString() : data + " Skill Roll =  1d100") : data + " Skill Roll = 1d100 + " + num102.ToString();
                bool flag8 = false;
                if (num101 > 0 & simpleList3.Data1[index24] != 2 && (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById7].GetData(0, num101, 6))) == 8)
                {
                  tstring17 += " -25";
                  flag8 = true;
                }
                if (simpleList3.Data1[index24] == 2 | flag8)
                  tstring17 += " *";
                DrawMod.DrawTextColouredConsoleCenter(ref g, tstring17, this.game.MarcFont4, x11 + (int) Math.Round((double) width / 2.0), y25, this.game.seColWhite);
                if (simpleList3.Data1[index24] == 2)
                {
                  trect3 = new Rectangle(x11, y25 - 20, width, 40);
                  Rectangle trect9 = trect3;
                  this.AddMouse(ref trect9, "ASTERIX *", "This *-sign means the Skill Roll is actually made by the targetted Leader.");
                }
                else if (flag8)
                {
                  trect3 = new Rectangle(x11, y25 - 20, width, 40);
                  Rectangle trect10 = trect3;
                  this.AddMouse(ref trect10, "ASTERIX *", "This *-sign means because Secretary is executing the Stratagem there is a -25 penalty.");
                }
                y25 += 16;
              }
              y18 = y25 + 10;
            }
          }
        }
        int num103 = num80 - 10;
        int num104 = y18 + 2;
        int num105 = 235;
        if (flag4)
          flag1 = false;
        if (this.hovernr > -1)
        {
          if (!flag1)
          {
            SubPartClass tsubpart19 = (SubPartClass) new TextButtonPartClass("EXECUTE STRATAGEM", num105, "The selected target is not valid.", ref this.OwnBitmap, num103, num104, true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.info2id = this.AddSubPart(ref tsubpart19, num103, num104, num105, 40, 1);
          }
          else if (flag3)
          {
            SubPartClass tsubpart20 = (SubPartClass) new TextButtonPartClass("EXECUTE STRATAGEM", num105, "Click to play this stratagem", ref this.OwnBitmap, num103, num104, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.Info1Id = this.AddSubPart(ref tsubpart20, num103, num104, num105, 40, 1);
          }
          else
          {
            SubPartClass tsubpart21 = (SubPartClass) new TextButtonPartClass("EXECUTE STRATAGEM", num105, "You dont have the " + str4 + " to play this stratagem.", ref this.OwnBitmap, num103, num104, true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.info2id = this.AddSubPart(ref tsubpart21, num103, num104, num105, 40, 1);
          }
        }
        else if (this.detailnr > -1)
        {
          if (!flag1)
          {
            SubPartClass tsubpart22 = (SubPartClass) new TextButtonPartClass("EXECUTE STRATAGEM", num105, "The selected target is not valid.", ref this.OwnBitmap, num103, num104, true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.info2id = this.AddSubPart(ref tsubpart22, num103, num104, num105, 40, 1);
          }
          else if (flag3)
          {
            SubPartClass tsubpart23 = (SubPartClass) new TextButtonPartClass("EXECUTE STRATAGEM", num105, "Click to play this stratagem", ref this.OwnBitmap, num103, num104, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.Info1Id = this.AddSubPart(ref tsubpart23, num103, num104, num105, 40, 1);
          }
          else
          {
            SubPartClass tsubpart24 = (SubPartClass) new TextButtonPartClass("EXECUTE STRATAGEM", num105, "You dont have the " + str4 + " to play this stratagem.", ref this.OwnBitmap, num103, num104, true, theight: 40, usefont: this.game.MarcFont3, useshadow: true, tMarcStyle: true);
            this.info2id = this.AddSubPart(ref tsubpart24, num103, num104, num105, 40, 1);
          }
        }
      }
      this.CopyToEditObj();
    }

    public override void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            if (this.SubPartID[index] == this.pageId)
            {
              this.game.EditObj.TipButton = false;
              this.SubPartList[index].HandleToolTip(x - this.SubPartX[index], y - this.SubPartY[index]);
              if (this.game.EditObj.TipButton)
                return;
            }
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
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          if (this.MouseData[mouseCounter] > -1)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[mouseCounter];
          this.game.EditObj.TipText = this.MouseText[mouseCounter];
          break;
        }
      }
    }

    public override WindowReturnClass handleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      windowReturnClass.Flag = false;
      if (this.SubPartCounter > -1)
      {
        for (int subPartCounter = this.SubPartCounter; subPartCounter >= 0; subPartCounter += -1)
        {
          if (x > this.SubPartX[subPartCounter] & y > this.SubPartY[subPartCounter] & x < this.SubPartX[subPartCounter] + this.SubPartW[subPartCounter] & y < this.SubPartY[subPartCounter] + this.SubPartH[subPartCounter])
          {
            SubPartClass subPart = this.SubPartList[subPartCounter];
            int x1 = x - this.SubPartX[subPartCounter];
            int y1 = y - this.SubPartY[subPartCounter];
            WindowClass windowClass = (WindowClass) this;
            ref WindowClass local = ref windowClass;
            if (subPart.HandleTimerWheel(x1, y1, ref local))
            {
              windowReturnClass.SetFlag(true);
              if (this.miniId == this.SubPartID[subPartCounter])
              {
                if (this.miniId > 0)
                {
                  this.RemoveSubPart(this.miniId);
                  this.miniId = 0;
                }
                if (this.Info1Id > 0)
                {
                  this.RemoveSubPart(this.Info1Id);
                  this.Info1Id = 0;
                }
                this.game.EditObj.MiniMap = new Bitmap(10, 10);
                this.DoRefresh();
                this.prepareTempValue4();
                this.dostuff();
              }
              return windowReturnClass;
            }
          }
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      if (this.mouseOverWhichTab > 0 && !this.MouseInThisWindow)
      {
        this.mouseOverWhichTab = 0;
        this.dostuff();
        windowReturnClass1.SetFlag(true);
        return windowReturnClass1;
      }
      if (this.game.EditObj.WINDOW_DEBUG_MODE)
      {
        int index1 = -1;
        int mouseCounter = this.MouseCounter;
        for (int index2 = 0; index2 <= mouseCounter; ++index2)
        {
          if (this.MouseData[index2] == 2 | this.MouseData[index2] == 1 && this.viewMode != this.MouseData[index2])
          {
            index1 = index2;
            break;
          }
        }
        int x = 0;
        int y = 0;
        int num = DrawMod.RandyNumber.Next(0, 1000);
        if (num <= 600 & this.Info1Id > 0)
        {
          int index3 = this.SubpartNr(this.Info1Id);
          if (index3 > -1)
          {
            x = this.SubPartX[index3] + 3;
            y = this.SubPartY[index3] + 3;
          }
        }
        else if (num <= 130 & index1 > -1)
        {
          x = this.MouseRect[index1].X + 3;
          y = this.MouseRect[index1].Y + 3;
        }
        else if (num <= 150 & this.sizeId > 0)
        {
          int index4 = this.SubpartNr(this.sizeId);
          if (index4 > -1)
          {
            x = this.SubPartX[index4] + 3;
            y = this.SubPartY[index4] + 3;
          }
        }
        else
        {
          x = DrawMod.RandyNumber.Next(60, this.w - 420);
          y = DrawMod.RandyNumber.Next(30, this.h - 50);
        }
        if (x > 0)
        {
          WindowReturnClass windowReturnClass2 = this.HandleMouseClick(x, y, 1);
          if (windowReturnClass2.Counter > -1)
            ;
          return windowReturnClass2;
        }
      }
      return windowReturnClass1;
    }

    public override WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      WindowReturnClass windowReturnClass2 = base.HandleMouseMove(x, y);
      bool flag = false;
      int num1 = -1;
      int num2 = -1;
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          if (this.cardSize == 1 && this.MouseData[mouseCounter] >= 100 & this.MouseData[mouseCounter] <= 100 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter + 100)
          {
            if (this.hovernr == this.MouseData[mouseCounter] - 100)
            {
              flag = true;
              break;
            }
            flag = true;
            this.hovernr = this.MouseData[mouseCounter] - 100;
            this.dostuff();
            windowReturnClass2.SetFlag(true);
            break;
          }
          if (this.MouseData[mouseCounter] >= 1 & this.MouseData[mouseCounter] <= 2)
            num1 = this.MouseData[mouseCounter];
          if (this.MouseData[mouseCounter] >= 50100 & this.MouseData[mouseCounter] <= 50100 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter + 100)
            num2 = this.MouseData[mouseCounter] - 50100;
        }
      }
      if (num1 > 0)
      {
        if (this.mouseOverWhichTab != num1)
        {
          if (this.game.EmpireStyle)
            SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav", ref this.game.EditObj);
          this.mouseOverWhichTab = num1;
          this.dostuff();
          windowReturnClass2.SetFlag(true);
          return windowReturnClass2;
        }
      }
      else
      {
        if (this.mouseOverWhichTab > 0)
        {
          this.mouseOverWhichTab = -1;
          this.dostuff();
          windowReturnClass2.SetFlag(true);
          return windowReturnClass2;
        }
        if (num2 >= 0)
        {
          if (this.scrapMouseOver != num2)
          {
            if (this.game.EmpireStyle)
              SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav", ref this.game.EditObj);
            this.scrapMouseOver = num2;
            this.dostuff();
            windowReturnClass2.SetFlag(true);
            return windowReturnClass2;
          }
        }
        else if (num2 == -1 & this.scrapMouseOver != -1)
        {
          if (this.game.EmpireStyle)
            SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav", ref this.game.EditObj);
          this.scrapMouseOver = -1;
          this.dostuff();
          windowReturnClass2.SetFlag(true);
          return windowReturnClass2;
        }
      }
      if (!flag & this.hovernr > -1)
      {
        this.hovernr = -1;
        this.dostuff();
        windowReturnClass2.SetFlag(true);
      }
      return windowReturnClass2;
    }

    public override void Before_DoRefresh_Called_By_FlagAllIncludingRefresh()
    {
      int mapWidth = this.game.Data.MapObj[0].MapWidth;
      int mapHeight = this.game.Data.MapObj[0].MapHeight;
      if (this.game.EditObj.se1_CardsCategory > 0)
      {
        if (this.categorySelectMode[this.currentCat] == 4)
        {
          this.miniSelectValue = (int) Math.Round(Conversion.Val((object) this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0))].FindRow(0, this.miniSelectLeader)));
          if (this.miniSelectValue < 0)
            this.miniSelectLeader = -1;
        }
        if (this.categorySelectMode[this.currentCat] == 3 & this.miniUnitSelect > -1 && this.miniUnitSelect > this.game.Data.UnitCounter | this.miniUnitSelect < 1)
          this.miniUnitSelect = -1;
        if (this.categorySelectMode[this.currentCat] == 5 & this.miniUnitSelect > -1 && this.miniUnitSelect > this.game.Data.UnitCounter | this.miniUnitSelect < 1)
          this.miniUnitSelect = -1;
        if (this.categorySelectMode[this.currentCat] == 1 & this.miniSelectValue > -1)
        {
          this.game.EditObj.se1_CardsSelectX = this.miniSelectX;
          this.game.EditObj.se1_CardsSelectY = this.miniSelectY;
          if (this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 143, 0, 0))].FindRow(0, this.miniSelectValue) < 0)
            this.miniSelectValue = -1;
          bool flag = false;
          if (this.game.EditObj.se1_CardsSelectX > -1 & this.game.EditObj.se1_CardsSelectY > -1 & this.game.EditObj.se1_CardsSelectX <= this.game.Data.MapObj[0].MapWidth & this.game.EditObj.se1_CardsSelectY <= this.game.Data.MapObj[0].MapHeight)
          {
            if (this.game.Data.MapObj[0].HexObj[this.game.EditObj.se1_CardsSelectX, this.game.EditObj.se1_CardsSelectY].Regime > -1)
            {
              if (this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[this.game.EditObj.se1_CardsSelectX, this.game.EditObj.se1_CardsSelectY].Regime].id != this.miniSelectValue)
                flag = true;
            }
            else
              flag = true;
          }
          if (this.miniSelectValue > 0 & flag)
          {
            int num1 = -1;
            int num2 = -1;
            int num3 = 0;
            do
            {
              int num4 = mapWidth;
              for (int index1 = 0; index1 <= num4; ++index1)
              {
                int num5 = mapHeight;
                for (int index2 = 0; index2 <= num5; ++index2)
                {
                  if (this.game.Data.MapObj[0].HexObj[index1, index2].Regime > -1 && num3 == 1 | this.game.Data.MapObj[0].HexObj[index1, index2].MaxRecon > 0 && this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[index1, index2].Regime].id == this.miniSelectValue & num1 == -1)
                  {
                    num1 = index1;
                    num2 = index2;
                  }
                }
              }
              ++num3;
            }
            while (num3 <= 1);
            if (num1 > -1)
            {
              this.game.EditObj.se1_CardsSelectX = num1;
              this.game.EditObj.se1_CardsSelectY = num2;
            }
            else
              this.miniSelectValue = -1;
          }
        }
        if (this.categorySelectMode[this.currentCat] == 2 & this.miniSelectValue > -1)
        {
          this.game.EditObj.se1_CardsSelectX = this.miniSelectX;
          this.game.EditObj.se1_CardsSelectY = this.miniSelectY;
          if (this.game.Data.StringListObj[this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 123, 0, 0))].FindRow(0, this.miniSelectValue) < 0)
            this.miniSelectValue = -1;
          bool flag = false;
          if (this.game.EditObj.se1_CardsSelectX > -1 & this.game.EditObj.se1_CardsSelectY > -1 && this.zones.Value[this.game.EditObj.se1_CardsSelectX, this.game.EditObj.se1_CardsSelectY] != this.miniSelectValue)
            flag = true;
          if (this.miniSelectValue > 0 & flag)
          {
            int num6 = -1;
            int num7 = -1;
            int num8 = 0;
            do
            {
              int num9 = mapWidth;
              for (int index3 = 0; index3 <= num9; ++index3)
              {
                int num10 = mapHeight;
                for (int index4 = 0; index4 <= num10; ++index4)
                {
                  if (num8 == 1 | this.game.Data.MapObj[0].HexObj[index3, index4].MaxRecon > 0 && this.zones.Value[index3, index4] == this.miniSelectValue & num6 == -1)
                  {
                    num6 = index3;
                    num7 = index4;
                  }
                }
              }
              ++num8;
            }
            while (num8 <= 1);
            if (num6 > -1)
            {
              this.game.EditObj.se1_CardsSelectX = num6;
              this.game.EditObj.se1_CardsSelectY = num7;
            }
            else
              this.miniSelectValue = -1;
          }
        }
        this.miniSelectX = this.game.EditObj.se1_CardsSelectX;
        this.miniSelectY = this.game.EditObj.se1_CardsSelectY;
      }
      if (this.miniSelectX < 0 | this.miniSelectY < 0)
      {
        this.miniSelectX = this.game.SelectX;
        this.miniSelectY = this.game.SelectY;
      }
      this.prepareTempValue4();
      this.donePrepareCardPlayable = false;
      this.dostuff();
    }

    public void PopUpRefresh()
    {
      this.DoRefresh();
      this.prepareTempValue4();
      this.donePrepareCardPlayable = false;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height)
        {
          if (this.MouseData[mouseCounter] >= 1 & this.MouseData[mouseCounter] <= 2)
          {
            this.viewMode = this.MouseData[mouseCounter];
            if (this.OptionsListId > 0)
            {
              this.RemoveSubPart(this.OptionsListId);
              this.OptionsListId = 0;
            }
            if (this.OptionsList2Id > 0)
            {
              this.RemoveSubPart(this.OptionsList2Id);
              this.OptionsList2Id = 0;
            }
            this.dostuff();
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[mouseCounter] == 9999999)
          {
            this.game.EditObj.SetViewMode2 = 0;
            if (this.game.EditObj.GuiDown)
            {
              this.game.EditObj.GuiDown = false;
              this.game.EditObj.SetViewMode2 = 0;
              windowReturnClass.AddCommand(3, 11);
            }
            else
            {
              windowReturnClass.AddCommand(1, 9);
              windowReturnClass.AddCommand(7, 12);
              windowReturnClass.AddCommand(4, 67);
            }
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[mouseCounter] == 11)
          {
            this.game.EditObj.UDSpopupText = "";
            this.formref.Cursor = Cursors.WaitCursor;
            this.game.EditObj.UDSClearInput();
            this.game.EventRelatedObj.SetUDSKey("CHARID", this.MouseData2[mouseCounter]);
            this.game.EventRelatedObj.DoCheckSpecificEvent(this.game.EventRelatedObj.CheckGetEventByLib("SE_Present", 531, 0, 0));
            this.formref.Cursor = Cursors.Default;
            this.game.EditObj.PopupValue = 21;
            windowReturnClass.AddCommand(5, 14);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          }
          if (this.MouseData[mouseCounter] >= 100 & this.MouseData[mouseCounter] <= 100 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter + 100)
          {
            if (this.MouseData[mouseCounter] - 100 != this.detailnr)
            {
              this.detailnr = this.MouseData[mouseCounter] - 100;
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
          else
          {
            if (this.MouseData[mouseCounter] >= 50100 & this.MouseData[mouseCounter] <= 100 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter + 50100)
            {
              if (this.game.EmpireStyle)
                SoundMod.PlayAWave(this.game.AppPath + "sound/specials/cash.wav", ref this.game.EditObj);
              int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
              int setValue = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "scrapPoints", 2))) + this.MouseData2[mouseCounter];
              this.game.Data.StringListObj[stringListById].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "scrapPoints", 2, setValue, true);
              int num = this.MouseData[mouseCounter] - 50100;
              for (int actionCardCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter; actionCardCounter >= 0; actionCardCounter += -1)
              {
                if (actionCardCounter == num)
                {
                  int nr = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[actionCardCounter];
                  this.game.Data.RegimeObj[this.game.Data.Turn].RemoveActionCard(actionCardCounter);
                  this.game.Data.RemoveActionCard(nr);
                  break;
                }
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (this.MouseData[mouseCounter] > 100000)
            {
              this.detailnr = -1;
              this.lastActualCard = -1;
              this.pageNr = 0;
              this.currentCat = this.MouseData[mouseCounter] - 100000;
              this.miniCatSelectValue = -1;
              this.miniUnitSelect = -1;
              this.miniSelectValue = -1;
              this.miniSelectLeader = -1;
              this.prepareTempValue4();
              this.donePrepareCardPlayable = false;
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
          if (this.MouseData[mouseCounter] == 51)
          {
            int index1 = this.SubpartNr(this.miniId);
            Coordinate hexCoord = ((MiniMapPartClass) this.SubPartList[index1]).GetHexCoord(x - this.SubPartX[index1], y - this.SubPartY[index1]);
            if (hexCoord.onmap)
            {
              if (this.categorySelectMode[this.currentCat] == 1)
              {
                int index2 = this.game.EditObj.TempAI[hexCoord.x, hexCoord.y];
                if (index2 > -1)
                {
                  int id = this.game.Data.RegimeObj[index2].id;
                  if (this.miniSelectValue != id)
                  {
                    this.miniSelectValue = id;
                    this.miniSelectX = hexCoord.x;
                    this.miniSelectY = hexCoord.y;
                    this.dostuff();
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
              }
              if (this.categorySelectMode[this.currentCat] == 2)
              {
                int index3 = this.game.EditObj.TempValue4[0].Value[hexCoord.x, hexCoord.y];
                if (index3 > 0 && this.zoneVisible[index3] && this.miniSelectValue != index3)
                {
                  this.miniSelectValue = index3;
                  this.miniSelectX = hexCoord.x;
                  this.miniSelectY = hexCoord.y;
                  this.dostuff();
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
              }
            }
          }
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index4 = 0; index4 <= subPartCounter; ++index4)
        {
          if (x > this.SubPartX[index4] & x < this.SubPartX[index4] + this.SubPartW[index4] && y > this.SubPartY[index4] & y < this.SubPartY[index4] + this.SubPartH[index4])
          {
            int num1 = this.SubPartID[index4];
            if (num1 == this.nextId)
            {
              ++this.pageNr;
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.prevId)
            {
              --this.pageNr;
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.sizeId)
            {
              this.cardSize = this.cardSize != 1 ? 1 : 2;
              this.pageNr = 1;
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.scrapId)
            {
              this.scrapMode = !this.scrapMode;
              if (!this.scrapMode)
                this.donePrepareCardPlayable = false;
              if (this.OptionsListId > 0)
              {
                this.RemoveSubPart(this.OptionsListId);
                this.OptionsListId = 0;
              }
              if (this.OptionsList2Id > 0)
              {
                this.RemoveSubPart(this.OptionsList2Id);
                this.OptionsList2Id = 0;
              }
              this.dostuff();
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              int index5 = this.SubPartList[index4].Click(x - this.SubPartX[index4], y - this.SubPartY[index4]);
              if (index5 > -1)
              {
                this.SubPartFlag[index4] = true;
                if (this.categorySelectMode[this.currentCat] == 1)
                {
                  if (this.miniSelectValue == this.game.Data.RegimeObj[index5].id)
                    ;
                  this.miniSelectValue = this.game.Data.RegimeObj[index5].id;
                  Coordinate coordinate;
                  coordinate.onmap = false;
                  int mapWidth = this.game.Data.MapObj[0].MapWidth;
                  for (int index6 = 0; index6 <= mapWidth; ++index6)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index7 = 0; index7 <= mapHeight; ++index7)
                    {
                      if (this.game.Data.MapObj[0].HexObj[index6, index7].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[index6, index7].Regime].id == this.miniSelectValue && this.game.Data.MapObj[0].HexObj[index6, index7].MaxRecon > 0)
                      {
                        coordinate.x = index6;
                        coordinate.y = index7;
                        coordinate.onmap = true;
                        break;
                      }
                    }
                    if (coordinate.onmap)
                      break;
                  }
                  if (coordinate.onmap)
                  {
                    this.miniSelectX = coordinate.x;
                    this.miniSelectY = coordinate.y;
                  }
                }
                if (this.categorySelectMode[this.currentCat] == 2)
                {
                  if (this.miniSelectValue == index5)
                    ;
                  this.miniSelectValue = index5;
                  Coordinate coordinate;
                  coordinate.onmap = false;
                  int mapWidth = this.game.Data.MapObj[0].MapWidth;
                  for (int index8 = 0; index8 <= mapWidth; ++index8)
                  {
                    int mapHeight = this.game.Data.MapObj[0].MapHeight;
                    for (int index9 = 0; index9 <= mapHeight; ++index9)
                    {
                      if (this.zones.Value[index8, index9] > 0 && this.game.Data.MapObj[0].HexObj[index8, index9].MaxRecon > 0 && this.zones.Value[index8, index9] == this.miniSelectValue)
                      {
                        coordinate.x = index8;
                        coordinate.y = index9;
                        coordinate.onmap = true;
                        break;
                      }
                    }
                    if (coordinate.onmap)
                      break;
                  }
                  if (coordinate.onmap)
                  {
                    this.miniSelectX = coordinate.x;
                    this.miniSelectY = coordinate.y;
                  }
                }
                if (this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5)
                {
                  this.miniUnitSelect = index5;
                  Coordinate coordinate;
                  coordinate.onmap = false;
                }
                if (this.categorySelectMode[this.currentCat] == 4)
                {
                  int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0));
                  this.miniSelectValue = index5;
                  this.miniSelectLeader = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].Data[this.miniSelectValue, 0]));
                  Coordinate coordinate;
                  coordinate.onmap = false;
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else if (num1 == this.OptionsList2Id)
            {
              int num2 = this.SubPartList[index4].Click(x - this.SubPartX[index4], y - this.SubPartY[index4]);
              if (num2 > -1)
              {
                this.SubPartFlag[index4] = true;
                if (this.categorySelectMode[this.currentCat] == 3 | this.categorySelectMode[this.currentCat] == 5)
                {
                  this.miniUnitSelect = -1;
                  this.miniCatSelectValue = num2;
                  Coordinate coordinate;
                  coordinate.onmap = false;
                }
                if (this.categorySelectMode[this.currentCat] == 4)
                {
                  this.miniSelectValue = -1;
                  this.miniCatSelectValue = num2;
                  this.miniSelectLeader = -1;
                  Coordinate coordinate;
                  coordinate.onmap = false;
                }
                this.dostuff();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else if (num1 == this.pageId)
            {
              int enr = this.SubPartList[index4].Click(x - this.SubPartX[index4], y - this.SubPartY[index4]);
              if (enr > 0)
              {
                this.game.EditObj.UDSpopupText = "";
                this.formref.Cursor = Cursors.WaitCursor;
                this.game.EventRelatedObj.DoCheckSpecificEvent(enr);
                this.formref.Cursor = Cursors.Default;
                if (this.game.EditObj.UDSpopupText.Length > 1)
                {
                  this.game.EditObj.PopupValue = 21;
                  this.game.EditObj.udsLastCalledPopupEventNr = enr;
                  windowReturnClass.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.SubPartFlag[index4] = true;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            else
            {
              if (num1 == this.buyScrapId)
              {
                if (this.game.EmpireStyle)
                  SoundMod.PlayAWave(this.game.AppPath + "sound/specials/powerup.wav", ref this.game.EditObj);
                this.game.EventRelatedObj.ExecMakeAndGiveScrapCard(this.game.Data.Turn);
                int num3 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter];
                string str = "New Stratagem has been crafted!";
                int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 210, 0, 0));
                int num4 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "scrapPoints", 2)));
                int num5 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "scrapPointCost", 2)));
                if (num5 < 15)
                  num5 = 15;
                int setValue1 = num4 - num5;
                if (0 > setValue1)
                  setValue1 = 0;
                int setValue2 = num5 + Math.Max(1, (int) Math.Round(Math.Floor((double) num5 / 10.0)));
                this.game.Data.StringListObj[stringListById].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "scrapPoints", 2, setValue1, true);
                this.game.Data.StringListObj[stringListById].SetData2(0, this.game.Data.RegimeObj[this.game.Data.Turn].id, 1, "scrapPointCost", 2, setValue2, true);
                this.game.EditObj.PopupValue = 29;
                this.game.EditObj.QuestionText = str;
                this.game.EditObj.QuestionCard = num3;
                this.game.EditObj.AnswerCount = 1;
                this.game.EditObj.AnswerText[1] = "Okay";
                this.game.EditObj.AnswerTextMouseOver[1] = "Acknowledge the receival of this new Scrap Stragem.";
                windowReturnClass.AddCommand(5, 14);
                this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                this.scrapMode = false;
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
              if (num1 == this.Info1Id)
              {
                this.game.EditObj.se1_map_data3cache_set = false;
                int unitSelected = this.game.EditObj.UnitSelected;
                this.lastActualCard = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr];
                int cardNr = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr];
                this.game.EditObj.SkippedPreSelectPopup = false;
                this.viewMode = 1;
                if (this.OptionsListId > 0)
                {
                  this.RemoveSubPart(this.OptionsListId);
                  this.OptionsListId = 0;
                }
                if (this.OptionsList2Id > 0)
                {
                  this.RemoveSubPart(this.OptionsList2Id);
                  this.OptionsList2Id = 0;
                }
                if (this.game.Data.ActionCardObj[cardNr].AreaSlot > -1 & this.categorySelectMode[this.currentCat] < 1)
                {
                  if (this.game.EditObj.AreaX == -1)
                  {
                    this.game.FormRef.Cursor = Cursors.WaitCursor;
                    this.game.EditObj.DoCardSlot = this.detailnr;
                    this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, this.detailnr);
                    if (this.game.HandyFunctionsObj.CardSelectHexTestPossible(cardNr, this.game.Data.ActionCardObj[cardNr].AreaSlot, this.game.Data.ActionCardObj[cardNr].AreaValue))
                    {
                      this.game.FormRef.Cursor = Cursors.Default;
                      this.game.EditObj.DoCardSlot = this.detailnr;
                      this.game.EditObj.HandCard = -1;
                      this.game.EditObj.AreaSlot = -1;
                      this.game.EditObj.AreaValue = -1;
                      this.game.EditObj.AreaX = -1;
                      this.game.EditObj.AreaY = -1;
                      this.game.EditObj.AreaMap = -1;
                      this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[cardNr].AreaSlot;
                      this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[cardNr].AreaValue;
                      this.game.EditObj.PopupValue = 1;
                      windowReturnClass.AddCommand(5, 14);
                      this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                      windowReturnClass.SetFlag(true);
                      return windowReturnClass;
                    }
                    this.game.EditObj.SkippedPreSelectPopup = true;
                  }
                  else
                  {
                    int num6 = (int) Interaction.MsgBox((object) "Error. Cant have selected an Area X,Y already.");
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                }
                else if (this.game.Data.ActionCardObj[cardNr].UnitSelect & this.categorySelectMode[this.currentCat] < 1)
                {
                  this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, this.detailnr);
                  if (this.game.HandyFunctionsObj.CardSelectUnitTestPossible(cardNr))
                  {
                    this.game.EditObj.DoCardSlot = this.detailnr;
                    this.game.EditObj.HandCard = -1;
                    this.game.EditObj.AreaSlot = -1;
                    this.game.EditObj.AreaValue = -1;
                    this.game.EditObj.AreaX = -1;
                    this.game.EditObj.AreaY = -1;
                    this.game.EditObj.AreaMap = -1;
                    this.game.EditObj.PopupValue = 3;
                    this.game.EditObj.UnitSelected = this.miniUnitSelect;
                    windowReturnClass.AddCommand(5, 14);
                    this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                    windowReturnClass.SetFlag(true);
                    return windowReturnClass;
                  }
                  this.game.EditObj.SkippedPreSelectPopup = true;
                }
                int stringListById = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 277, 0, 0));
                bool dontDelete = false;
                if ((int) Math.Round(Conversion.Val(this.game.Data.StringListObj[stringListById].GetData(0, this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].TempVar0, 16))) > 0)
                  dontDelete = true;
                if ((double) this.game.Data.RuleVar[408] > 0.0)
                {
                  int selectX = this.game.SelectX;
                  int selectY = this.game.SelectY;
                  this.game.SelectX = this.miniSelectX;
                  this.game.SelectY = this.miniSelectY;
                  this.game.EditObj.DoCardSlot = this.detailnr;
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  if (this.categorySelectMode[this.currentCat] == 1)
                  {
                    int regime = this.game.Data.MapObj[0].HexObj[this.game.SelectX, this.game.SelectY].Regime;
                    int num7 = 0;
                    if (regime > -1)
                    {
                      if (this.game.Data.RegimeObj[regime].id != this.miniSelectValue)
                        num7 = 1;
                    }
                    else
                      num7 = 1;
                    if (num7 == 1)
                    {
                      int mapWidth1 = this.game.Data.MapObj[0].MapWidth;
                      for (int index10 = 0; index10 <= mapWidth1; ++index10)
                      {
                        int mapHeight = this.game.Data.MapObj[0].MapHeight;
                        for (int index11 = 0; index11 <= mapHeight; ++index11)
                        {
                          if (this.game.Data.MapObj[0].HexObj[index10, index11].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[index10, index11].Regime].id == this.miniSelectValue && this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[index10, index11].Regime].id == this.game.EditObj.TempValue4[0].Value[this.game.SelectX, this.game.SelectY])
                          {
                            this.game.SelectX = index10;
                            this.game.SelectY = index11;
                            num7 = 0;
                            break;
                          }
                        }
                      }
                      if (num7 == 1)
                      {
                        int mapWidth2 = this.game.Data.MapObj[0].MapWidth;
                        for (int index12 = 0; index12 <= mapWidth2; ++index12)
                        {
                          int mapHeight = this.game.Data.MapObj[0].MapHeight;
                          for (int index13 = 0; index13 <= mapHeight; ++index13)
                          {
                            if (this.game.Data.MapObj[0].HexObj[index12, index13].Regime > -1 && this.game.Data.RegimeObj[this.game.Data.MapObj[0].HexObj[index12, index13].Regime].id == this.miniSelectValue)
                            {
                              this.game.SelectX = index12;
                              this.game.SelectY = index13;
                              break;
                            }
                          }
                        }
                      }
                    }
                  }
                  if (this.categorySelectMode[this.currentCat] == 2 && this.zones.Value[this.game.SelectX, this.game.SelectY] != this.miniSelectValue)
                  {
                    int mapWidth = this.game.Data.MapObj[0].MapWidth;
                    for (int index14 = 0; index14 <= mapWidth; ++index14)
                    {
                      int mapHeight = this.game.Data.MapObj[0].MapHeight;
                      for (int index15 = 0; index15 <= mapHeight; ++index15)
                      {
                        if (this.game.Data.MapObj[0].HexObj[index14, index15].Regime > -1 && this.zones.Value[index14, index15] == this.miniSelectValue && this.zones.Value[index14, index15] == this.game.EditObj.TempValue4[0].Value[this.game.SelectX, this.game.SelectY])
                        {
                          this.game.SelectX = index14;
                          this.game.SelectY = index15;
                        }
                      }
                    }
                  }
                  this.game.ProcessingObj.PlayCard(this.game.Data.Turn, this.detailnr, dontDelete);
                  if (this.miniUnitSelect > 0 & this.categorySelectMode[this.currentCat] == 3)
                  {
                    int num8 = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[this.miniUnitSelect].Historical].GiveHisVarValue(28);
                    if (num8 != 0)
                      this.game.Data.UnitObj[this.miniUnitSelect].SODefendPercent = 100 - num8;
                    else
                      this.game.Data.UnitObj[this.miniUnitSelect].SODefendPercent = 50;
                  }
                  this.game.EditObj.DoCardSlot = -1;
                  windowReturnClass.SetFlag(true);
                  this.game.EditObj.PopupValue = 21;
                  windowReturnClass.AddCommand(5, 14);
                  windowReturnClass.SetFlag(true);
                  this.game.SelectX = selectX;
                  this.game.SelectY = selectY;
                  return windowReturnClass;
                }
                this.game.EditObj.UnitSelected = unitSelected;
                int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
                this.game.ProcessingObj.PlayCard(this.game.Data.Turn, this.detailnr, dontDelete);
                this.game.EditObj.HandCard = -1;
                this.game.EditObj.DoCardSlot = -1;
                if (this.game.EditObj.DoQuit)
                {
                  this.game.Data = new DataClass();
                  this.game.EditObj.DoQuit = false;
                  this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
                  if (this.game.Data.UseAI == 1)
                    this.game.NewAIObj.LastRegime = -1;
                  this.game.EditObj.ShowInitialMenu = true;
                  windowReturnClass.AddCommand(3, 12);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                if (Strings.Len(this.game.Data.LoadGame) > 0 & this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter <= messCounter)
                {
                  this.game.FormRef.Cursor = Cursors.WaitCursor;
                  Form formRef = (Form) this.game.FormRef;
                  this.game.HandyFunctionsObj.LoadGameNow();
                  this.game.FormRef = (Form1) formRef;
                  this.game.FormRef.Cursor = Cursors.Default;
                  windowReturnClass.AddCommand(3, 13);
                  return windowReturnClass;
                }
                if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
                {
                  this.game.EditObj.AreaSlot = -1;
                  this.game.EditObj.AreaValue = -1;
                  this.game.EditObj.AreaX = -1;
                  this.game.EditObj.AreaY = -1;
                  this.game.EditObj.AreaMap = -1;
                  this.game.EditObj.PopupValue = 0;
                  this.game.EditObj.FromMessage = messCounter + 1;
                  windowReturnClass.AddCommand(5, 14);
                  this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
                  windowReturnClass.SetFlag(true);
                  return windowReturnClass;
                }
                this.DoRefresh();
                windowReturnClass.SetFlag(true);
                return windowReturnClass;
              }
            }
            return windowReturnClass;
          }
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public Rectangle DrawOneTab(
      Graphics g,
      bool wideTab,
      bool active,
      int tx,
      int ty,
      string sHeader,
      string sText,
      int spriteSlot,
      int iconSlot,
      int smallNumber = -1,
      bool grayedOut = false,
      int textOffsetX = 0,
      int spriteOffsetY = 0,
      bool tMousingOverNow = false)
    {
      Bitmap bitmap1;
      if (tMousingOverNow)
      {
        if (active & wideTab)
        {
          ref Graphics local1 = ref g;
          Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1HIGH);
          ref Bitmap local2 = ref bitmap2;
          int x = tx;
          int y = ty;
          DrawMod.Draw(ref local1, ref local2, x, y, 0.05f, 0.05f, 0.05f, 1f);
        }
        if (!active & wideTab)
        {
          ref Graphics local3 = ref g;
          Bitmap bitmap3 = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1LOW);
          ref Bitmap local4 = ref bitmap3;
          int x = tx;
          int y = ty;
          DrawMod.Draw(ref local3, ref local4, x, y, 0.05f, 0.05f, 0.05f, 1f);
        }
      }
      else
      {
        if (active & wideTab)
        {
          ref Graphics local5 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1HIGH);
          ref Bitmap local6 = ref bitmap1;
          int x = tx;
          int y = ty;
          DrawMod.DrawSimple(ref local5, ref local6, x, y);
        }
        if (!active & wideTab)
        {
          ref Graphics local7 = ref g;
          bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ORDERBAR_TAB1LOW);
          ref Bitmap local8 = ref bitmap1;
          int x = tx;
          int y = ty;
          DrawMod.DrawSimple(ref local7, ref local8, x, y);
        }
      }
      if (wideTab)
      {
        if (spriteSlot > 0)
        {
          if (active)
          {
            ref Graphics local9 = ref g;
            bitmap1 = BitmapStore.GetBitmap(spriteSlot);
            ref Bitmap local10 = ref bitmap1;
            int x = tx + 3;
            int y = ty + 4 + spriteOffsetY;
            DrawMod.DrawSimple(ref local9, ref local10, x, y);
          }
          if (!active)
          {
            ref Graphics local11 = ref g;
            bitmap1 = BitmapStore.GetBitmap(spriteSlot);
            ref Bitmap local12 = ref bitmap1;
            int x = tx + 3;
            int y = ty + 11 + spriteOffsetY;
            DrawMod.DrawSimple(ref local11, ref local12, x, y);
          }
        }
        else if (iconSlot > -1 && !grayedOut)
        {
          Rectangle rectangle1;
          Rectangle rectangle2;
          if (active)
          {
            ref Graphics local13 = ref g;
            bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local14 = ref bitmap1;
            rectangle1 = new Rectangle(iconSlot * 42, 32, 42, 32);
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(tx + 4, ty + 11, 42, 32);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
          }
          if (!active)
          {
            ref Graphics local15 = ref g;
            bitmap1 = BitmapStore.GetBitmap(this.game.SE1_ICONS);
            ref Bitmap local16 = ref bitmap1;
            rectangle2 = new Rectangle(iconSlot * 42, 0, 42, 32);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(tx + 4, ty + 18, 42, 32);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
          }
        }
      }
      g.MeasureString(sText, DrawMod.TGame.MarcFont16);
      Color c;
      Color color;
      if (active)
      {
        c = this.game.seColWhite;
        color = this.game.seColGray;
      }
      if (!active)
      {
        c = this.game.seColGray;
        color = this.game.seColGray;
      }
      if (grayedOut)
      {
        c = Color.FromArgb((int) byte.MaxValue, 128, 128, 128);
        color = Color.FromArgb((int) byte.MaxValue, 128, 128, 128);
      }
      if (active)
      {
        if (wideTab)
          DrawMod.DrawTextColouredConsoleCenter(ref g, sText, this.game.MarcFont16, tx + 97, ty + 18, c);
      }
      else if (wideTab)
        DrawMod.DrawTextColouredConsoleCenter(ref g, sText, this.game.MarcFont16, tx + 97, ty + 25, c);
      Rectangle rectangle = new Rectangle(tx, ty, 200, 50);
      if (!wideTab)
        rectangle = new Rectangle(tx, ty, 75, 50);
      return rectangle;
    }
  }
}
