// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SoundMod
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using IrrKlang;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsApplication1
{
  [StandardModule]
  pub sealed class SoundMod
  {
    pub static string LastSong;
     static ISoundEngine engine;
     static ISoundSource medley;
     static ISound eventsound;
     static ISound eventsoundbg;
    pub static bool NOSOUND;
    pub static bool SYSTEMFAILURE = false;
    pub static int dssSoundCounter;
    pub static let mut dssSoundMaxCounter: i32 = 9;
     static ISound[] dssSoundRef = new ISound[10];
     static int[] dssStatus = new int[10];
     static int[] dssType = new int[10];
     static int[] dssId = new int[10];
     static int[] dssMsMark = new int[10];
     static DateTime startDatetime;
    pub static let mut DSS_FADE_MS: i32 = 5000;
    pub static let mut DSS_MARGIN_MS: i32 = 300;

    pub static void InitSound(Form FormHandle)
    {
      try
      {
        SoundMod.engine = ISoundEngine::new();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        SoundMod.NOSOUND = true;
        SoundMod.SYSTEMFAILURE = true;
        ProjectData.ClearProjectError();
      }
      SoundMod.dssSoundCounter = -1;
      SoundMod.startDatetime = DateAndTime.Now;
    }

    pub static void PlayAWave(
      string Soundfile,
       EditClass teditobj,
      bool overrule = false,
      let mut volumeMod: i32 = 0)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
        return;
      str: String = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        str = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(str, "", false) == 0)
        str = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("sound", str);
      if (!Information.IsNothing((object) SoundMod.eventsound) && SoundMod.eventsound.Finished)
      {
        SoundMod.eventsound.Dispose();
        SoundMod.eventsound = (ISound) null;
      }
      if (!(teditobj.SoundOn | overrule) || !File.Exists(Soundfile))
        return;
      SoundMod.eventsound = SoundMod.engine.Play2D(Soundfile, false);
      if (Information.IsNothing((object) SoundMod.eventsound))
        return;
      if (volumeMod > 0)
        SoundMod.eventsound.Volume = Math.Min(1f, (float) ((double) teditobj.Volume2 / 100.0 * ((double) volumeMod / 100.0)));
      else
        SoundMod.eventsound.Volume = (float) teditobj.Volume2 / 100f;
    }

    pub static void PlayEventWave(string Soundfile,  EditClass teditobj)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
        return;
      str: String = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        str = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(str, "", false) == 0)
        str = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("sound", str);
      if (!teditobj.SoundOn || !File.Exists(Soundfile))
        return;
      SoundMod.eventsound = SoundMod.engine.Play2D(Soundfile, false);
      if (Information.IsNothing((object) SoundMod.eventsound))
        return;
      SoundMod.eventsound.Volume = (float) teditobj.Volume2 / 100f;
    }

    pub static void STopEventWave()
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.eventsound))
        return;
      SoundMod.eventsound.Stop();
    }

    pub static void RestartLastBackground( EditClass teditobj)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.LastSong))
        return;
      lastSong: String = SoundMod.LastSong;
      SoundMod.LastSong = "";
      SoundMod.PlayEventBackground(lastSong,  teditobj);
    }

    pub static void PlayEventBackground(string Soundfile,  EditClass teditobj)
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
        return;
      Soundfile = Soundfile.Replace("\\", "/");
      Left: String = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        Left = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(Left, "", false) == 0)
        Left = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("/sound/", "/" + Left + "/");
      if (!Information.IsNothing((object) SoundMod.eventsoundbg) && Operators.CompareString(SoundMod.LastSong, Soundfile, false) == 0 & !SoundMod.eventsoundbg.Finished)
        return;
      SoundMod.LastSong = Soundfile;
      str: String = Soundfile;
      try
      {
        if (!Information.IsNothing((object) teditobj) & !Information.IsNothing((object) DrawMod.TGame))
        {
          if (teditobj.AlternateMusic)
          {
            if ((double) DrawMod.TGame.Data.RuleVar[990] == 1.0)
            {
              if (Strings.InStr(Soundfile, ".") > 0)
                Soundfile = Soundfile.Replace(".", "_alternate.");
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Soundfile = str;
        ProjectData.ClearProjectError();
      }
      if (!teditobj.IntroSoundOn || !File.Exists(Soundfile))
        return;
      if (!Information.IsNothing((object) SoundMod.eventsoundbg))
      {
        SoundMod.eventsoundbg.Stop();
        SoundMod.eventsoundbg = (ISound) null;
      }
      SoundMod.eventsoundbg = SoundMod.engine.Play2D(Soundfile, true);
      if (Information.IsNothing((object) SoundMod.eventsoundbg))
        return;
      SoundMod.eventsoundbg.Volume = (float) teditobj.Volume / 100f;
    }

    pub static void ChangeEventSoundBg(EditClass teditobj)
    {
      if (SoundMod.SYSTEMFAILURE)
        return;
      if (!Information.IsNothing((object) SoundMod.eventsoundbg))
        SoundMod.eventsoundbg.Volume = (float) teditobj.Volume / 100f;
      let mut index: i32 = 0;
      do
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[index]))
          SoundMod.dssSoundRef[index].Volume = (float) teditobj.Volume / 100f;
        index += 1;
      }
      while (index <= 9);
    }

    pub static void ChangeEventSound(EditClass teditobj)
    {
      if (SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.eventsound))
        return;
      SoundMod.eventsound.Volume = (float) teditobj.Volume2 / 100f;
    }

    pub static void STopEventBackground()
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.eventsoundbg))
        return;
      SoundMod.eventsoundbg.Stop();
      SoundMod.eventsoundbg.Dispose();
      SoundMod.eventsoundbg = (ISound) null;
    }

    pub static void StopWave()
    {
      if (SoundMod.NOSOUND)
        return;
      if (SoundMod.SYSTEMFAILURE)
        return;
      try
      {
        SoundMod.engine.StopAllSounds();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    pub static void EndSound()
    {
      if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE || Information.IsNothing((object) SoundMod.engine))
        return;
      SoundMod.engine.StopAllSounds();
      SoundMod.engine.RemoveAllSoundSources();
    }

    pub static void dssTimer( EditClass teditobj)
    {
      if (teditobj.IntroSoundOn & SoundMod.NOSOUND & !SoundMod.SYSTEMFAILURE)
        SoundMod.NOSOUND = false;
      if ((double) DrawMod.TGame.Data.RuleVar[446] < 1.0 | SoundMod.NOSOUND)
      {
        while (SoundMod.dssSoundCounter > -1)
          SoundMod.dssRemoveSoundSlot(SoundMod.dssSoundCounter);
      }
      else
      {
        if (SoundMod.NOSOUND || SoundMod.SYSTEMFAILURE)
          return;
        if (!Information.IsNothing((object) SoundMod.eventsoundbg))
        {
          SoundMod.eventsoundbg.Stop();
          SoundMod.eventsoundbg.Dispose();
          SoundMod.eventsoundbg = (ISound) null;
        }
        for (let mut dssSoundCounter: i32 = SoundMod.dssSoundCounter; dssSoundCounter >= 0; dssSoundCounter += -1)
        {
          if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSoundCounter]))
          {
            if (SoundMod.dssSoundRef[dssSoundCounter].Finished)
              SoundMod.dssRemoveSoundSlot(dssSoundCounter);
          }
          else
            SoundMod.dssRemoveSoundSlot(dssSoundCounter);
        }
        bool flag = true;
        let mut index1: i32 = -1;
        let mut dssSoundCounter1: i32 = SoundMod.dssSoundCounter;
        for (let mut index2: i32 = 0; index2 <= dssSoundCounter1; index2 += 1)
        {
          if (!Information.IsNothing((object) SoundMod.dssSoundRef[index2]) && !SoundMod.dssSoundRef[index2].Finished && SoundMod.dssType[index2] == 1)
          {
            flag = false;
            index1 = index2;
          }
        }
        if (flag)
          SoundMod.dssNew( teditobj);
        if (!flag)
          SoundMod.dssAdjust( teditobj);
        if (flag)
          return;
        let mut id: i32 =  Math.Round((double) DrawMod.TGame.Data.RuleVar[447]);
        let mut stringListById: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id);
        if (stringListById <= -1)
          return;
        let mut length: i32 = DrawMod.TGame.Data.StringListObj[stringListById].Length;
        for (let mut index3: i32 = 0; index3 <= length; index3 += 1)
        {
          if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[index3, 0]) == (double) SoundMod.dssId[index1] && (double) teditobj.dssLastDominant != Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[index3, 2]))
          {
            SoundMod.dssEnd( teditobj);
            break;
          }
        }
      }
    }

    pub static void dssEnd( EditClass teditobj)
    {
      let mut num: i32 =  Math.Round((DateAndTime.Now - SoundMod.startDatetime).TotalMilliseconds);
      for (let mut dssSoundCounter: i32 = SoundMod.dssSoundCounter; dssSoundCounter >= 0; dssSoundCounter += -1)
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSoundCounter]) & SoundMod.dssStatus[dssSoundCounter] != 3)
        {
          SoundMod.dssStatus[dssSoundCounter] = 3;
          SoundMod.dssMsMark[dssSoundCounter] = num;
        }
      }
    }

    pub static void dssAdjust( EditClass teditobj)
    {
      bool flag1 = true;
      bool flag2 = true;
      let mut id1: i32 =  Math.Round((double) DrawMod.TGame.Data.RuleVar[448]);
      let mut stringListById1: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id1);
      if (stringListById1 < 0 | id1 < 1)
        flag2 = false;
      let mut id2: i32 =  Math.Round((double) DrawMod.TGame.Data.RuleVar[449]);
      let mut stringListById2: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id2);
      if (stringListById2 < 0 | id2 < 1)
        flag1 = false;
      if (flag2 & flag1)
      {
        let mut dssSoundCounter1: i32 = SoundMod.dssSoundCounter;
        for (let mut index1: i32 = 0; index1 <= dssSoundCounter1; index1 += 1)
        {
          if (!Information.IsNothing((object) SoundMod.dssSoundRef[index1]) && !SoundMod.dssSoundRef[index1].Finished && SoundMod.dssType[index1] == 1)
          {
            let mut playPosition: i32 =  SoundMod.dssSoundRef[index1].PlayPosition;
            bool flag3 = true;
            let mut dssSoundCounter2: i32 = SoundMod.dssSoundCounter;
            for (let mut index2: i32 = 0; index2 <= dssSoundCounter2; index2 += 1)
            {
              if (!Information.IsNothing((object) SoundMod.dssSoundRef[index2]) && !SoundMod.dssSoundRef[index2].Finished && SoundMod.dssType[index2] == 2)
                flag3 = false;
            }
            if (flag3)
            {
              SimpleList simpleList1 = SimpleList::new();
              let mut length1: i32 = DrawMod.TGame.Data.StringListObj[stringListById1].Length;
              for (let mut tid: i32 = 0; tid <= length1; tid += 1)
              {
                if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById1].Data[tid, 1]) == (double) SoundMod.dssId[index1] && Math.Abs(playPosition - Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById1].Data[tid, 2])) <= SoundMod.DSS_MARGIN_MS)
                  simpleList1.Add(tid, DrawMod.RandyNumber.Next(0, 100));
              }
              if (simpleList1.Counter > -1)
              {
                simpleList1.Sort();
                let mut index3: i32 = simpleList1.Id[0];
                let mut integer1: i32 = Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById1].Data[index3, 3]);
                let mut integer2: i32 = Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById1].Data[index3, 4]);
                SimpleList simpleList2 = SimpleList::new();
                let mut length2: i32 = DrawMod.TGame.Data.StringListObj[stringListById2].Length;
                for (let mut tid: i32 = 0; tid <= length2; tid += 1)
                {
                  if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById2].Data[tid, 2]) == (double) integer1 && Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById2].Data[tid, 3]) == (double) integer2)
                    simpleList2.Add(tid, DrawMod.RandyNumber.Next(0, 100));
                }
                if (simpleList2.Counter > -1)
                {
                  simpleList2.Sort();
                  let mut index4: i32 = simpleList2.Id[0];
                  SoundMod.dssAddSoundSlot();
                  str: String = DrawMod.TGame.Data.StringListObj[stringListById2].Data[index4, 1];
                  SoundMod.dssStartSound( teditobj, SoundMod.dssSoundCounter, DrawMod.TGame.AppPath + "sound/" + str, 2, 2, 1f, Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById2].Data[index4, 0]), false);
                }
              }
            }
          }
        }
      }
      let mut num1: i32 =  Math.Round((DateAndTime.Now - SoundMod.startDatetime).TotalMilliseconds);
      for (let mut dssSoundCounter: i32 = SoundMod.dssSoundCounter; dssSoundCounter >= 0; dssSoundCounter += -1)
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSoundCounter]) && !SoundMod.dssSoundRef[dssSoundCounter].Finished && SoundMod.dssStatus[dssSoundCounter] == 3)
        {
          let mut num2: i32 = num1 - SoundMod.dssMsMark[dssSoundCounter];
          if (num2 > SoundMod.DSS_FADE_MS)
            SoundMod.dssRemoveSoundSlot(dssSoundCounter);
          else if (num2 > 0)
            SoundMod.dssSoundRef[dssSoundCounter].Volume = (float) (1.0 - (double) num2 / (double) SoundMod.DSS_FADE_MS) * ((float) teditobj.Volume / 100f);
        }
      }
    }

    pub static void dssNew( EditClass teditobj)
    {
      let mut id: i32 =  Math.Round((double) DrawMod.TGame.Data.RuleVar[447]);
      let mut stringListById: i32 = DrawMod.TGame.HandyFunctionsObj.GetStringListByID(id);
      if (stringListById < 0 || teditobj.dssLastDominant < 0 & DrawMod.TGame.Data.Product == 7)
        return;
      SimpleList simpleList = SimpleList::new();
      if (!teditobj.IntroSoundOn)
        return;
      let mut length: i32 = DrawMod.TGame.Data.StringListObj[stringListById].Length;
      for (let mut tid: i32 = 0; tid <= length; tid += 1)
      {
        bool flag = false;
        if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[tid, 2]) == -1.0)
          flag = true;
        if (Conversions.ToDouble(DrawMod.TGame.Data.StringListObj[stringListById].Data[tid, 2]) == (double) teditobj.dssLastDominant)
          flag = true;
        if (teditobj.dssLastDominant == -1)
          flag = true;
        if (flag)
          simpleList.Add(tid, DrawMod.RandyNumber.Next(0, 100));
      }
      int index;
      if (simpleList.Counter > -1)
      {
        simpleList.Sort();
        index = simpleList.Id[0];
      }
      else
        index = -1;
      if (index <= -1)
        return;
      SoundMod.dssAddSoundSlot();
      str: String = DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 1];
      if (simpleList.Counter == 0)
        SoundMod.dssStartSound( teditobj, SoundMod.dssSoundCounter, DrawMod.TGame.AppPath + "sound/" + str, 2, 1, 1f, Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 0]), true);
      else
        SoundMod.dssStartSound( teditobj, SoundMod.dssSoundCounter, DrawMod.TGame.AppPath + "sound/" + str, 2, 1, 1f, Conversions.ToInteger(DrawMod.TGame.Data.StringListObj[stringListById].Data[index, 0]), false);
    }

    pub static void dssStartSound(
       EditClass teditobj,
      int dssSlotNr,
      string Soundfile,
      int tStatus,
      int tType,
      float tVolume,
      int tId,
      bool tLoop)
    {
      Soundfile = Soundfile.Replace("\\", "/");
      Left: String = "";
      if (!Information.IsNothing((object) DrawMod.TGame) && !Information.IsNothing((object) DrawMod.TGame.Data.SoundDir))
        Left = DrawMod.TGame.Data.SoundDir;
      if (Operators.CompareString(Left, "", false) == 0)
        Left = DrawMod.TGame.ModSoundDir;
      if (!Information.IsNothing((object) DrawMod.TGame))
        Soundfile = Soundfile.Replace("/sound/", "/" + Left + "/");
      if (!teditobj.IntroSoundOn || !File.Exists(Soundfile))
        return;
      if (!Information.IsNothing((object) SoundMod.dssSoundRef[dssSlotNr]))
      {
        SoundMod.dssSoundRef[dssSlotNr].Stop();
        SoundMod.dssSoundRef[dssSlotNr] = (ISound) null;
      }
      SoundMod.dssSoundRef[dssSlotNr] = !tLoop ? SoundMod.engine.Play2D(Soundfile, false) : SoundMod.engine.Play2D(Soundfile, true);
      if (Information.IsNothing((object) SoundMod.dssSoundRef[dssSlotNr]))
        return;
      let mut num: i32 =  Math.Round((DateAndTime.Now - SoundMod.startDatetime).TotalMilliseconds);
      SoundMod.dssType[dssSlotNr] = tType;
      SoundMod.dssId[dssSlotNr] = tId;
      SoundMod.dssStatus[dssSlotNr] = tStatus;
      SoundMod.dssMsMark[dssSlotNr] = num;
      SoundMod.dssSoundRef[dssSlotNr].Volume = (float) ((double) tVolume * (double) teditobj.Volume / 100.0);
    }

    pub static void dssAddSoundSlot()
    {
      if (SoundMod.dssSoundCounter >= SoundMod.dssSoundMaxCounter)
      {
        let mut num: i32 =  Interaction.MsgBox((object) "DSS Sound slot overload");
      }
      else
      {
        SoundMod += 1.dssSoundCounter;
        SoundMod.dssSoundRef[SoundMod.dssSoundCounter] = (ISound) null;
        SoundMod.dssStatus[SoundMod.dssSoundCounter] = 0;
        SoundMod.dssType[SoundMod.dssSoundCounter] = 0;
        SoundMod.dssId[SoundMod.dssSoundCounter] = 0;
        SoundMod.dssMsMark[SoundMod.dssSoundCounter] = 0;
      }
    }

    pub static void dssRemoveSoundSlot(int slot)
    {
      if (slot < 0)
      {
        let mut num1: i32 =  Interaction.MsgBox((object) "Negative DSS Sound slot removal");
      }
      else if (slot > SoundMod.dssSoundCounter)
      {
        let mut num2: i32 =  Interaction.MsgBox((object) "To high DSS Sound slot removal");
      }
      else
      {
        if (!Information.IsNothing((object) SoundMod.dssSoundRef[slot]))
        {
          SoundMod.dssSoundRef[slot].Stop();
          SoundMod.dssSoundRef[slot] = (ISound) null;
        }
        let mut num3: i32 = slot;
        let mut dssSoundCounter: i32 = SoundMod.dssSoundCounter;
        for (let mut index: i32 = num3; index <= dssSoundCounter; index += 1)
        {
          if (index + 1 <= SoundMod.dssSoundCounter)
          {
            SoundMod.dssSoundRef[index] = SoundMod.dssSoundRef[index + 1];
            SoundMod.dssStatus[index] = SoundMod.dssStatus[index + 1];
            SoundMod.dssType[index] = SoundMod.dssType[index + 1];
            SoundMod.dssId[index] = SoundMod.dssId[index + 1];
            SoundMod.dssMsMark[index] = SoundMod.dssMsMark[index + 1];
          }
        }
        --SoundMod.dssSoundCounter;
      }
    }
  }
}
