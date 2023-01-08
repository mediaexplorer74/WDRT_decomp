# WDRT 

Windows Device Recovery Tool Components Decompiled

## Abstract

Decompiled dotnet source for Windows Device Recovery Tool, this code is provided 'as-is' and produced with "dnSpy", so expect errors in places.

# Design / Screenshots
<table><tr>
<td> <img src="Images/shot1.png" alt="Drawing" style="width: 800px;"/> </td>
</tr></table>

## My 2 cents
- All projects "assembled" to one solution (.sln)
- All "bad blocks" banned (disabled), but app logics crashed (events, dictionary etc. : mulfunction)
- App compilation ok, app starts (shows blank window)


## "Architecture" ("Files decompiled")

```
en\System.Windows.Interactivity.resources
en-GB\Microsoft.WindowsDeviceRecoveryTool.Localization.resources
FFUComponents
HoloLensClickerUtilityLibrary
ImageCommon
ImageSigner
Microsoft.Azure.KeyVault.Core
Microsoft.Data.Edm
Microsoft.Data.OData
Microsoft.Data.Services.Client
Microsoft.Diagnostics.Tracing.EventSource
Microsoft.Tools.Connectivity
Microsoft.Tools.DeviceUpdate.DeviceUtils
Microsoft.WindowsAzure.Storage
Microsoft.WindowsDeviceRecoveryTool.AcerAdaptation
Microsoft.WindowsDeviceRecoveryTool.AlcatelAdaptation
Microsoft.WindowsDeviceRecoveryTool.AnalogAdaptation
Microsoft.WindowsDeviceRecoveryTool.BluAdaptation
Microsoft.WindowsDeviceRecoveryTool.BusinessLogic
Microsoft.WindowsDeviceRecoveryTool.Common
Microsoft.WindowsDeviceRecoveryTool.Core
Microsoft.WindowsDeviceRecoveryTool.DiginnosAdaptation
Microsoft.WindowsDeviceRecoveryTool.FawkesAdaptation
Microsoft.WindowsDeviceRecoveryTool.Ffu
Microsoft.WindowsDeviceRecoveryTool.FfuFileReader
Microsoft.WindowsDeviceRecoveryTool.FreetelAdaptation
Microsoft.WindowsDeviceRecoveryTool.HoneywellAdaptation
Microsoft.WindowsDeviceRecoveryTool.HPAdaptation
Microsoft.WindowsDeviceRecoveryTool.HtcAdaptation
Microsoft.WindowsDeviceRecoveryTool.InversenetAdaptation
Microsoft.WindowsDeviceRecoveryTool.JenesisAdaptation
Microsoft.WindowsDeviceRecoveryTool.KMAdaptation
Microsoft.WindowsDeviceRecoveryTool.LenovoAdaptation
Microsoft.WindowsDeviceRecoveryTool.LgeAdaptation
Microsoft.WindowsDeviceRecoveryTool.Localization
Microsoft.WindowsDeviceRecoveryTool.LogicCommon
Microsoft.WindowsDeviceRecoveryTool.Lucid
Microsoft.WindowsDeviceRecoveryTool.LumiaAdaptation
Microsoft.WindowsDeviceRecoveryTool.McjAdaptation
Microsoft.WindowsDeviceRecoveryTool.MicromaxAdaptation
Microsoft.WindowsDeviceRecoveryTool.Model
Microsoft.WindowsDeviceRecoveryTool.OemAdaptation
Microsoft.WindowsDeviceRecoveryTool.StateMachine
Microsoft.WindowsDeviceRecoveryTool.Styles
Microsoft.WindowsDeviceRecoveryTool.TrekStorAdaptation
Microsoft.WindowsDeviceRecoveryTool.TrinityAdaptation
Microsoft.WindowsDeviceRecoveryTool.UnistrongAdaptation
Microsoft.WindowsDeviceRecoveryTool.VAIOAdaptation
Microsoft.WindowsDeviceRecoveryTool.WileyfoxAdaptation
Microsoft.WindowsDeviceRecoveryTool.XOLOAdaptation
Microsoft.WindowsDeviceRecoveryTool.YEZZAdaptation
Microsoft.WindowsDeviceRecoveryTool.ZebraAdaptation
Newtonsoft.Json
Nokia.Lucid
Nokia.Lucid.GenericStream
Nokia.Lucid.IsiStream
Nokia.Mira
PresentationFramework
SirepInterop
SoftwareRepository
System.Drawing
System.Management
System.Spatial
System.Windows.Forms
System.Windows.Interactivity
ToolsCommon
ufphostm
WindowsDeviceRecoveryTool
ZipForge
```

## CAUTION

- This is as-is. Just manual R.E. after automatic decompiling (or "reversing"), no more. 
They are just a "system template" for me to learn and maybe others.
- System engeneers, use / re-use it at your own risk. This app is not easy type of WPF app, IMHO.


## TODO
- Try to find the time for more WDRT RnD...
- Try to assemble the lite version: use minimal number of projects, more special logics for ffu (re)flashing... idk

## References
https://github.com/Empyreal96/WindowsDeviceRecoveryTool_components_decompiled

https://github.com/microsoft


## ..
AS IS. No support. RnD only / DIY

## .
[m][e] 8 January, 2023


