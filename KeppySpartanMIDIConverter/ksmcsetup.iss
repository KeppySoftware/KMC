[Setup]
AppName=Keppy's MIDI Converter
AppVersion=8.6.0
AppCopyright=Copyright(C) Keppy Studios 2013-2015
AppId={{D4BCF8FB-EF29-4A72-9681-879BC2C3EAB8}
LicenseFile=userdocs:Visual Studio 2013\Projects\KeppySpartanMIDIConverter\KeppySpartanMIDIConverter\license.rtf
SetupIconFile=userdocs:Visual Studio 2013\Projects\KeppySpartanMIDIConverter\KeppySpartanMIDIConverter\favicon.ico
DefaultDirName={pf}\Keppy's MIDI Converter
EnableDirDoesntExistWarning=True
DirExistsWarning=no
ShowLanguageDialog=no
DefaultGroupName=Keppy's MIDI Converter
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64
AppPublisher=Keppy Studios
AppPublisherURL=http://kaleidonkep99.altervista.org
AppSupportURL=http://kaleidonkep99.altervista.org/contacts.html
AppComments=MIDI to WAV converter
AppContact=Mail: kaleidonkep99@outlook.com
AppSupportPhone=+393511888475
OutputDir=userdocs:Visual Studio 2013\Projects\KeppySpartanMIDIConverter\KeppySpartanMIDIConverter\bin
OutputBaseFilename=KMCSetup
Compression=lzma2/ultra64
VersionInfoVersion=8.6.0
VersionInfoCompany=Keppy Studios
VersionInfoDescription=MIDI to WAV converter, for everyone!
VersionInfoCopyright=Copyright(C) 2013-2015 Keppy Studios
VersionInfoProductName=KSMC
VersionInfoProductVersion=8.6.0
MinVersion=0,5.0

[Files]
;64-bit files
Source: "bin\x64\bass.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\Bass.Net.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassenc.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\bassmidi.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.Sensors.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.Shell.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.ShellExtensions.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
Source: "bin\x64\KeppyMIDIConverter.exe"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: Is64BitInstallMode
;32-bit files
Source: "bin\x86\bass.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\Bass.Net.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\bassenc.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\bassmidi.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.Sensors.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.Shell.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.ShellExtensions.dll"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
Source: "bin\x86\KeppyMIDIConverter.exe"; DestDir: "{app}"; Flags: ignoreversion replacesameversion; Check: not Is64BitInstallMode
;Generic
Source: "license.rtf"; DestDir: "{app}"; Flags: ignoreversion replacesameversion


[UninstallDelete]
Type: files; Name: "{app}\bass.dll"
Type: files; Name: "{app}\bassenc.dll"
Type: files; Name: "{app}\bassmidi.dll"
Type: files; Name: "{app}\Bass.Net.dll"
Type: files; Name: "{app}\KeppyMIDIConverter.exe"
Type: files; Name: "{app}\license.rtf"

[Run]
Filename: "{app}\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser; Description: "Run the converter"
Filename: "{app}\license.rtf"; Flags: nowait shellexec postinstall; Description: "Read the license"

[UninstallRun]
Filename: "http://keppystudios.com"; Flags: nowait shellexec

[Icons]
Name: "{group}\Keppy's MIDI Converter"; Filename: "{app}\KeppyMIDIConverter.exe"; IconFilename: "{app}\KeppyMIDIConverter.exe"

Name: "{group}\Uninstall the converter"; Filename: "{uninstallexe}"; IconFilename: "{app}\KeppyMIDIConverter.exe" 