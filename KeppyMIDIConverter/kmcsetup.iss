#define use_ie6
#define use_dotnetfx46
#define use_wic
#define use_msiproduct
#define vc

#define MyAppSetupName "Keppy's MIDI Converter"
#define MyAppVersion '18.2.7'

[Setup]
AllowCancelDuringInstall=False
AlwaysShowDirOnReadyPage=True
AppName={#MyAppSetupName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppSetupName} {#MyAppVersion}
AppComments=MIDI to WAV/OGG converter
AllowNoIcons=yes
AppContact=mailto:kaleidonkep99@outlook.com
AppCopyright=Copyright(C) KaleidonKep99 2017
AppId={{D4BCF8FB-EF29-4A72-9681-879BC2C3EAB8}
AppPublisher=KaleidonKep99
AppPublisherURL=https://github.com/KaleidonKep99/Keppys-MIDI-Converter
AppSupportPhone=+393511888475
AppSupportURL=https://github.com/KaleidonKep99/Keppys-MIDI-Converter/issues
AppUpdatesURL=https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64
Compression=lzma2/ultra64
OutputBaseFilename=KeppyMIDIConverterSetup
DefaultGroupName={#MyAppSetupName}
DefaultDirName={pf}\{#MyAppSetupName}
DisableReadyPage=no
DisableReadyMemo=no
InternalCompressLevel=ultra64
LanguageDetectionMethod=locale
LicenseFile=license.rtf
MinVersion=0,6.0.6001sp1
OutputDir=bin
SetupIconFile=Resources\mainlogo.ico
SourceDir=.
ShowLanguageDialog=no
TimeStampsInUTC=True
PrivilegesRequired=admin
UninstallDisplayIcon={app}\x86\KeppyMIDIConverter.exe
UninstallDisplayName=Keppy's MIDI Converter (Remove only)
UninstallDisplaySize=4835000
VersionInfoCompany=KaleidonKep99
VersionInfoCopyright=Copyright(C) KaleidonKep99 2016
VersionInfoDescription=Keppy's MIDI Converter
VersionInfoProductName=KMC
VersionInfoProductVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
WizardImageFile=setuppages\WizModernImage.bmp
WizardSmallImageFile=setuppages\WizModernSmallImage.bmp
SolidCompression=True
LZMABlockSize=65536
LZMANumBlockThreads=4
EnableDirDoesntExistWarning=True
DirExistsWarning=yes
CompressionThreads=2
LZMAAlgorithm=1

[Files]
;Generic
Source: "license.rtf"; DestDir: "{app}"; Flags: ignoreversion replacesameversion
Source: "bin\GMGeneric.sf2"; DestDir: "{app}"; Flags: ignoreversion replacesameversion

;64-bit files
Source: "bin\x64\KeppyMIDIConverter.exe"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\KeppyMIDIConverter.exe.config"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bass.dll"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\basswasapi.dll"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bass_mpc.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bass_vst.dll"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassenc.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassflac.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassmidi.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassopus.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\basswv.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\LoudMax.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\kmcogg.exe"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\kmcmp3.exe"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode

;32-bit files
Source: "bin\x86\KeppyMIDIConverter.exe"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\KeppyMIDIConverter.exe.config"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\bass.dll"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\basswasapi.dll"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\bass_mpc.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bass_vst.dll"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\bassenc.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bassflac.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bassmidi.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bassopus.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\basswv.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\LoudMax.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\kmcogg.exe"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\kmcmp3.exe"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Icons]
; Start menu/screen group
Name: "{group}\Keppy's MIDI Converter"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Check: not Is64BitInstallMode
Name: "{group}\Restore default language"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Parameters: "/restorelanguage"; Check: not Is64BitInstallMode
Name: "{group}\Skip update process"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Parameters: "/skipupdate"; Check: not Is64BitInstallMode
Name: "{group}\Keppy's MIDI Converter (x86)"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Check: Is64BitInstallMode
Name: "{group}\Keppy's MIDI Converter (x64)"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Check: Is64BitInstallMode
Name: "{group}\Restore default language"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Parameters: "/restorelanguage"; Check: Is64BitInstallMode
Name: "{group}\Skip update process"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Parameters: "/skipupdate"; Check: Is64BitInstallMode
; Desktop/Quick launch shortcuts
Name: "{userdesktop}\{#MyAppSetupName} (x86)"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Tasks: desktopicon; Check: not Is64BitInstallMode
Name: "{userdesktop}\{#MyAppSetupName} (x64)"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Tasks: desktopicon; Check: Is64BitInstallMode
Name: "{userdesktop}\{#MyAppSetupName} (x86)"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Tasks: desktopicon; Check: Is64BitInstallMode
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppSetupName} (x86)"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Tasks: quicklaunchicon; Check: not Is64BitInstallMode
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppSetupName} (x64)"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Tasks: quicklaunchicon; Check: Is64BitInstallMode
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppSetupName} (x86)"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Tasks: quicklaunchicon; Check: Is64BitInstallMode

[Dirs]
Name: "{app}\EE"; Attribs: hidden

[InstallDelete]
Type: filesandordirs; Name: "{app}\x86"
Type: filesandordirs; Name: "{app}\x64"
Type: filesandordirs; Name: "{app}\EE"
Type: filesandordirs; Name: "{app}"
Type: filesandordirs; Name: "{group}"

[UninstallDelete]
Type: filesandordirs; Name: "{app}\x86"
Type: filesandordirs; Name: "{app}\x64"
Type: filesandordirs; Name: "{app}\EE"
Type: filesandordirs; Name: "{app}"
Type: filesandordirs; Name: "{group}"

[Languages]
Name: en; MessagesFile: "compiler:Default.isl"
Name: de; MessagesFile: "compiler:Default.isl"

[Registry]
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter"; ValueType: none; Flags: uninsdeletekey dontcreatekey deletekey

[Run]
Filename: "{app}\x86\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser; Description: "Run the converter"; Check: not Is64BitInstallMode
Filename: "{app}\x86\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser unchecked; Description: "Run the x86 version of the converter"; Check: Is64BitInstallMode
Filename: "{app}\x64\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser; Description: "Run the x64 version of the converter"; Check: Is64BitInstallMode
Filename: "{app}\license.rtf"; Flags: nowait shellexec postinstall unchecked; Description: "Read the license"
Filename: "https://github.com/KaleidonKep99/Keppys-MIDI-Converter"; Flags: nowait postinstall shellexec unchecked; Description: "Look at the source code on GitHub"
[CustomMessages]
win_sp_title=Windows %1 Service Pack %2

[Code]
// shared code for installing the products
#include "scripts\products.iss"
// helper functions
#include "scripts\products\stringversion.iss"
#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"
#include "scripts\products\dotnetfxversion.iss"


#ifdef use_dotnetfx46
#include "scripts\products\dotnetfx46.iss"
#endif

#ifdef use_wic
#include "scripts\products\wic.iss"
#endif

#ifdef use_msiproduct
#include "scripts\products\msiproduct.iss"
#endif

#ifdef vc
#include "scripts\products\vcredist.iss"
#endif


function InitializeSetup(): boolean;
begin
	// initialize windows version
	initwinversion();

#ifdef use_msi40
	msi45('4.0'); // min allowed version is 4.0
#endif

#ifdef use_wic
	wic();
#endif

	// if no .netfx 4.5+ is found, install the client (smallest)
#ifdef use_dotnetfx46
    dotnetfx46(50); // min allowed version is 4.5.0
#endif

#ifdef vc
	vcredist2010();
#endif

	Result := true;
end;