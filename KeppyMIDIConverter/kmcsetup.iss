[Setup]
AllowCancelDuringInstall=False
AlwaysShowDirOnReadyPage=True
AppComments=MIDI to WAV/OGG converter
AppContact=mailto:kaleidonkep99@outlook.com
AppCopyright=Copyright(C) KaleidonKep99 2016
AppId={{D4BCF8FB-EF29-4A72-9681-879BC2C3EAB8}
AppName=Keppy's MIDI Converter
AppPublisher=KaleidonKep99
AppPublisherURL=https://github.com/KaleidonKep99/Keppys-MIDI-Converter
AppSupportPhone=+393511888475
AppSupportURL=https://github.com/KaleidonKep99/Keppys-MIDI-Converter/issues
AppUpdatesURL=https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases
AppVersion=13.0.7
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64
Compression=lzma2/ultra64
DefaultDirName={pf}\Keppy's MIDI Converter
DefaultGroupName=Keppy's MIDI Converter
InternalCompressLevel=ultra64
LanguageDetectionMethod=locale
LicenseFile=license.rtf
MinVersion=0,5.01.2600sp3
OutputBaseFilename=KeppyMIDIConverterInstaller
OutputDir=bin
SetupIconFile=Resources\mainlogo.ico
ShowLanguageDialog=no
TimeStampsInUTC=True
UninstallDisplayIcon={app}\x86\KeppyMIDIConverter.exe
UninstallDisplayName=Keppy's MIDI Converter (Remove only)
UninstallDisplaySize=4835000
VersionInfoCompany=KaleidonKep99
VersionInfoCopyright=Copyright(C) KaleidonKep99 2016
VersionInfoDescription=Keppy's MIDI Converter
VersionInfoProductName=KMC
VersionInfoProductVersion=13.0.7
VersionInfoVersion=13.0.7
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

;64-bit files
Source: "bin\x64\KeppyMIDIConverter.exe"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bass.dll"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bass_mpc.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bass_vst.dll"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassenc.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassflac.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassmidi.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassopus.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\basswv.dll"; DestDir: "{app}\x64";  Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\kmcogg.exe"; DestDir: "{app}\x64"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode

;32-bit files
Source: "bin\x86\KeppyMIDIConverter.exe"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\bass.dll"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\bass_mpc.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bass_vst.dll"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion
Source: "bin\x86\bassenc.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bassflac.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bassmidi.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\bassopus.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\basswv.dll"; DestDir: "{app}\x86";  Flags: ignoreversion replacesameversion
Source: "bin\x86\kmcogg.exe"; DestDir: "{app}\x86"; Flags: ignoreversion replacesameversion

[InstallDelete]
Type: filesandordirs; Name: "{app}\x86"
Type: filesandordirs; Name: "{app}\x64"
Type: filesandordirs; Name: "{app}"
Type: filesandordirs; Name: "{group}"

[UninstallDelete]
Type: filesandordirs; Name: "{app}\x86"
Type: filesandordirs; Name: "{app}\x64"
Type: filesandordirs; Name: "{app}"
Type: filesandordirs; Name: "{group}"

[Languages]
Name: en; MessagesFile: "compiler:Default.isl"
Name: it; MessagesFile: "compiler:Languages\Italian.isl"
Name: nl; MessagesFile: "compiler:Languages\Dutch.isl"
Name: de; MessagesFile: "compiler:Languages\German.isl"
Name: jp; MessagesFile: "compiler:Languages\Japanese.isl"

[Registry]
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "chorus"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "compressor"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "distortion"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "echo"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "flanger"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "gargle"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "reverb"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "sittingroom"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "audiofreq"; ValueData: "44100"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "disabledx8"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "disablefx"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "noteoff1"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "oldtimethingy"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "voices"; ValueData: "100000"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "volume"; ValueData: "10000"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "disabledx8"; ValueData: "1"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "lastexportfolder"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "lastmidifolder"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "lastsffolder"; Flags: createvalueifdoesntexist uninsdeletekey

[Run]
Filename: "{app}\x86\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser; Description: "Run the converter"; Check: not Is64BitInstallMode
Filename: "{app}\x86\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser unchecked; Description: "Run the x86 version of the converter"; Check: Is64BitInstallMode
Filename: "{app}\x64\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser; Description: "Run the x64 version of the converter"; Check: Is64BitInstallMode
Filename: "{app}\license.rtf"; Flags: nowait shellexec postinstall unchecked; Description: "Read the license"
Filename: "https://github.com/KaleidonKep99/Keppys-MIDI-Converter"; Flags: nowait postinstall shellexec unchecked; Description: "Look at the source code on GitHub"

[Icons]
Name: "{group}\Keppy's MIDI Converter"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Check: not Is64BitInstallMode
Name: "{group}\Restore default language"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Parameters: "/RLN"; Check: not Is64BitInstallMode
Name: "{group}\Skip update process"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Parameters: "/NAU"; Check: not Is64BitInstallMode
Name: "{group}\Keppy's MIDI Converter (x86)"; Filename: "{app}\x86\KeppyMIDIConverter.exe"; IconFilename: "{app}\x86\KeppyMIDIConverter.exe"; Check: Is64BitInstallMode
Name: "{group}\Keppy's MIDI Converter (x64)"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Check: Is64BitInstallMode
Name: "{group}\Restore default language"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Parameters: "/RLN"; Check: Is64BitInstallMode
Name: "{group}\Skip update process"; Filename: "{app}\x64\KeppyMIDIConverter.exe"; IconFilename: "{app}\x64\KeppyMIDIConverter.exe"; Parameters: "/NAU"; Check: Is64BitInstallMode
