// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.HistoryWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Threading;

namespace WindowsApplication1
{
  public class HistoryWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info3id;
    private int mapid;
    private int info4id;
    private int info5id;
    private int info6id;
    private int ViewAntiCapId;
    private int ViewAntiCapTextId;
    private int ViewAntiCap2Id;
    private int ViewAntiCapText2Id;
    private int ViewAntiCap3Id;
    private int ViewAntiCapText3Id;
    private int ViewHistoryId;
    private int ViewHistoryTextId;
    private int ViewSupplyId;
    private int ViewSupplyTextId;
    private int Slider1Id;
    public int StartStep;
    public int EndStep;
    public int TotStep;
    public int Curstep;
    public int RealStepNr;
    public DateTime showtime;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    public bool AutoPlay;
    private int SpecialTextId;
    public int detail1;
    public int detail2;
    public int HumanPlayer;
    private int Turny;
    public int detailnr;
    public int lastregime;
    private int w;
    private int h;
    private int lastendstep;

    public HistoryWindowClass2(ref GameClass tGame, Bitmap screenbitmap = null, int sx = -1, int sy = -1)
      : base(ref tGame, tGame.ScreenWidth, 222, BackSprite: tGame.MARCBOTBAR)
    {
      this.w = tGame.ScreenWidth;
      this.h = 222;
      this.BlockBlit = true;
      if (!this.game.EditObj.AIMoving)
      {
        this.game.EditObj.RealRound = this.game.Data.Round;
        this.game.EditObj.RealTurn = this.game.Data.Turn;
      }
      this.StartStep = -1;
      this.EndStep = 0;
      this.lastendstep = 0;
      this.TotStep = -1;
      this.Curstep = 0;
      this.HumanPlayer = -1;
      this.Turny = this.game.EditObj.RealTurn;
      if (this.game.EditObj.TempAIWatch)
      {
        this.HumanPlayer = this.game.EditObj.HumanPlayer;
        this.Turny = this.game.EditObj.HumanPlayer;
      }
      this.detailnr = this.game.EditObj.MapSelected;
      this.game.EditObj.MiniMap = new Bitmap(1, 1);
      if (this.game.EditObj.TempAIWatch)
      {
        this.AutoPlay = true;
        this.game.EditObj.AIMoving = true;
      }
      this.game.EditObj.TempAIWatch = false;
      this.game.EditObj.OrderType = 26;
      this.showtime = DateAndTime.Now;
      this.game.EditObj.HisInfoString = "";
      this.game.EditObj.HisLossCounter = -1;
      if (this.game.Data.RegimeObj[this.Turny].HistoryStepCounter > -1)
      {
        this.StartStep = 1;
        this.EndStep = this.game.HandyFunctionsObj.GetRegimeHistoryTotSteps(this.Turny);
      }
      this.StartSit();
      if (this.game.EditObj.LastHistoryStep > 0)
      {
        this.Forward(this.game.EditObj.LastHistoryStep);
        this.Curstep = this.game.EditObj.LastHistoryStep;
        this.game.EditObj.LastHistoryStep = -1;
      }
      this.dostuff();
    }

    public void StartSit()
    {
      this.game.EditObj.HisForce = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.game.EditObj.HisSFType = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.game.EditObj.HisOwner = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.game.EditObj.HisHis = new MapMatrix2[this.game.Data.MapCounter + 1];
      this.game.EditObj.HisDepth = new MapMatrix2[this.game.Data.MapCounter + 1];
      int mapCounter = this.game.Data.MapCounter;
      for (int index = 0; index <= mapCounter; ++index)
      {
        this.game.EditObj.HisForce[index] = this.game.Data.RegimeObj[this.Turny].HistoryForce[index].Clone();
        this.game.EditObj.HisSFType[index] = this.game.Data.RegimeObj[this.Turny].HistorySFType[index].Clone();
        this.game.EditObj.HisOwner[index] = this.game.Data.RegimeObj[this.Turny].HistoryOwner[index].Clone();
        this.game.EditObj.HisHis[index] = this.game.Data.RegimeObj[this.Turny].HistoryHis[index].Clone();
        this.game.EditObj.HisDepth[index] = this.game.Data.RegimeObj[this.Turny].HistoryDepth[index].Clone();
      }
      if (this.game.Data.RegimeObj[this.Turny].HistoryStepCounter > -1)
        this.RealStepNr = this.game.Data.RegimeObj[this.Turny].HistoryStep[0].StepNr - 1;
      this.game.EditObj.HisHotX = -1;
      this.game.EditObj.HisHotY = -1;
      this.game.EditObj.HisHotMap = -1;
      this.game.EditObj.HisLossCounter = -1;
      this.game.EditObj.HisLossAttacker = new int[1];
      this.game.EditObj.HisLossDEAD = new int[1];
      this.game.EditObj.HisLossOK = new int[1];
      this.game.EditObj.HisLossSFType = new int[1];
      this.game.EditObj.HisRegimeWon = -1;
      this.game.EditObj.HisAttackType = -1;
      this.game.EditObj.TempCoordList = new CoordList();
    }

    public void Forward(int steps)
    {
      int num1 = -1;
      int num2 = 0;
      this.game.EditObj.HisHotX = -1;
      this.game.EditObj.HisHotY = -1;
      this.game.EditObj.HisHotMap = -1;
      this.game.EditObj.HisLossAttacker = new int[1];
      this.game.EditObj.HisLossDEAD = new int[1];
      this.game.EditObj.HisLossOK = new int[1];
      this.game.EditObj.HisLossSFType = new int[1];
      this.game.EditObj.HisLossCounter = -1;
      this.game.EditObj.HisRegimeWon = -1;
      this.game.EditObj.HisLossDefReg = -1;
      this.game.EditObj.HisLossAttReg = -1;
      this.game.EditObj.HisInfoString = "";
      this.game.EditObj.HisAttackType = -1;
      int num3 = 0;
      int historyStepCounter = this.game.Data.RegimeObj[this.Turny].HistoryStepCounter;
      for (int index1 = 0; index1 <= historyStepCounter; ++index1)
      {
        HistoryStepClass historyStepClass = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1];
        if (historyStepClass.StepNr > this.RealStepNr)
        {
          if (historyStepClass.StepNr != num1)
          {
            ++num2;
            num1 = historyStepClass.StepNr;
            if (num2 > steps)
            {
              this.RealStepNr = historyStepClass.StepNr - 1;
              break;
            }
            this.game.EditObj.HisLossCounter = -1;
            this.game.EditObj.HisRegimeWon = -1;
            this.game.EditObj.HisLossDefReg = -1;
            this.game.EditObj.HisLossAttReg = -1;
            this.game.EditObj.HisInfoString = "";
            this.game.EditObj.HisAttackType = -1;
          }
          else if (num2 > steps)
          {
            this.RealStepNr = historyStepClass.StepNr - 1;
            break;
          }
          this.lastregime = historyStepClass.Regime;
          this.game.EditObj.HisForce[historyStepClass.Map].Value[historyStepClass.X, historyStepClass.Y] = historyStepClass.Force;
          this.game.EditObj.HisSFType[historyStepClass.Map].Value[historyStepClass.X, historyStepClass.Y] = historyStepClass.SFType;
          this.game.EditObj.HisOwner[historyStepClass.Map].Value[historyStepClass.X, historyStepClass.Y] = historyStepClass.Ownership;
          this.game.EditObj.HisHis[historyStepClass.Map].Value[historyStepClass.X, historyStepClass.Y] = historyStepClass.His;
          this.game.EditObj.HisDepth[historyStepClass.Map].Value[historyStepClass.X, historyStepClass.Y] = historyStepClass.Depth;
          this.game.EditObj.TempCoordList.AddCoord(historyStepClass.X, historyStepClass.Y, historyStepClass.Map);
          int tfacing = 1;
          do
          {
            Coordinate coordinate = this.game.HandyFunctionsObj.HexNeighbour(historyStepClass.X, historyStepClass.Y, historyStepClass.Map, tfacing);
            if (coordinate.onmap)
              this.game.EditObj.TempCoordList.AddCoord(coordinate.x, coordinate.y, coordinate.map);
            ++tfacing;
          }
          while (tfacing <= 6);
          this.game.HandyFunctionsObj.SetcornerXY2(historyStepClass.X, historyStepClass.Y);
          if (this.game.EditObj.MapSelected != historyStepClass.Map)
          {
            this.game.EditObj.MapSelected = historyStepClass.Map;
            this.game.CornerX = 0;
            this.game.CornerY = 0;
            num3 = 1;
          }
          if (Strings.Len(historyStepClass.InfoString) > 0)
            this.game.EditObj.HisInfoString = historyStepClass.InfoString;
          if (historyStepClass.AttackOtherType > -1)
          {
            this.game.EditObj.HisHotX = historyStepClass.X;
            this.game.EditObj.HisHotY = historyStepClass.Y;
            this.game.EditObj.HisHotMap = historyStepClass.Map;
            this.game.EditObj.HisNeighbour = new Neighbours();
            int index2 = 0;
            do
            {
              this.game.EditObj.HisNeighbour.data[index2] = historyStepClass.AttackDirection[index2];
              ++index2;
            }
            while (index2 <= 5);
            this.game.EditObj.HisAttackType = historyStepClass.AttackOtherType;
          }
          else
          {
            this.game.EditObj.HisHotX = historyStepClass.X;
            this.game.EditObj.HisHotY = historyStepClass.Y;
            this.game.EditObj.HisHotMap = historyStepClass.Map;
          }
          if (historyStepClass.LossCounter > -1)
          {
            this.game.EditObj.HisLossAttacker = new int[historyStepClass.LossCounter + 1];
            this.game.EditObj.HisLossDEAD = new int[historyStepClass.LossCounter + 1];
            this.game.EditObj.HisLossOK = new int[historyStepClass.LossCounter + 1];
            this.game.EditObj.HisLossSFType = new int[historyStepClass.LossCounter + 1];
            this.game.EditObj.HisLossCounter = historyStepClass.LossCounter;
            int lossCounter = historyStepClass.LossCounter;
            for (int index3 = 0; index3 <= lossCounter; ++index3)
            {
              this.game.EditObj.HisLossAttacker[index3] = historyStepClass.LossAttacker[index3];
              this.game.EditObj.HisLossDEAD[index3] = historyStepClass.LossDEAD[index3];
              this.game.EditObj.HisLossOK[index3] = historyStepClass.LossOK[index3];
              this.game.EditObj.HisLossSFType[index3] = historyStepClass.LossSFType[index3];
            }
            this.game.EditObj.HisRegimeWon = historyStepClass.LossRegimeWin;
            this.game.EditObj.HisLossAttReg = historyStepClass.LossAttReg;
            this.game.EditObj.HisLossDefReg = historyStepClass.LossDefReg;
          }
          if (historyStepClass.LossCounter == -1 & historyStepClass.AttackOtherType > -1 && this.game.Data.RegimeObj[this.Turny].HistoryStepCounter >= index1 + 1 && historyStepClass.X == this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].X & historyStepClass.Y == this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].Y && this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter > -1 && this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter > -1)
          {
            this.game.EditObj.HisLossAttacker = new int[this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter + 1];
            this.game.EditObj.HisLossDEAD = new int[this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter + 1];
            this.game.EditObj.HisLossOK = new int[this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter + 1];
            this.game.EditObj.HisLossSFType = new int[this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter + 1];
            this.game.EditObj.HisLossCounter = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter;
            int lossCounter = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossCounter;
            for (int index4 = 0; index4 <= lossCounter; ++index4)
            {
              this.game.EditObj.HisLossAttacker[index4] = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossAttacker[index4];
              this.game.EditObj.HisLossDEAD[index4] = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossDEAD[index4];
              this.game.EditObj.HisLossOK[index4] = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossOK[index4];
              this.game.EditObj.HisLossSFType[index4] = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossSFType[index4];
            }
            this.game.EditObj.HisRegimeWon = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossRegimeWin;
            this.game.EditObj.HisLossAttReg = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossAttReg;
            this.game.EditObj.HisLossDefReg = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].LossDefReg;
            if (Strings.Len(historyStepClass.InfoString) == 0 && Strings.Len(this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].InfoString) > 0)
              this.game.EditObj.HisInfoString = this.game.Data.RegimeObj[this.Turny].HistoryStep[index1 + 1].InfoString;
          }
        }
      }
      int num4 = (int) Math.Round((double) this.game.ScreenWidth / 53.0);
      int num5 = (int) Math.Round((double) (this.game.ScreenHeight - 200) / 48.0);
      int num6 = 0;
      if (this.game.EditObj.HisHotX > -1 & this.game.EditObj.HisHotY > -1)
      {
        if (this.game.Data.MapObj[0].MapLoop)
        {
          if (this.game.EditObj.HisHotX <= this.game.CornerX + 1)
          {
            int num7 = this.game.CornerX + this.game.Data.MapObj[0].MapWidth + num4 + 5;
            if (num7 > this.game.Data.MapObj[0].MapWidth)
              num7 -= this.game.Data.MapObj[0].MapWidth + 1;
            if (this.game.EditObj.HisHotX > num7)
              num6 = 1;
          }
        }
        else if (this.game.EditObj.HisHotX <= this.game.CornerX + 1)
          num6 = 1;
        if (this.game.EditObj.HisHotY <= this.game.CornerY + 1)
          num6 = 1;
        int num8 = this.game.CornerX + num4 - 2;
        if (this.game.Data.MapObj[0].MapLoop)
        {
          if (num8 > this.game.Data.MapObj[0].MapWidth)
            num8 -= this.game.Data.MapObj[0].MapWidth + 1;
          if (this.game.EditObj.HisHotX >= num8 && this.game.EditObj.HisHotX < this.game.CornerX - 5)
            num6 = 1;
        }
        else if (this.game.EditObj.HisHotX >= num8)
          num6 = 1;
        if (this.game.EditObj.HisHotY >= this.game.CornerY + num5 - 2)
          num6 = 1;
      }
      if (num3 == 1)
        this.game.EditObj.TempCoordList = new CoordList();
      if (num6 != 1)
        return;
      if (this.game.Data.MapObj[0].MapLoop)
      {
        this.game.HandyFunctionsObj.SetcornerXY2(this.game.EditObj.HisHotX, this.game.EditObj.HisHotY);
      }
      else
      {
        this.game.EditObj.TempCoordList = new CoordList();
        int num9 = (int) Math.Round((double) this.game.EditObj.HisHotX - (double) num4 / 2.0);
        int num10 = (int) Math.Round((double) this.game.EditObj.HisHotY - (double) num5 / 2.0);
        if (0 > num9)
          num9 = 0;
        if (0 > num10)
          num10 = 0;
        if (Math.Abs(this.game.CornerX - num9) > 3)
          this.game.CornerX = num9;
        if (Math.Abs(this.game.CornerY - num10) > 3)
          this.game.CornerY = num10;
        if (num9 == 0 & this.game.CornerX > 0)
          this.game.CornerX = 0;
        if (num10 == 0 & this.game.CornerY > 0)
          this.game.CornerY = 0;
        int num11 = 265;
        if (this.game.EditObj.RealRound == 0)
          num11 += 100;
        int num12 = (int) Math.Round((double) (this.game.ScreenWidth - 0) / 53.0);
        int num13 = (int) Math.Round((double) (this.game.ScreenHeight - num11) / 48.0);
        int num14 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - this.game.CornerX;
        int num15 = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - this.game.CornerY;
        if (num12 > num14)
          this.game.CornerX = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapWidth - num12 + 2;
        if (num13 > num15)
          this.game.CornerY = this.game.Data.MapObj[this.game.EditObj.MapSelected].MapHeight - num13 + 1;
        if (this.game.CornerX < 0)
          this.game.CornerX = 0;
        if (this.game.CornerY >= 0)
          return;
        this.game.CornerY = 0;
      }
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuffonlyslider()
    {
    }

    public void dostuff()
    {
      if (this.Info1Id > 0)
        this.RemoveSubPart(this.Info1Id);
      if (this.info3id > 0)
        this.RemoveSubPart(this.info3id);
      if (this.info4id > 0)
        this.RemoveSubPart(this.info4id);
      if (this.info5id > 0)
        this.RemoveSubPart(this.info5id);
      if (this.info6id > 0)
        this.RemoveSubPart(this.info6id);
      if (this.SpecialTextId > 0)
        this.RemoveSubPart(this.SpecialTextId);
      if (this.ViewAntiCapId > 0)
        this.RemoveSubPart(this.ViewAntiCapId);
      if (this.ViewAntiCapTextId > 0)
        this.RemoveSubPart(this.ViewAntiCapTextId);
      if (this.ViewHistoryId > 0)
        this.RemoveSubPart(this.ViewHistoryId);
      if (this.ViewHistoryTextId > 0)
        this.RemoveSubPart(this.ViewHistoryTextId);
      if (this.ViewAntiCap2Id > 0)
        this.RemoveSubPart(this.ViewAntiCap2Id);
      if (this.ViewAntiCapText2Id > 0)
        this.RemoveSubPart(this.ViewAntiCapText2Id);
      if (this.ViewAntiCap3Id > 0)
        this.RemoveSubPart(this.ViewAntiCap3Id);
      if (this.ViewAntiCapText3Id > 0)
        this.RemoveSubPart(this.ViewAntiCapText3Id);
      if (this.OptionsListId > 0)
        this.RemoveSubPart(this.OptionsListId);
      if (this.OptionsList2Id > 0)
        this.RemoveSubPart(this.OptionsList2Id);
      if (this.ViewSupplyId > 0)
        this.RemoveSubPart(this.ViewSupplyId);
      if (this.ViewSupplyTextId > 0)
        this.RemoveSubPart(this.ViewSupplyTextId);
      this.NewBackGroundAndClearAll(this.w, this.h, this.game.MARCBOTBAR);
      this.ClearMouse();
      int num1 = (int) Math.Round((double) (this.game.ScreenWidth - 1024) / 2.0);
      if (this.mapid > 0)
        this.RemoveSubPart(this.mapid);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawBlockGradient2(ref Expression, 0, 0, this.w, this.h, Color.FromArgb(20, 0, 0, 0), Color.FromArgb(150, 0, 0, 0));
      DrawMod.DrawBlockGradient2(ref Expression, num1, 4, 1024, this.h - 6, this.game.MarcCol1, this.game.MarcCol2);
      DrawMod.DrawFrame(ref this.OwnBitmap, ref this.BackBitmap, ref Expression, num1, 4, 1024, this.h - 6, num1, 4);
      SizeF sizeF1 = new SizeF();
      if ((this.game.AIRunning | this.game.AIThreadRunning) & this.Curstep >= this.EndStep)
      {
        if (!Information.IsNothing((object) this.game.EditObj.TempAIString) & this.game.EditObj.AIProgressMax > 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextPartClass(this.game.EditObj.TempAIString, new Font(this.game.FontCol.Families[1], 19f, FontStyle.Bold, GraphicsUnit.Pixel), 600, 20, true, tBlackBack: true, tProgress: ((int) Math.Round((double) this.game.EditObj.AIProgressNow / (double) this.game.EditObj.AIProgressMax * 100.0)), tMarc: true);
          this.info5id = this.AddSubPart(ref tsubpart, num1 + 200, 92, 600, 20, 0);
        }
      }
      else if (this.game.EditObj.HisLossCounter > -1)
      {
        this.OptionsListObj = new ListClass();
        this.OptionsListObj.add("TYPE", -1, "START", "LOSS", tWeight: 9999999);
        try
        {
          int hisLossCounter = this.game.EditObj.HisLossCounter;
          for (int index1 = 0; index1 <= hisLossCounter; ++index1)
          {
            if (this.game.EditObj.HisLossAttacker[index1] == 1)
            {
              int index2 = this.game.EditObj.HisLossSFType[index1];
              if (index2 == -1)
              {
                this.OptionsListObj.add("Unknown Troops", -1, "?", "?", tWeight: 0);
              }
              else
              {
                int Number = this.game.EditObj.HisLossOK[index1] + this.game.EditObj.HisLossDEAD[index1];
                if (this.game.Data.SFTypeObj[index2].Ratio > 0)
                  Number *= this.game.Data.SFTypeObj[index2].Ratio;
                int num2 = this.game.EditObj.HisLossDEAD[index1];
                if (this.game.Data.SFTypeObj[index2].Ratio > 0)
                  num2 *= this.game.Data.SFTypeObj[index2].Ratio;
                string str = this.game.Data.SFTypeObj[index2].Name;
                if (Strings.Len(str) > 20)
                  str = Strings.Left(str, 20);
                if (Strings.Len(str) > 20)
                  str = Strings.Left(str, 20);
                this.OptionsListObj.add(str, -1, Strings.Trim(Conversion.Str((object) Number)), Strings.Trim(Conversion.Str((object) num2)), tWeight: num2);
              }
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        string str1 = !(this.game.EditObj.HisLossAttReg < 0 | this.game.EditObj.HisLossAttReg > this.game.Data.RegimeCounter) ? "ATTACKER: " + Strings.UCase(this.game.Data.RegimeObj[this.game.EditObj.HisLossAttReg].Name) : "ATTACKER: ?";
        this.OptionsListObj.SortOnWeight(-1);
        SizeF sizeF2 = Expression.MeasureString(str1, this.game.MarcFont4);
        DrawMod.DrawTextColouredMarc(ref Expression, str1, this.game.MarcFont4, (int) Math.Round((double) ((float) (num1 + 200) + (float) (145.0 - (double) sizeF2.Width / 2.0))), 45, Color.White);
        SubPartClass tsubpart1 = (SubPartClass) new ListSubPartClass(this.OptionsListObj, 8, 290, -1, this.game, true, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 140, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 200), bby: 65, tMarcStyle: true, overruleFont: (ref this.game.MarcFont5));
        this.OptionsListId = this.AddSubPart(ref tsubpart1, num1 + 200, 65, 290, 176, 0);
        this.OptionsList2Obj = new ListClass();
        this.OptionsList2Obj.add("TYPE", -1, "START", "LOSS", tWeight: 9999999);
        int hisLossCounter1 = this.game.EditObj.HisLossCounter;
        for (int index3 = 0; index3 <= hisLossCounter1; ++index3)
        {
          if (this.game.EditObj.HisLossAttacker[index3] == 0)
          {
            int index4 = this.game.EditObj.HisLossSFType[index3];
            if (index4 == -1)
            {
              this.OptionsList2Obj.add("Unknown Troops", -1, "?", "?", tWeight: 0);
            }
            else
            {
              int Number = this.game.EditObj.HisLossOK[index3] + this.game.EditObj.HisLossDEAD[index3];
              int num3 = this.game.EditObj.HisLossDEAD[index3];
              if (this.game.Data.SFTypeObj[index4].Ratio > 0)
                Number *= this.game.Data.SFTypeObj[index4].Ratio;
              if (this.game.Data.SFTypeObj[index4].Ratio > 0)
                num3 *= this.game.Data.SFTypeObj[index4].Ratio;
              string str2 = this.game.Data.SFTypeObj[index4].Name;
              if (Strings.Len(str2) > 20)
                str2 = Strings.Left(str2, 20);
              this.OptionsList2Obj.add(str2, -1, Strings.Trim(Conversion.Str((object) Number)), Strings.Trim(Conversion.Str((object) num3)), tWeight: num3);
            }
          }
        }
        this.OptionsList2Obj.SortOnWeight(-1);
        string str3 = !(this.game.EditObj.HisLossDefReg < 0 | this.game.EditObj.HisLossDefReg > this.game.Data.RegimeCounter) ? "DEFENDER: " + Strings.UCase(this.game.Data.RegimeObj[this.game.EditObj.HisLossDefReg].Name) : "DEFENDER: ?";
        SizeF sizeF3 = Expression.MeasureString(str3, this.game.MarcFont4);
        DrawMod.DrawTextColouredMarc(ref Expression, str3, this.game.MarcFont4, (int) Math.Round((double) ((float) (num1 + 500) + (float) (145.0 - (double) sizeF3.Width / 2.0))), 45, Color.White);
        SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(this.OptionsList2Obj, 8, 290, -1, this.game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 140, tdotopandbottom: false, tbackbitmap: (ref this.OwnBitmap), bbx: (num1 + 500), bby: 65, tMarcStyle: true, overruleFont: (ref this.game.MarcFont5));
        this.OptionsList2Id = this.AddSubPart(ref tsubpart2, num1 + 500, 65, 290, 176, 0);
        string str4 = "AN ATTACK";
        if (this.game.EditObj.HisAttackType == 2)
          str4 = "ATTACK";
        if (this.game.EditObj.HisAttackType == 55)
          str4 = "AIR BRIDGE";
        if (this.game.EditObj.HisAttackType == 33)
          str4 = "AIR RECON";
        if (this.game.EditObj.HisAttackType == 12)
          str4 = "SEA ATTACK";
        if (this.game.EditObj.HisAttackType == 11)
          str4 = "ARTILLERY";
        if (this.game.EditObj.HisAttackType == 13)
          str4 = "SEA ARTILLERY";
        if (this.game.EditObj.HisAttackType == 14)
          str4 = "AIRSTRIKE";
        if (this.game.EditObj.HisAttackType == 15)
          str4 = "BOMBING RUN";
        if (this.game.EditObj.HisAttackType == 21)
          str4 = "AMPHIBIOUS ATTACK";
        if (this.game.EditObj.HisAttackType == 18)
          str4 = "AIR LANDING";
        if (this.game.EditObj.HisAttackType == 19)
          str4 = "PARADROP ATTACK";
        if (this.game.EditObj.HisAttackType == 42)
          str4 = "AIRLIFT";
        if (this.game.EditObj.HisAttackType == 17)
          str4 = "ANTICAP DOGFIGHT";
        if (this.game.EditObj.HisAttackType == 31)
          str4 = "REBEL ATTACK (from inside Hex)";
        if (this.game.EditObj.HisRegimeWon == -1)
        {
          SizeF sizeF4 = Expression.MeasureString(str4, this.game.MarcFont3);
          DrawMod.DrawTextColouredMarc(ref Expression, str4, this.game.MarcFont3, (int) Math.Round((double) ((float) (num1 + 210) + (float) (300.0 - (double) sizeF4.Width / 2.0))), 7, Color.White);
          if (Strings.Len(this.game.EditObj.HisInfoString) > 0)
          {
            SizeF sizeF5 = Expression.MeasureString(this.game.EditObj.HisInfoString, this.game.MarcFont7);
            DrawMod.DrawTextColouredMarc(ref Expression, this.game.EditObj.HisInfoString, this.game.MarcFont7, (int) Math.Round((double) ((float) (num1 + 210) + (float) (300.0 - (double) sizeF5.Width / 2.0))), 28, Color.White);
          }
        }
        else
        {
          string str5 = this.game.EditObj.HisRegimeWon != this.game.EditObj.HisLossDefReg ? str4 + ": ATTACKER WAS VICTORIOUS" : str4 + ": DEFENDER STOOD FIRM";
          SizeF sizeF6 = Expression.MeasureString(str5, this.game.MarcFont3);
          DrawMod.DrawTextColouredMarc(ref Expression, str5, this.game.MarcFont3, (int) Math.Round((double) ((float) (num1 + 195) + (float) (300.0 - (double) sizeF6.Width / 2.0))), 7, Color.White);
          if (Strings.Len(this.game.EditObj.HisInfoString) > 0)
          {
            SizeF sizeF7 = Expression.MeasureString(this.game.EditObj.HisInfoString, this.game.MarcFont7);
            DrawMod.DrawTextColouredMarc(ref Expression, this.game.EditObj.HisInfoString, this.game.MarcFont7, (int) Math.Round((double) ((float) (num1 + 195) + (float) (300.0 - (double) sizeF7.Width / 2.0))), 28, Color.White);
          }
        }
      }
      else if (Strings.Len(this.game.EditObj.HisInfoString) > 0)
      {
        SizeF sizeF8 = Expression.MeasureString(this.game.EditObj.HisInfoString, this.game.MarcFont3);
        DrawMod.DrawTextColouredMarc(ref Expression, this.game.EditObj.HisInfoString, this.game.MarcFont3, (int) Math.Round((double) ((float) (num1 + 210) + (float) (300.0 - (double) sizeF8.Width / 2.0))), 92, Color.White);
      }
      else
      {
        string str = "No further information on History Step";
        SizeF sizeF9 = Expression.MeasureString(str, this.game.MarcFont3);
        DrawMod.DrawTextColouredMarc(ref Expression, str, this.game.MarcFont3, (int) Math.Round((double) ((float) (num1 + 210) + (float) (300.0 - (double) sizeF9.Width / 2.0))), 92, Color.White);
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI | this.HumanPlayer > -1)
        return windowReturnClass;
      try
      {
        switch (nr)
        {
          case 27:
            this.game.EditObj.TempCoordList = new CoordList();
            if ((double) this.game.Data.RuleVar[839] == 0.0)
              windowReturnClass.AddCommand(3, 3);
            else
              windowReturnClass.AddCommand(3, 11);
            this.game.EditObj.OrderType = 0;
            windowReturnClass.SetFlag(true);
            return windowReturnClass;
          case 80:
            this.AutoPlay = !this.AutoPlay;
            windowReturnClass.SetFlag(true);
            windowReturnClass.AddCommand(4, 81);
            this.dostuff();
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (!Information.IsNothing((object) this.game.se1Thread))
      {
        if (this.game.se1Thread.ThreadState == ThreadState.Stopped)
        {
          this.game.se1ThreadRunning = false;
          this.game.se1Running = false;
          this.game.se1Thread.Abort();
          this.game.se1Thread.Join();
        }
        else if (!this.game.se1Running & this.game.se1ThreadRunning)
        {
          this.game.se1ThreadRunning = false;
          this.game.se1Thread.Abort();
          this.game.se1Thread.Join();
        }
        else
          windowReturnClass.SetFlag(true);
      }
      int num1 = 1;
      int index = this.game.EditObj.RealTurn;
      bool flag1 = false;
      while (num1 == 1)
      {
        ++index;
        int num2;
        if (index > this.game.Data.RegimeCounter)
        {
          index = 0;
          ++num2;
        }
        if (num2 > 1)
          num1 = 0;
        if (!this.game.Data.RegimeObj[index].Sleep)
        {
          flag1 = this.game.Data.RegimeObj[index].AI;
          num1 = 0;
        }
      }
      if (!this.game.Data.RegimeObj[this.game.EditObj.RealTurn].AI & this.HumanPlayer > -1)
        flag1 = false;
      this.game.EditObj.LastHistoryStep = -1;
      bool flag2;
      if (this.EndStep >= -1)
      {
        TimeSpan timeSpan = DateAndTime.Now.Subtract(this.showtime);
        if ((double) timeSpan.Ticks > 2000000.0 & this.game.EditObj.HisLossCounter == -1 | timeSpan.Ticks > 20000000L)
        {
          if (this.HumanPlayer > -1)
            this.EndStep = this.game.HandyFunctionsObj.GetRegimeHistoryTotSteps(this.HumanPlayer);
          this.showtime = DateAndTime.Now;
          if (this.AutoPlay & (this.Curstep < this.EndStep | this.EndStep == -1) | this.game.EditObj.AIMoving & !this.game.se1Running & !this.game.se1ThreadRunning & this.Curstep >= this.EndStep)
          {
            this.game.EditObj.TempCoordList = new CoordList();
            if (this.Curstep < this.EndStep)
            {
              this.Forward(1);
              ++this.Curstep;
              this.StartStep = 1;
              windowReturnClass.AddCommand(4, 12);
              windowReturnClass.AddCommand(4, 81);
              windowReturnClass.AddCommand(4, 67);
              windowReturnClass.AddCommand(4, 9);
            }
            if (this.Curstep == this.EndStep & this.HumanPlayer == -1)
              this.AutoPlay = false;
            if (!flag1 & this.HumanPlayer > -1 & (this.Curstep >= this.EndStep | this.EndStep == -1) && !this.game.se1Running & !this.game.se1ThreadRunning)
            {
              this.game.EditObj.AIMoving = false;
              windowReturnClass.SetFlag(true);
              this.game.EditObj.Test = 99;
              windowReturnClass.AddCommand(3, 13);
              return windowReturnClass;
            }
            windowReturnClass.SetFlag(true);
            this.dostuff();
            return windowReturnClass;
          }
          if (this.game.se1Running)
          {
            windowReturnClass.SetFlag(true);
            this.dostuff();
            flag2 = false;
          }
        }
        else if ((double) timeSpan.Ticks > 2500000.0 & this.game.se1Running)
        {
          windowReturnClass.SetFlag(true);
          this.dostuff();
          flag2 = false;
        }
      }
      else
      {
        TimeSpan timeSpan = DateAndTime.Now.Subtract(this.showtime);
        if ((double) timeSpan.Ticks > 2500000.0 & this.game.se1Running)
        {
          this.EndStep = this.game.HandyFunctionsObj.GetRegimeHistoryTotSteps(this.HumanPlayer);
          windowReturnClass.SetFlag(true);
          this.showtime = DateAndTime.Now;
          if (this.EndStep != this.lastendstep)
            windowReturnClass.AddCommand(4, 81);
          flag2 = true;
        }
        else if (timeSpan.Ticks > 10000000L & this.AutoPlay & !this.game.se1Running & (this.HumanPlayer == -1 | !this.game.se1ThreadRunning))
        {
          windowReturnClass.SetFlag(true);
          this.showtime = DateAndTime.Now;
          if (this.EndStep != this.lastendstep)
            windowReturnClass.AddCommand(4, 81);
          flag2 = true;
        }
      }
      this.lastendstep = this.EndStep;
      if (flag2)
      {
        windowReturnClass.Flag = true;
        this.dostuff();
      }
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            int num2;
            if (num1 == this.OptionsListId)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
            }
            else if (num1 == this.OptionsList2Id)
            {
              num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
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
