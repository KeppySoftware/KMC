[Setup]
AllowCancelDuringInstall=False
AlwaysShowDirOnReadyPage=True
AppComments=MIDI to WAV/OGG converter
AppContact=Mail: kaleidonkep99@outlook.com
AppCopyright=Copyright(C) Keppy Studios & Frozen Snow Productions 2013-2016
AppId={{D4BCF8FB-EF29-4A72-9681-879BC2C3EAB8}
AppName=Keppy's MIDI Converter
AppPublisher=Keppy Studios & Frozen Snow Productions
AppPublisherURL=http://kaleidonkep99.altervista.org
AppSupportPhone=+393511888475
AppSupportURL=http://kaleidonkep99.altervista.org/contacts.html
AppUpdatesURL=https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases
AppVersion=10.0.23
ArchitecturesAllowed=x86 x64
ArchitecturesInstallIn64BitMode=x64
Compression=lzma2/ultra64
DefaultDirName={pf}\Keppy's MIDI Converter
DefaultGroupName=Keppy's MIDI Converter
InternalCompressLevel=ultra64
LanguageDetectionMethod=locale
LicenseFile=license.rtf
MinVersion=0,5.01.2600sp3
OutputBaseFilename=KMCSetup
OutputDir=bin
SetupIconFile=favicon.ico
ShowLanguageDialog=no
TimeStampsInUTC=True
UninstallDisplayIcon={app}\KeppyMIDIConverter.exe
UninstallDisplayName=Keppy's MIDI Converter (Remove only)
UninstallDisplaySize=2799697
VersionInfoCompany=Keppy Studios & Frozen Snow Productions
VersionInfoCopyright=Copyright(C) Keppy Studios 2013-2016
VersionInfoDescription=MIDI to WAV/OGG converter, for everyone!
VersionInfoProductName=KSMC
VersionInfoProductVersion=10.0.23
VersionInfoVersion=10.0.23
WizardImageFile=setuppages\WizModernImage.bmp
WizardSmallImageFile=setuppages\WizModernSmallImage.bmp
SolidCompression=True
LZMABlockSize=65535
LZMANumBlockThreads=4

[Files]
;Generic
Source: "license.rtf"; DestDir: "{app}"; Flags: ignoreversion replacesameversion
Source: "convfin.wav"; DestDir: "{app}"; Flags: ignoreversion replacesameversion
;64-bit files
Source: "bin\x64\bass.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\Bass.Net.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\bassenc.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\bassmidi.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.Sensors.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.Shell.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\Microsoft.WindowsAPICodePack.ShellExtensions.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\KeppyMIDIConverter.exe"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
Source: "bin\x64\oggenc2.exe"; DestDir: "{app}"; Flags: ignoreversion; Check: Is64BitInstallMode
;32-bit files
Source: "bin\x86\bass.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\Bass.Net.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\bassenc.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\bassmidi.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.ExtendedLinguisticServices.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.Sensors.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.Shell.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\Microsoft.WindowsAPICodePack.ShellExtensions.dll"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\KeppyMIDIConverter.exe"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode
Source: "bin\x86\oggenc2.exe"; DestDir: "{app}"; Flags: ignoreversion; Check: not Is64BitInstallMode

[UninstallDelete]
Type: files; Name: "{app}\bass.dll"
Type: files; Name: "{app}\bassenc.dll"
Type: files; Name: "{app}\bassmidi.dll"
Type: files; Name: "{app}\Bass.Net.dll"
Type: files; Name: "{app}\KeppyMIDIConverter.exe"
Type: files; Name: "{app}\license.rtf"

[Registry]
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "audiofreq"; ValueData: "44100"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "voices"; ValueData: "100000"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "volume"; ValueData: "10000"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "noteoff1"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: dword; ValueName: "disablefx"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "lastsffolder"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "disabledx8"; ValueData: "1"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "lastmidifolder"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Settings"; ValueType: string; ValueName: "lastexportfolder"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "chorus"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "compressor"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "distortion"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "echo"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "flanger"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "gargle"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "reverb"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey
Root: "HKCU"; Subkey: "Software\Keppy's MIDI Converter\Effects"; ValueType: dword; ValueName: "sittingroom"; ValueData: "0"; Flags: createvalueifdoesntexist uninsdeletekey

[Run]
Filename: "{app}\KeppyMIDIConverter.exe"; Flags: nowait postinstall runasoriginaluser; Description: "Run the converter"
Filename: "{app}\license.rtf"; Flags: nowait shellexec postinstall unchecked; Description: "Read the license"
Filename: "https://github.com/KaleidonKep99/Keppys-MIDI-Converter"; Flags: nowait postinstall shellexec unchecked; Description: "Look at the source code on GitHub"

[UninstallRun]
Filename: "http://keppystudios.com"; Flags: shellexec

[Icons]
Name: "{group}\Keppy's MIDI Converter"; Filename: "{app}\KeppyMIDIConverter.exe"; IconFilename: "{app}\KeppyMIDIConverter.exe"

[Messages]
ExitSetupMessage=You didn't finished installing the converter yet.%nAre you sure you want to quit?%n%nYou can run the installer later, if you want.
ApplicationsFound=It seems that you didn't closed the converter. It is recommended that you allow the setup to automatically close it.
CannotContinue=The setup encountered an unknown error. Click Cancel to exit.
FinishedLabel=Hooray!%nThe converter has been succesfully installed on your computer!%n%nIt may be launched by selecting the installed icons.
WelcomeLabel1=Keppy's MIDI Converter Setup
WelcomeLabel2=This will install the [name] on your computer.%n%nIt is recommended to check if an older version of the converter is running, before installing the new one.%n%nAlso, be sure to check my other project, the Keppy's Driver. You can find it on my GitHub page.
ConfirmUninstall=This will uninstall the converter.%n%nAre you sure mate?
WindowsVersionNotSupported=This program requires Windows Vista or newer.%n%nYour current version is NOT supported.
